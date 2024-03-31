using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchancementDrugs
{
    [HarmonyPatch(typeof(Db), nameof(Db.Initialize))]
    public class DbPatch
    {
        public static void Postfix(Db __instance)
        {
            //__instance.effects.Add(new SuperPillConfig.PillEffect().effect);
            __instance.effects.Add(new BuffoutConfig.PillEffect().effect);
            __instance.effects.Add(new MoodBoosterConfig.PillEffect().effect);
            __instance.effects.Add(new SugarConfig.PillEffect().effect);
            __instance.effects.Add(new CaffeinePillConfig.PillEffect().effect);
            __instance.effects.Add(new RadPillConfig.PillEffect().effect);
            __instance.effects.Add(new AdvancedRadPillConfig.PillEffect().effect);
            __instance.effects.Add(new MentatsConfig.PillEffect().effect);
            __instance.effects.Add(new ExperimentalPillConfig.PillEffect().effect);
        }
    }
}
