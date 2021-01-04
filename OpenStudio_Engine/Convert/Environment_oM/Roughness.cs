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

using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;
using BHG = BH.oM.Geometry;
using BHM = BH.oM.Environment.MaterialFragments;

using BH.Engine.Environment;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static string ToOSM(this BHM.Roughness roughness)
        {
            switch (roughness)
            {
                case BHM.Roughness.MediumRough:
                    return "MediumRough";
                case BHM.Roughness.MediumSmooth:
                    return "MediumSmooth";
                case BHM.Roughness.Rough:
                    return "Rough";
                case BHM.Roughness.Smooth:
                    return "Smooth";
                case BHM.Roughness.VeryRough:
                    return "VeryRough";
                case BHM.Roughness.VerySmooth:
                    return "VerySmooth";
                default:
                    return "";
            }
        }

        public static BHM.Roughness ToBHoMRoughness(this string roughness)
        {
            if (roughness.Equals("MediumRough"))
                return BHM.Roughness.MediumRough;
            if (roughness.Equals("MediumSmooth"))
                return BHM.Roughness.MediumSmooth;
            if (roughness.Equals("Rough"))
                return BHM.Roughness.Rough;
            if (roughness.Equals("Smooth"))
                return BHM.Roughness.Smooth;
            if (roughness.Equals("VeryRough"))
                return BHM.Roughness.VeryRough;
            if (roughness.Equals("VerySmooth"))
                return BHM.Roughness.VerySmooth;

            return BHM.Roughness.Undefined;
        }
    }
}


