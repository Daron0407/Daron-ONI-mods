using TUNING;
using UnityEngine;
using static STRINGS.UI;
using static TUNING.BUILDINGS;

namespace AdvancedCoolers
{
    class SpaceCooler : IBuildingConfig
    {
        public const string ID = "SpaceCooler";


        public const string Id = nameof(SpaceCooler);
        public static readonly LocString Name = FormatAsLink("Space Cooler", Id);

        public static readonly LocString Description =
            "Absorbs heat at the cost of energy";

        public static readonly string Effect = Description;

        public override BuildingDef CreateBuildingDef()
        {
            float[] tier =
            {
                CONSTRUCTION_MASS_KG.TIER4[0],
                CONSTRUCTION_MASS_KG.TIER1[0]
            };
            string[] materials =
            {
                "RefinedMetal",
                "Fullerene"
            };


            EffectorValues tieR2 = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues tieR1 = BUILDINGS.DECOR.BONUS.TIER1;
            EffectorValues noise = tieR2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 2, 2, "spacecooler_kanim", 30, 30f, tier, materials, 1600f, BuildLocationRule.OnFloor, tieR1, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 60f;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = -64f;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.OverheatTemperature = 398.15f;
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<MinimumOperatingTemperature>();
            SpaceHeater sh = go.AddOrGet<SpaceHeater>();
            sh.targetTemperature = 10000f;
            go.AddOrGet<AdjustableSlider>();
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
