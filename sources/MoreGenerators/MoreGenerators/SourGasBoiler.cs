using static STRINGS.UI;
using static TUNING.BUILDINGS;
using TUNING;
using UnityEngine;

namespace MoreGenerators
{
    class SourGasBoiler : IBuildingConfig
    {
        public const string Id = nameof(SourGasBoiler);
        public static readonly LocString Name = FormatAsLink("Sour Gas Boiler", Id);

        public static readonly LocString Description =
            "Produces Methane";

        public static readonly string Effect =
            $"Burns Petroleum into Methane and Sulfur.";

        private const int HitPoints = HITPOINTS.TIER1;
        private const float ConstructTime = CONSTRUCTION_TIME_SECONDS.TIER3;
        private const float MeltingPoint = MELTING_POINT_KELVIN.TIER2;

        private const string AnimationString = "oilrefinery_kanim";



        private Tag convertedElement = SimHashes.Petroleum.CreateTag();
        private const float consumeRate = 1f;
        private const float produceRate1 = 0.5f;
        private const float produceRate2 = 0.25f;

        private const int wattage = 1200;
        private const float outputTemp = 273.15f + 75f;


        public static readonly string IdUpper = Id.ToUpper();

        public override BuildingDef CreateBuildingDef()
        {
            float[] tieR3_1 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] allMetals = {MATERIALS.REFINED_METAL};
            EffectorValues tieR3_2 = NOISE_POLLUTION.NOISY.TIER3;
            EffectorValues tieR1 = BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = tieR3_2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(Id, 4, 4, AnimationString, 30, 30f, tieR3_1, allMetals, 800f, BuildLocationRule.OnFloor, tieR1, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.PowerInputOffset = new CellOffset(1, 0);
            buildingDef.EnergyConsumptionWhenActive = wattage;
            buildingDef.ExhaustKilowattsWhenActive = 2f;
            buildingDef.SelfHeatKilowattsWhenActive = 8f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.UtilityOutputOffset = new CellOffset(-1, 3);
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;

            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = consumeRate;
            conduitConsumer.capacityTag = convertedElement;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.forceAlwaysSatisfied = true;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.invertElementFilter = true;
            conduitDispenser.elementFilter = new SimHashes[1]
            {
                    SimHashes.Petroleum
            };
            go.AddOrGet<Storage>().showInUI = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
            {
                new ElementConverter.ConsumedElement(SimHashes.Petroleum.CreateTag(), 1f)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[2]
            {
                  new ElementConverter.OutputElement(produceRate1, SimHashes.Methane, 273.15f + outputTemp, storeOutput: true),
                  new ElementConverter.OutputElement(produceRate2, SimHashes.Sulfur, 273.15f + outputTemp, storeOutput: true)
            };

            ElementDropper elementDropper = go.AddOrGet<ElementDropper>();
            elementDropper.emitMass = 10f;
            elementDropper.emitOffset = new Vector3(1f, 2f, 0f);
            elementDropper.emitTag = SimHashes.Sulfur.CreateTag();

            Prioritizable.AddRef(go);
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go) => RegisterPorts(go);

        public override void DoPostConfigureUnderConstruction(GameObject go) => RegisterPorts(go);

        public override void DoPostConfigureComplete(GameObject go)
        {
            RegisterPorts(go);
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }

        private static void RegisterPorts(GameObject go) =>
            GeneratedBuildings.RegisterSingleLogicInputPort(go);
    }
}

