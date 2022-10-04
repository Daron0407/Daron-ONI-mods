using HarmonyLib;
using UnityEngine;
using PeterHan.PLib.UI;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using KMod;
using System;
using Newtonsoft.Json;


class Patch : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
		PUtil.InitLibrary();
		new POptions().RegisterOptions(this, typeof(Config));
		base.OnLoad(harmony);
    }
}

[Serializable]
[RestartRequired]
public class Config : SingletonOptions<Config>
{
	[JsonProperty]
	[Option("Wattage", "Watts produced when processing steam at max temperature (default 850W)")]
    [Limit(1f, 10000f)]
    public float maxWattage { get; set; }


	[JsonProperty]
	[Option("Min Active Temp", "How cold the steam can get before turbine stops proccesing it (default 125C)")]
	[Limit(95f, 500f)]
	public float minActiveTempC { get; set; }


	[JsonProperty]
	[Option("Max Active Temp", "At what steam temperature reaches it's maxiumum wattage (default 200C)")]
	[Limit(100f, 1000f)]
	public float maxActiveTempC { get; set; }


	[JsonProperty]
	[Option("Output Temp", "Temperature of outputted water (default 95C)")]
	[Limit(0f, 100f)]
	public float outputTempC { get; set; }


	[JsonProperty]
	[Option("Max Self Heat", "Maximum Self Heat (default 64)")]
	[Limit(0f, 1024f)]
	public float maxSelfHeat { get; set; }

	[JsonProperty]
	[Option("Heat Convert Rate", "How much of heat siphoned from water should be turned into turbine self heat (default 0.1)")]
	[Limit(0f, 2f)]
	public float steamHeatConvert { get; set; }

	[JsonProperty]
	[Option("Max Building Temperature", "At what temperature should turbine stop working (deafult 100C)")]
	[Limit(0f, 2000f)]
	public float maxBuildingTemperatureC { get; set; }

	[JsonProperty]
	[Option("Self Heat When Active", "How much heat does turbine generate when working (deafult 4)")]
	[Limit(-256f, 1024f)]
	public float SelfExhaustKilowattsWhenActive { get; set; }

	[JsonProperty]
	[Option("Pumping Rate", "How much mass turbine proceses (deafult 2kg)")]
	[Limit(1f, 10f)]
	public float PumpKGRate { get; set; }
	public Config()
    {
		maxWattage = 850f;
		minActiveTempC = 125f;
		maxActiveTempC = 200f;
		outputTempC = 95f;
		maxSelfHeat = 64f;
		steamHeatConvert = 0.1f;
		maxBuildingTemperatureC = 100f;
		SelfExhaustKilowattsWhenActive = 4f;
		PumpKGRate = 2f;
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
			ST.maxBuildingTemperature = 273.15f + Config.Instance.maxBuildingTemperatureC;
			ST.pumpKGRate = Config.Instance.PumpKGRate;
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

