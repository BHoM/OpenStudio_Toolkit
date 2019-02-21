using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Properties;

using BH.Engine.Environment;
using BH.Engine.Geometry;

using BHG = BH.oM.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.SubSurface ToOSM(this BHE.Opening opening, OpenStudio.Surface hostSurface, OpenStudio.Construction construction, OpenStudio.Model referenceModel)
        {
            Point3dVector openingPts = opening.OpeningCurve.IDiscontinuityPoints().ToOSM();
            SubSurface osmOpening = new SubSurface(openingPts, referenceModel);

            BHP.ElementProperties openingProps = opening.ElementProperties() as BHP.ElementProperties;
            if(openingProps != null)
                osmOpening.setSubSurfaceType(openingProps.BuildingElementType.ToOSMFenestrationType());

            osmOpening.setSurface(hostSurface);
            osmOpening.setConstruction(construction);

            double oA = osmOpening.azimuth();
            double hA = hostSurface.azimuth();
            
            if(oA != hA)
            {
                osmOpening.setName("NOT EQUAL AZIMUTH - " + osmOpening.name());
            }            

            if(osmOpening.azimuth() < (hostSurface.azimuth() -1) || osmOpening.azimuth() > (hostSurface.azimuth() + 1))
            {
                osmOpening.setVertices(opening.OpeningCurve.IFlip().ICollapseToPolyline(BHG.Tolerance.Angle).ToOSM());
            }

            return osmOpening;
        }
    }
}
