/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

using BHE = BH.oM.Environment.Elements;

namespace BH.Engine.Adapters.OpenStudio
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

