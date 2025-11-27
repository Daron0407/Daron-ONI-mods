using System.Collections.Generic;
using STRINGS;
using TUNING;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;

namespace CooledStorage
{
    public class CooledStorageBin : IBuildingConfig
    {
        public const string ID = nameof(CooledStorageBin);

        public static readonly LocString Name = FormatAsLink(Setup.CooledStorage.name, ID);

        public static readonly LocString Description = Setup.CooledStorage.description;

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


            EffectorValues decor = TUNING.BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "cooledstoragebin_kanim", 30, 60f, tier, materials, 1600f, BuildLocationRule.OnFloor, decor, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = Setup.CooledStorage.EnergyUsage;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = Setup.CooledStorage.HeatOutputWhenEnergySaving;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.Overheatable = true;
            buildingDef.OverheatTemperature = Setup.Overheat + 273.15f;

            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AddSearchTerms((string)SEARCH_TERMS.STORAGE);
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
            go.AddOrGetDef<RocketUsageRestriction.Def>().restrictOperational = false;
            RefrigeratorController.Def def = go.AddOrGetDef<RefrigeratorController.Def>();


            def.powerSaverEnergyUsage = Setup.CooledStorage.EnergySaverMode;
            def.coolingHeatKW = Setup.CooledStorage.HeatOutputAC;
            def.steadyHeatKW = 0f;
            def.simulatedInternalTemperature = 273.15f + Setup.CooledStorage.SimulatedTemperature;
            def.simulatedThermalConductivity = Setup.SimulatedThermalConductivity;
            def.simulatedInternalHeatCapacity = Setup.SimulatedHeatCapacity;
        }
    }
}
