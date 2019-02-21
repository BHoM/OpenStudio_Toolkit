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
    //    [Description("BH.Engine.EnergyPlus.Create HVACTemplateZoneIdealLoadsAirSystem => ")]
    //    [Input("zoneName", "Zone name must be a BH.oM.EnergyPlus.Zone object")]
    //    [Input("templateThermostatName", "A BH.oM.EnergyPlus.Thermostat object")]
    //    [Input("availabilityScheduleName", "A BH.oM.EnergyPlus.ScheduleFile object")]
    //    [Input("maxHeatingSupplyAirTemp", "")]
    //    [Input("maxCoolingSupplyAirTemp", "")]
    //    [Input("maxHeatingSupplyAirHumidityRatio", "")]
    //    [Input("minCoolingSupplyAirHumidityRatio", "")]
    //    [Input("heatingLimit", "")]
    //    [Input("maximumHeatingAirFlowRate", "This field is ignored if Heating Limit = NoLimit If this field is blank, there is no limit.")]
    //    [Input("maximumSensibleHeatCapacity", "This field is ignored if Heating Limit = NoLimit If this field is blank, there is no limit.")]
    //    [Input("coolingLimit", "")]
    //    [Input("maximumCoolingAirFlowRate", "This field is ignored if Cooling Limit = NoLimit If this field is blank, there is no limit.")]
    //    [Input("maximumTotalCoolingCapacity", "This field is ignored if Cooling Limit = NoLimit")]
    //    [Input("heatingAvailabilitySchedule", "If blank, heating is always available.")]
    //    [Input("coolingAvailabilitySchedule", "If blank, cooling is always available.")]
    //    [Input("dehumidificationControlType", "ConstantSensibleHeatRatio means that the ideal loads system will be controlled to meet the sensible cooling load, and the latent cooling rate will be computed using a constant sensible heat ratio (SHR) Humidistat means that there is a ZoneControl:Humidistat for this zone and the ideal loads system will attempt to satisfy the humidistat. None means that there is no dehumidification. ConstantSupplyHumidityRatio means that during cooling the supply air will always be at the Minimum Cooling Supply Humidity Ratio.")]
    //    [Input("coolingSensibleHeatRatio", "This field is applicable only when Dehumidification Control Type is ConstantSensibleHeatRatio")]
    //    [Input("dehumidificationSetpoint", "Zone relative humidity setpoint in percent (0 to 100)")]
    //    [Input("humidificationControlType", "None means that there is no humidification. Humidistat means that there is a ZoneControl:Humidistat for this zone and the ideal loads system will attempt to satisfy the humidistat. ConstantSupplyHumidityRatio means that during heating the supply air will always be at the Maximum Heating Supply Humidity Ratio.")]
    //    [Input("humidificationSetpoint", "Zone relative humidity setpoint in percent (0 to 100)")]
    //    [Input("outdoorAirMethod", "None means there is no outdoor air and all related fields will be ignored Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
    //    [Input("outdoorAirFlowRatePerPerson", "Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air Method is Flow/Person, Sum, or Maximum")]
    //    [Input("outdoorAirFlowRatePerFloorZoneArea", "This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
    //    [Input("outdoorAirFlowRatePerZone", "This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
    //    [Input("designSpecificationOutdoorAirObjectName", "When the name of a DesignSpecification:OutdoorAir object is entered, the minimum outdoor air flow rate will be computed using these specifications. The outdoor air flow rate will also be affected by the next two fields. If this field is blank, there will be no outdoor air and the remaining fields will be ignored.")]
    //    [Input("demandControlledVentilationType", "This field controls how the minimum outdoor air flow rate is calculated. None means that design occupancy will be used to compute the minimum outdoor air flow rate OccupancySchedule means that current occupancy level will be used. CO2Setpoint means that the design occupancy will be used to compute the minimum outdoor air flow rate and the outdoor air flow rate may be increased if necessary to maintain the indoor air carbon dioxide setpoint defined in a ZoneControl:ContaminantController object.")]
    //    [Input("outdoorAirEconomizerType", "DifferentialDryBulb and DifferentialEnthalpy will increase the outdoor air flow rate when there is a cooling load and the outdoor air temperature or enthalpy is below the zone exhaust air temperature or enthalpy.")]
    //    [Input("heatRecoveryType", "")]
    //    [Input("sensibleHeatRecoveryEffectiveness", "")]
    //    [Input("latentHeatRecoveryEffectiveness", "")]
    //    [Output("HVACTemplateZoneIdealLoadsAirSystem", "A BH.oM.EnergyPlus.HVACTemplateZoneIdealLoadsAirSystem object")]
    //    public static HVACTemplateZoneIdealLoadsAirSystem HVACTemplateZoneIdealLoadsAirSystem(
    //        Zone zoneName = null,
    //        HVACTemplateThermostat templateThermostatName = null,
    //        ScheduleFile availabilityScheduleName = null,
    //        double maxHeatingSupplyAirTemp = 50.0,
    //        double maxCoolingSupplyAirTemp = 13.0,
    //        double maxHeatingSupplyAirHumidityRatio = 0.0156,
    //        double minCoolingSupplyAirHumidityRatio = 0.0077,
    //        HeatingCoolingLimitType heatingLimit = HeatingCoolingLimitType.NoLimit,
    //        double maximumHeatingAirFlowRate = 0.0,
    //        double maximumSensibleHeatCapacity = 0.0,
    //        HeatingCoolingLimitType coolingLimit = HeatingCoolingLimitType.NoLimit,
    //        double maximumCoolingAirFlowRate = 0.0,
    //        double maximumTotalCoolingCapacity = 0.0,
    //        ScheduleFile heatingAvailabilitySchedule = null,
    //        ScheduleFile coolingAvailabilitySchedule = null,
    //        DehumidificationControlType dehumidificationControlType = DehumidificationControlType.ConstantSensibleHeatRatio,
    //        double coolingSensibleHeatRatio = 0.7,
    //        double dehumidificationSetpoint = 60.0,
    //        HumidificationControlType humidificationControlType = HumidificationControlType.None,
    //        double humidificationSetpoint = 30.0,
    //        OutdoorAirMethodType outdoorAirMethod = OutdoorAirMethodType.None,
    //        double outdoorAirFlowRatePerPerson = 0.00944,
    //        double outdoorAirFlowRatePerFloorZoneArea = 0.0,
    //        double outdoorAirFlowRatePerZone = 0.0,
    //        DesignSpecificationOutdoorAir designSpecificationOutdoorAirObjectName = null,
    //        DemandControlledVentilationType demandControlledVentilationType = DemandControlledVentilationType.None,
    //        OutdoorAirEconomizerType outdoorAirEconomizerType = OutdoorAirEconomizerType.NoEconomizer,
    //        HeatRecoveryType heatRecoveryType = HeatRecoveryType.None,
    //        double sensibleHeatRecoveryEffectiveness = 0.7,
    //        double latentHeatRecoveryEffectiveness = 0.65
    //    )
    //    {
    //        if ((maxHeatingSupplyAirTemp <= 0) || (maxHeatingSupplyAirTemp >= 100))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maxHeatingSupplyAirTemp must be between 0C and 100C");
    //            return null;
    //        }

    //        if ((maxCoolingSupplyAirTemp <= -100) || (maxCoolingSupplyAirTemp >= 50))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maxCoolingSupplyAirTemp must be between -100C and 50C");
    //            return null;
    //        }

    //        if (maxHeatingSupplyAirHumidityRatio < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maxHeatingSupplyAirHumidityRatio cannot be less than 0");
    //            return null;
    //        }

    //        if (minCoolingSupplyAirHumidityRatio < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("minCoolingSupplyAirHumidityRatio cannot be less than 0");
    //            return null;
    //        }
            
    //        if (heatingLimit == HeatingCoolingLimitType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("heatingLimit is undefined - default is NoLimit");
    //            return null;
    //        }

    //        if (maximumHeatingAirFlowRate < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumHeatingAirFlowRate cannot be less than 0");
    //            return null;
    //        }

    //        if (maximumSensibleHeatCapacity < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumSensibleHeatCapacity cannot be less than 0");
    //            return null;
    //        }

    //        if (coolingLimit == HeatingCoolingLimitType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("coolingLimit is undefined - default is NoLimit");
    //            return null;
    //        }

    //        if (maximumCoolingAirFlowRate < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumCoolingAirFlowRate cannot be less than 0");
    //            return null;
    //        }

    //        if (maximumTotalCoolingCapacity < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumTotalCoolingCapacity cannot be less than 0");
    //            return null;
    //        }

    //        if ((coolingSensibleHeatRatio <= 0) || (coolingSensibleHeatRatio > 1))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("coolingSensibleHeatRatio must be greater > 0 and <= 1");
    //            return null;
    //        }

    //        if ((dehumidificationSetpoint < 0) || (dehumidificationSetpoint > 100))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("dehumidificationSetpoint must be between 0 and 100");
    //            return null;
    //        }

    //        if ((humidificationSetpoint < 0) || (humidificationSetpoint > 100))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("humidificationSetpoint must be between 0 and 100");
    //            return null;
    //        }

    //        if ((sensibleHeatRecoveryEffectiveness < 0) || (sensibleHeatRecoveryEffectiveness > 1))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("sensibleHeatRecoveryEffectiveness must be between 0 and 1");
    //            return null;
    //        }

    //        if ((latentHeatRecoveryEffectiveness < 0) || (latentHeatRecoveryEffectiveness > 1))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("latentHeatRecoveryEffectiveness must be between 0 and 1");
    //            return null;
    //        }

    //        return new HVACTemplateZoneIdealLoadsAirSystem
    //        {
    //            ZoneName = zoneName,
    //            TemplateThermostatName = templateThermostatName,
    //            AvailabilityScheduleName = availabilityScheduleName,
    //            MaxHeatingSupplyAirTemp = maxHeatingSupplyAirTemp,
    //            MaxCoolingSupplyAirTemp = maxCoolingSupplyAirTemp,
    //            MaxHeatingSupplyAirHumidityRatio = maxHeatingSupplyAirHumidityRatio,
    //            MinCoolingSupplyAirHumidityRatio = minCoolingSupplyAirHumidityRatio,
    //            HeatingLimit = heatingLimit,
    //            MaximumHeatingAirFlowRate = maximumHeatingAirFlowRate,
    //            MaximumSensibleHeatCapacity = maximumSensibleHeatCapacity,
    //            CoolingLimit = coolingLimit,
    //            MaximumCoolingAirFlowRate = maximumCoolingAirFlowRate,
    //            MaximumTotalCoolingCapacity = maximumTotalCoolingCapacity,
    //            HeatingAvailabilitySchedule = heatingAvailabilitySchedule,
    //            CoolingAvailabilitySchedule = coolingAvailabilitySchedule,
    //            DehumidificationControlType = dehumidificationControlType,
    //            CoolingSensibleHeatRatio = coolingSensibleHeatRatio,
    //            DehumidificationSetpoint = dehumidificationSetpoint,
    //            HumidificationControlType = humidificationControlType,
    //            HumidificationSetpoint = humidificationSetpoint,
    //            OutdoorAirMethod = outdoorAirMethod,
    //            OutdoorAirFlowRatePerPerson = outdoorAirFlowRatePerPerson,
    //            OutdoorAirFlowRatePerFloorZoneArea = outdoorAirFlowRatePerFloorZoneArea,
    //            OutdoorAirFlowRatePerZone = outdoorAirFlowRatePerZone,
    //            DesignSpecificationOutdoorAirObjectName = designSpecificationOutdoorAirObjectName,
    //            DemandControlledVentilationType = demandControlledVentilationType,
    //            OutdoorAirEconomizerType = outdoorAirEconomizerType,
    //            HeatRecoveryType = heatRecoveryType,
    //            SensibleHeatRecoveryEffectiveness = sensibleHeatRecoveryEffectiveness,
    //            LatentHeatRecoveryEffectiveness = latentHeatRecoveryEffectiveness
    //        };
    //    }
    //}
}