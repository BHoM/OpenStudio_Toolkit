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
        public static global::OpenStudio.Zone ToOSM(this BHE.Space zone, global::OpenStudio.Zone osmZone)
        {
            osmZone.setName(zone.Name);
            return osmZone;
        }
    }
}