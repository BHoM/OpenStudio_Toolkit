using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static Point3dVector ToOSM(this BHG.PolyCurve pCurve)
        {
            return pCurve.ICollapseToPolyline(BHG.Tolerance.Angle).ToOSM();
        }
    }
}
