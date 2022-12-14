using TUNING;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;

namespace AdvancedCoolers
{
    class LiquidCooler : IBuildingConfig
    {

        public const string ID = "LiquidCooler";
        public const float CONSUMPTION_RATE = 1f;

        public const string Id = nameof(LiquidCooler);
        public static readonly LocString Name = FormatAsLink("Liquid Cooler", Id);

        public static readonly LocString Description =
            "Absorbs heat at the cost of energy";

        public static readonly string Effect = Description;

        public override BuildingDef CreateBuildingDef()
        {
            float[] tieR4 = CONSTRUCTION_MASS_KG.TIER4;
            string[] allMetals = MATERIALS.ALL_METALS;
            EffectorValues none = NOISE_POLLUTION.NONE;
            EffectorValues tieR1 = BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = none;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 4, 1, "boiler_kanim", 30, 30f, tieR4, allMetals, 3200f, BuildLocationRule.Anywhere, tieR1, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.Floodable = false;
            buildingDef.EnergyConsumptionWhenActive = 960f;
            buildingDef.ExhaustKilowattsWhenActive = -2000f;
            buildingDef.SelfHeatKilowattsWhenActive = -32f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "SolidMetal";
            buildingDef.OverheatTemperature = 398.15f;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<MinimumOperatingTemperature>();
            SpaceHeater sh = go.AddOrGet<SpaceHeater>();
            sh.targetTemperature = 10000f;
            sh.minimumCellMass = 400f;
            sh.SetLiquidHeater();
            go.AddOrGet<AdjustableSlider>();
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
