using System.Collections.Generic;
using STRINGS;
using TUNING;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;

namespace CooledStorage
{
    public class CryoStorageBin : IBuildingConfig
    {
        public const string ID = nameof(CryoStorageBin);

        public static readonly LocString Name = FormatAsLink(Setup.CryoStorage.name, ID);

        public static readonly LocString Description = Setup.CryoStorage.description;

        public static readonly string Effect = Description;

        public override BuildingDef CreateBuildingDef()
        {
            float[] tier =
            {
                CONSTRUCTION_MASS_KG.TIER4[0],
                CONSTRUCTION_MASS_KG.TIER2[0]
            };
            string[] materials =
            {
                "RefinedMetal",
                "Fullerene"
            };


            EffectorValues decor = TUNING.BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "cryostoragebin_kanim", 30, 60f, tier, materials, 1600f, BuildLocationRule.OnFloor, decor, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = Setup.CryoStorage.EnergyUsage;
            buildingDef.SelfHeatKilowattsWhenActive = Setup.CryoStorage.HeatOutputWhenEnergySaving;
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


            def.powerSaverEnergyUsage = Setup.CryoStorage.EnergySaverMode;
            def.coolingHeatKW = Setup.CryoStorage.HeatOutputAC;
            def.simulatedInternalTemperature = 273.15f + Setup.CryoStorage.SimulatedTemperature;
            def.steadyHeatKW = 0f;
            def.simulatedThermalConductivity = Setup.SimulatedThermalConductivity;
            def.simulatedInternalHeatCapacity = Setup.SimulatedHeatCapacity;
        }
    }
}
