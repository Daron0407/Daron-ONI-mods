using static STRINGS.UI;
using static TUNING.BUILDINGS;
using TUNING;
using UnityEngine;

namespace MoreGenerators
{

    internal class RefinedCarbonGenerator : IBuildingConfig
    {
        public const string Id = nameof(RefinedCarbonGenerator);
        public static readonly LocString Name = FormatAsLink("Refined Carbon Generator", Id);

        public static readonly LocString Description =
            "Produce much more electricity than coal generator, by burning refined carbon, emits exhaust";

        public static readonly string Effect =
            $"Burns {FormatAsLink("Refined Carbon", "REFINEDCARBON")} into {FormatAsLink("Power", "POWER")}.";

        private const int HitPoints = HITPOINTS.TIER1;
        private const float ConstructTime = CONSTRUCTION_TIME_SECONDS.TIER3;
        private const float MeltingPoint = MELTING_POINT_KELVIN.TIER2;

        private const string AnimationString = "generatorphos_kanim";

        private const int Watt = 1200;

        private const float CarbonCapacity = 600f;
        private const float RefillCapacity = 100f;

        private const float CarbonBurnRate = 1f;
        private const float Co2GenerationRate = 0.02f;

        private const float OutCo2Temperature = 273.15f + 110f;

        private static readonly string[] Materials = new[] { MATERIALS.METAL, MATERIALS.BUILDABLERAW };
        private static readonly float[] MateMassKg = new[] { BUILDINGS.MASS_KG.TIER5, BUILDINGS.MASS_KG.TIER4 };

        public static readonly string IdUpper = Id.ToUpper();

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues tieR2 = BUILDINGS.DECOR.PENALTY.TIER2;
            EffectorValues noise = NOISE_POLLUTION.NOISY.TIER5;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(Id, 3, 3, AnimationString, HitPoints, ConstructTime,
                MateMassKg, Materials, MeltingPoint, BuildLocationRule.OnFloor, tieR2, noise);
            buildingDef.GeneratorWattageRating = Watt;
            buildingDef.GeneratorBaseCapacity = 20000f;
            buildingDef.ExhaustKilowattsWhenActive = 8f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.RequiresPowerOutput = true;
            buildingDef.PowerOutputOffset = new CellOffset(0, 0);
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.AudioSize = "large";
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);

            var t = GameTagExtensions.Create(SimHashes.RefinedCarbon);

            var eg = go.AddOrGet<EnergyGenerator>();
            eg.ignoreBatteryRefillPercent = true;
            eg.formula = new EnergyGenerator.Formula
            {
                inputs = new EnergyGenerator.InputItem[]
                {
                    new EnergyGenerator.InputItem(t, CarbonBurnRate, CarbonCapacity)
                },
                outputs = new EnergyGenerator.OutputItem[]
                {
                    new EnergyGenerator.OutputItem(SimHashes.CarbonDioxide, Co2GenerationRate, false,
                        new CellOffset(1, 2), OutCo2Temperature)
                }
            };
            eg.powerDistributionOrder = 9;

            var st = go.AddOrGet<Storage>();
            st.capacityKg = CarbonCapacity;
            st.showInUI = true;

            //var dropper = go.AddOrGet<ElementDropper>();
            //dropper.emitTag = GameTagExtensions.Create(SimHashes.CarbonDioxide);
            //dropper.emitMass = 1f;

            go.AddOrGet<LoopingSounds>();
            Prioritizable.AddRef(go);

            var manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKg.allowPause = false;
            manualDeliveryKg.SetStorage(st);
            manualDeliveryKg.RequestedItemTag = t;
            manualDeliveryKg.capacity = st.capacityKg;
            manualDeliveryKg.refillMass = RefillCapacity;
            manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.PowerFetch.IdHash;

            Tinkerable.MakePowerTinkerable(go);
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
