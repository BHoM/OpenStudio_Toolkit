/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BHM = BH.oM.Physical.Materials;
using BHP = BH.oM.Physical.Constructions;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.Construction ToOSM(this BHP.Construction construction, global::OpenStudio.Model modelReference)
        {
            global::OpenStudio.Construction osmConstruction = new Construction(modelReference);
            osmConstruction.setName(construction.Name);

            MaterialVector materialLayer = new MaterialVector();
            foreach(BHP.Layer layer in construction.Layers)
                materialLayer.Add(layer.Material.ToOSM(modelReference));

            //foreach (BHM.Material material in construction.Materials)
                //materialLayer.Add(material.ToOSM(construction.Roughness, modelReference, (construction.ConstructionType == BHE.ConstructionType.Transparent)));

            osmConstruction.setLayers(materialLayer);
            return osmConstruction;
        }
    }
}

