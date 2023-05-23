using System.Collections.Generic;
using Database;
using HarmonyLib;



namespace BlueHydrogen
{
    public class Patches : KMod.UserMod2
    {

        public override void OnLoad(Harmony harmony)
        {
            harmony.PatchAll();
        }



        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch(nameof(Db.Initialize))]
        public static class Db_Initialize_Patch
        {

            public static void Postfix()
            {
                SetupStrings();
                ModUtil.AddBuildingToPlanScreen("Utilities", H2Producer.Id);
            }


            private static void SetupStrings()
            {
                SetString(H2Producer.Id.ToUpper(), H2Producer.Name,
                    H2Producer.Description,
                    H2Producer.Effect);
            }

            private static void SetString(string path, string name, string description, string effect)
            {
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.NAME", name);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.DESC", description);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.EFFECT", effect);
            }
        }

    }
}