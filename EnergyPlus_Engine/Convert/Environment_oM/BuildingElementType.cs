using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHE = BH.oM.Environment.Elements;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static string ToOSMSurfaceType(this BHE.BuildingElementType type)
        {
            switch(type)
            {
                case BHE.BuildingElementType.Ceiling:
                    return "Ceiling";
                case BHE.BuildingElementType.Floor:
                    return "Floor";
                case BHE.BuildingElementType.Wall:
                case BHE.BuildingElementType.CurtainWall:
                    return "Wall";
                case BHE.BuildingElementType.Roof:
                    return "Roof";
                default:
                    return "Wall";
            }
        }

        public static string ToOSMFenestrationType(this BHE.BuildingElementType type)
        {
            switch(type)
            {
                case BHE.BuildingElementType.CurtainWall:
                case BHE.BuildingElementType.Window:
                case BHE.BuildingElementType.WindowWithFrame:
                case BHE.BuildingElementType.Rooflight:
                case BHE.BuildingElementType.RooflightWithFrame:
                    return "Window";
                case BHE.BuildingElementType.Door:
                    return "Door";
                default:
                    return "Window";
            }
        }

        public static BHE.BuildingElementType ToBHoMBuildingElementType(this string type)
        {
            if (type == "Wall")
                return BHE.BuildingElementType.Wall;
            if (type == "Roof")
                return BHE.BuildingElementType.Roof;
            if (type == "Window")
                return BHE.BuildingElementType.Window;
            if (type == "Door")
                return BHE.BuildingElementType.Door;
            if (type == "Floor")
                return BHE.BuildingElementType.Floor;
            if (type == "Ceiling")
                return BHE.BuildingElementType.Ceiling;

            return BHE.BuildingElementType.Undefined;
        }
    }
}
