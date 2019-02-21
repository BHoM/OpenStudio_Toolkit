using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenStudio;
using BHE = BH.oM.Environment.Elements;
using BHM = BH.oM.Environment.Materials;
using BHP = BH.oM.Environment.Properties;

namespace BH.Engine.EnergyPlus
{
    public static partial class Convert
    {
        public static OpenStudio.Material ToOSM(this BHM.Material material, BHE.ConstructionRoughness roughness, OpenStudio.Model modelReference, bool isGlazed = false)
        {
            switch(material.MaterialType)
            {
                case BHE.MaterialType.Opaque:
                    return material.ToOSMOpaqueMaterial(roughness, modelReference);
                case BHE.MaterialType.Transparent:
                    return material.ToOSMGlazing(modelReference);
                case BHE.MaterialType.Gas:
                    if (isGlazed)
                        return material.ToOSMGas(modelReference);
                    else
                        return material.ToOSMAirGap(modelReference);
                default:
                    return null;
            }
        }

        public static OpenStudio.OpaqueMaterial ToOSMOpaqueMaterial(this BHM.Material material, BHE.ConstructionRoughness roughness, OpenStudio.Model modelReference)
        {
            BHP.MaterialPropertiesOpaque matProp = material.MaterialProperties as BHP.MaterialPropertiesOpaque;

            StandardOpaqueMaterial osmMaterial = new StandardOpaqueMaterial(modelReference);
            osmMaterial.setName(material.Name);
            osmMaterial.setRoughness(roughness.ToOSM());
            osmMaterial.setThickness(material.Thickness);

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

        public static OpenStudio.AirGap ToOSMAirGap(this BHM.Material material, OpenStudio.Model modelReference)
        {
            AirGap airGap = new AirGap(modelReference);
            airGap.setName(material.Name);

            if(material.MaterialProperties != null)
                airGap.setThermalConductivity(material.MaterialProperties.Conductivity);

            return airGap;
        }

        public static OpenStudio.StandardGlazing ToOSMGlazing(this BHM.Material material, OpenStudio.Model modelReference)
        {
            BHP.MaterialPropertiesTransparent matProp = material.MaterialProperties as BHP.MaterialPropertiesTransparent;

            StandardGlazing glazing = new StandardGlazing(modelReference);

            //ToDo: Front and back side checks and inclusion when required - issue raised
            glazing.setName(material.Name);
            glazing.setOpticalDataType("SpectralAverage");
            glazing.setThickness(material.Thickness);
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

        public static OpenStudio.Gas ToOSMGas(this BHM.Material material, OpenStudio.Model modelReference)
        {
            BHP.MaterialPropertiesGas matProp = material.MaterialProperties as BHP.MaterialPropertiesGas;

            Gas gas = new Gas(modelReference);

            gas.setName(material.Name);
            gas.setThickness(material.Thickness);
            gas.setGasType(matProp.GasType.ToOSM());

            return gas;
        }
    }
}
