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

using BH.oM.Base;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Physical.Materials;
using BHP = BH.oM.Environment.Fragments;
using BH.Engine.Environment;
using BH.Engine.Adapters.OpenStudio;

using BHC = BH.oM.Physical.Constructions;
using BHEM = BH.oM.Environment.MaterialFragments;

using BH.oM.Adapter;
using BH.Engine.Adapter;

namespace BH.Adapter.OpenStudio
{
    public partial class OpenStudioAdapter : BHoMAdapter
    {
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            bool success = true;

            if (typeof(IBHoMObject).IsAssignableFrom(typeof(T)))
            {
                CreateModel(objects as List<IBHoMObject>);
            }

            return success;
        }

        public bool CreateModel(List<IBHoMObject> objects)
        {
            bool success = true;

            global::OpenStudio.Model model = new Model();
                        
            List<IBHoMObject> objs = objects.ToList() as List<IBHoMObject>;

            List<BHE.Panel> buildingElements = objs.Panels();

            List<List<BHE.Panel>> elementsAsSpaces = buildingElements.ToSpaces();

            model = CreateModel(elementsAsSpaces, model);

            EnergyPlusForwardTranslator translator = new EnergyPlusForwardTranslator();
            Workspace workspace = translator.translateModel(model);
            IdfFile idf = workspace.toIdfFile();
            idf.save(global::OpenStudio.OpenStudioUtilitiesCore.toPath(m_IDFFilePath.GetFullFileName()), true); //setting overwrite file true to avoid appending the surfaces to the exisiting idf file

            return success;
        }

        public static global::OpenStudio.Model CreateModel(List<List<BHE.Panel>> panelsAsSpaces, global::OpenStudio.Model modelReference)
        {
            List<BHC.Construction> uniqueConstructions = panelsAsSpaces.UniqueConstructions();

            //Create a curtain wall construction
            BHC.Construction curtainWallConstruction = new BHC.Construction();
            curtainWallConstruction.Name = "Curtain Wall Construction Replacement";

            BHC.Layer curtainWallLayer = new BHC.Layer();
            curtainWallLayer.Thickness = 0.1;

            BHM.Material curtainWallMaterial = new BHM.Material();
            curtainWallMaterial.Name = "Curtain Wall Construction Replacement";

            BHEM.SolidMaterial curtainWallMaterialProperties = new BHEM.SolidMaterial();
            curtainWallMaterialProperties.Roughness = BHEM.Roughness.VerySmooth;
            curtainWallMaterialProperties.SpecificHeat = 101;
            curtainWallMaterialProperties.Conductivity = 0.1;
            curtainWallMaterialProperties.EmissivityExternal = 0.1;
            curtainWallMaterialProperties.SolarReflectanceExternal = 0.1;
            curtainWallMaterialProperties.LightReflectanceExternal = 0.1;
            curtainWallMaterialProperties.Density = 0.1;

            curtainWallMaterial.Properties.Add(curtainWallMaterialProperties);
            curtainWallLayer.Material = curtainWallMaterial;
            curtainWallConstruction.Layers.Add(curtainWallLayer);

            Dictionary<string, Construction> osmConstructions = new Dictionary<string, Construction>();
            foreach(BHC.Construction c in uniqueConstructions)
                osmConstructions.Add(c.UniqueConstructionName(), c.ToOSM(modelReference));

            osmConstructions.Add("CurtainWallReplacementConstruction", curtainWallConstruction.ToOSM(modelReference));

            foreach(List<BHE.Panel> space in panelsAsSpaces)
            {
                ThermalZone osmZone = new ThermalZone(modelReference);
                Space osmSpace = new Space(modelReference);
                osmSpace.setThermalZone(osmZone);

                foreach(BHE.Panel be in space)
                {
                    string conName = be.Construction.UniqueConstructionName();

                    //be.ToOSM(modelReference, osmSpace, (conName == "" ? null : osmConstructions[conName]));
                    Surface host = be.ToOSM(modelReference, osmSpace, osmConstructions, be.OutsideBoundaryCondition(be.AdjacentSpaces(panelsAsSpaces)));

                    foreach (BHE.Opening o in be.Openings)
                    {
                        conName = o.OpeningConstruction.UniqueConstructionName();

                        o.ToOSM(host, (conName == "" ? null : osmConstructions[conName]), modelReference);
                    }
                }
            }

            return modelReference;
        }
    }
}



