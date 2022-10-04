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
                var addTrait = new DUPLICANTSTATS.TraitVal()
                {
                    id = "RadiationEater",
                    dlcId = "EXPANSION1_ID"
                };

                DUPLICANTSTATS.GENESHUFFLERTRAITS.Add(addTrait);

            }

        }
    }
}