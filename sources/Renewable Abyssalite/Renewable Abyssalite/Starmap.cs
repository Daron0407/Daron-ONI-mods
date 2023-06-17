using HarmonyLib;
using KMod;
using System.Collections.Generic;

namespace Renewable_Abyssalite
{

    
    public class StarmapPatch
    {

        public static bool dummy()
        {
            return true;
        }
        public static void Postfix(ref List<HarvestablePOIConfig.HarvestablePOIParams> __result)
        {
            foreach (HarvestablePOIConfig.HarvestablePOIParams harvestable in __result)
            {
                if (harvestable.poiType.id.Equals("GlimmeringAsteroidField"))
                {
                    Debug.Log("[Renewable_Abyssalite]: Starmap patch succesful");
                    harvestable.poiType.harvestableElements.Clear();
                    harvestable.poiType.harvestableElements[SimHashes.MoltenTungsten] = 2f;
                    harvestable.poiType.harvestableElements[SimHashes.Wolframite] = 6f;
                    harvestable.poiType.harvestableElements[SimHashes.Carbon] = 0.9f;
                    harvestable.poiType.harvestableElements[SimHashes.CarbonDioxide] = 0.9f;
                    harvestable.poiType.harvestableElements[SimHashes.Katairite] = 0.2f;
                }

            }
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
    public class Patch
    {
        public static Harmony harmony_instance;
        public static bool patched = false;
        public static bool Prefix()
        {
            if (!patched)
            {
                Debug.Log("[Renewable_Abyssalite]: Attempting to patch starmap");
                patched = true;
                var original = typeof(HarvestablePOIConfig).GetMethod("GenerateConfigs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
                var prefix = typeof(StarmapPatch).GetMethod(nameof(StarmapPatch.dummy));
                var postfix = typeof(StarmapPatch).GetMethod(nameof(StarmapPatch.Postfix));
                if (original != null)
                {
                    harmony_instance.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));
                }
            }
            else
            {
                Debug.Log("[Renewable_Abyssalite]: Starmap patch failed");
            }
            return true;
        }
    }

}
