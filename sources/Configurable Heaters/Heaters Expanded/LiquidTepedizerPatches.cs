using HarmonyLib;
using UnityEngine;

namespace Heaters_Expanded
{
    [HarmonyPatch(typeof(LiquidHeaterConfig), nameof(LiquidHeaterConfig.CreateBuildingDef))]
    public class LiquidHeaterConfig_CreateBuildingDef
    {
        public static void Postfix(ref BuildingDef __result)
        {
            __result.ExhaustKilowattsWhenActive = 0f;
            __result.SelfHeatKilowattsWhenActive = Config.Instance.LTheating;

            __result.EnergyConsumptionWhenActive = Config.Instance.LTwattage;
            if (__result.EnergyConsumptionWhenActive.Equals(0f))
            {
                __result.RequiresPowerInput = false;
            }
        }
    }

    [HarmonyPatch(typeof(LiquidHeaterConfig), nameof(LiquidHeaterConfig.ConfigureBuildingTemplate))]
    public class LiquidHeaterConfig_ConfigureBuildingTemplate
    {
        public static void Postfix(GameObject go, TabHeaderIcon prefab_tag)
        {
            go.GetComponent<SpaceHeater>().targetTemperature = globals.temperature(Config.Instance.LTheating);
        }
    }
}
