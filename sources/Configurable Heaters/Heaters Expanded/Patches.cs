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
        public static float MAX_TEMP = 10000f;

        public static float temperature(float celcuis) => celcuis + 273.15f;
    }
}
