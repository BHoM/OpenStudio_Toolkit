using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.Engine.Base;
using BH.Engine.Geometry;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.Engine.Radiance;

namespace BH.Engine.EnergyPlus
{
    public static partial class Modify
    {
        [Description ("Reduces the area of the opening(s) if the total area of the opening(s) is equal to the area of the panel itself. Returns an Environment Panel object.")]
        [Input ("panel", "an Environment Panel object")]
        [Output("panel", "an Environment Panel object")]
        public static BHE.Panel OffsetOpening(BHE.Panel panel)
        {
            BHE.Panel energyPlusPanel = new BHE.Panel();            

            // checking if there are openings
            int nropenings = panel.Openings.Count();

            if (nropenings == 0)
            {
                energyPlusPanel = panel;                
            }
            
            else
            {                                                
                //OpeningArea                
                List<BHE.Opening> openings = panel.Openings;
                List<double> openingAreas = new List<double>();
                List<PolyCurve> openingPolyCurves = new List<PolyCurve>();
                foreach (BHE.Opening opening in panel.Openings)
                {
                    List<ICurve> openingCrvs = new List<ICurve>();
                    foreach (BHE.Edge edge in opening.Edges)
                    {
                        openingCrvs.Add(edge.Curve);
                    }
                    PolyCurve openingOutline = BH.Engine.Geometry.Create.PolyCurve(openingCrvs);
                    double openingArea = openingOutline.Area();
                    openingAreas.Add(openingArea);
                    openingPolyCurves.Add(openingOutline);
                }
                double totalOpeningArea = openingAreas.Sum();

                //PanelArea
                List<ICurve> panelCrvs = new List<ICurve>();
                foreach (BHE.Edge edge in panel.ExternalEdges)
                {
                    panelCrvs.Add(edge.Curve);
                }
                PolyCurve panelOutline = BH.Engine.Geometry.Create.PolyCurve(panelCrvs);
                double panelArea = panelOutline.Area();

                //Comparing the total opening area to the panel area, if equal: reduce the area of the opening(s).

                if (totalOpeningArea.Equals(panelArea) == false)
                {
                    energyPlusPanel = panel;
                }
                    
                if (totalOpeningArea.Equals(panelArea) == true)
                {                                        
                    List<BH.oM.Geometry.Polyline> openingPolylines = new List<BH.oM.Geometry.Polyline>();
                    List<List<BH.oM.Geometry.Polyline>> offsetPolylines = new List<List<BH.oM.Geometry.Polyline>>();
                    List<BHE.Opening> newOpenings = new List<BHE.Opening>();
                    double distance = new double();
                    distance = -0.01;
                    panel.Openings.Clear();



                    foreach (BH.oM.Geometry.PolyCurve openingPolyCurve in openingPolyCurves)
                    {                        
                        List<BH.oM.Geometry.Point> polyPoints = openingPolyCurve.IDiscontinuityPoints();
                        BH.oM.Geometry.Polyline openingPolyLine = BH.Engine.Geometry.Create.Polyline(polyPoints);
                        List<BH.oM.Geometry.Polyline> offsetPolyline = BH.Engine.Radiance.Compute.Offset(openingPolyLine, distance);
                        List<BHE.Edge> edges = new List<BHE.Edge>();
                        
                        foreach (BH.oM.Geometry.Polyline pline in offsetPolyline)
                        {
                            BHE.Edge edge = BH.Engine.Environment.Create.Edge(pline);
                            edges.Add(edge);
                        }
                        BHE.Opening newOpening = BH.Engine.Environment.Create.Opening("name", edges);
                        panel.Openings.Add(newOpening);                        
                    }
                    energyPlusPanel = panel;
                }
            }
            return energyPlusPanel;            
        }
    }
}


