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

namespace BH.oM.Adapters.OpenStudio
{
    // All algorithms referenced here can be found in documentation for EnergyPlus - https://bigladdersoftware.com/epx/docs/8-0/engineering-reference/page-021.html

    public enum HeatBalanceAlgorithmType
    {
        Undefined,
        CombinedHeatAndMoistureFiniteElement,
        ConductionFiniteDifference,
        ConductionTransferFunction,
        MoisturePenetrationDepthConductionTransferFunction,
    }

    public enum DifferenceSchemeType
    {
        Undefined,
        CrankNicholsonSecondOrder,
        FullyImplicitFirstOrder,
    }

    public enum ShadowCalculationMethodType
    {
        Undefined,
        AverageOverDaysInFrequency,
        TimestepFrequency,
    }

    public enum PolygonClippingAlgorithmType
    {
        Undefined,
        ConvexWeilerAtherton,
        SutherlandHodgman,
    }

    public enum SkyDiffuseModelingAlgorithmType
    {
        Undefined,
        DetailedSkyDiffuseModeling,
        SimpleSkyDiffuseModeling,
    }

    public enum ExternalShadingCalculationMethodType
    {
        Undefined,
        InternalCalculation,
        ScheduledShading,
    }

    public enum SurfaceConvectionAlgorithmInsideType
    {
        Undefined,
        AdaptiveConvectionAlgorithm,
        CeilingDiffuser,
        Simple,
        TARP,
    }

    public enum SurfaceConvectionAlgorithmOutsideType
    {
        Undefined,
        AdaptiveConvectionAlgorithm,
        DOE2,
        MoWiTT,
        SimpleCombined,
        TARP,
    }

    public enum ZoneAirHeatBalanceAlgorithmType
    {
        Undefined,
        AnalyticalSolution,
        EulerMethod,
        ThirdOrderBackwardDifference,
    }

    public enum InfiltrationBalancingZonesType
    {
        Undefined,
        AllZones,
        MixingSourceZonesOnly,
    }

    public enum InfiltrationBalancingMethodType
    {
        Undefined,
        AddInfiltrationFlow,
        AdjustInfiltrationFlow,
    }
}


