using HarmonyLib;
using UnityEngine;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using KMod;


namespace ConfigurableSteamTurbine
{
	class Patch : UserMod2
	{
		public override void OnLoad(Harmony harmony)
		{
			PUtil.InitLibrary();
			new POptions().RegisterOptions(this, typeof(Config));
			base.OnLoad(harmony);
			LocString.CreateLocStringKeys(typeof(ConfigurableSteamTurbine.STRINGS.UI));
		}
	}


	class STPatches
	{
		[HarmonyPatch(typeof(SteamTurbineConfig2), nameof(SteamTurbineConfig2.DoPostConfigureComplete))]
		class SteamTurbinePatch1
		{
			static bool Prefix()
			{
				SteamTurbineConfig2.MAX_WATTAGE = Config.Instance.maxWattage;
				return true;
			}
			static void Postfix(GameObject go)
			{
				SteamTurbine ST = go.GetComponent<SteamTurbine>();
				ST.outputElementTemperature = 273.15f + Config.Instance.outputTempC;
				ST.minActiveTemperature = 273.15f + Config.Instance.minActiveTempC;
				ST.idealSourceElementTemperature = 273.15f + Config.Instance.maxActiveTempC;
				ST.maxSelfHeat = Config.Instance.maxSelfHeat;
				ST.wasteHeatToTurbinePercent = Config.Instance.steamHeatConvert;
				ST.pumpKGRate = Config.Instance.PumpKGRate;

				go.AddOrGet<TurbineSlider>();
			}
		}

		[HarmonyPatch(typeof(SteamTurbineConfig2), nameof(SteamTurbineConfig2.CreateBuildingDef))]
		class SteamTurbinePatch2
		{
			static void Prefix()
			{
				SteamTurbineConfig2.MAX_WATTAGE = Config.Instance.maxWattage;
			}
			static void Postfix(BuildingDef __result)
			{
				__result.SelfHeatKilowattsWhenActive = Config.Instance.SelfExhaustKilowattsWhenActive;
			}
		}

	}


}