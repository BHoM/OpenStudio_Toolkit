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
    //    [Description("BH.Engine.EnergyPlus.Create ScheduleFile => A Schedule:File points to a text computer file that has 8760-8784 hours of data.")]
    //    [Input("scheduleTypeLimitsName", "A BH.oM.EnergyPlus.ScheduleTypeLimits object")]
    //    [Input("fileName", "Path to the file containing the annual hourly values")]
    //    [Input("columnNumber", "Column from file from which to read values")]
    //    [Input("rowsToSkipAtTop", "Number of rows to skip")]
    //    [Input("numberOfHoursOfData", "Number of rows of values in the file")]
    //    [Input("columnSeparator", "Column separator character")]
    //    [Input("interpolateToTimestep", "when the interval does not match the user specified timestep a 'Yes' choice will average between the intervals request (to timestep resolution.  a 'No' choice will use the interval value at the simulation timestep without regard to if it matches the boundary or not.")]
    //    [Input("minutesPerItem", "Must be evenly divisible into 60")]
    //    [Output("scheduleFile", "A BH.oM.EnergyPlus.ScheduleFile object")]
    //    public static ScheduleFile ScheduleFile(
    //        ScheduleTypeLimits scheduleTypeLimitsName = null,
    //        string fileName = "",
    //        int columnNumber = 1,
    //        int rowsToSkipAtTop = 0,
    //        int numberOfHoursOfData = 8760,
    //        ScheduleColumnSeparatorType columnSeparator = ScheduleColumnSeparatorType.Comma,
    //        bool interpolateToTimestep = false,
    //        int minutesPerItem = 0
    //    )
    //    {
    //        if (scheduleTypeLimitsName == null)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("scheduleTypeLimitsName is null. It needs to reference a BH.oM.EnergyPlus.ScheduleTypeLimits object.");
    //            return null;
    //        }

    //        if (fileName == "")
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("No filepath given to the schedule file object");
    //            return null;
    //        }

    //        if (columnNumber < 1)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("columnNumber must be greater than or equal to 1");
    //            return null;
    //        }

    //        if (rowsToSkipAtTop < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("rowsToSkipAtTop must be greater than or equal to 0");
    //            return null;
    //        }

    //        if (numberOfHoursOfData > 8760)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("numberOfHoursOfData must be 8760 (currently no implementation for leap years incuded)");
    //            return null;
    //        }

    //        if (columnSeparator == ScheduleColumnSeparatorType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("columnSeparator can't be Undefined, usually this is Comma.");
    //            return null;
    //        }

    //        if (columnSeparator == ScheduleColumnSeparatorType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("columnSeparator can't be Undefined, usually this is Comma.");
    //            return null;
    //        }

    //        if ((minutesPerItem < 1) || (minutesPerItem > 60))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("minutesPerItem must be between 1 and 60");
    //            return null;
    //        }

    //        return new ScheduleFile
    //        {
    //            ScheduleTypeLimitsName = scheduleTypeLimitsName,
    //            FileName = fileName,
    //            ColumnNumber = columnNumber,
    //            RowsToSkipAtTop = rowsToSkipAtTop,
    //            NumberOfHoursOfData = numberOfHoursOfData,
    //            ColumnSeparator = columnSeparator,
    //            InterpolateToTimestep = interpolateToTimestep,
    //            MinutesPerItem = minutesPerItem
    //        };
    //    }
    //}
}