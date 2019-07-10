using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;

using BH.oM.Base;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Physical.Materials;
using BHP = BH.oM.Environment.Fragments;
using BH.Engine.Environment;
using BH.Engine.EnergyPlus;

using BHC = BH.oM.Physical.Constructions;
using BHEM = BH.oM.Environment.MaterialFragments;

namespace BH.Adapter.EnergyPlus
{
    public partial class EnergyPlusAdapter : BHoMAdapter
    {
        protected override bool Create<T>(IEnumerable<T> objects, bool replaceAll = false)
        {
            bool success = true;

            if (typeof(IBHoMObject).IsAssignableFrom(typeof(T)))
            {
                CreateModel(objects as List<IBHoMObject>);
            }

            /*OpenStudio.Model model = new Model();

            if (typeof(IBHoMObject).IsAssignableFrom(typeof(T)))
            {
                List<IBHoMObject> objs = objects.ToList() as List<IBHoMObject>;

                List<BHE.BuildingElement> buildingElements = objs.BuildingElements();

                List<List<BHE.BuildingElement>> elementsAsSpaces = buildingElements.BuildSpaces(buildingElements.UniqueSpaceNames());

                model = CreateModel(elementsAsSpaces, model);
            }

            EnergyPlusForwardTranslator translator = new EnergyPlusForwardTranslator();
            Workspace workspace = translator.translateModel(model);
            IdfFile idf = workspace.toIdfFile();
            idf.save(OpenStudio.OpenStudioUtilitiesCore.toPath(IDFFilePath));
            /*OpenStudio.Model model = new Model();

            EnergyPlusForwardTranslator t2 = new EnergyPlusForwardTranslator();
            Workspace w2 = t2.translateModel(model);
            IdfFile i2 = w2.toIdfFile();


            i2.save(new OpenStudio.Path(OpenStudio.OpenStudioUtilitiesCore.toPath(@"C:\Users\fgreenro\Documents\Repo Code\Test Files & Scripts\BHoM Testing\EnergyPlus_Toolkit\firstTest.idf")), true);
            */
            return success;
        }

        public bool CreateModel(List<IBHoMObject> objects)
        {
            bool success = true;

            OpenStudio.Model model = new Model();
                        
            List<IBHoMObject> objs = objects.ToList() as List<IBHoMObject>;

            List<BHE.Panel> buildingElements = objs.Panels();

            List<List<BHE.Panel>> elementsAsSpaces = buildingElements.ToSpaces();

            model = CreateModel(elementsAsSpaces, model);

            EnergyPlusForwardTranslator translator = new EnergyPlusForwardTranslator();
            Workspace workspace = translator.translateModel(model);
            IdfFile idf = workspace.toIdfFile();
            idf.save(OpenStudio.OpenStudioUtilitiesCore.toPath(IDFFilePath), true); //setting overwrite file true to avoid appending the surfaces to the exisiting idf file

            return success;
        }

        public static OpenStudio.Model CreateModel(List<List<BHE.Panel>> panelsAsSpaces, OpenStudio.Model modelReference)
        {
            List<BHC.Construction> uniqueConstructions = panelsAsSpaces.UniqueConstructions();

            //Create a curtain wall construction
            BHC.Construction curtainWallConstruction = new BHC.Construction();
            curtainWallConstruction.Name = "Curtain Wall Construction Replacement";

            BHC.Layer curtainWallLayer = new BHC.Layer();
            curtainWallLayer.Thickness = 0.1;

            BHM.Material curtainWallMaterial = new BHM.Material();
            curtainWallMaterial.Name = "Curtain Wall Construction Replacement";

            BHEM.SolidMaterial curtainWallMaterialProperties = new BHEM.SolidMaterial();
            curtainWallMaterialProperties.Roughness = BHEM.Roughness.VerySmooth;
            curtainWallMaterialProperties.SpecificHeat = 101;
            curtainWallMaterialProperties.Conductivity = 0.1;
            curtainWallMaterialProperties.EmissivityExternal = 0.1;
            curtainWallMaterialProperties.SolarReflectanceExternal = 0.1;
            curtainWallMaterialProperties.LightReflectanceExternal = 0.1;
            curtainWallMaterialProperties.Density = 0.1;

            curtainWallMaterial.Properties.Add(curtainWallMaterialProperties);
            curtainWallLayer.Material = curtainWallMaterial;
            curtainWallConstruction.Layers.Add(curtainWallLayer);

            Dictionary<string, OpenStudio.Construction> osmConstructions = new Dictionary<string, Construction>();
            foreach(BHC.Construction c in uniqueConstructions)
                osmConstructions.Add(c.UniqueConstructionName(), c.ToOSM(modelReference));

            osmConstructions.Add("CurtainWallReplacementConstruction", curtainWallConstruction.ToOSM(modelReference));

            foreach(List<BHE.Panel> space in panelsAsSpaces)
            {
                ThermalZone osmZone = new ThermalZone(modelReference);
                Space osmSpace = new Space(modelReference);
                osmSpace.setThermalZone(osmZone);

                foreach(BHE.Panel be in space)
                {
                    string conName = be.Construction.UniqueConstructionName();

                    //be.ToOSM(modelReference, osmSpace, (conName == "" ? null : osmConstructions[conName]));
                    Surface host = be.ToOSM(modelReference, osmSpace, osmConstructions, be.OutsideBoundaryCondition(be.AdjacentSpaces(panelsAsSpaces)));

                    foreach (BHE.Opening o in be.Openings)
                    {
                        conName = o.OpeningConstruction.UniqueConstructionName();

                        o.ToOSM(host, (conName == "" ? null : osmConstructions[conName]), modelReference);
                    }
                }
            }

            return modelReference;
        }
    }
}
