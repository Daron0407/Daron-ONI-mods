using HarmonyLib;
using UnityEngine;

namespace EnchancementDrugs
{
    [HarmonyPatch(typeof(MedicinalPillWorkable), nameof(MedicinalPillWorkable.CanBeTakenBy))]
    public class CanBeTakenByPatch
    {
        public static void Postfix(ref bool __result, ref MedicinalPill ___pill, GameObject consumer)
        {
            switch (___pill.info.id)
            {
                case MoodBoosterConfig.ID:
                    __result = MoodBoosterConfig.CheckConditions(consumer);
                    return;
                case CaffeinePillConfig.ID:
                    __result = CaffeinePillConfig.CheckConditions(consumer);
                    return;
                    case RadPillConfig.ID:
                    __result = RadPillConfig.CheckConditions(consumer);
                    return;
                case AdvancedRadPillConfig.ID:
                    __result = AdvancedRadPillConfig.CheckConditions(consumer);
                    return;
                default:
                    __result = true;
                    return;
            }
        }
    }
}
