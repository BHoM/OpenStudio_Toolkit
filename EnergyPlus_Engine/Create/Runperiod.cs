using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Reflection.Attributes;
using BH.oM.EnergyPlus;
using BH.Engine.Base;
using System.Collections;
using System.ComponentModel;
using BH.oM.Environment.Elements;

namespace BH.Engine.EnergyPlus
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create RunPeriod => Specify a range of dates and other parameters for a simulation. Multiple run periods may be input, but they may not overlap.")]
    //    [Input("Name", "descriptive name (used in reporting mainly) If blank, weather file title is used.  If not blank, must be unique")]
    //    [Input("BeginMonth", "BeginMonth")]
    //    [Input("BeginDayOfMonth", "BeginDayOfMonth")]
    //    [Input("BeginYear", "Start year of the simulation, if this field is specified it must agree with the Day of Week for Start Day If this field is blank, the year will be selected to match the weekday, which is Sunday if not specified")]
    //    [Input("EndMonth", "EndMonth")]
    //    [Input("EndDayOfMonth", "EndDayOfMonth")]
    //    [Input("EndYear", "end year of simulation, if specified")]
    //    [Input("DayOfWeekForStartDay", " If yes or blank, use holidays as specified on Weatherfile. If no, do not use the holidays specified on the Weatherfile. Note: You can still specify holidays/special days using the RunPeriodControl:SpecialDays object(s).")]
    //    [Input("UseWeatherFileHolidaysAndSpecialDays", " If yes or blank, use holidays as specified on Weatherfile. If no, do not use the holidays specified on the Weatherfile. Note: You can still specify holidays/special days using the RunPeriodControl:SpecialDays object(s).")]
    //    [Input("UseWeatherFileDaylightSavingPeriod", " If yes or blank, use daylight saving period as specified on Weatherfile. If no, do not use the daylight saving period as specified on the Weatherfile.")]
    //    [Input("ApplyWeekendHolidayRule", "if yes and single day holiday falls on weekend, holiday occurs on following Monday")]
    //    [Input("UseWeatherFileRainIndicators", "UseWeatherFileRainIndicators")]
    //    [Input("UseWeatherFileSnowIndicators", "UseWeatherFileSnowIndicators")]
    //    [Input("TreatWeatherAsActual", "TreatWeatherAsActual")]
    //    [Output("RunPeriod", "A BH.oM.EnergyPlus.RunPeriod object")]

    //    public static RunPeriod RunPeriod(
    //       string name = "Jan",
    //       int beginMonth = 1,
    //       int beginDayOfMonth = 1,
    //       int beginYear = 2000,
    //       int endMonth = 1,
    //       int endDayOfMonth = 1,
    //       int endYear = 2000,
    //       SimulationDayType dayOfWeekforStartDay = SimulationDayType.Tuesday,
    //       bool useWeatherfileHolidaysAndSpecialDays=true,
    //       bool useWeatherfileDaylightSavingPeriod = true,
    //       bool applyWeekendHolidayRule = true,
    //       bool useWeatherfileRainIndicators = true,
    //       bool useWeatherfileSnowIndicators = true,
    //       bool treatWeatherAsActual = true
    //       )
    //    {
    //        if (beginMonth < 1 || beginMonth > 12)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("beginMonth cannot be less than 1 or more than 12");
    //            return null;
    //        }
    //        if (beginDayOfMonth < 1 || beginDayOfMonth > 31)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("beginDayOfMonth cannot be less than 1 or more than 31");
    //            return null;
    //        }
    //        if (beginYear < 1)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("beginYear cannot be less than 1");
    //            return null;
    //        }

    //        if (endMonth < 1 || endMonth > 12)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("endMonth cannot be less than 1 or more than 12");
    //            return null;
    //        }
    //        if (endDayOfMonth < 1 || endDayOfMonth > 31)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("endDayOfMonth cannot be less than 1 or more than 31");
    //            return null;
    //        }
    //        if (endYear < beginYear)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("endYear cannot be earlier than beginYear");
    //            return null;
    //        }
    //        if (dayOfWeekforStartDay == SimulationDayType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("SimulationDayType cannot be undefined");
    //            return null;
    //        }

    //        return new RunPeriod
    //        {
    //            Name = name,
    //            BeginMonth=beginMonth,
    //            BeginDayofMonth=beginDayOfMonth,
    //            BeginYear=beginYear,
    //            EndMonth=endMonth,
    //            EndDayofMonth=endDayOfMonth,
    //            EndYear=endYear,
    //            DayOfWeekforStartDay=dayOfWeekforStartDay,
    //            UseWeatherFileHolidaysAndSpecialDays =useWeatherfileHolidaysAndSpecialDays,
    //            UseWeatherFileDaylightSavingPeriod=useWeatherfileDaylightSavingPeriod,
    //            UseWeatherFileRainIndicators=useWeatherfileRainIndicators,
    //            UseWeatherFileSnowIndicators=useWeatherfileSnowIndicators,
    //        };
    //    }
    //}
}
