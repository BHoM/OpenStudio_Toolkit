/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.EnergyPlus;
using BH.Engine.Base;

namespace BH.Engine.EnergyPlus
{
    public static partial class Create
    {
        [Description("BH.Engine.EnergyPlus.Create OutputVariable =>Variable command picks variables to be put onto the standard output file (.eso) Some variables may not be reported for every simulation a list of variables that can be reported are available after a run on the report dictionary file(.rdd) if the Output: VariableDictionary has been requested.")]
        [Input("keyValue", "KeyValue")]
        [Input("variableName", "VariableName")]
        [Input("reportingFrequency", "Detailed lists every instance (i.e. HVAC variable timesteps) Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod and Environment are the same")]
        [Input("scheduleName", "ScheduleName")]
        [Output("outputVariable", "A BH.oM.EnergyPlus.OutputVariable object")]

        public static OutputVariable OutputVariable(
            string keyValue="*",
            string variableName = "Site Outdoor Air Drybulb Temperature",
            OutputVariableReportingFrequencyType reportingFrequency = OutputVariableReportingFrequencyType.Hourly,
            string scheduleName = "System Availability Schedule"
        )
        {
            if (reportingFrequency==OutputVariableReportingFrequencyType.Undefined)
            {
                BH.Engine.Reflection.Compute.RecordError("OutputVariableReportingFrequencyType cannot be undefined");
                return null;
            }

            return new OutputVariable
            {
                KeyValue = keyValue,
                VariableName = variableName,
                ReportingFrequency =reportingFrequency,
                ScheduleName=scheduleName,
            };
        }
    }
}
