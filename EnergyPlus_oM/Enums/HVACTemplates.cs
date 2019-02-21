using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum HeatingCoolingLimitType
    {
        Undefined,
        LimitCapacity,
        LimitFlowRate,
        LimitFlowRateAndCapacity,
        NoLimit,
    }

    public enum DehumidificationControlType
    {
        Undefined,
        ConstantSensibleHeatRatio,
        ConstantSupplyHumidityRatio,
        Humidistat,
        None,
    }

    public enum HumidificationControlType
    {
        Undefined,
        ConstantSupplyHumidityRatio,
        None,
        Humidistat,
    }

    public enum DemandControlledVentilationType
    {
        Undefined,
        CO2Setpoint,
        None,
        OccupancySchedule,
    }

    public enum OutdoorAirEconomizerType
    {
        Undefined,
        DifferentialDryBulb,
        DifferentialEnthalpy,
        NoEconomizer,
    }

    public enum HeatRecoveryType
    {
        Undefined,
        Enthalpy,
        None,
        Sensible,
    }
}