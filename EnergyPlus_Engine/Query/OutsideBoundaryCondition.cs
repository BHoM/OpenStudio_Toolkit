using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;

using BH.Engine.Environment;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Query
    {
        public static string OutsideBoundaryCondition(this BHE.Panel panel, List<List<BHE.Panel>> adjacentSpaces)
        {
            if (panel.Type == BHE.PanelType.Roof || panel.Type == BHE.PanelType.WallExternal)
                return "Outdoors";

            if (adjacentSpaces.Count == 2)
                return "Zone";

            return "";
        }
    }
}