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
        public static string ToOSMSurfaceType(this BHE.PanelType type)
        {
            switch(type)
            {
                case BHE.PanelType.Ceiling:
                    return "Ceiling";
                case BHE.PanelType.Floor:
                    return "Floor";
                case BHE.PanelType.Wall:
                case BHE.PanelType.CurtainWall:
                    return "Wall";
                case BHE.PanelType.Roof:
                    return "Roof";
                default:
                    return "Wall";
            }
        }

        public static string ToOSMFenestrationType(this BHE.OpeningType type)
        {
            switch(type)
            {
                case BHE.OpeningType.CurtainWall:
                case BHE.OpeningType.Window:
                case BHE.OpeningType.WindowWithFrame:
                case BHE.OpeningType.Rooflight:
                case BHE.OpeningType.RooflightWithFrame:
                    return "Window";
                case BHE.OpeningType.Door:
                    return "Door";
                default:
                    return "Window";
            }
        }

        public static BHE.PanelType ToBHoMPanelType(this string type)
        {
            if (type == "Wall")
                return BHE.PanelType.Wall;
            if (type == "Roof")
                return BHE.PanelType.Roof;
            
            if (type == "Floor")
                return BHE.PanelType.Floor;
            if (type == "Ceiling")
                return BHE.PanelType.Ceiling;

            return BHE.PanelType.Undefined;
        }

        public static BHE.OpeningType ToBHoMOpeningType(this string type)
        {
            if (type == "Window")
                return BHE.OpeningType.Window;
            if (type == "Door")
                return BHE.OpeningType.Door;

            return BHE.OpeningType.Undefined;
        }
    }
}
