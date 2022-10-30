﻿using HarmonyLib;

namespace ElementsRebalanced
{
    public class Patches
    {
        [HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
        public class Db_Initialize_Patch
        {
            private static readonly float SuperCoolantLiquidGasTemp = 6000f;
            private static readonly float SuperCoolantThermalConductivity = 200f;

            private static readonly float ViscoGelHighTemp = 1000f;
            private static readonly float ViscoGelLowTemp = 100f;
            private static readonly float ViscoGelThermalConductivity = 0.001f;
            private static readonly float ViscoGelSpecificHeatCapacity = 6f;

            private static readonly float ThermiumHighTemp = 4000f;
            public static void Postfix(ElementLoader.ElementEntry entry, Element elem)
            {
                if (entry.elementId.ToString().Equals("SuperCoolant"))
                {
                    elem.highTemp = SuperCoolantLiquidGasTemp;
                    elem.thermalConductivity = SuperCoolantThermalConductivity;
                }
                if (entry.elementId.ToString().Equals("SuperCoolantGas"))
                {
                    elem.lowTemp = SuperCoolantLiquidGasTemp;
                }
                if (entry.elementId.ToString().Equals("ViscoGel"))
                {
                    elem.highTemp = ViscoGelHighTemp;
                    elem.lowTemp = ViscoGelLowTemp;
                    elem.thermalConductivity = ViscoGelThermalConductivity;
                    elem.specificHeatCapacity = ViscoGelSpecificHeatCapacity;
                }
                if (entry.elementId.ToString().Equals("TempConductorSolid"))
                {
                    elem.highTemp = ThermiumHighTemp;
                }
            }
        }
    }
}
