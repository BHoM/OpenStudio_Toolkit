using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClipperLib;

using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;

namespace BH.Engine.EnergyPlus
{
    public static partial class Modify
    {
        [Description("Offsets a planar 3D polyline, translating it to 2D for offseting, then re-translating the offset to 3D")]
        [Input("tbdPolygon", "TAS TBD Polygon")]
        [Output("BHoM Geometry Polyline")]
        public static BHG.PolyCurve OffsetCurve(BHG.PolyCurve polycurve, double offsetDistance)
        {
            //Clipper.OffsetPolygons(new List<List<ClipperLib.IntPoint>>(), 0.1, JoinType.jtSquare);
            //List<BHG.Point> childpts = child.OpeningCurve.IDiscontinuityPoints();
            return new BHG.PolyCurve();
        }


        public static BHG.Vector ThreePointNormal(BHG.Point A, BHG.Point B, BHG.Point C, bool flip = false)
        {
            BHG.Point U = CartesianSubtraction(B, A);
            BHG.Point V = CartesianSubtraction(C, A);

            double Nx = U.Y * V.Z - U.Z * V.Y;
            double Ny = U.Z * V.X - U.X * V.Z;
            double Nz = U.X * V.Y - U.Y * V.X;

            double magnitude = Math.Sqrt(Math.Pow(Nx, 2) + Math.Pow(Ny, 2) + Math.Pow(Nz, 2));

            if (flip)
            {
                return CartesianDivision(Create.Vector(Nx, Ny, Nz), magnitude);
            }

            return CartesianDivision(Create.Vector(-Nx, -Ny, -Nz), magnitude);
        }


        public static BHG.Vector UnitVector(BHG.Vector A, BHG.Vector B)
        {
            BHG.Vector distanceBetween = CartesianSubtraction(B, A);
            return distanceBetween / Math.Sqrt(CartesianSum(CartesianMultiplication(distanceBetween, distanceBetween)));
        }

        public static BHG.Point UnitVector(BHG.Point A, BHG.Point B)
        {
            BHG.Point distanceBetween = CartesianSubtraction(B, A);
            return distanceBetween / Math.Sqrt(CartesianSum(CartesianMultiplication(distanceBetween, distanceBetween)));
        }


        public static double CartesianSum(BHG.Vector A)
        {
            return A.X + A.Y + A.Z;
        }

        public static double CartesianSum(BHG.Point A)
        {
            return A.X + A.Y + A.Z;
        }


        public static double CartesianProduct(BHG.Vector A)
        {
            return A.X * A.Y * A.Z;
        }

        public static double CartesianProduct(BHG.Point A)
        {
            return A.X * A.Y * A.Z;
        }


        public static BHG.Vector CartesianAddition(BHG.Vector A, BHG.Vector B)
        {
            return Create.Vector(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
        }

        public static BHG.Vector CartesianAddition(BHG.Vector A, double B)
        {
            return Create.Vector(A.X + B, A.Y + B, A.Z + B);
        }

        public static BHG.Point CartesianAddition(BHG.Point A, BHG.Point B)
        {
            return Create.Point(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
        }

        public static BHG.Point CartesianAddition(BHG.Point A, double B)
        {
            return Create.Point(A.X + B, A.Y + B, A.Z + B);
        }


        public static BHG.Vector CartesianSubtraction(BHG.Vector A, BHG.Vector B)
        {
            return Create.Vector(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

        public static BHG.Vector CartesianSubtraction(BHG.Vector A, double B)
        {
            return Create.Vector(A.X - B, A.Y - B, A.Z - B);
        }

        public static BHG.Point CartesianSubtraction(BHG.Point A, BHG.Point B)
        {
            return Create.Point(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

        public static BHG.Point CartesianSubtraction(BHG.Point A, double B)
        {
            return Create.Point(A.X - B, A.Y - B, A.Z - B);
        }


        public static BHG.Vector CartesianMultiplication(BHG.Vector A, BHG.Vector B)
        {
            return Create.Vector(A.X * B.X, A.Y * B.Y, A.Z * B.Z);
        }

        public static BHG.Vector CartesianMultiplication(BHG.Vector A, double B)
        {
            return Create.Vector(A.X * B, A.Y * B, A.Z * B);
        }

        public static BHG.Point CartesianMultiplication(BHG.Point A, BHG.Point B)
        {
            return Create.Point(A.X * B.X, A.Y * B.Y, A.Z * B.Z);
        }

        public static BHG.Point CartesianMultiplication(BHG.Point A, double B)
        {
            return Create.Point(A.X * B, A.Y * B, A.Z * B);
        }


        public static BHG.Vector CartesianDivision(BHG.Vector A, BHG.Vector B)
        {
            return Create.Vector(A.X / B.X, A.Y / B.Y, A.Z / B.Z);
        }

        public static BHG.Vector CartesianDivision(BHG.Vector A, double B)
        {
            return Create.Vector(A.X / B, A.Y / B, A.Z / B);
        }

        public static BHG.Point CartesianDivision(BHG.Point A, BHG.Point B)
        {
            return Create.Point(A.X / B.X, A.Y / B.Y, A.Z / B.Z);
        }

        public static BHG.Point CartesianDivision(BHG.Point A, double B)
        {
            return Create.Point(A.X / B, A.Y / B, A.Z / B);
        }
    }
}
