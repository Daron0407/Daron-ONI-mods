using HarmonyLib;
using UnityEngine;

namespace Heaters_Expanded
{
    [HarmonyPatch(typeof(SpaceHeaterConfig), nameof(SpaceHeaterConfig.CreateBuildingDef))]
    public class SpaceHeaterConfig_CreateBuildingDef
    {
        public static void Postfix(ref BuildingDef __result)
        {
            __result.ExhaustKilowattsWhenActive = 0f;
            __result.SelfHeatKilowattsWhenActive = Config.Instance.SHheating;

            __result.EnergyConsumptionWhenActive = Config.Instance.SHwattage;
            if (__result.EnergyConsumptionWhenActive.Equals(0f))
            {
                __result.RequiresPowerInput = false;
            }
        }
    }

    [HarmonyPatch(typeof(SpaceHeaterConfig), nameof(SpaceHeaterConfig.ConfigureBuildingTemplate))]
    public class SpaceHeaterConfig_ConfigureBuildingTemplate
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<MinimumOperatingTemperature>();
            go.AddOrGet<AdjustableSpaceHeater>();
        }
    }
}
