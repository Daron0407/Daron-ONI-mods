using HarmonyLib;
using UnityEngine;

namespace Sanishells_Clear_Water
{
    [HarmonyPatch(typeof(CrabFreshWaterConfig), nameof(CrabFreshWaterConfig.CreateCrabFreshWater))]
    public class SanishellClearWaterSetup
    {
        public static float cleaningRate = 0.5f;
        public static SimHashes Consumed = SimHashes.DirtyWater;
        public static SimHashes Outputed = SimHashes.Water;
        public static void Postfix(
            string id,
            string name,
            string desc,
            string anim_file,
            bool is_baby,
            string deathDropID,
            ref GameObject __result)
        {
            if (!is_baby)
            {
                Storage storage = __result.AddOrGet<Storage>();
                storage.capacityKg = cleaningRate * 10f;
                storage.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);
                PassiveElementConsumer passiveElementConsumer = __result.AddOrGet<PassiveElementConsumer>();
                passiveElementConsumer.elementToConsume = Consumed;
                passiveElementConsumer.consumptionRate = cleaningRate;
                passiveElementConsumer.capacityKG = cleaningRate * 10f;
                passiveElementConsumer.consumptionRadius = (byte)3;
                passiveElementConsumer.showInStatusPanel = true;
                passiveElementConsumer.sampleCellOffset = new Vector3(0.0f, 0.0f, 0.0f);
                passiveElementConsumer.isRequired = false;
                passiveElementConsumer.storeOnConsume = true;
                passiveElementConsumer.showDescriptor = false;
                __result.AddOrGet<UpdateElementConsumerPosition>();
                BubbleSpawner bubbleSpawner = __result.AddOrGet<BubbleSpawner>();
                bubbleSpawner.element = Outputed;
                bubbleSpawner.emitMass = cleaningRate * 10f; ;
                bubbleSpawner.emitVariance = 0.5f;
                bubbleSpawner.initialVelocity = (Vector2)new Vector2f(0, 1);
                ElementConverter elementConverter = __result.AddOrGet<ElementConverter>();
                elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
                {
                new ElementConverter.ConsumedElement(Consumed.CreateTag(), cleaningRate)
                };
                elementConverter.outputElements = new ElementConverter.OutputElement[1]
                {
                new ElementConverter.OutputElement(cleaningRate, Outputed, 0.0f, true, true)
                };
            }
        }
    }

    [HarmonyPatch(typeof(CrabFreshWaterConfig), nameof(CrabFreshWaterConfig.OnSpawn))]
    public class SanishellClearOnSpawn
    {
        public static void Postfix(GameObject inst)
        {
            ElementConsumer component = inst.GetComponent<ElementConsumer>();
            if (!((Object)component != (Object)null))
                return;
            component.EnableConsumption(true);
        }
    }
}
