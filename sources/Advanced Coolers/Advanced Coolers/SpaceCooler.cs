using Advanced_Coolers;
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
            buildingDef.EnergyConsumptionWhenActive = Config.Instance.SCWattage;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = -Config.Instance.SCCooling;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.OverheatTemperature = 398.15f;
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            MinimumOperatingTemperature mot = go.AddOrGet<MinimumOperatingTemperature>();
            mot.minimumTemperature = 273.15f - 260f;
            SpaceHeater sh = go.AddOrGet<SpaceHeater>();
            sh.targetTemperature = 10000f;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
