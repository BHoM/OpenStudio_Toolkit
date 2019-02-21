using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Properties;

using BH.Engine.Environment;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Surface ToOSM(this BHE.BuildingElement element, OpenStudio.Model modelReference, OpenStudio.Space osmSpace, Dictionary<string, OpenStudio.Construction> uniqueConstructions, string outsideBoundaryCondition)
        {
            BHP.ElementProperties elementProperties = element.ElementProperties() as BHP.ElementProperties;

            Surface osmElement = new Surface(element.PanelCurve.ToOSM(), modelReference);
            osmElement.setName(element.Name);
            osmElement.setSpace(osmSpace);
            if(outsideBoundaryCondition != "")
                osmElement.setOutsideBoundaryCondition(outsideBoundaryCondition);
            
            BHP.EnvironmentContextProperties envContextProperties = element.EnvironmentContextProperties() as BHP.EnvironmentContextProperties;

            if (elementProperties != null)
            {
                osmElement.setSurfaceType(elementProperties.BuildingElementType.ToOSMSurfaceType());
                osmElement.setConstruction(uniqueConstructions[elementProperties.Construction.UniqueConstructionName()]);
            }

            //Fix curtain wall
            if(elementProperties != null && elementProperties.BuildingElementType == BHE.BuildingElementType.CurtainWall)
            {
                osmElement.setConstruction(uniqueConstructions["CurtainWallReplacementConstruction"]); //No need for construction on a curtain wall as the opening will handle it

                List <BHG.Polyline> newOpeningBounds = new List<BHG.Polyline>();
                if (element.Openings.Count > 0)
                {
                    //This surface already has openings - cut them out of the new opening
                    List<BHG.Polyline> refRegion = element.Openings.Where(y => y.OpeningCurve != null).ToList().Select(z => z.OpeningCurve.ICollapseToPolyline(BHG.Tolerance.Angle)).ToList();
                    newOpeningBounds.AddRange((new List<BHG.Polyline> { element.PanelCurve.ICollapseToPolyline(BHG.Tolerance.Angle) }).BooleanDifference(refRegion, 0.01));
                }
                else
                    newOpeningBounds.Add(element.PanelCurve.ICollapseToPolyline(BHG.Tolerance.Angle));

                BHE.Opening curtainWallOpening = BH.Engine.Environment.Create.Opening(newOpeningBounds);
                //Scale the bounding curve to comply with IDF rules
                BHG.Polyline crv = curtainWallOpening.OpeningCurve.ICollapseToPolyline(BHG.Tolerance.Angle);
                curtainWallOpening.OpeningCurve = crv.Scale(crv.Centre(), BH.Engine.Geometry.Create.Vector(0.95, 0.95, 0.95));

                curtainWallOpening.Name = element.Name;
                BHP.EnvironmentContextProperties curtainWallProperties = new BHP.EnvironmentContextProperties();
                if (envContextProperties != null)
                {
                    curtainWallProperties.ElementID = envContextProperties.ElementID;
                    curtainWallProperties.TypeName = envContextProperties.TypeName;
                }

                BHP.ElementProperties curtainElementProperties = new BHP.ElementProperties();
                if (elementProperties != null)
                {
                    curtainElementProperties.BuildingElementType = BHE.BuildingElementType.CurtainWall;
                    curtainElementProperties.Construction = elementProperties.Construction;
                }

                curtainWallOpening.ExtendedProperties.Add(curtainWallProperties);
                curtainWallOpening.ExtendedProperties.Add(curtainElementProperties);

                element.Openings = new List<BHE.Opening> { curtainWallOpening };
            }

            return osmElement;
        }
    }
}
