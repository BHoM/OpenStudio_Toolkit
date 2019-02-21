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
    //    [Description("BH.Engine.EnergyPlus.Create HeatBalanceSettingsConductionFiniteDifference => Determines settings for the Conduction Finite Difference algorithm for surface heat transfer modeling.")]
    //    [Input("differenceScheme", "Difference scheme to use")]
    //    [Input("spaceDiscretizationConstant", "Increase or decrease number of nodes")]
    //    [Input("relaxationFactor", "See EnergyPlus reference material")]
    //    [Input("insideFaceSurfaceTemperatureConvergenceCriteria", "See EnergyPlus reference material")]
    //    [Output("HeatBalanceSettingsConductionFiniteDifference", "A BH.oM.EnergyPlus.HeatBalanceSettingsConductionFiniteDifference object")]
    //    public static HeatBalanceSettingsConductionFiniteDifference HeatBalanceSettingsConductionFiniteDifference(
    //        DifferenceSchemeType differenceScheme = DifferenceSchemeType.FullyImplicitFirstOrder,
    //        int spaceDiscretizationConstant = 3,
    //        double relaxationFactor = 1.0,
    //        double insideFaceSurfaceTemperatureConvergenceCriteria = 0.002
    //    )
    //    {
    //        if (differenceScheme == DifferenceSchemeType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("differenceScheme is currently Undefined - it can't be undefined you fool!");
    //            return null;
    //        }

    //        if ((relaxationFactor < 0.01) || (relaxationFactor > 1))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("relaxationFactor must be between 0.01 and 1");
    //            return null;
    //        }

    //        if ((insideFaceSurfaceTemperatureConvergenceCriteria < 0.0000001) || (insideFaceSurfaceTemperatureConvergenceCriteria > 0.01))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("insideFaceSurfaceTemperatureConvergenceCriteria must be between 0.0000001 and 0.01");
    //            return null;
    //        }

    //        return new HeatBalanceSettingsConductionFiniteDifference
    //        {
    //            DifferenceScheme = differenceScheme,
    //            SpaceDiscretizationConstant = spaceDiscretizationConstant,
    //            RelaxationFactor = relaxationFactor,
    //            InsideFaceSurfaceTemperatureConvergenceCriteria = insideFaceSurfaceTemperatureConvergenceCriteria,
    //        };
    //    }
    //}
}