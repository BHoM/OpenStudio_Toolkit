/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;

using BH.Engine.Environment;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.Surface ToOSM(this BHE.Panel panel, global::OpenStudio.Model modelReference, global::OpenStudio.Space osmSpace, Dictionary<string, global::OpenStudio.Construction> uniqueConstructions, string outsideBoundaryCondition)
        {
            Surface osmElement = new Surface(panel.Polyline().ToOSM(), modelReference);
            osmElement.setName(panel.Name);
            osmElement.setSpace(osmSpace);
            if(outsideBoundaryCondition != "")
                osmElement.setOutsideBoundaryCondition(outsideBoundaryCondition);

            osmElement.setSurfaceType(panel.Type.ToOSMSurfaceType());
            osmElement.setConstruction(uniqueConstructions[panel.Construction.UniqueConstructionName()]);

            BHP.OriginContextFragment envContextProperties = panel.FindFragment<BHP.OriginContextFragment>(typeof(BHP.OriginContextFragment));

            //Fix curtain wall
            if (panel.Type == BHE.PanelType.CurtainWall)
            {
                osmElement.setConstruction(uniqueConstructions["CurtainWallReplacementConstruction"]); //No need for construction on a curtain wall as the opening will handle it

                List<BHG.Polyline> newOpeningBounds = new List<BHG.Polyline>();
                if (panel.Openings.Count > 0)
                {
                    //This surface already has openings - cut them out of the new opening
                    List<BHG.Polyline> refRegion = panel.Openings.Where(y => y.Polyline() != null).ToList().Select(z => z.Polyline()).ToList();
                    newOpeningBounds.AddRange((panel.Polyline().BooleanDifference(refRegion, 0.01)));
                }
                else
                    newOpeningBounds.Add(panel.Polyline());

                BHE.Opening curtainWallOpening = new BHE.Opening() { Edges = BH.Engine.Geometry.Create.PolyCurve(newOpeningBounds).ICollapseToPolyline(BH.oM.Geometry.Tolerance.Angle).ToEdges() };

                //Scale the bounding curve to comply with IDF rules
                BHG.Polyline crv = curtainWallOpening.Polyline();
                curtainWallOpening.Edges = crv.Scale(crv.Centre(), BH.Engine.Geometry.Create.Vector(0.95, 0.95, 0.95)).ToEdges();

                curtainWallOpening.Name = panel.Name;
                BHP.OriginContextFragment curtainWallProperties = new BHP.OriginContextFragment();
                
                if (envContextProperties != null)
                {
                    curtainWallProperties.ElementID = envContextProperties.ElementID;
                    curtainWallProperties.TypeName = envContextProperties.TypeName;
                }

                curtainWallOpening.Type = BHE.OpeningType.CurtainWall;
                curtainWallOpening.OpeningConstruction = panel.Construction;

                panel.Openings = new List<BHE.Opening> { curtainWallOpening };
            }

            return osmElement;
        }
    }
}




