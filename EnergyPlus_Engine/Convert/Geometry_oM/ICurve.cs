using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHG = BH.oM.Geometry;
using OpenStudio;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static Point3dVector ToOSM(this BHG.ICurve crv)
        {
            return ToOSM(crv as dynamic);
        }
    }
}
