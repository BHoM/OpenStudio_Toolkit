using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Properties;
using BHG = BH.oM.Geometry;

using BH.Engine.Environment;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static string ToOSM(this BHE.ConstructionRoughness roughness)
        {
            switch (roughness)
            {
                case BHE.ConstructionRoughness.MediumRough:
                    return "MediumRough";
                case oM.Environment.Elements.ConstructionRoughness.MediumSmooth:
                    return "MediumSmooth";
                case oM.Environment.Elements.ConstructionRoughness.Rough:
                    return "Rough";
                case oM.Environment.Elements.ConstructionRoughness.Smooth:
                    return "Smooth";
                case oM.Environment.Elements.ConstructionRoughness.VeryRough:
                    return "VeryRough";
                case oM.Environment.Elements.ConstructionRoughness.VerySmooth:
                    return "VerySmooth";
                default:
                    return "";
            }
        }

        public static BHE.ConstructionRoughness ToBHoMRoughness(this string roughness)
        {
            if (roughness.Equals("MediumRough"))
                return BHE.ConstructionRoughness.MediumRough;
            if (roughness.Equals("MediumSmooth"))
                return BHE.ConstructionRoughness.MediumSmooth;
            if (roughness.Equals("Rough"))
                return BHE.ConstructionRoughness.Rough;
            if (roughness.Equals("Smooth"))
                return BHE.ConstructionRoughness.Smooth;
            if (roughness.Equals("VeryRough"))
                return BHE.ConstructionRoughness.VeryRough;
            if (roughness.Equals("VerySmooth"))
                return BHE.ConstructionRoughness.VerySmooth;

            return BHE.ConstructionRoughness.Undefined;
        }
    }
}

