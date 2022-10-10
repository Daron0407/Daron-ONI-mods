using HarmonyLib;
using UnityEngine;

namespace MinimumOutputTempRestored
{
    public static class Constants
    {
        public static float Minimum_output_temp = 0f;
        public static float Water_sieve_drop_size = 200f;
        public static float Desalinator_drop_size = 600f;
    }
    
    //Sets minimum output temp, sets drop size, increases amount of polluted dirt
    [HarmonyPatch(typeof(WaterPurifierConfig), nameof(WaterPurifierConfig.ConfigureBuildingTemplate))]
    public class WaterSievePatch1
    {
        static void Postfix(GameObject go, Tag prefab_tag)
        {
            ElementConverter elementConverter = go.GetComponent<ElementConverter>();
            elementConverter.outputElements = new ElementConverter.OutputElement[2]
            {
                new ElementConverter.OutputElement(5f, SimHashes.Water, 273.15f + Constants.Minimum_output_temp, storeOutput: true, diseaseWeight: 0.75f),
                new ElementConverter.OutputElement(1.0f, SimHashes.ToxicSand, 0.0f, storeOutput: true, diseaseWeight: 0.25f)
            };
            ElementDropper elementDropper = go.GetComponent<ElementDropper>();
            elementDropper.emitMass = Constants.Water_sieve_drop_size;
        }
    }

    [HarmonyPatch(typeof(WaterPurifierConfig), nameof(WaterPurifierConfig.CreateBuildingDef))]
    public class WaterSievePatch2
    {
        static void Postfix(ref BuildingDef __result)
        {
            __result.Floodable = false;
        }
    }

    [HarmonyPatch(typeof(DesalinatorConfig), nameof(DesalinatorConfig.ConfigureBuildingTemplate))]
    public class DesalinatorPatch
    {
        static void Postfix(GameObject go, Tag prefab_tag)
        {
            ElementConverter[] elementConverters = go.GetComponents<ElementConverter>();

            ElementConverter elementConverter1 = elementConverters[0];
            elementConverter1.consumedElements = new ElementConverter.ConsumedElement[1]
            {
                new ElementConverter.ConsumedElement(new Tag("SaltWater"), 5f)
            };
            elementConverter1.outputElements = new ElementConverter.OutputElement[2]
            {
                new ElementConverter.OutputElement(4.65f, SimHashes.Water, 273.15f + Constants.Minimum_output_temp, storeOutput: true, diseaseWeight: 0.75f),
                new ElementConverter.OutputElement(0.35f, SimHashes.Salt, 0.0f, storeOutput: true, diseaseWeight: 0.25f)
            };
            ElementConverter elementConverter2 = elementConverters[1];
            elementConverter2.consumedElements = new ElementConverter.ConsumedElement[1]
            {
                new ElementConverter.ConsumedElement(new Tag("Brine"), 5f)
            };
            elementConverter2.outputElements = new ElementConverter.OutputElement[2]
            {
                new ElementConverter.OutputElement(3.5f, SimHashes.Water, 273.15f + Constants.Minimum_output_temp, storeOutput: true, diseaseWeight: 0.75f),
                new ElementConverter.OutputElement(1.5f, SimHashes.Salt, 0.0f, storeOutput: true, diseaseWeight: 0.25f)
            };

            ElementDropper dropper = go.AddComponent<ElementDropper>();
            dropper.emitMass = Constants.Desalinator_drop_size;
            dropper.emitTag = new Tag("Salt");
            dropper.emitOffset = new Vector3(0.0f, 1f, 0.0f);
        }
    }
}
