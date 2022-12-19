using static STRINGS.UI;
using static TUNING.BUILDINGS;
using TUNING;
using UnityEngine;

namespace MoreGenerators
{
    class UraniumGenerator : IBuildingConfig
    {
        public const string Id = nameof(UraniumGenerator);
        public static readonly LocString Name = FormatAsLink("Enriched Uranium Generator", Id);

        public static readonly LocString Description =
            "Produces electricity";

        public static readonly string Effect =
            $"Burns Enriched Uranium into {FormatAsLink("Power", "POWER")}.";

        private const int HitPoints = HITPOINTS.TIER1;
        private const float ConstructTime = CONSTRUCTION_TIME_SECONDS.TIER3;
        private const float MeltingPoint = MELTING_POINT_KELVIN.TIER2;

        private const string AnimationString = "generatorphos_kanim";

        //private const int WATTAGE = 417; //power generated/1g of uranium



        private const float Capacity = 12f;
        private const float RefillCapacity = 3f;

        private const float UraniumBurnRate = 0.010f;
        private const float WasteProductionRate = UraniumBurnRate * 0.9f;


        private const int Watt = 4000;

        private const float WasteOutputTemp = 273.15f + 100f;


        public static readonly string IdUpper = Id.ToUpper();

        public override BuildingDef CreateBuildingDef()
        {
            string[] strArray = new string[2]
            {
              "RefinedMetal",
              "Plastic"
            };
            float[] construction_mass = new float[2]
            {
              TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
              TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]
            };
            string[] construction_materials = strArray;
            EffectorValues tieR5 = NOISE_POLLUTION.NOISY.TIER5;
            EffectorValues tieR1 = TUNING.BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = tieR5;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(Id, 3, 4, "enrichmentCentrifuge_kanim", 100, 480f, construction_mass, construction_materials, 2400f, BuildLocationRule.OnFloor, tieR1, noise);
            buildingDef.Overheatable = true;

            buildingDef.RequiresPowerOutput = true;
            buildingDef.GeneratorWattageRating = Watt;
            buildingDef.PowerOutputOffset = new CellOffset(0, 0);
            buildingDef.ViewMode = OverlayModes.Power.ID;

            buildingDef.GeneratorBaseCapacity = 20000f;
            buildingDef.ExhaustKilowattsWhenActive = 16f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;

            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.AudioSize = "large";
            

            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));



            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);

            Tag t = GameTagExtensions.Create(SimHashes.EnrichedUranium);

            EnergyGenerator eg = go.AddOrGet<EnergyGenerator>();
            eg.ignoreBatteryRefillPercent = true;
            eg.formula = new EnergyGenerator.Formula
            {
                inputs = new EnergyGenerator.InputItem[]
                {
                    new EnergyGenerator.InputItem(t, UraniumBurnRate, Capacity)
                },
                outputs = new EnergyGenerator.OutputItem[]
                {
                    new EnergyGenerator.OutputItem(SimHashes.DepletedUranium, WasteProductionRate, true,  WasteOutputTemp)
                }
            };
            eg.powerDistributionOrder = 9;

            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = Capacity;
            storage.showInUI = true;

            ElementDropper dropper = go.AddOrGet<ElementDropper>();
            dropper.emitTag = SimHashes.DepletedUranium.CreateTag();
            dropper.emitMass = 1f;
            dropper.emitOffset = new Vector3(1f,2f,0f);
            
            go.AddOrGet<LoopingSounds>();
            Prioritizable.AddRef(go);

            ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKg.allowPause = false;
            manualDeliveryKg.SetStorage(storage);
            manualDeliveryKg.RequestedItemTag = t;
            manualDeliveryKg.capacity = storage.capacityKg;
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
