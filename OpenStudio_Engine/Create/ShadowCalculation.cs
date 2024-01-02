/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.oM.Reflection.Attributes;
using BH.oM.Adapters.OpenStudio;
using BH.Engine.Base;

using System.Collections;
using System.ComponentModel;

namespace BH.Engine.Adapters.OpenStudio
{
    //public static partial class Create
    //{
    //    /***************************************************/
    //    /**** Public Methods                            ****/
    //    /***************************************************/

    //    [Description("BH.Engine.EnergyPlus.Create ShadowCalculation => IDF,ShadowCalculation,AverageOverDaysInFrequency,20,15000,SutherlandHodgman,SimpleSkyDiffuseModeling,,Yes,,,,,,,,;")]
    //    [Input("CalculationMethod", "choose calculation method. note that TimestepFrequency is only needed for certain cases and can increase execution time significantly.")]
    //    [Input("CalculationFrequency", "enter number of days this field is only used if the previous field is set to AverageOverDaysInFrequency 0=Use Default Periodic Calculation|<else> calculate every <value> day only really applicable to RunPeriods warning issued if >31")]
    //    [Input("MaximumFiguresinShadowOverlapCalculations", "Number of allowable figures in shadow overlap calculations")]
    //    [Input("PolygonClippingAlgorithm", "Advanced Feature.  Internal default is SutherlandHodgman Refer to InputOutput Reference and Engineering Reference for more information")]
    //    [Input("SkyDiffuseModelingAlgorithm", "Advanced Feature.  Internal default is SimpleSkyDiffuseModeling If you have shading elements that change transmittance over the year, you may wish to choose the detailed method. Refer to InputOutput Reference and Engineering Reference for more information")]
    //    [Input("ExternalShadingCalculationMethod", " If ScheduledShading is chosen, the External Shading Fraction Schedule Name is required in SurfaceProperty:LocalEnvironment. If ImportedShading is chosen, the Schedule:File:Shading object is required.")]
    //    [Input("OutputExternalShadingCalculationResults", "If Yes is chosen, the calculated external shading fraction results will be saved to an external CSV file with surface names as the column headers.")]
    //    [Output("ShadowCalculation", "A BH.oM.EnergyPlus.ShadowCalculation object")]
    //    public static ShadowCalculation ShadowCalculation(
    //        ShadowCalculationMethodType CalculationMethod = ShadowCalculationMethodType.AverageOverDaysInFrequency,
    //        int CalculationFrequency = 20,
    //        int MaximumFiguresinShadowOverlapCalculations = 15000,
    //        PolygonClippingAlgorithmType PolygonClippingAlgorithm = PolygonClippingAlgorithmType.SutherlandHodgman,
    //        SkyDiffuseModelingAlgorithmType SkyDiffuseModelingAlgorithm = SkyDiffuseModelingAlgorithmType.SimpleSkyDiffuseModeling,
    //        ExternalShadingCalculationMethodType ExternalShadingCalculationMethod = ExternalShadingCalculationMethodType.InternalCalculation,
    //        bool OutputExternalShadingCalculationResults = true
    //        )
    //    {

    //        if (MaximumFiguresinShadowOverlapCalculations < 200)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("MaximumFiguresinShadowOverlapCalculations cannot be less than 200");
    //            return null;
    //        }

    //        return new ShadowCalculation
    //        {
    //            CalculationMethod = CalculationMethod,
    //            CalculationFrequency = CalculationFrequency,
    //            MaximumFiguresinShadowOverlapCalculations = MaximumFiguresinShadowOverlapCalculations,
    //            PolygonClippingAlgorithm = PolygonClippingAlgorithm,
    //            SkyDiffuseModelingAlgorithm = SkyDiffuseModelingAlgorithm,
    //            ExternalShadingCalculationMethod = ExternalShadingCalculationMethod
    //        };
    //    }
    //}
}




