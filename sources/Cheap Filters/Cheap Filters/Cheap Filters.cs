using HarmonyLib;

class FilterPatches
{
    [HarmonyPatch(typeof(GasFilterConfig), nameof(GasFilterConfig.CreateBuildingDef))]
    class GasFilter_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 20.0f;
        }
    }

    [HarmonyPatch(typeof(LiquidFilterConfig), nameof(LiquidFilterConfig.CreateBuildingDef))]
    class LiquidFilter_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 20.0f;
        }
    }

    [HarmonyPatch(typeof(SolidFilterConfig), nameof(SolidFilterConfig.CreateBuildingDef))]
    class SolidFilter_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 20.0f;
        }
    }
}