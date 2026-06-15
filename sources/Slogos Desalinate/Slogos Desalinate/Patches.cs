using HarmonyLib;
using UnityEngine;


namespace Slogos_Desalinate
{
    [HarmonyPatch(typeof(SnailConfig), nameof(SnailConfig.CreateSnail))]
    public class Patch
    {
        public static float desalinatingRate = 0.2f;
        public static float brineRate = 3.5f / 5f;
        public static float saltWaterRate = 4.65f / 5f;

        public static void Postfix(bool is_baby, ref GameObject __result)
        {
            if (!is_baby)
            {
                Storage storage = __result.AddOrGet<Storage>();
                storage.capacityKg = desalinatingRate * 20f;
                storage.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);

                AddFilterProcess(__result, SimHashes.Brine, SimHashes.Water, brineRate);
                AddFilterProcess(__result, SimHashes.SaltWater, SimHashes.Water, saltWaterRate);
                AddFilterProcess(__result, SimHashes.MurkyBrine, SimHashes.DirtyWater, brineRate);


                __result.AddOrGet<UpdateElementConsumerPosition>();

                ElementDropper elementDropper = __result.AddComponent<ElementDropper>();
                elementDropper.emitTag = SimHashes.Salt.CreateTag();
                elementDropper.emitMass = desalinatingRate * 10f;
                elementDropper.emitOffset = Vector3.zero;
            }
        }

        private static void AddFilterProcess(GameObject prefab, SimHashes input, SimHashes output, float rate)
        {
            PassiveElementConsumer consumer = prefab.AddComponent<PassiveElementConsumer>();
            consumer.elementToConsume = input;
            consumer.consumptionRate = desalinatingRate;
            consumer.capacityKG = desalinatingRate * 10f;
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
                new ElementConverter.ConsumedElement(input.CreateTag(), desalinatingRate)
            };
            converter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(desalinatingRate * rate, output, 0.0f, true, true),
                new ElementConverter.OutputElement(desalinatingRate * (1f - rate), SimHashes.Salt, 0.0f, true, true)
            };


            BubbleSpawner bubbleSpawner = prefab.AddComponent<BubbleSpawner>();
            bubbleSpawner.element = output;
            bubbleSpawner.emitMass = desalinatingRate * 10f;
            bubbleSpawner.emitVariance = 0.5f;
            bubbleSpawner.emitOffset = Vector3.zero;

        }
    }
    [HarmonyPatch(typeof(SnailConfig), nameof(SnailConfig.OnSpawn))]
    public class SnailOnSpawn
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
