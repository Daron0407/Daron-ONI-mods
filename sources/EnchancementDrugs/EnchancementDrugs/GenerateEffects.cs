using HarmonyLib;

namespace EnchancementDrugs
{
    [HarmonyPatch(typeof(Db), nameof(Db.Initialize))]
    public class GenerateEffects
    {
        public static void Postfix(Db __instance)
        {
            __instance.effects.Add(AdvancedRadPillConfig.GetPillEffect());
            __instance.effects.Add(BuffoutConfig.GetPillEffect());
            __instance.effects.Add(CaffeinePillConfig.GetPillEffect());
            __instance.effects.Add(CandyConfig.GetPillEffect());
            __instance.effects.Add(ExperimentalPillConfig.GetPillEffect());
            __instance.effects.Add(MentatsConfig.GetPillEffect());
            __instance.effects.Add(MoodBoosterConfig.GetPillEffect());
            __instance.effects.Add(RadPillConfig.GetPillEffect());
            __instance.effects.Add(RegenrativeSerumConfig.GetPillEffect());
            //__instance.effects.Add(SuperPillConfig.GetPillEffect());s
        }
    }
}
