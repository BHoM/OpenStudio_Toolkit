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

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Physical.Materials;
using BHP = BH.oM.Environment.Fragments;
using BHEM = BH.oM.Environment.MaterialFragments;

using BH.Engine.Environment;

namespace BH.Engine.OpenStudio
{
    public static partial class Convert
    {
        public static global::OpenStudio.Material ToOSM(this BHM.Material material, global::OpenStudio.Model modelReference, double thickness = 0.0, bool isGlazed = false)
        {
            List<BHM.IMaterialProperties> environmentMaterialProperties = material.Properties.Where(x => x is BHEM.IEnvironmentMaterial).ToList();
            if (environmentMaterialProperties.Count > 0)
            {
                if (environmentMaterialProperties[0].GetType() == typeof(BHEM.SolidMaterial))
                {
                    if (material.IsTransparent())
                        return material.ToOSMGlazing(thickness, modelReference);
                    else
                        return material.ToOSMOpaqueMaterial((environmentMaterialProperties[0] as BHEM.IEnvironmentMaterial).Roughness, thickness, modelReference);
                }
                else if (environmentMaterialProperties[0].GetType() == typeof(BHEM.GasMaterial))
                {
                    if (isGlazed)
                        return material.ToOSMGas(thickness, modelReference);
                    else
                        return material.ToOSMAirGap(modelReference);
                }
            }

            return null;
        }

        public static global::OpenStudio.OpaqueMaterial ToOSMOpaqueMaterial(this BHM.Material material, BHEM.Roughness roughness, double thickness, global::OpenStudio.Model modelReference)
        {
            BHEM.SolidMaterial matProp = material.Properties.Where(x => x.GetType() == typeof(BHEM.SolidMaterial)).FirstOrDefault() as BHEM.SolidMaterial;

            StandardOpaqueMaterial osmMaterial = new StandardOpaqueMaterial(modelReference);
            osmMaterial.setName(material.Name);
            osmMaterial.setRoughness(roughness.ToOSM());
            osmMaterial.setThickness(thickness);

            if (matProp != null)
            {
                osmMaterial.setConductivity(matProp.Conductivity);
                osmMaterial.setDensity(matProp.Density);
                osmMaterial.setSpecificHeat(matProp.SpecificHeat);
                osmMaterial.setThermalAbsorptance(1 - matProp.EmissivityExternal); //ToDo Review for external and internal as appropriate at some point
                osmMaterial.setSolarAbsorptance(1 - matProp.SolarReflectanceExternal); //ToDo Review for external and internal as appropriate at some point
                osmMaterial.setVisibleAbsorptance(1 - matProp.LightReflectanceExternal); //ToDo Review for external and internal as appropriate at some point
            }

            return osmMaterial;
        }

        public static global::OpenStudio.AirGap ToOSMAirGap(this BHM.Material material, global::OpenStudio.Model modelReference)
        {
            AirGap airGap = new AirGap(modelReference);
            airGap.setName(material.Name);

            if(material.Properties.Where(x => x is BHEM.IEnvironmentMaterial).FirstOrDefault() != null)
                airGap.setThermalConductivity((material.Properties.Where(x => x is BHEM.IEnvironmentMaterial).FirstOrDefault() as BHEM.IEnvironmentMaterial).Conductivity);

            return airGap;
        }

        public static global::OpenStudio.StandardGlazing ToOSMGlazing(this BHM.Material material, double thickness, global::OpenStudio.Model modelReference)
        {
            BHEM.SolidMaterial matProp = material.Properties.Where(x => x.GetType() == typeof(BHEM.SolidMaterial)).FirstOrDefault() as BHEM.SolidMaterial;

            StandardGlazing glazing = new StandardGlazing(modelReference);

            //ToDo: Front and back side checks and inclusion when required - issue raised
            glazing.setName(material.Name);
            glazing.setOpticalDataType("SpectralAverage");
            glazing.setThickness(thickness);
            glazing.setSolarTransmittance(matProp.SolarTransmittance);
            glazing.setFrontSideSolarReflectanceatNormalIncidence(0);
            glazing.setBackSideSolarReflectanceatNormalIncidence(0);
            glazing.setVisibleTransmittance(matProp.LightTransmittance);
            glazing.setFrontSideVisibleReflectanceatNormalIncidence(0);
            glazing.setBackSideVisibleReflectanceatNormalIncidence(0);
            //ToDo: Figure out infrared transmittance if required
            glazing.setFrontSideInfraredHemisphericalEmissivity(0);
            glazing.setBackSideInfraredHemisphericalEmissivity(0);
            glazing.setConductivity(matProp.Conductivity);
            glazing.setSolarDiffusing(false);

            return glazing;
        }

        public static global::OpenStudio.Gas ToOSMGas(this BHM.Material material, double thickness, global::OpenStudio.Model modelReference)
        {
            BHEM.GasMaterial matProp = material.Properties.Where(x => x.GetType() == typeof(BHEM.GasMaterial)).FirstOrDefault() as BHEM.GasMaterial;

            Gas gas = new Gas(modelReference);

            gas.setName(material.Name);
            gas.setThickness(thickness);
            gas.setGasType(matProp.Gas.ToOSM());

            return gas;
        }
    }
}
