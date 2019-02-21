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
        public static string ToOSM(this BHM.GasType gasType)
        {
            switch (gasType)
            {
                case BHM.GasType.Air:
                    return "Air";
                case BHM.GasType.Argon:
                    return "Argon";
                case BHM.GasType.Krypton:
                    return "Krypton";
                case BHM.GasType.Xenon:
                    return "Xenon";
                default:
                    return "Air";
            }
        }

        public static BHM.GasType ToBHoMGasType(this string gasType)
        {
            if (gasType.Equals("Air"))
                return BHM.GasType.Air;
            if (gasType.Equals("Argon"))
                return BHM.GasType.Argon;
            if (gasType.Equals("Krypton"))
                return BHM.GasType.Krypton;
            if (gasType.Equals("Xenon"))
                return BHM.GasType.Xenon;

            return BHM.GasType.Undefined;
        }
    }
}

