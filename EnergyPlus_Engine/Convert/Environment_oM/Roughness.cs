using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;
using BHG = BH.oM.Geometry;
using BHM = BH.oM.Environment.MaterialFragments;

using BH.Engine.Environment;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static string ToOSM(this BHM.Roughness roughness)
        {
            switch (roughness)
            {
                case BHM.Roughness.MediumRough:
                    return "MediumRough";
                case BHM.Roughness.MediumSmooth:
                    return "MediumSmooth";
                case BHM.Roughness.Rough:
                    return "Rough";
                case BHM.Roughness.Smooth:
                    return "Smooth";
                case BHM.Roughness.VeryRough:
                    return "VeryRough";
                case BHM.Roughness.VerySmooth:
                    return "VerySmooth";
                default:
                    return "";
            }
        }

        public static BHM.Roughness ToBHoMRoughness(this string roughness)
        {
            if (roughness.Equals("MediumRough"))
                return BHM.Roughness.MediumRough;
            if (roughness.Equals("MediumSmooth"))
                return BHM.Roughness.MediumSmooth;
            if (roughness.Equals("Rough"))
                return BHM.Roughness.Rough;
            if (roughness.Equals("Smooth"))
                return BHM.Roughness.Smooth;
            if (roughness.Equals("VeryRough"))
                return BHM.Roughness.VeryRough;
            if (roughness.Equals("VerySmooth"))
                return BHM.Roughness.VerySmooth;

            return BHM.Roughness.Undefined;
        }
    }
}

