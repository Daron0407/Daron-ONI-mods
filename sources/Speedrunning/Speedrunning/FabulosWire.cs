﻿using HarmonyLib;

namespace Speedrunning
{
    class WirePatches
    {
        [HarmonyPatch(typeof(Wire), nameof(Wire.GetMaxWattageAsFloat))]
        class Wire_GetMaxWattage_Patch
        {

            static bool Prefix(Wire.WattageRating rating, ref float __result)
            {
                if (rating == Wire.WattageRating.Max2000)
                {
                    __result = 100000f;
                    return false; // skip the original
                }
                return true;
            }

        }
    }
}
