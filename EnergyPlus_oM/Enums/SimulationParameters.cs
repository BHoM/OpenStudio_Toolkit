using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
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