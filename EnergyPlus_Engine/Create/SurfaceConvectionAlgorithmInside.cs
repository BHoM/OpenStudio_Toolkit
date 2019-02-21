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
    //    [Description("BH.Engine.EnergyPlus.Create SurfaceConvectionAlgorithmInside => Default indoor surface heat transfer convection algorithm to be used for all zones")]
    //    [Input("algorithm", "Simple = constant value natural convection (ASHRAE) TARP = variable natural convection based on temperature difference (ASHRAE, Walton) CeilingDiffuser = ACH-based forced and mixed convection correlations for ceiling diffuser configuration with simple natural convection limit AdaptiveConvectionAlgorithm = dynamic selection of convection models based on conditions")]
    //    [Output("surfaceConvectionAlgorithmInside", "A BH.oM.EnergyPlus.SurfaceConvectionAlgorithmInside object")]
    //    public static SurfaceConvectionAlgorithmInside SurfaceConvectionAlgorithmInside(
    //        SurfaceConvectionAlgorithmInsideType algorithm = SurfaceConvectionAlgorithmInsideType.TARP
    //    )
    //    {
    //        if (algorithm < SurfaceConvectionAlgorithmInsideType.Undefined)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("SurfaceConvectionAlgorithmInsideType cannot be Undefined");
    //            return null;
    //        }

    //        return new SurfaceConvectionAlgorithmInside
    //        {
    //            Algorithm = algorithm,
    //        };
    //    }
    //}
}