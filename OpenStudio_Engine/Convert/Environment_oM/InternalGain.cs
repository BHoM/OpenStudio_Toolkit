/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapters.OpenStudio;
using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BH.oM.Environment.SpaceCriteria;
using BH.oM.Environment.Fragments;
using System.ComponentModel;

using BH.oM.Reflection.Attributes;
using BH.Engine.Base;

namespace BH.Engine.Adapters.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.ScheduleTypeLimits ToOSMScheduleTypeLimits(global::OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleTypeLimits ScheduleTypeLimitsAlwaysOn = new ScheduleTypeLimits(modelReference);
            ScheduleTypeLimitsAlwaysOn.setNumericType("Discrete");
            ScheduleTypeLimitsAlwaysOn.setUnitType("Dimensionless");
            ScheduleTypeLimitsAlwaysOn.setLowerLimitValue(0);
            ScheduleTypeLimitsAlwaysOn.setUpperLimitValue(1);
            return ScheduleTypeLimitsAlwaysOn;
        }

        public static global::OpenStudio.ScheduleTypeLimits ToOSMScheduleTypeLimitsActivity(global::OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleTypeLimits ScheduleTypeLimitsActivity = new ScheduleTypeLimits(modelReference);
            ScheduleTypeLimitsActivity.setNumericType("Continuous");
            ScheduleTypeLimitsActivity.setUnitType("ActivityLevel");
            ScheduleTypeLimitsActivity.setLowerLimitValue(0);
            ScheduleTypeLimitsActivity.setUpperLimitValue(1000);
            return ScheduleTypeLimitsActivity;
        }

        public static global::OpenStudio.ScheduleConstant ToOSMScheduleConstantsAlwaysOn(global::OpenStudio.Model modelReference)
        {
            // TODO: Convert from BH.oM Profiles to OpenStudio profiles rather than using these fixed/constant profiles!
            ScheduleConstant ScheduleConstantsAlwaysOn = new ScheduleConstant(modelReference);
            ScheduleConstantsAlwaysOn.setScheduleTypeLimits(ToOSMScheduleTypeLimits(modelReference));
            ScheduleConstantsAlwaysOn.setValue(1);
            return ScheduleConstantsAlwaysOn;
        }

        public static global::OpenStudio.ScheduleConstant ToOSMScheduleConstantActivity(global::OpenStudio.Model modelReference)
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

        public static global::OpenStudio.People ToOSMPeopleGain(this BH.oM.Environment.SpaceCriteria.People peopleGain, global::OpenStudio.Model modelReference, global::OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            global::OpenStudio.ScheduleConstant activitySchedule = ToOSMScheduleConstantActivity(modelReference);
            global::OpenStudio.ScheduleConstant occupancySchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

            PeopleDefinition PeopleDefinition = new PeopleDefinition(modelReference);
            
            // TODO:Check the method being used to define the number of poeple within the space

            PeopleDefinition.setPeopleperSpaceFloorArea(peopleGain.Sensible);

            global::OpenStudio.People osPeopleGain = new global::OpenStudio.People(PeopleDefinition);
            osPeopleGain.setNumberofPeopleSchedule(occupancySchedule);
            osPeopleGain.setActivityLevelSchedule(activitySchedule);
            osPeopleGain.setSpace(space);
            return osPeopleGain;
        }

        public static global::OpenStudio.Lights ToOSMLightingGain(this BH.oM.Environment.SpaceCriteria.Lighting lightGain, global::OpenStudio.Model modelReference, global::OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            global::OpenStudio.ScheduleConstant lightingSchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

            LightsDefinition LightsDefinition = new LightsDefinition(modelReference);

            LightsDefinition.setLightingLevel(lightGain.Sensible);
            // TODO: Include additional methods to calculate lighting load here based on alternative metrics
            Lights lightingGain = new Lights(LightsDefinition);
            lightingGain.setSpace(space);
            lightingGain.setSchedule(lightingSchedule);
            return lightingGain;
        }

        public static global::OpenStudio.ElectricEquipment ToOSMEquipmentGain(this BH.oM.Environment.SpaceCriteria.Equipment equipGain, global::OpenStudio.Model modelReference, global::OpenStudio.Space space)
        {
            // TODO: remove static instance below for input of profile object instead!
            global::OpenStudio.ScheduleConstant equipmentSchedule = ToOSMScheduleConstantsAlwaysOn(modelReference);

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
