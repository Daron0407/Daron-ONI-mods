using HarmonyLib;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using KMod;

namespace Heaters_Expanded
{
    class Patch : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            PUtil.InitLibrary();
            new POptions().RegisterOptions(this, typeof(Config));
            LocString.CreateLocStringKeys(typeof(STRINGS.UI));
            base.OnLoad(harmony);
        }
    }

    public static class globals
    {
        public static bool SHheating() => (Config.Instance.SHheating > 0f);
        public static bool LTheating() => (Config.Instance.LTheating > 0f);

        public static float MIN_TEMP = 0f;
        public static float MAX_TEMP = 10000f;

        public static float KELVIN_TO_CELCIUS = -273.15f;
        public static float CELCIUS_TO_KELVIN = -KELVIN_TO_CELCIUS;
    }
}
