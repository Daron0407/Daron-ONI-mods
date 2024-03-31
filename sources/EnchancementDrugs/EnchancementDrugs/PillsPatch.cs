using HarmonyLib;
using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnchancementDrugs
{
    public class PillsPatch
    {
        [HarmonyPatch(typeof(MedicinalPillWorkable), nameof(MedicinalPillWorkable.CanBeTakenBy))]
        public class Patch
        {
            public static void Postfix(ref bool __result, ref MedicinalPill ___pill, GameObject consumer)
            {
                if (___pill.info.id == MoodBoosterConfig.ID)
                {
                    if (MoodBoosterConfig.condition.checkCondition(___pill, consumer))
                    {
                        return;
                    }
                    __result = false;
                }

                if (___pill.info.id == CaffeinePillConfig.ID)
                {
                    if (CaffeinePillConfig.condition.checkCondition(___pill, consumer))
                    {
                        return;
                    }
                    __result = false;
                }
                if (___pill.info.id == RadPillConfig.ID)
                {
                    if (RadPillConfig.condition.checkCondition(___pill, consumer))
                    {
                        return;
                    }
                    __result = false;
                }
                if (___pill.info.id == AdvancedRadPillConfig.ID)
                {
                    if (AdvancedRadPillConfig.condition.checkCondition(___pill, consumer))
                    {
                        return;
                    }
                    __result = false;
                }

            }
        }
    }
}
