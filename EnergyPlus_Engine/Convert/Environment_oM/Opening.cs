using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHP = BH.oM.Environment.Fragments;

using BH.Engine.Environment;
using BH.Engine.Geometry;

using BHG = BH.oM.Geometry;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.SubSurface ToOSM(this BHE.Opening opening, OpenStudio.Surface hostSurface, OpenStudio.Construction construction, OpenStudio.Model referenceModel)
        {
            Point3dVector openingPts = opening.Polyline().IDiscontinuityPoints().ToOSM();
            SubSurface osmOpening = new SubSurface(openingPts, referenceModel);

            osmOpening.setSubSurfaceType(opening.Type.ToOSMFenestrationType());

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
                osmOpening.setVertices(opening.Polyline().IFlip().ICollapseToPolyline(BHG.Tolerance.Angle).ToOSM());
            }

            return osmOpening;
        }
    }
}
