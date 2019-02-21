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
        public static OpenStudio.Zone ToOSM(this BHE.Space zone, OpenStudio.Zone osmZone)
        {
            osmZone.setName(zone.Name);
            return osmZone;
        }
    }
}