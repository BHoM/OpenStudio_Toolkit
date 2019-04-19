using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHM = BH.oM.Environment.Materials;
using BHP = BH.oM.Environment.Properties;
using BHG = BH.oM.Geometry;

using BH.Engine.Environment;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static string ToOSM(this BHM.Gas gasType)
        {
            switch (gasType)
            {
                case BHM.Gas.Air:
                    return "Air";
                case BHM.Gas.Argon:
                    return "Argon";
                case BHM.Gas.Krypton:
                    return "Krypton";
                case BHM.Gas.Xenon:
                    return "Xenon";
                default:
                    return "Air";
            }
        }

        public static BHM.Gas ToBHoMGasType(this string gasType)
        {
            if (gasType.Equals("Air"))
                return BHM.Gas.Air;
            if (gasType.Equals("Argon"))
                return BHM.Gas.Argon;
            if (gasType.Equals("Krypton"))
                return BHM.Gas.Krypton;
            if (gasType.Equals("Xenon"))
                return BHM.Gas.Xenon;

            return BHM.Gas.Undefined;
        }
    }
}

