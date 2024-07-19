using Advanced_Coolers;
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
            EffectorValues none = NOISE_POLLUTION.NONE;
            EffectorValues tieR1 = BUILDINGS.DECOR.PENALTY.TIER1;
            EffectorValues noise = none;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 4, 1, "liquidcooler_kanim", 30, 30f, tier, materials, 3200f, BuildLocationRule.Anywhere, tieR1, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.Floodable = false;
            buildingDef.EnergyConsumptionWhenActive = Config.Instance.LCWattage;
            buildingDef.ExhaustKilowattsWhenActive = -Config.Instance.LCCooling;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "SolidMetal";
            buildingDef.OverheatTemperature = 398.15f;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            MinimumOperatingTemperature mot = go.AddOrGet<MinimumOperatingTemperature>();
            mot.minimumTemperature = 273.15f - 260f;
            SpaceHeater sh = go.AddOrGet<SpaceHeater>();
            sh.targetTemperature = 10000f;
            sh.minimumCellMass = 400f;
            sh.SetLiquidHeater();
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
