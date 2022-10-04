using HarmonyLib;
using KMod;
using System.Collections.Generic;
using UnityEngine;

namespace StarMapRebalanced
{

    class Methods
    {
        private static readonly float poiCapacityMultiplier = 10.0f;
        private static bool patched = false;
        public static bool Prefix()
        {
            return true;
        }
        public static void Postfix(ref List<HarvestablePOIConfig.HarvestablePOIParams> __result)
        {
            if (patched)
            {
                Debug.Log("[Starmap Rebalanced] : Unexpected Attempt to patch again?");
                return;
            }
            patched = true;
            Debug.Log("[Starmap Rebalanced] : Inserting own definitions");
            StarMapRebalanced.StarmapDict.initialize();


            foreach (HarvestablePOIConfig.HarvestablePOIParams harvestable in __result)
            {
                string id = harvestable.poiType.id;
                harvestable.poiType.poiCapacityMin *= poiCapacityMultiplier;
                harvestable.poiType.poiCapacityMax *= poiCapacityMultiplier;
               
                if (StarmapDict.harvestablePOIs.ContainsKey(id))
                {
                    Debug.Log("[Starmap Rebalanced] : Patching " + id);
                    harvestable.poiType.harvestableElements.Clear();
                    foreach(SimHashes key in StarmapDict.harvestablePOIs[id].Keys)
                    {
                        harvestable.poiType.harvestableElements[key] = StarmapDict.harvestablePOIs[id][key];
                    }
                }
            }
            Debug.Log("[Starmap Rebalanced] : Definitions inserted");
        }
    }

    public class GlobalPatch : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            Patch.harmony_instance = harmony;
            base.OnLoad(harmony);
        }
    }

    [HarmonyPatch(typeof(AutoMinerConfig), nameof(AutoMinerConfig.CreateBuildingDef))]
    class Patch
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
                    Debug.Log("[Starmap Rebalanced] : Succesfully Patched");
                    harmony_instance.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));
                }
                else
                {
                    Debug.Log("[Starmap Rebalanced] : Patch failed");
                }
            }
            return true;
        }

    }
}
