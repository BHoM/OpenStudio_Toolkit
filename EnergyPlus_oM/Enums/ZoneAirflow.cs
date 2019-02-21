using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum VentilationType
    {
        Undefined,
        Balanced,
        Exhaust,
        Intake,
        Natural,
    }

    public enum ZoneAirflowInfiltrationDesignFlowRateCalculationMethodType
    {
        Undefined,
        AirChangesPerHour,
        FlowPerArea,
        FlowPerExteriorArea,
        FlowPerExteriorWallArea,
        FlowPerZone,
    }

    public enum ZoneAirflowVentilationDesignFlowRateCalculationMethodType
    {
        Undefined,
        AirChangesPerHour,
        FlowPerArea,
        FlowPerPerson,
        FlowPerZone,
    }
}
