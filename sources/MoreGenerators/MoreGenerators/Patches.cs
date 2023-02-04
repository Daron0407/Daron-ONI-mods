using System.Collections.Generic;
using Database;
using HarmonyLib;



namespace MoreGenerators
{
    public class AdvancedGenerators : KMod.UserMod2
    {

        public override void OnLoad(Harmony harmony)
        {
            harmony.PatchAll();
        }



        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch(nameof(Db.Initialize))]
        public static class Db_Initialize_Patch
        {
            private static Dictionary<string, string[]> _techGrouping;

            public static void Prefix()
            {
                _techGrouping = Traverse.Create(typeof(Techs))?.Field("TECH_GROUPING")
                    ?.GetValue<Dictionary<string, string[]>>();
            }

            public static void Postfix()
            {
                SetupStrings();
                ModUtil.AddBuildingToPlanScreen("Power", RefinedCarbonGenerator.Id);
                ModUtil.AddBuildingToPlanScreen("Power", UraniumGenerator.Id);
                //ModUtil.AddBuildingToPlanScreen("Refinement", SourGasBoiler.Id);

                InsertToTechTree("AdvancedPowerRegulation", RefinedCarbonGenerator.Id);
                InsertToTechTree("RenewableEnergy", UraniumGenerator.Id);
                //InsertToTechTree("Plastics", SourGasBoiler.Id);
            }

            private static void InsertToTechTree(string techId, string buildingId)
            {
                if(_techGrouping != null)
                {
                    if (_techGrouping.ContainsKey(techId))
                    {
                        var techList = new List<string>(_techGrouping[techId]) { buildingId };
                        _techGrouping[techId] = techList.ToArray();
                    }
                }
            }

            private static void SetupStrings()
            {
                SetString(RefinedCarbonGenerator.IdUpper, RefinedCarbonGenerator.Name,
                    RefinedCarbonGenerator.Description,
                    RefinedCarbonGenerator.Effect);
                SetString(UraniumGenerator.IdUpper, UraniumGenerator.Name,
                    UraniumGenerator.Description,
                    UraniumGenerator.Effect);
                SetString(SourGasBoiler.IdUpper, SourGasBoiler.Name,
                    SourGasBoiler.Description,
                    UraniumGenerator.Effect);
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