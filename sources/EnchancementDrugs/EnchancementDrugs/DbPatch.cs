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
            __instance.effects.Add(new SuperPillConfig.SuperPillEffect().effect);
        }
    }
}
