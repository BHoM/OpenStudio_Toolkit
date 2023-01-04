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
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.Adapters.OpenStudio;
using BH.Engine.Base;

namespace BH.Engine.Adapters.OpenStudio
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create SurfaceConvectionAlgorithmInside => Default indoor surface heat transfer convection algorithm to be used for all zones")]
    //    [Input("algorithm", "Simple = constant value natural convection (ASHRAE) TARP = variable natural convection based on temperature difference (ASHRAE, Walton) CeilingDiffuser = ACH-based forced and mixed convection correlations for ceiling diffuser configuration with simple natural convection limit AdaptiveConvectionAlgorithm = dynamic selection of convection models based on conditions")]
    //    [Output("surfaceConvectionAlgorithmInside", "A BH.oM.EnergyPlus.SurfaceConvectionAlgorithmInside object")]
    //    public static SurfaceConvectionAlgorithmInside SurfaceConvectionAlgorithmInside(
    //        SurfaceConvectionAlgorithmInsideType algorithm = SurfaceConvectionAlgorithmInsideType.TARP
    //    )
    //    {
    //        if (algorithm < SurfaceConvectionAlgorithmInsideType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("SurfaceConvectionAlgorithmInsideType cannot be Undefined");
    //            return null;
    //        }

    //        return new SurfaceConvectionAlgorithmInside
    //        {
    //            Algorithm = algorithm,
    //        };
    //    }
    //}
}


