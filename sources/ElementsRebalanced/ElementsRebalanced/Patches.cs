using HarmonyLib;
using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ElementsRebalanced
{
    public class Patches
    {
        [HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
        public class Db_Initialize_Patch
        {

            public static void Postfix(ElementLoader.ElementEntry entry, Element elem)
            {
                if (entry.elementId.ToString().Equals("SuperCoolant"))
                {
                    //elem.highTemp = 6000f;
                    //elem.thermalConductivity = 1000f;
                }
                if (entry.elementId.ToString().Equals("SuperCoolantGas"))
                {
                    //elem.lowTemp = 6000f;
                }
                if (entry.elementId.ToString().Equals("ViscoGel"))
                {
                    //elem.highTemp = 1000f;
                    //elem.lowTemp = 100f;
                    elem.thermalConductivity = 0.0001f;
                    elem.specificHeatCapacity = 6f;
                }
                if (entry.elementId.ToString().Equals("TempConductorSolid"))
                {
                    //elem.highTemp = 4000f;
                    //elem.thermalConductivity = 300f;
                }
                if (entry.elementId.ToString().Equals("Petroleum"))
                {
                    //elem.highTempTransitionTarget = (SimHashes)Hash.SDBMLower("Methane");
                }

            }
        }
        [HarmonyPatch(typeof(LegacyModMain), "ConfigElements")]
        public class LegacyModMainPatch
        {
            public static void modifyDecor(SimHashes hash, float amount)
            {
                Element elementByHash = ElementLoader.FindElementByHash(hash);
                bool changed = false;
                foreach(var v in elementByHash.attributeModifiers)
                {
                    if (v.AttributeId == "Decor")
                    {
                        v.SetValue(amount);
                        changed = true;
                    }
                }
                if (!changed)
                {
                    AttributeModifier atr = new AttributeModifier("Decor", amount, elementByHash.name, true);
                    elementByHash.attributeModifiers.Add(atr);
                }
            }
            public static void modifyOverheat(SimHashes hash, float amount)
            {

                Element elementByHash = ElementLoader.FindElementByHash(hash);

                bool changed = false;
                foreach (var v in elementByHash.attributeModifiers)
                {
                    if (v.AttributeId == Db.Get().BuildingAttributes.OverheatTemperature.Id)
                    {
                        v.SetValue(amount);
                        changed = true;
                    }
                }
                if (!changed)
                {
                    AttributeModifier atr = new AttributeModifier(Db.Get().BuildingAttributes.OverheatTemperature.Id, amount, elementByHash.name);
                    elementByHash.attributeModifiers.Add(atr);
                }
            }
            public static void Postfix()
            {
                modifyDecor(SimHashes.Cobalt, 0.5f);
                
                //modifyDecor(SimHashes.Gold, 1.0f);

                modifyDecor(SimHashes.Cobaltite, 0.1f);

                modifyOverheat(SimHashes.Wolframite, 50f);
                modifyOverheat(SimHashes.Tungsten, 100f);

                modifyDecor(SimHashes.Ceramic, 1.0f);

                //modifyDecor(SimHashes.TempConductorSolid, 0.5f);
                //modifyOverheat(SimHashes.TempConductorSolid, 5000f);

                modifyDecor(SimHashes.Glass, 0.5f);
            }
        }
    }
}
