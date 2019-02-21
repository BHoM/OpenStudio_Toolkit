using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.oM.EnergyPlus;
using BH.Engine.Base;

namespace BH.Engine.EnergyPlus
{
    //public static partial class Create
    //{
    //    [Description("BH.Engine.EnergyPlus.Create Timestep => Specifies the basic timestep for the simulation. The value entered here is also known as the Zone Timestep.This is used in the Zone Heat Balance Model calculation as the driving timestep for heat transfer and load calculations.")]
    //    [Input("NumberofTimestepsperHour", "Number in hour: normal validity 4 to 60: 6 suggested Must be evenly divisible into 60 Allowable values include 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, and 60 Normal 6 is minimum as lower values may cause inaccuracies A minimum value of 20 is suggested for both ConductionFiniteDifference and CombinedHeatAndMoistureFiniteElement surface heat balance algorithms A minimum of 12 is suggested for simulations involving a Vegetated Roof ")]
    //    [Output("timestep", "A BH.oM.EnergyPlus.Timestep object")]
    //    public static Timestep Timestep(
    //        int numberOfTimeStepsPerHour = 6
    //    )
    //    {
    //        if (numberOfTimeStepsPerHour > 60 || numberOfTimeStepsPerHour < 4)
    //        {
    //            BH.Engine.Reflection.Compute.RecordError("numberOfTimeStepsPerHour should be 4 to 60");
    //            return null;
    //        }

    //        return new Timestep
    //        {
    //            NumberOfTimeStepsPerHour = numberOfTimeStepsPerHour,
    //        };
    //    }
    //}
}