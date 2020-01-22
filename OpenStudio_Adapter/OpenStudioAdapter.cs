using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Data.Requests;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;

namespace BH.Adapter.OpenStudio
{
    public partial class OpenStudioAdapter : BHoMAdapter
    {
        [Description("Produces an OpenStudio Adapter to allow interopability with IDF files and the BHoM. This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status")]
        [Input("idfFilePath", "Path to an IDF File")]
        [Output("adapter", "Adapter to an IDF File")]
        public OpenStudioAdapter(string idfFilePath)
        {
            BH.Engine.Reflection.Compute.RecordWarning("This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status");
            m_IDFFilePath = idfFilePath;

            AdapterIdName = "OpenStudio_Adapter";

            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
        }

        private string m_IDFFilePath;
    }
}