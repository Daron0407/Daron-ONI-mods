using HarmonyLib;

namespace PetroleumToMethane
{
    [HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
    public class Patch
    {
        public static void Postfix(ElementLoader.ElementEntry entry, Element elem)
        {
            if (entry.elementId.ToString().Equals("Petroleum"))
            {
                elem.highTempTransitionTarget = (SimHashes) Hash.SDBMLower("Methane");
            }
        }
    }
}
