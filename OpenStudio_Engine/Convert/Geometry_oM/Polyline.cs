/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

using OpenStudio;
using BHG = BH.oM.Geometry;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static Point3dVector ToOSM(this BHG.Polyline pLine)
        {
            Point3dVector osmLine = new Point3dVector();

            foreach (BHG.Point p in pLine.ControlPoints)
                osmLine.Add(p.ToOSM());

            osmLine.RemoveAt(pLine.ControlPoints.Count - 1);

            return osmLine;
        }
        
        public static BHG.Polyline ToBHoM(this Point3dVector osmLine)
        {
            BHG.Polyline pLine = new BHG.Polyline();

            foreach (Point3d p in osmLine)
                pLine.ControlPoints.Add(p.ToBHoM());

            return pLine;
        }
    }
}



