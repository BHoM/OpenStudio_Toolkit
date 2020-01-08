using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Physical.Materials;
using BHP = BH.oM.Physical.Constructions;

namespace BH.Engine.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.Construction ToOSM(this BHP.Construction construction, global::OpenStudio.Model modelReference)
        {
            global::OpenStudio.Construction osmConstruction = new Construction(modelReference);
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
