using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Building ToOSM(this BHE.Building building, OpenStudio.Building osmBuilding)
        {
            osmBuilding.setName(building.Name);
            osmBuilding.setNorthAxis(building.Latitude);
            //osmBuilding.
            return osmBuilding;
        }
    }
}
