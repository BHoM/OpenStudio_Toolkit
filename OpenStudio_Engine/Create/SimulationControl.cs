/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.OpenStudio;
using BH.Engine.Base;

namespace BH.Engine.OpenStudio
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create SimulationControl => Note that the following 3 fields are related to the Sizing:Zone, Sizing:System,  and Sizing:Plant objects.  Having these fields set to Yes but no corresponding  Sizing object will not cause the sizing to be done. However, having any of these  fields set to No, the corresponding Sizing object is ignored.  Note also, if you want to do system sizing, you must also do zone sizing in the same  run or an error will result.")]
    //    [Input("doZoneSizingCalculation", " If Yes, Zone sizing is accomplished from corresponding Sizing:Zone objects and autosize fields.")]
    //    [Input("doSystemSizingCalculation", "If Yes, System sizing is accomplished from corresponding Sizing:System objects and autosize fields. If Yes, Zone sizing (previous field) must also be Yes.")]
    //    [Input("doPlantSizingCalculation", "If Yes, Plant sizing is accomplished from corresponding Sizing:Plant objects and autosize fields.")]
    //    [Input("runSimulationforSizingPeriods", "If Yes, SizingPeriod:* objects are executed and results from those may be displayed..")]
    //    [Input("runSimulationforWeatherFileRunPeriods", "If Yes, RunPeriod:* objects are executed and results from those may be displayed..")]
    //    [Input("doHVACSizingSimulationforSizingPeriods", "If Yes, SizingPeriod:* objects are exectuted additional times for advanced sizing. Currently limited to use with coincident plant sizing, see Sizing:Plant object")]
    //    [Input("maximumNumberofHVACSizingSimulationPasses", "The entire set of SizingPeriod:* objects may be repeated to fine tune size results this input sets a limit on the number of passes that the sizing algorithms can repeate the set")]
    //    [Output("simulationControl", "A BH.oM.EnergyPlus.SimulationControl object")]
    //    public static SimulationControl SimulationControl(
    //        bool doZoneSizingCalculation = false,
    //        bool doSystemSizingCalculation = false,
    //        bool doPlantSizingCalculation = false,
    //        bool runSimulationforSizingPeriods = false,
    //        bool runSimulationforWeatherFileRunPeriods = true,
    //        bool doHVACSizingSimulationforSizingPeriods = false,
    //        int maximumNumberofHVACSizingSimulationPasses = 1
    //    )
    //    {
    //        if (maximumNumberofHVACSizingSimulationPasses < 1)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("maximumNumberofHVACSizingSimulationPasses cannot be less than 1");
    //            return null;
    //        }

    //        return new SimulationControl
    //        {
    //            DoZoneSizingCalculation = doZoneSizingCalculation,
    //            DoSystemSizingCalculation = doSystemSizingCalculation,
    //            DoPlantSizingCalculation = doPlantSizingCalculation,
    //            RunSimulationforSizingPeriods = runSimulationforSizingPeriods,
    //            RunSimulationforWeatherFileRunPeriods = runSimulationforWeatherFileRunPeriods,
    //            DoHVACSizingSimulationforSizingPeriods = doHVACSizingSimulationforSizingPeriods,
    //            MaximumNumberofHVACSizingSimulationPasses = maximumNumberofHVACSizingSimulationPasses,
    //        };
    //    }
    //}
}