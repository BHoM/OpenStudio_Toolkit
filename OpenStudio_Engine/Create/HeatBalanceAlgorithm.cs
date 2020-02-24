/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.OpenStudio;
using BH.Engine.Base;

namespace BH.Engine.OpenStudio
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create HeatBalanceAlgorithm => Determines which Heat Balance Algorithm will be used ie. CTF(Conduction Transfer Functions), EMPD(Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced / Research Usage: CondFD(Conduction Finite Difference) Advanced / Research Usage: ConductionFiniteDifferenceSimplified Advanced / Research Usage: HAMT(Combined Heat And Moisture Finite Element)")]
    //    [Input("algorithm", "Algorithm type to use - ConductionFiniteDifference requires an additional HeatBalanceSettingsConductionFiniteDifference object to be defined (or use its defaults)")]
    //    [Output("HeatBalanceAlgorithm", "A BH.oM.EnergyPlus.HeatBalanceAlgorithm object")]
    //    public static HeatBalanceAlgorithm HeatBalanceAlgorithm(
    //        HeatBalanceAlgorithmType algorithm = HeatBalanceAlgorithmType.ConductionTransferFunction,
    //        double surfaceTemperatureUpperLimit = 200.0,
    //        double minimumSurfaceConvectionHeatTransferCoefficientValue = 0.1,
    //        double maximumSurfaceConvectionHeatTransferCoefficientValue = 1000
    //    )
    //    {
    //        if (algorithm == HeatBalanceAlgorithmType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("algorithm is Undefined - itr must be defined to run if you're specifying a HeatBalanceAlgorithm!");
    //            return null;
    //        }

    //        if (surfaceTemperatureUpperLimit < 200)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("surfaceTemperatureUpperLimit cannot be less than 200");
    //            return null;
    //        }

    //        if (minimumSurfaceConvectionHeatTransferCoefficientValue <= 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("minimumSurfaceConvectionHeatTransferCoefficientValue cannot be less than 0");
    //            return null;
    //        }

    //        if (maximumSurfaceConvectionHeatTransferCoefficientValue < 1)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumSurfaceConvectionHeatTransferCoefficientValue cannot be less than 1");
    //            return null;
    //        }

    //        return new HeatBalanceAlgorithm
    //        {
    //            Algorithm = algorithm,
    //            SurfaceTemperatureUpperLimit = surfaceTemperatureUpperLimit,
    //            MinimumSurfaceConvectionHeatTransferCoefficientValue = minimumSurfaceConvectionHeatTransferCoefficientValue,
    //            MaximumSurfaceConvectionHeatTransferCoefficientValue = maximumSurfaceConvectionHeatTransferCoefficientValue,
    //        };
    //    }
    //}
}