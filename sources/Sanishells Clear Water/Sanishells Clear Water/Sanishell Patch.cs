using HarmonyLib;
using UnityEngine;

namespace Sanishells_Clear_Water
{


    [HarmonyPatch(typeof(CrabFreshWaterConfig), nameof(CrabFreshWaterConfig.CreateCrabFreshWater))]
    public class SanishellClearWaterSetup
    {
        public static float cleaningRate = 0.5f;
        public static float conversionEfficiency = 0.99f;
        public static void Postfix(bool is_baby, ref GameObject __result)
        {
            if (!is_baby)
            {
                Storage storage = __result.AddOrGet<Storage>();
                storage.capacityKg = cleaningRate * 20f;
                storage.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);

                AddFilterProcess(__result, SimHashes.DirtyWater, SimHashes.Water);
                AddFilterProcess(__result, SimHashes.MurkyBrine, SimHashes.Brine);


                __result.AddOrGet<UpdateElementConsumerPosition>();

                ElementDropper elementDropper = __result.AddComponent<ElementDropper>();
                elementDropper.emitTag = SimHashes.ToxicSand.CreateTag();
                elementDropper.emitMass = (1f - conversionEfficiency) * 10f;
                elementDropper.emitOffset = Vector3.zero;
            }
        }

        private static void AddFilterProcess(GameObject prefab, SimHashes input, SimHashes output)
        {
            PassiveElementConsumer consumer = prefab.AddComponent<PassiveElementConsumer>();
            consumer.elementToConsume = input;
            consumer.consumptionRate = cleaningRate;
            consumer.capacityKG = cleaningRate * 10f;
            consumer.consumptionRadius = 3;
            consumer.showInStatusPanel = true;
            consumer.sampleCellOffset = Vector3.zero;
            consumer.isRequired = false;
            consumer.storeOnConsume = true;
            consumer.showDescriptor = false;
            consumer.showInStatusPanel = false;



            ElementConverter converter = prefab.AddComponent<ElementConverter>();
            converter.ShowInUI = true;
            converter.showDescriptors = true;
            converter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(input.CreateTag(), cleaningRate)
            };
            converter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(cleaningRate * conversionEfficiency, output, 0.0f, true, true),
                new ElementConverter.OutputElement(cleaningRate * (1f - conversionEfficiency), SimHashes.ToxicSand, 0.0f, true, true)
            };


            BubbleSpawner bubbleSpawner = prefab.AddComponent<BubbleSpawner>();
            bubbleSpawner.element = output;
            bubbleSpawner.emitMass = cleaningRate * 10f;
            bubbleSpawner.emitVariance = 0.5f;
            bubbleSpawner.emitOffset = Vector3.zero;

        }
    }

    [HarmonyPatch(typeof(CrabFreshWaterConfig), nameof(CrabFreshWaterConfig.OnSpawn))]
    public class SanishellClearOnSpawn
    {
        public static void Postfix(GameObject inst)
        {
            ElementConsumer[] components = inst.GetComponents<ElementConsumer>();
            foreach (var component in components)
            {
                if (component != null)
                {
                    component.EnableConsumption(true);
                }
            }
        }
    }
}
