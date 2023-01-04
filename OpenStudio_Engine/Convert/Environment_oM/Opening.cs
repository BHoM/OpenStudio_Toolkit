/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.Engine.Geometry;

using BHG = BH.oM.Geometry;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.SubSurface ToOSM(this BHE.Opening opening, global::OpenStudio.Surface hostSurface, global::OpenStudio.Construction construction, global::OpenStudio.Model referenceModel)
        {
            Point3dVector openingPts = opening.Polyline().IDiscontinuityPoints().ToOSM();
            SubSurface osmOpening = new SubSurface(openingPts, referenceModel);

            osmOpening.setSubSurfaceType(opening.Type.ToOSMFenestrationType());

            osmOpening.setSurface(hostSurface);
            osmOpening.setConstruction(construction);

            double oA = osmOpening.azimuth();
            double hA = hostSurface.azimuth();
            
            if(oA != hA)
            {
                osmOpening.setName("NOT EQUAL AZIMUTH - " + osmOpening.name());
            }            

            if(osmOpening.azimuth() < (hostSurface.azimuth() -1) || osmOpening.azimuth() > (hostSurface.azimuth() + 1))
            {
                osmOpening.setVertices(opening.Polyline().IFlip().ICollapseToPolyline(BHG.Tolerance.Angle).ToOSM());
            }

            return osmOpening;
        }
    }
}



