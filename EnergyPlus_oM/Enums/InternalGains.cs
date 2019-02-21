using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.EnergyPlus
{
    public enum ElectricEquipmentDesignLevelCalculationMethodType
    {
        Undefined,
        EquipmentLevel,
        WattsPerArea,
        WattsPerPerson,
    }

    public enum LightsDesignLevelCalculationMethodType
    {
        Undefined,
        LightingLevel,
        WattsPerArea,
        WattsPerPerson,
    }

    public enum NumberOfPeopleCalculationMethodType
    {
        Undefined,
        AreaPerPerson,
        People,
        PeoplePerArea,
    }
}