using HarmonyLib;
using Klei.AI;

    [HarmonyPatch(typeof(PlantMutation), nameof(PlantMutation.AttributeModifier))]
    class MutationPatch
    {
        static void Prefix(Attribute attribute, ref float amount)
        {
            if (attribute.Description.Equals(Db.Get().PlantAttributes.MinRadiationThreshold.Description))
            {
                amount = 0f;
            }
        }
    }
