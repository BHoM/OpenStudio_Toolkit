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
    //    [Description("BH.Engine.EnergyPlus.Create ZoneAirHeatBalanceAlgorithm => Determines which algorithm will be used to solve the zone air heat balance.")]
    //    [Input("algorithm", "Algorithm/method used to calculate Zone Air Heat Balance")]
    //    [Output("zoneAirHeatBalanceAlgorithm", "A BH.oM.EnergyPlus.ZoneAirHeatBalanceAlgorithm object")]
    //    public static ZoneAirHeatBalanceAlgorithm ZoneAirHeatBalanceAlgorithm(
    //        ZoneAirHeatBalanceAlgorithmType algorithm = ZoneAirHeatBalanceAlgorithmType.ThirdOrderBackwardDifference
    //    )
    //    {
    //        if (algorithm == ZoneAirHeatBalanceAlgorithmType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("The algorithm selected is Undefined. How can you do anything with an undefined algorithm? You absolute madman/madwoman!");
    //            return null;
    //        }

    //        return new ZoneAirHeatBalanceAlgorithm
    //        {
    //           Algorithm = algorithm
    //        };
    //    }
    //}
}