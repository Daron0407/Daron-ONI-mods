using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EndlessStarmapMining
{
    class StarmapPatch : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary();
            new POptions().RegisterOptions(this, typeof(Config));
            base.OnLoad(harmony);
            StarmapPatchInternal.harmony_instance = harmony;
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
                    harvestable.poiType.poiCapacityMin *= (float)Config.Instance.Massmultiplier;
                    harvestable.poiType.poiCapacityMax *= (float)Config.Instance.Massmultiplier;
                }
            }
        }


        [HarmonyPatch(typeof(AutoMinerConfig), nameof(AutoMinerConfig.CreateBuildingDef))]
        class StarmapPatchInternal
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

        [HarmonyPatch(typeof(NoseconeHarvestConfig), nameof(NoseconeHarvestConfig.ConfigureBuildingTemplate))]
        class NoseconeHarvestConfigPatch
        {
            public static void Postfix(ref GameObject go, ref Tag prefab_tag)
            {
                Storage storage = go.GetComponent<Storage>();
                storage.capacityKg = 1000f * Config.Instance.drillconeMultiplier;
                ManualDeliveryKG manualDeliveryKg = go.GetComponent<ManualDeliveryKG>();
                manualDeliveryKg.MinimumMass = storage.capacityKg;
                manualDeliveryKg.capacity = storage.capacityKg;
                manualDeliveryKg.refillMass = storage.capacityKg;
            }
        }


    }
}
