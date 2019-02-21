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
    //    [Description("BH.Engine.EnergyPlus.Create HVACTemplateThermostat => ")]
    //    [Input("heatingSetpointScheduleName", "Leave blank if constant setpoint specified below, must enter schedule or constant setpoint")]
    //    [Input("constantHeatingSetpoint", "Ignored if schedule specified above, must enter schedule or constant setpoint")]
    //    [Input("coolingSetpointScheduleName", "Leave blank if constant setpoint specified below, must enter schedule or constant setpoint")]
    //    [Input("constantCoolingSetpoint", "Ignored if schedule specified above, must enter schedule or constant setpoint")]
    //    [Output("", "A BH.oM.EnergyPlus.HVACTemplateThermostat object")]
    //    public static HVACTemplateThermostat HVACTemplateThermostat(
    //        ScheduleFile heatingSetpointScheduleName = null,
    //        double constantHeatingSetpoint = 0.0,
    //        ScheduleFile coolingSetpointScheduleName = null,
    //        double constantCoolingSetpoint = 0.0
    //    )
    //    {
    //        if ((heatingSetpointScheduleName != null) || (coolingSetpointScheduleName != null))
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("The heating or cooling setpoint schedule hasn't been given. They require a BH.oM.EnergyPlus.Schedule object.");
    //            return null;
    //        }

    //        return new HVACTemplateThermostat
    //        {
    //            HeatingSetpointScheduleName = heatingSetpointScheduleName,
    //            ConstantHeatingSetpoint = constantHeatingSetpoint,
    //            CoolingSetpointScheduleName = coolingSetpointScheduleName,
    //            ConstantCoolingSetpoint = constantCoolingSetpoint
    //        };
    //    }
    //}
}