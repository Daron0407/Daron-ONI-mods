using HarmonyLib;
using TUNING;

namespace ONI_mod
{
    public class Patches
    {

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]

        public class DuplicantStatsPatch
        {
            public static void Postfix()
            {
                DUPLICANTSTATS.TraitVal[] traits = new DUPLICANTSTATS.TraitVal[]
                {
                    new DUPLICANTSTATS.TraitVal()
                    {
                        id = "RadiationEater",
                        dlcId = "EXPANSION1_ID"
                    },
                    new DUPLICANTSTATS.TraitVal()
                    {
                        id = "StarryEyed",
                        dlcId = "EXPANSION1_ID"
                    }
                };
                foreach(var trait in traits)
                {
                    DUPLICANTSTATS.GENESHUFFLERTRAITS.Add(trait);
                }

            }

        }
    }
}