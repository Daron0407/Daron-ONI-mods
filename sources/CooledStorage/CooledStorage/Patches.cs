﻿using HarmonyLib;

namespace CooledStorage
{
    public class Patches : KMod.UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            LocString.CreateLocStringKeys(typeof(STRINGS.UI));
            base.OnLoad(harmony);
        }
    }

    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch(nameof(Db.Initialize))]
    public static class Db_Initialize_Patch
    {

        public static void Postfix()
        {
            SetupStrings();
            ModUtil.AddBuildingToPlanScreen("Base", CooledLocker.ID);
            //ModUtil.AddBuildingToPlanScreen("Utilities", CooledLocker.ID);
        }


        private static void SetupStrings()
        {
            SetString(CooledLocker.ID.ToUpper(), CooledLocker.Name, CooledLocker.Description, CooledLocker.Effect);
        }

        private static void SetString(string path, string name, string description, string effect)
        {
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.NAME", name);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.DESC", description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{path}.EFFECT", effect);
        }
    }
}
