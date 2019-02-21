using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.EnergyPlus.Interface;

namespace BH.oM.EnergyPlus
{
    //public class SizingPeriodDesignDay : BHoMObject
    //{
    //    public int Month { get; set; } = 0;
    //    public int DayOfMonth { get; set; } = 0;
    //    public BH.oM.Environment.Elements.SimulationDayType DayType { get; set; } = BH.oM.Environment.Elements.SimulationDayType.Undefined;
    //    public double MaximumDryBulbTemperature { get; set; } = 0.0;
    //    public double DailyDryBulbTemperatureRange { get; set; } = 0.0;
    //    public DryBulbTemperatureRangeModifierType DryBulbTemperatureRangeModifierType { get; set; } = EnergyPlus.DryBulbTemperatureRangeModifierType.Undefined;
    //    public IScheduleDay DryBulbTemperatureRangeModifierScheduleName { get; set; } = new ScheduleDayHourly();
    //    public HumidityConditionType HumidityConditionType { get; set; } = HumidityConditionType.Undefined;
    //    public double WetbulbOrDewpointAtMaximumDryBulb { get; set; } = 0.0;
    //    public IScheduleDay HumidityConditionDayScheduleName { get; set; } = new ScheduleDayHourly();
    //    public double HumidityRatioAtMaximumDryBulb { get; set; } = 0.0;
    //    public double EnthalpyAtMaximumDryBulb { get; set; } = 0.0;
    //    public double DailyWetBulbTemperatureRange { get; set; } = 0.0;
    //    public double BarometricPressure { get; set; } = 0.0;
    //    public double WindSpeed { get; set; } = 0.0;
    //    public double WindDirection { get; set; } = 0.0;
    //    public bool Rain { get; set; } = false;
    //    public bool SnowOnGround { get; set; } = false;
    //    public bool DaylightSavingsTimeIndicator { get; set; } = false;
    //    public SolarModelIndicatorType SolarModelIndicator { get; set; } = SolarModelIndicatorType.Undefined;
    //    public IScheduleDay BeamSolarDayScheduleName { get; set; } = new ScheduleDayHourly();
    //    public IScheduleDay DiffuseSolarDayScheduleName { get; set; } = new ScheduleDayHourly();
    //    public double ASHRAEClearSkyOpticalDepthForBeamIrradianceTaub { get; set; } = 0.0;
    //    public double ASHRAEClearSkyOpticalDepthForDiffuseIrradianceTaud { get; set; } = 0.0;
    //    public double Clearness { get; set; } = 0.0;
    //}
}
