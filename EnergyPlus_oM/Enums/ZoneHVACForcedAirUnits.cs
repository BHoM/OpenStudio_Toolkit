using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum CapacityControlMethodType
    {
        Undefined,
        ASHRAE90VariableFan,
        ConstantFanVariableFlow,
        CyclingFan,
        MultiSpeedFan,
        VariableFanConstantFlow,
        VariableFanVariableFlow,
    }

    public enum OutdoorAirMixerObjectType
    {
        Undefined,
        OutdoorAirMixer,
    }

    public enum SupplyAirFanObjectType
    {
        Undefined,
        FanConstantVolume,
        FanOnOff,
        FanSystemModel,
        FanVariableVolume,
    }

    public enum CoolingCoilObjectType
    {
        Undefined,
        CoilCoolingWater,
        CoilCoolingWaterDetailedGeometry,
        CoilSystemCoolingWaterHeatExchangerAssisted,
    }

    public enum HeatingCoilObjectType
    {
        Undefined,
        CoilHeatingElectric,
        CoilHeatingWater,
    }
}
