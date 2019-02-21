using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum SolarModelIndicatorType
    {
        Undefined,
        ASHRAEClearSky,
        ASHRAETau,
        ASHRAETau2017,
        Schedule,
        ZhangHuang,
    }

    public enum HumidityConditionType
    {
        Undefined,
        DewPoint,
        Enthalpy,
        HumidityRatio,
        RelativeHumiditySchedule,
        WetBulb,
        WetBulbProfileDefaultMultipliers,
        WetBulbProfileDifferenceSchedule,
        WetBulbProfileMultiplierSchedule,
    }

    public enum DryBulbTemperatureRangeModifierType
    {
        Undefined,
        DefaultMultipliers,
        DifferenceSchedule,
        MultiplierSchedule,
        TemperatureProfileSchedule,
    }
}