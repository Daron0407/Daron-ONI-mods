using HarmonyLib;


namespace AdvancedCoolers
{
    public class AdvancedGenerators : KMod.UserMod2
    {

        public override void OnLoad(Harmony harmony)
        {
            LocString.CreateLocStringKeys(typeof(STRINGS.UI));
            base.OnLoad(harmony);
        }



        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch(nameof(Db.Initialize))]
        public static class Db_Initialize_Patch
        {

            public static void Postfix()
            {
                SetupStrings();
                ModUtil.AddBuildingToPlanScreen("Utilities", SpaceCooler.Id);
                ModUtil.AddBuildingToPlanScreen("Utilities", LiquidCooler.Id);
            }


            private static void SetupStrings()
            {
                SetString(SpaceCooler.Id.ToUpper(), SpaceCooler.Name,
                    SpaceCooler.Description,
                    SpaceCooler.Effect);
                SetString(LiquidCooler.Id.ToUpper(), LiquidCooler.Name,
                    LiquidCooler.Description,
                    LiquidCooler.Effect);
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
