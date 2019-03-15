using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClipperLib;
using Path = System.Collections.Generic.List<ClipperLib.IntPoint>;
using Paths = System.Collections.Generic.List<System.Collections.Generic.List<ClipperLib.IntPoint>>;
// http://www.angusj.com/delphi/clipper.php

using BH.oM.Geometry;
using BH.Engine.Geometry;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;

namespace BH.Engine.EnergyPlus
{
    public static partial class Modify
    {
        public static int CountDecimalPlaces(double value)
        {
            if (Math.Floor(value) == value)
            {
                return 0;
            }
            string[] words = value.ToString().Split('.');
            return words[1].Length;
        }

        public static int IntegerizePointFactor(List<Point> points)
        {
            // Get the factor to multiply by
            List<int> factorList = new List<int>();
            foreach (Point pt in points)
            {
                factorList.Add(CountDecimalPlaces(pt.X));
                factorList.Add(CountDecimalPlaces(pt.Y));
                factorList.Add(CountDecimalPlaces(pt.Z));
            }

            int factor = (int)Math.Pow(10, factorList.Max());

            return factor;
        }

        public static Point PointDifference(Point A, Point B)
        {
            return Create.Point(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

        public static Point PointSum(Point A, Point B, Point C)
        {
            // There must be a better way of doing this. Sum of three/any length list of points/vectors
            return Create.Point(A.X + B.X + C.X, A.Y + B.Y + C.Y, A.Z + B.Z + C.Z);
        }

        public static Vector ScaleVector(Vector A, double V)
        {
            return Create.Vector(A.X * V, A.Y * V, A.Z * V);
        }

        public static Vector NormalizeVector(Vector A)
        {
            double length = Math.Sqrt(Math.Pow(A.X, 2) + Math.Pow(A.Y, 2) + Math.Pow(A.Z, 2));
            return Create.Vector(A.X / length, A.Y / length, A.Z / length);
        }

        public static Vector VectorDifference(Vector A, Vector B)
        {
            return Create.Vector(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

        public static List<PolyCurve> TranslateCurve2DAndBack(Polyline curve)
        {
            // From here translates the curve to 2D
            List<Point> points = curve.IDiscontinuityPoints();

            Point loc0 = points[0];
            Point p1 = points[1];
            Point p2 = null;
            if (points.Last() == loc0)
            {
                p2 = points[points.Count - 2];
            }
            else
            {
                p2 = points.Last();
            }

            Vector locx = Create.Vector(PointDifference(p1, loc0));
            Vector normal = Geometry.Query.CrossProduct(locx, Create.Vector(PointDifference(p2, loc0)));
            Vector locy = Geometry.Query.CrossProduct(normal, locx);

            Vector ulocx = NormalizeVector(locx);
            Vector ulocy = NormalizeVector(locy);

            List<Point> local_coords = new List<Point>();
            foreach (Point pt in points)
            {
                Vector v = Create.Vector(PointDifference(pt, loc0));
                local_coords.Add(Create.Point(Geometry.Query.DotProduct(v, ulocx), Geometry.Query.DotProduct(v, ulocy)));
            }

            local_coords.Add(local_coords[0]); // this adds the first point to the end of the points list to close it again
            PolyCurve translated = Create.PolyCurve(new List<Polyline> { Create.Polyline(local_coords) });

            // TODO - ADD METHOD TO CONVERT DOUBLE POINT LOCATIONS TO INTEGER POINT LOCATIONS
            int factor = IntegerizePointFactor(local_coords);
            List<Point> intPoints = new List<Point>();
            foreach (Point pt in local_coords)
            {
                intPoints.Add(Create.Point(pt.X * factor, pt.Y * factor, pt.Z * factor));
            }
            
            // TODO - OFFSET POINTS USING CLIPPER
            // TODO - UNINTEGERIZE THE POINTS BACK TO THEIR DOUBLE LOCATIONS
            // TODO - TRANSLATE THE OFFSET BACK TO THE ORIGINALPLANE

            // From here un-translates the curve
            List<Point> untranslated_coords = new List<Point>();
            foreach (Point pt in local_coords)
            {
                untranslated_coords.Add(PointSum(loc0, Create.Point(ScaleVector(ulocx, pt.X)), Create.Point(ScaleVector(ulocy, pt.Y))));
            }

            untranslated_coords.Add(untranslated_coords[0]); // this adds the first point to the end of the points list to close it again
            PolyCurve untranslated = Create.PolyCurve(new List<Polyline> { Create.Polyline(untranslated_coords) });

            List<PolyCurve> output = new List<PolyCurve>() { translated, untranslated };

            return output;
        }





        //public static PolyCurve OffsetCurve(PolyCurve curve)
        //{
        //    return new PolyCurve();
        //}
    }
}
