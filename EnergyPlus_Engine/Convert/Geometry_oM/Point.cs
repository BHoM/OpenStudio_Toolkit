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
        public static Point3dVector ToOSM(this List<BHG.Point> pts)
        {
            Point3dVector vector = new Point3dVector();

            pts.Remove(pts.Last());

            foreach (BHG.Point p in pts)
                vector.Add(p.ToOSM());

            return vector;
        }

        public static Point3d ToOSM(this BHG.Point point)
        {
            return new Point3d(point.X, point.Y, point.Z);
        }

        public static BHG.Point ToBHoM(this Point3d point)
        {
            return new BHG.Point
            {
                X = point.x(),
                Y = point.y(),
                Z = point.z(),
            };
        }
    }
}
