using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Properties;

using BH.Engine.Environment;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Query
    {
        public static string OutsideBoundaryCondition(this BHE.BuildingElement element, List<List<BHE.BuildingElement>> adjacentSpaces)
        {
            BHP.ElementProperties elementProperties = element.ElementProperties() as BHP.ElementProperties;

            if (elementProperties.BuildingElementType == BHE.BuildingElementType.Roof || elementProperties.BuildingElementType == BHE.BuildingElementType.WallExternal)
                return "Outdoors";

            if (adjacentSpaces.Count == 2)
                return "Zone";

            return "";
        }
    }
}