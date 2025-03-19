using HarmonyLib;

namespace Speedrunning
{
    public class BetterGenerators
    {
        [HarmonyPatch(typeof(ManualGeneratorConfig), nameof(ManualGeneratorConfig.CreateBuildingDef))]
        public class Manual
        {
            static void Postfix(BuildingDef __result)
            {
                __result.GeneratorWattageRating = 50f * 1000f;
            }
        }
    }
}
