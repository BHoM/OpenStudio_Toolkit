using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHG = BH.oM.Geometry;

namespace BH.Engine.EnergyPlus
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
