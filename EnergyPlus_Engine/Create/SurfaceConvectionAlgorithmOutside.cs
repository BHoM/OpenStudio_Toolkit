using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.EnergyPlus;
using BH.Engine.Base;

namespace BH.Engine.EnergyPlus
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create SurfaceConvectionAlgorithmOutside => efault outside surface heat transfer convection algorithm to be used for all zones")]
    //    [Input("algorithm", "SimpleCombined = Combined radiation and convection coefficient using simple ASHRAE model TARP = correlation from models developed by ASHRAE, Walton, and Sparrow et. al. MoWiTT = correlation from measurements by Klems and Yazdanian for smooth surfaces DOE-2 = correlation from measurements by Klems and Yazdanian for rough surfaces AdaptiveConvectionAlgorithm = dynamic selection of correlations based on conditions")]
    //    [Output("surfaceConvectionAlgorithmOutside", "A BH.oM.EnergyPlus.SurfaceConvectionAlgorithmOutside object")]
    //    public static SurfaceConvectionAlgorithmOutside SurfaceConvectionAlgorithmOutside(
    //        SurfaceConvectionAlgorithmOutsideType algorithm = SurfaceConvectionAlgorithmOutsideType.DOE2
    //    )
    //    {
    //        if (algorithm < SurfaceConvectionAlgorithmOutsideType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("SurfaceConvectionAlgorithmOutsideType cannot be Undefined");
    //            return null;
    //        }

    //        return new SurfaceConvectionAlgorithmOutside
    //        {
    //            Algorithm = algorithm,
    //        };
    //    }
    //}
}