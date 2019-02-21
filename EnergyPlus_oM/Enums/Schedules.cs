using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum NumericType
    {
        Undefined,
        Continuous,
        Discrete,
    }

    public enum VariableUnitType
    {
        Undefined,
        ActivityLevel,
        Angle,
        Availability,
        Capacity,
        Control,
        ConvectionCoefficient,
        DeltaTemperature,
        Dimensionless,
        Mode,
        Percent,
        Power,
        PrecipitationRate,
        Temperature,
        Velocity,
    }

    public enum ScheduleColumnSeparatorType
    {
        Undefined,
        Comma,
        Fixed,
        Semicolon,
        Tab,
    }
}