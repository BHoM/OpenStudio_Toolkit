using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Environment.Materials;
using BHP = BH.oM.Environment.Properties;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Construction ToOSM(this BHE.Construction construction, OpenStudio.Model modelReference)
        {
            OpenStudio.Construction osmConstruction = new Construction(modelReference);
            osmConstruction.setName(construction.Name);

            MaterialVector materialLayer = new MaterialVector();
            foreach (BHM.Material material in construction.Materials)
                materialLayer.Add(material.ToOSM(construction.Roughness, modelReference, (construction.ConstructionType == BHE.ConstructionType.Transparent)));

            osmConstruction.setLayers(materialLayer);
            return osmConstruction;
        }
    }
}
