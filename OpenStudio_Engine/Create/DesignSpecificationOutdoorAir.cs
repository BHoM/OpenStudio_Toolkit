/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.Adapters.OpenStudio;
using BH.Engine.Base;

namespace BH.Engine.Adapters.OpenStudio
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create DesignSpecificationOutdoorAir => ")]
    //    [Input("outdoorAirFlowPerPerson", "0.00944 m3/s is equivalent to 20 cfm per person This input is only used if the field Outdoor Air Method is Flow/Person, Sum, or Maximum For sizing, the design number of occupants is used. For outdoor air flow control, the use of design occupants or current occupants depends on the component and DCV options. AirTerminal:SingleDuct:VAV:NoReheat, AirTerminal:SingleDuct:VAV:Reheat use the DCV flag specified in Controller:MechanicalVentilation AirTerminal:DualDuct:VAV:OutdoorAir and ZoneHVAC:IdealLoadsAirSystem have their own DCV control input. ZoneHVAC:FourPipeFanCoil always uses current occupants.")]
    //    [Input("outdoorAirFlowPerZoneFloorArea", "This input is only used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
    //    [Input("outdoorAirFlowPerZone", "This input is only used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
    //    [Input("outdoorAirFlowAirChangesPerHour", "This input is only used if the field Outdoor Air Method is AirChanges/Hour, Sum, or Maximum")]
    //    [Input("outdoorAirFlowFractionScheduleName", "A BH.oM.EnergyPlus.ScheduleFile object. Schedule values are multiplied by the Outdoor Air Flow rate calculated using the previous four inputs. Schedule values are limited to 0 to 1. If left blank, the schedule defaults to 1.0. This schedule is ignored during sizing.  All other components which reference this design specification use the current schedule value to calculate the current outdoor air requirement. This includes AirTerminal:SingleDuct:VAV:NoReheat, AirTerminal:SingleDuct:VAV:Reheat, AirTerminal:DualDuct:VAV:OutdoorAir, ZoneHVAC:FourPipeFanCoil, and ZoneHVAC:IdealLoadsAirSystem. This schedule will also be applied by Controller:MechanicalVentilation for all System Outdoor Air Methods.")]
    //    [Output("designSpecificationOutdoorAir", "A BH.oM.EnergyPlus.DesignSpecificationOutdoorAir object")]
    //    public static DesignSpecificationOutdoorAir DesignSpecificationOutdoorAir(
    //        OutdoorAirMethodType outdoorAirMethod = OutdoorAirMethodType.FlowPerPerson,
    //        double outdoorAirFlowPerPerson = 0.00944,
    //        double outdoorAirFlowPerZoneFloorArea = 0.0,
    //        double outdoorAirFlowPerZone = 0.0,
    //        double outdoorAirFlowAirChangesPerHour = 0.0,
    //        ScheduleFile outdoorAirFlowFractionScheduleName = null
    //    )
    //    {
    //        if (outdoorAirMethod == OutdoorAirMethodType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirMethod isn't set. Default is FlowPerPerson");
    //            return null;
    //        }

    //        if (outdoorAirFlowPerPerson < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirFlowPerPerson must be greater than 0");
    //            return null;
    //        }

    //        if (outdoorAirFlowPerZoneFloorArea < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirFlowPerZoneFloorArea must be greater than 0");
    //            return null;
    //        }

    //        if (outdoorAirFlowPerZone < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirFlowPerZone must be greater than 0");
    //            return null;
    //        }

    //        if (outdoorAirFlowAirChangesPerHour < 0)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirFlowAirChangesPerHour must be greater than 0");
    //            return null;
    //        }

    //        if (outdoorAirFlowFractionScheduleName == null)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("outdoorAirFlowFractionScheduleName is null. This must reference a BH.oM.EnergyPlus.ScheduleFile object");
    //            return null;
    //        }

    //        return new DesignSpecificationOutdoorAir
    //        {
    //            OutdoorAirMethod = outdoorAirMethod,
    //            OutdoorAirFlowPerPerson = outdoorAirFlowPerPerson,
    //            OutdoorAirFlowPerZoneFloorArea = outdoorAirFlowPerZoneFloorArea,
    //            OutdoorAirFlowPerZone = outdoorAirFlowPerZone,
    //            OutdoorAirFlowAirChangesPerHour = outdoorAirFlowAirChangesPerHour,
    //            OutdoorAirFlowFractionScheduleName = outdoorAirFlowFractionScheduleName,
    //        };
    //    }
    //}
}

