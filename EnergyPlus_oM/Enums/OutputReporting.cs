using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
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