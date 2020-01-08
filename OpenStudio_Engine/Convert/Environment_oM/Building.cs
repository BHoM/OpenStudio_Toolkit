using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;

namespace BH.Engine.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.Building ToOSM(this BHE.Building building, global::OpenStudio.Building osmBuilding)
        {
            osmBuilding.setName(building.Name);
            osmBuilding.setNorthAxis(building.Latitude);
            //osmBuilding.
            return osmBuilding;
        }
    }
}
