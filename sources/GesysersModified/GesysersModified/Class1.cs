using HarmonyLib;
using Klei;
using System;
using System.Collections.Generic;

namespace GesysersModified
{
    [HarmonyPatch(typeof(GeyserGenericConfig), "GenerateConfigs")]
    public class Patch
    {
        private static float kelvin(float temp)
        {
            return 273.15f + temp;
        }
        

        static bool Prefix(ref List<GeyserGenericConfig.GeyserPrefabParams> __result)
        {
            __result = new List<GeyserGenericConfig.GeyserPrefabParams> ();
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_kanim", 2, 4, new GeyserConfigurator.GeyserType("steam", SimHashes.Water, GeyserConfigurator.GeyserShape.Gas, kelvin(60f), 1000f, 2000f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_steam", SimHashes.Water, GeyserConfigurator.GeyserShape.Gas, kelvin(90f), 500f, 1000f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_hot_kanim", 4, 2, new GeyserConfigurator.GeyserType("hot_water", SimHashes.Water, GeyserConfigurator.GeyserShape.Liquid, kelvin(5f), 2000f, 4000f, 500f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_slush_kanim", 4, 2, new GeyserConfigurator.GeyserType("slush_water", SimHashes.DirtyIce, GeyserConfigurator.GeyserShape.Liquid, kelvin(-40f), 1000f, 2000f, 500f, geyserTemperature: 263f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_filthy_kanim", 4, 2, new GeyserConfigurator.GeyserType("filthy_water", SimHashes.DirtyWater, GeyserConfigurator.GeyserShape.Liquid, kelvin(-15f), 2000f, 4000f, 500f).AddDisease(new SimUtil.DiseaseInfo()
            {
                idx = Db.Get().Diseases.GetIndex((HashedString)"FoodPoisoning"),
                count = 20000
            }), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_salt_water_cool_slush_kanim", 4, 2, new GeyserConfigurator.GeyserType("slush_salt_water", SimHashes.BrineIce, GeyserConfigurator.GeyserShape.Liquid, kelvin(-40f), 1000f, 2000f, 500f, geyserTemperature: 263f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_salt_water_kanim", 4, 2, new GeyserConfigurator.GeyserType("salt_water", SimHashes.SaltWater, GeyserConfigurator.GeyserShape.Liquid, kelvin(-5f), 2000f, 4000f, 500f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_small_kanim", 3, 3, new GeyserConfigurator.GeyserType("small_volcano", SimHashes.IgneousRock, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 400f, 800f, 150f, 6000f, 12000f, 0.005f, 0.01f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_big_kanim", 3, 3, new GeyserConfigurator.GeyserType("big_volcano", SimHashes.IgneousRock, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 800f, 1600f, 150f, 6000f, 12000f, 0.005f, 0.01f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_co2_kanim", 4, 2, new GeyserConfigurator.GeyserType("liquid_co2", SimHashes.SolidCarbonDioxide, GeyserConfigurator.GeyserShape.Liquid, kelvin(-100f), 100f, 200f, 50f, geyserTemperature: 218f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_co2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_co2", SimHashes.CarbonDioxide, GeyserConfigurator.GeyserShape.Gas, kelvin(-45f), 70f, 140f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_hydrogen_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_hydrogen", SimHashes.Hydrogen, GeyserConfigurator.GeyserShape.Gas, kelvin(-150f), 70f, 140f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_po2", SimHashes.ContaminatedOxygen, GeyserConfigurator.GeyserShape.Gas, kelvin(-180f), 70f, 140f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_slimy_kanim", 2, 4, new GeyserConfigurator.GeyserType("slimy_po2", SimHashes.LiquidOxygen, GeyserConfigurator.GeyserShape.Gas, kelvin(-210f), 70f, 140f, 5f).AddDisease(new SimUtil.DiseaseInfo()
            {
                idx = Db.Get().Diseases.GetIndex((HashedString)"SlimeLung"),
                count = 5000
            }), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_chlorine_kanim", 2, 4, new GeyserConfigurator.GeyserType("chlorine_gas", SimHashes.ChlorineGas, GeyserConfigurator.GeyserShape.Gas, kelvin(-30f), 70f, 140f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_methane_kanim", 2, 4, new GeyserConfigurator.GeyserType("methane", SimHashes.Methane, GeyserConfigurator.GeyserShape.Gas, kelvin(-160f), 70f, 140f, 5f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_copper_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_copper", SimHashes.Copper, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_iron", SimHashes.Iron, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_gold_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_gold", SimHashes.Gold, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_aluminum_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_aluminum", SimHashes.Aluminum, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f, DlcID: "EXPANSION1_ID"), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_tungsten_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_tungsten", SimHashes.MoltenTungsten, GeyserConfigurator.GeyserShape.Molten, 4000f, 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f, DlcID: "EXPANSION1_ID"), false));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_niobium_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_niobium", SimHashes.MoltenNiobium, GeyserConfigurator.GeyserShape.Molten, 3500f, 800f, 1600f, 150f, 6000f, 12000f, 0.005f, 0.01f, DlcID: "EXPANSION1_ID"), false));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_cobalt_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_cobalt", SimHashes.Cobalt, GeyserConfigurator.GeyserShape.Molten, kelvin(150f), 200f, 400f, 150f, 480f, 1080f, 0.0166666675f, 0.1f, DlcID: "EXPANSION1_ID"), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_oil_kanim", 4, 2, new GeyserConfigurator.GeyserType("oil_drip", SimHashes.CrudeOil, GeyserConfigurator.GeyserShape.Liquid, kelvin(-35f), 1f, 250f, 50f, 600f, 600f, 1f, 1f, 100f, 500f), true));
            __result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_sulfur_kanim", 4, 2, new GeyserConfigurator.GeyserType("liquid_sulfur", SimHashes.Sulfur, GeyserConfigurator.GeyserShape.Liquid, kelvin(90f), 1000f, 2000f, 500f, DlcID: "EXPANSION1_ID"), true));
            __result.RemoveAll((Predicate<GeyserGenericConfig.GeyserPrefabParams>)(geyser => !geyser.geyserType.DlcID.IsNullOrWhiteSpace() && !DlcManager.IsContentActive(geyser.geyserType.DlcID)));
            return false;
        }
    }
}
