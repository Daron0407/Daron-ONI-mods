using HarmonyLib;

class WirePatches
{
    [HarmonyPatch(typeof(Wire), nameof(Wire.GetMaxWattageAsFloat))]
    class Wire_GetMaxWattage_Patch
    {

        static bool Prefix(Wire.WattageRating rating, ref float __result)
        {
            // tweak conductive wire
            if (rating == Wire.WattageRating.Max2000)
            {
                __result = 4000f;
                return false; // skip the original implementation
            }
            return true;
        }

    }
}