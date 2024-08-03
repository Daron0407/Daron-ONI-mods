using System.Collections.Generic;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;
using TUNING;

namespace CooledStorage
{
    public class CooledLocker : IBuildingConfig
    {
        public const string ID = nameof(CooledLocker);

        public static readonly LocString Name = FormatAsLink("Cooled Storage Bin", ID);

        public static readonly LocString Description =
            "Stores solids in a cooled manner";

        public static readonly string Effect = Description;

        public override BuildingDef CreateBuildingDef()
        {
            float[] tier =
            {
                CONSTRUCTION_MASS_KG.TIER4[0]
            };
            string[] materials =
            {
                "RefinedMetal"
            };


            EffectorValues decor = BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("StorageLockerSmart", 1, 2, "smartstoragelocker_kanim", 30, 60f, tier, materials, 1600f, BuildLocationRule.OnFloor, decor, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 120f; // Wattage
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f; // Heat production
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.OverheatTemperature = 398.15f; // Overheat
            return buildingDef;
        }


        public override void DoPostConfigureComplete(GameObject go)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.STORAGE_LOCKERS_STANDARD;
            storage.storageFullMargin = TUNING.STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
            go.AddOrGet<UserNameable>();
            go.AddOrGetDef<StorageController.Def>();
            go.AddOrGetDef<RocketUsageRestriction.Def>();
            RefrigeratorController.Def def = go.AddOrGetDef<RefrigeratorController.Def>();
            def.powerSaverEnergyUsage = 0f;
            def.coolingHeatKW = 4f;
            def.steadyHeatKW = 0f;
            def.simulatedInternalTemperature = 273.15f + 45f;
        }
    }
}
