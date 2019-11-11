using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
//using System.Reflection;
using BH.oM.Data.Requests;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;

namespace BH.Adapter.EnergyPlus
{
    public partial class EnergyPlusAdapter : BHoMAdapter
    {
        [Description("Produces an EnergyPlus Adapter to allow interopability with IDF files and the BHoM. This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status")]
        [Input("idfFilePath", "Path to an IDF File")]
        [Output("adapter", "Adapter to an IDF File")]
        public EnergyPlusAdapter(string idfFilePath)
        {
            BH.Engine.Reflection.Compute.RecordWarning("This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status");
            IDFFilePath = idfFilePath;

            AdapterId = "EnergyPlus_Adapter";
            Config.UseAdapterId = false;        //Set to true when NextId method and id tagging has been implemented
        }

        public override List<IObject> Push(IEnumerable<IObject> objects, String tag = "", Dictionary<String, object> config = null)
        {
            bool success = true;

            //MethodInfo methodInfos = typeof(Enumerable).GetMethod("Cast");
            /*foreach (var typeGroup in objects.GroupBy(x => x.GetType()))
            {
                MethodInfo mInfo = methodInfos.MakeGenericMethod(new[] { typeGroup.Key });
                var list = mInfo.Invoke(typeGroup, new object[] { typeGroup });
                success &= Create(list as dynamic, false);
            }*/

            CreateModel(objects.ToList().ConvertAll(x => (IBHoMObject)x).ToList());

            return success ? objects.ToList() : new List<IObject>();
        }

        public override IEnumerable<object> Pull(IRequest request, Dictionary<string, object> config = null)
        {
            if (request is IRequest)
                return Read();

            return new List<IBHoMObject>();
        }


        private string IDFFilePath { get; set; }
    }
}
