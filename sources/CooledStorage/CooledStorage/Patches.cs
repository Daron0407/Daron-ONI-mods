using HarmonyLib;

namespace CooledStorage
{
    public class Patches : KMod.UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            LocString.CreateLocStringKeys(typeof(STRINGS.MISC));
            base.OnLoad(harmony);
        }
    }

    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch(nameof(Db.Initialize))]
    public static class Db_Initialize_Patch
    {

        public static void Postfix()
        {
            Setup();
        }


        private static void Setup()
        {
            SetString(CooledStorageBin.ID.ToUpper(), CooledStorageBin.Name, CooledStorageBin.Description, CooledStorageBin.Effect);
            SetString(ChilledStorageBin.ID.ToUpper(), ChilledStorageBin.Name, ChilledStorageBin.Description, ChilledStorageBin.Effect);
            SetString(FrozenStorageBin.ID.ToUpper(), FrozenStorageBin.Name, FrozenStorageBin.Description, FrozenStorageBin.Effect);
            SetString(CryoStorageBin.ID.ToUpper(), CryoStorageBin.Name, CryoStorageBin.Description, CryoStorageBin.Effect);


            ModUtil.AddBuildingToPlanScreen("Base", CooledStorageBin.ID);
            ModUtil.AddBuildingToPlanScreen("Base", ChilledStorageBin.ID);
            ModUtil.AddBuildingToPlanScreen("Base", FrozenStorageBin.ID);
            ModUtil.AddBuildingToPlanScreen("Base", CryoStorageBin.ID);


            Db.Get().Techs.Get("TemperatureModulation").unlockedItemIDs.Add(CooledStorageBin.ID);
            Db.Get().Techs.Get("HVAC").unlockedItemIDs.Add(ChilledStorageBin.ID);
            Db.Get().Techs.Get("Catalytics").unlockedItemIDs.Add(FrozenStorageBin.ID);
            Db.Get().Techs.Get("Catalytics").unlockedItemIDs.Add(CryoStorageBin.ID);
        }

        private static void SetString(string path, string name, string description, string effect)
        {
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.NAME", name);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.DESC", description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.EFFECT", effect);
        }
    }
}
