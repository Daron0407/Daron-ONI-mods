using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStarmapMining
{
    class Patch : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary();
            new POptions().RegisterOptions(this, typeof(Config));
            base.OnLoad(harmony);
            StarmapPatch.harmony_instance = harmony;
        }

        class Methods
        {
            private static bool patched = false;
            public static bool Prefix()
            {
                return true;
            }
            public static void Postfix(ref List<HarvestablePOIConfig.HarvestablePOIParams> __result)
            {
                if (patched)
                {
                    Debug.Log("[ESM] : Unexpected Attempt to patch again?");
                    return;
                }
                patched = true;

                foreach (HarvestablePOIConfig.HarvestablePOIParams harvestable in __result)
                {
                    string id = harvestable.poiType.id;
                    harvestable.poiType.poiCapacityMin *= (float)Config.Instance.multiplier;
                    harvestable.poiType.poiCapacityMax *= (float)Config.Instance.multiplier;
                }
            }
        }


        [HarmonyPatch(typeof(AutoMinerConfig), nameof(AutoMinerConfig.CreateBuildingDef))]
        class StarmapPatch
        {
            public static Harmony harmony_instance;
            private static bool patched = false;

            public static bool Prefix()
            {
                if (!patched)
                {
                    patched = true;
                    var original = typeof(HarvestablePOIConfig).GetMethod("GenerateConfigs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
                    var prefix = typeof(Methods).GetMethod(nameof(Methods.Prefix));
                    var postfix = typeof(Methods).GetMethod(nameof(Methods.Postfix));
                    if (original != null)
                    {
                        harmony_instance.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));
                        Debug.Log("[ESM] : Succesfully Patched");
                    }
                    else
                    {
                        Debug.Log("[ESM] : Patch failed");
                    }
                }
                return true;
            }

        }


    }
}
