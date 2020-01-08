using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using BH.oM.Base;

namespace BH.Adapter.OpenStudio
{
    public partial class OpenStudioAdapter : BHoMAdapter
    {
        protected override IEnumerable<IBHoMObject> Read(Type type, IList indices = null)
        {
            return null;
        }

        public List<IBHoMObject> Read()
        {
            List<IBHoMObject> bhomObjects = new List<IBHoMObject>();

            return bhomObjects;
        }
    }
}
