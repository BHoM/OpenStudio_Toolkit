using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.EnergyPlus;
using BH.Engine.Base;

namespace BH.Engine.EnergyPlus
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