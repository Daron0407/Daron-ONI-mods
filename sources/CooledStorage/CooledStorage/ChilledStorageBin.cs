using System.Collections.Generic;
using STRINGS;
using TUNING;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;

namespace CooledStorage
{
    public class ChilledStorageBin : IBuildingConfig
    {
        public const string ID = nameof(ChilledStorageBin);

        public static readonly LocString Name = FormatAsLink(Setup.ChilledStorage.name, ID);

        public static readonly LocString Description = Setup.ChilledStorage.description;

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
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "chilledstoragebin_kanim", 30, 60f, tier, materials, 1600f, BuildLocationRule.OnFloor, decor, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = Setup.ChilledStorage.EnergyUsage;
            buildingDef.SelfHeatKilowattsWhenActive = Setup.ChilledStorage.HeatOutputWhenEnergySaving;
            buildingDef.OverheatTemperature = Setup.Overheat + 273.15f;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.Overheatable = true;

            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
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


            def.powerSaverEnergyUsage = Setup.ChilledStorage.EnergySaverMode;
            def.coolingHeatKW = Setup.ChilledStorage.HeatOutputAC;
            def.simulatedInternalTemperature = 273.15f + Setup.ChilledStorage.SimulatedTemperature;
            def.steadyHeatKW = 0f;
            def.simulatedThermalConductivity = Setup.SimulatedThermalConductivity;
            def.simulatedInternalHeatCapacity = Setup.SimulatedHeatCapacity;
        }
    }
}
