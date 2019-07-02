using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.EnergyPlus;
using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Environment.Gains;
using BH.oM.Environment.Fragments;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.Engine.Base;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.ScheduleTypeLimits ToOSMScheduleTypeLimits(OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleTypeLimits ScheduleTypeLimitsAlwaysOn = new ScheduleTypeLimits(modelReference);
            ScheduleTypeLimitsAlwaysOn.setNumericType("Discrete");
            ScheduleTypeLimitsAlwaysOn.setUnitType("Dimensionless");
            ScheduleTypeLimitsAlwaysOn.setLowerLimitValue(0);
            ScheduleTypeLimitsAlwaysOn.setUpperLimitValue(1);
            return ScheduleTypeLimitsAlwaysOn;
        }

        public static OpenStudio.ScheduleTypeLimits ToOSMScheduleTypeLimitsActivity(OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleTypeLimits ScheduleTypeLimitsActivity = new ScheduleTypeLimits(modelReference);
            ScheduleTypeLimitsActivity.setNumericType("Continuous");
            ScheduleTypeLimitsActivity.setUnitType("ActivityLevel");
            ScheduleTypeLimitsActivity.setLowerLimitValue(0);
            ScheduleTypeLimitsActivity.setUpperLimitValue(1000);
            return ScheduleTypeLimitsActivity;
        }

        public static OpenStudio.ScheduleConstant ToOSMScheduleConstantsAlwaysOn(OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleConstant ScheduleConstantsAlwaysOn = new ScheduleConstant(modelReference);
            ScheduleConstantsAlwaysOn.setScheduleTypeLimits(ToOSMScheduleTypeLimits(modelReference));
            ScheduleConstantsAlwaysOn.setValue(1);
            return ScheduleConstantsAlwaysOn;
        }

        public static OpenStudio.ScheduleConstant ToOSMScheduleConstantActivity(OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleConstant ScheduleConstantActivity = new ScheduleConstant(modelReference);
            ScheduleConstantActivity.setScheduleTypeLimits(ToOSMScheduleTypeLimitsActivity(modelReference));
            ScheduleConstantActivity.setValue(70);
            return ScheduleConstantActivity;
        }

        //[Description("BH.Engine.EnergyPlus.Convert ToOSM => gets Internal gains from BH.oM.Environment.Elements.InternalGain")]
        //[Input("InternalGain", "BHoM InternalGain")]
        //[Output("EnergyPlus InternalGain")]

        public static OpenStudio.People ToOSMPeopleGain(this BH.oM.Environment.Gains.People peopleGain, OpenStudio.Model modelReference, OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            OpenStudio.ScheduleConstant activitySchedule = ToOSMScheduleConstantActivity(modelReference);
            OpenStudio.ScheduleConstant occupancySchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

            PeopleDefinition PeopleDefinition = new PeopleDefinition(modelReference);
            
            // TODO:Check the method being used to define the number of poeple within the space

            PeopleDefinition.setPeopleperSpaceFloorArea(peopleGain.Sensible);

            OpenStudio.People osPeopleGain = new OpenStudio.People(PeopleDefinition);
            osPeopleGain.setNumberofPeopleSchedule(occupancySchedule);
            osPeopleGain.setActivityLevelSchedule(activitySchedule);
            osPeopleGain.setSpace(space);
            return osPeopleGain;
        }

        public static OpenStudio.Lights ToOSMLightingGain(this BH.oM.Environment.Gains.Lighting lightGain, OpenStudio.Model modelReference, OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            OpenStudio.ScheduleConstant lightingSchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

            LightsDefinition LightsDefinition = new LightsDefinition(modelReference);

            LightsDefinition.setLightingLevel(lightGain.Sensible);
            // TODO: Include additional methods to calculate lighting load here based on alternative metrics
            Lights lightingGain = new Lights(LightsDefinition);
            lightingGain.setSpace(space);
            lightingGain.setSchedule(lightingSchedule);
            return lightingGain;
        }

        public static OpenStudio.ElectricEquipment ToOSMEquipmentGain(this BH.oM.Environment.Gains.Equipment equipGain, OpenStudio.Model modelReference, OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            OpenStudio.ScheduleConstant equipmentSchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

            ElectricEquipmentDefinition EquipmentDefinition = new ElectricEquipmentDefinition(modelReference);

            EquipmentDefinition.setDesignLevel(equipGain.Sensible);
            // TODO: Include additional methods to calculate equipment load here based on alternative metrics
            ElectricEquipment equipmentGain = new ElectricEquipment(EquipmentDefinition);
            equipmentGain.setSpace(space);
            equipmentGain.setSchedule(equipmentSchedule);
            return equipmentGain;
        }
    }
}
