/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Data.Requests;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using System.IO;

namespace BH.Adapter.OpenStudio
{
    public partial class OpenStudioAdapter : BHoMAdapter
    {
        [Description("Produces an OpenStudio Adapter to allow interopability with IDF files and the BHoM. This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status")]
        [Input("fileSettings", "Input file settings to get the path to an IDF File")]
        [Output("adapter", "Adapter to an IDF File")]
        public OpenStudioAdapter(BH.oM.Adapter.FileSettings fileSettings)
        {
            BH.Engine.Reflection.Compute.RecordWarning("This adapter is under development. Its use is not yet sanctioned for project work. You use this at your own risk. Check the GitHub repo for the latest version and updates on development status");
            m_IDFFilePath = fileSettings;

            if (!Path.HasExtension(fileSettings.FileName) || Path.GetExtension(fileSettings.FileName) != ".idf")
            {
                BH.Engine.Reflection.Compute.RecordError("File name must contain a file extension");
            }

            AdapterIdName = "OpenStudio_Adapter";

            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
        }

        private BH.oM.Adapter.FileSettings m_IDFFilePath { get; set; } = null;
    }
}


