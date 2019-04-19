using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Physical.Properties;
using BHP = BH.oM.Physical.Properties.Construction;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Construction ToOSM(this BHP.Construction construction, OpenStudio.Model modelReference)
        {
            OpenStudio.Construction osmConstruction = new Construction(modelReference);
            osmConstruction.setName(construction.Name);

            MaterialVector materialLayer = new MaterialVector();
            foreach(BHP.Layer layer in construction.Layers)
                materialLayer.Add(layer.Material.ToOSM(modelReference));

            //foreach (BHM.Material material in construction.Materials)
                //materialLayer.Add(material.ToOSM(construction.Roughness, modelReference, (construction.ConstructionType == BHE.ConstructionType.Transparent)));

            osmConstruction.setLayers(materialLayer);
            return osmConstruction;
        }
    }
}
