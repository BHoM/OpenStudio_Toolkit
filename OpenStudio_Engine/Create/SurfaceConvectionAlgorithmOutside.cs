/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.Adapters.OpenStudio;
using BH.Engine.Base;

namespace BH.Engine.Adapters.OpenStudio
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create SurfaceConvectionAlgorithmOutside => efault outside surface heat transfer convection algorithm to be used for all zones")]
    //    [Input("algorithm", "SimpleCombined = Combined radiation and convection coefficient using simple ASHRAE model TARP = correlation from models developed by ASHRAE, Walton, and Sparrow et. al. MoWiTT = correlation from measurements by Klems and Yazdanian for smooth surfaces DOE-2 = correlation from measurements by Klems and Yazdanian for rough surfaces AdaptiveConvectionAlgorithm = dynamic selection of correlations based on conditions")]
    //    [Output("surfaceConvectionAlgorithmOutside", "A BH.oM.EnergyPlus.SurfaceConvectionAlgorithmOutside object")]
    //    public static SurfaceConvectionAlgorithmOutside SurfaceConvectionAlgorithmOutside(
    //        SurfaceConvectionAlgorithmOutsideType algorithm = SurfaceConvectionAlgorithmOutsideType.DOE2
    //    )
    //    {
    //        if (algorithm < SurfaceConvectionAlgorithmOutsideType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("SurfaceConvectionAlgorithmOutsideType cannot be Undefined");
    //            return null;
    //        }

    //        return new SurfaceConvectionAlgorithmOutside
    //        {
    //            Algorithm = algorithm,
    //        };
    //    }
    //}
}

