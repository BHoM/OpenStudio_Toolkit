using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;

using BH.Engine.Environment;
using BHG = BH.oM.Geometry;
using BH.Engine.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Surface ToOSM(this BHE.Panel panel, OpenStudio.Model modelReference, OpenStudio.Space osmSpace, Dictionary<string, OpenStudio.Construction> uniqueConstructions, string outsideBoundaryCondition)
        {
            Surface osmElement = new Surface(panel.ToPolyline().ToOSM(), modelReference);
            osmElement.setName(panel.Name);
            osmElement.setSpace(osmSpace);
            if(outsideBoundaryCondition != "")
                osmElement.setOutsideBoundaryCondition(outsideBoundaryCondition);

            osmElement.setSurfaceType(panel.Type.ToOSMSurfaceType());
            osmElement.setConstruction(uniqueConstructions[panel.Construction.UniqueConstructionName()]);

            BHP.OriginContextFragment envContextProperties = panel.FindFragment<BHP.OriginContextFragment>(typeof(BHP.OriginContextFragment));

            //Fix curtain wall
            if (panel.Type == BHE.PanelType.CurtainWall)
            {
                osmElement.setConstruction(uniqueConstructions["CurtainWallReplacementConstruction"]); //No need for construction on a curtain wall as the opening will handle it

                List<BHG.Polyline> newOpeningBounds = new List<BHG.Polyline>();
                if (panel.Openings.Count > 0)
                {
                    //This surface already has openings - cut them out of the new opening
                    List<BHG.Polyline> refRegion = panel.Openings.Where(y => y.ToPolyline() != null).ToList().Select(z => z.ToPolyline()).ToList();
                    newOpeningBounds.AddRange((new List<BHG.Polyline> { panel.ToPolyline() }).BooleanDifference(refRegion, 0.01));
                }
                else
                    newOpeningBounds.Add(panel.ToPolyline());

                BHE.Opening curtainWallOpening = BH.Engine.Environment.Create.Opening(externalEdges: BH.Engine.Geometry.Create.PolyCurve(newOpeningBounds).ICollapseToPolyline(BH.oM.Geometry.Tolerance.Angle).ToEdges());
                //Scale the bounding curve to comply with IDF rules
                BHG.Polyline crv = curtainWallOpening.ToPolyline();
                curtainWallOpening.Edges = crv.Scale(crv.Centre(), BH.Engine.Geometry.Create.Vector(0.95, 0.95, 0.95)).ToEdges();

                curtainWallOpening.Name = panel.Name;
                BHP.OriginContextFragment curtainWallProperties = new BHP.OriginContextFragment();
                
                if (envContextProperties != null)
                {
                    curtainWallProperties.ElementID = envContextProperties.ElementID;
                    curtainWallProperties.TypeName = envContextProperties.TypeName;
                }

                curtainWallOpening.Type = BHE.OpeningType.CurtainWall;
                curtainWallOpening.OpeningConstruction = panel.Construction;

                panel.Openings = new List<BHE.Opening> { curtainWallOpening };
            }

            return osmElement;
        }
    }
}
