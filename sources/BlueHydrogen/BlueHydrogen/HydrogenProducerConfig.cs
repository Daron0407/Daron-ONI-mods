using static STRINGS.UI;
using static TUNING.BUILDINGS;
using TUNING;
using UnityEngine;


namespace BlueHydrogen
{
    public class H2Producer : IBuildingConfig
    {
        public const string Id = nameof(H2Producer);
        public static readonly LocString Name = FormatAsLink("Blue Hydrogen Generator", Id);
        public static readonly LocString Description = "Extracts Hydrogen";
        public static readonly string Effect = "Consumes Water and Natural Gas to Produce Hydrogen";

        private const float NatGas_Consumption = 0.1f;
        private const float Water_consumption = 0.9f;
        private const float Hydrogen_production = 0.5f;
        private const float CO2_Production = 0.5f;

        private const float power_consumption = 480f;
        private const float output_temp = 272.15f + 120f;

        public override BuildingDef CreateBuildingDef()
        {
            float[] tieR2 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] rawMetals = MATERIALS.RAW_METALS;
            EffectorValues tieR3 = NOISE_POLLUTION.NOISY.TIER3;
            EffectorValues tieR1 = BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = tieR3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(Id, 2, 2, "co2scrubber_kanim", 30, 30f, tieR2, rawMetals, 800f, BuildLocationRule.OnFloor, tieR1, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = power_consumption;
            buildingDef.SelfHeatKilowattsWhenActive = 16f;
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
            buildingDef.PermittedRotations = PermittedRotations.Unrotatable;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
            Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
            defaultStorage.showInUI = true;
            defaultStorage.capacityKg = 30000f;
            defaultStorage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);


            go.AddOrGet<AirFilter>().filterTag = GameTagExtensions.Create(SimHashes.Water);


            //Water Input world
            PassiveElementConsumer passiveElementConsumer = go.AddOrGet<PassiveElementConsumer>();
            passiveElementConsumer.elementToConsume = SimHashes.Water;
            passiveElementConsumer.consumptionRate = Water_consumption * 2f;
            passiveElementConsumer.consumptionRadius = (byte) 2;
            passiveElementConsumer.capacityKG = Water_consumption * 5f;
            passiveElementConsumer.showInStatusPanel = true;
            passiveElementConsumer.sampleCellOffset = new Vector3(0.0f, 0.0f, 0.0f);
            passiveElementConsumer.isRequired = false;
            passiveElementConsumer.storeOnConsume = true;
            passiveElementConsumer.showDescriptor = false;
            passiveElementConsumer.EnableConsumption(true);

            //Methane Input pipe
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Gas;
            conduitConsumer.consumptionRate = NatGas_Consumption * 2;
            conduitConsumer.capacityKG = NatGas_Consumption * 5;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Methane).tag;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            conduitConsumer.forceAlwaysSatisfied = true;

            //Hydrogen Output pipe
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            //conduitDispenser.invertElementFilter = true;
            conduitDispenser.elementFilter = new SimHashes[1]
            {
                SimHashes.Hydrogen
            };

            //CO2 output world

            //Conversion
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.Water), Water_consumption),
                new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.Methane), NatGas_Consumption)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(Hydrogen_production, SimHashes.Hydrogen, 0.0f, storeOutput: true),
                new ElementConverter.OutputElement(CO2_Production, SimHashes.CarbonDioxide, 0.0f, storeOutput: true)
            };
            go.AddOrGet<KBatchedAnimController>().randomiseLoopedOffset = true;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
            go.AddOrGet<EnergyConsumer>();
        }
    }

}