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

namespace BH.oM.OpenStudio
{
    public enum OutputVariableDictionarySortOptionType
    {
        Undefined,
        Name,
        Unsorted,
    }

    public enum OutputVariableDictionaryKeyFieldType
    {
        Undefined,
        IDF,
        Regular,
    }

    public enum OutputSurfacesDrawingReportType
    {
        Undefined,
        DXF,
        DXFWireFrame,
        VRML,
    }

    public enum OutputSurfacesReportSpecificationsType
    {
        Undefined,
        RegularPolyline,
        ThickPolyline,
        Triangulate3DFace,
    }

    public enum OutputDiagnosticsKeyType
    {
        Undefined,
        DisplayAdvancedReportVariables,
        DisplayAllWarnings,
        DisplayExtraWarnings,
        DisplayUnusedObjects,
        DisplayUnusedSchedules,
        DisplayWeatherMissingDataWarnings,
        DisplayZoneAirHeatBalanceOffBalance,
        DoNotMirrorAttachedShading,
        DoNotMirrorDetachedShading,
        ReportDetailedWarmupConvergence,
        ReportDuringHVACSizingSimulation,
        ReportDuringWarmup,
    }

    public enum OutputSurfacesListReportType
    {
        Undefined,
        CostInfo,
        DecayCurvesFromComponentLoadsSummary,
        Details,
        DetailsWithVertices,
        Lines,
        Vertices,
        ViewFactorInfo,
    }

    public enum OutputVariableReportingFrequencyType
    {
        Undefined,
        Annual,
        Daily,
        Detailed,
        Environment,
        Hourly,
        Monthly,
        RunPeriod,
        Timestep,
    }

    public enum UnitConversionType
    {
        Undefined,
        InchPound,
        JtoGJ,
        JtoKWH,
        JtoMJ,
        None,
    }

    public enum ConstructionsDetailsType
    {
        Undefined,
        Constructions,
        Materials,
    }

    public enum ColumnSeparatorType
    {
        Undefined,
        All,
        Comma,
        CommaAndHTML,
        CommaAndXML,
        Fixed,
        HTML,
        Tab,
        TabAndHTML,
        XML,
        XMLandHTML,
    }
}
