using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

class STPatches
{

	public static float MaxWattage = 1700f;
	public static float minActiveTempC = 95f;
	public static float maxActiveTempC = 300f;
	public static float outputTempC = 90f;
	public static float maxSelfHeat = 0f;
	public static float steamHeatConvert = 0.01f;
	public static float maxBuildingTemperatureC = 1000f;



	[HarmonyPatch(typeof(SteamTurbineConfig2), nameof(SteamTurbineConfig2.DoPostConfigureComplete))]
	class SteamTurbinePatch1
	{
		static bool Prefix()
		{
			SteamTurbineConfig2.MAX_WATTAGE = MaxWattage;
			return true;
		}
		static void Postfix(GameObject go)
		{
			SteamTurbine ST = go.GetComponent<SteamTurbine>();
			ST.outputElementTemperature = 273.15f + outputTempC;
			ST.minActiveTemperature = 273.15f + minActiveTempC;
			ST.idealSourceElementTemperature = 273.15f + maxActiveTempC;
			ST.maxSelfHeat = maxSelfHeat;
			ST.wasteHeatToTurbinePercent = steamHeatConvert;
			ST.maxBuildingTemperature = 273.15f + maxBuildingTemperatureC;
		}
	}

	[HarmonyPatch(typeof(SteamTurbineConfig2), nameof(SteamTurbineConfig2.CreateBuildingDef))]
	class SteamTurbinePatch2
	{
		static void Prefix()
		{
			SteamTurbineConfig2.MAX_WATTAGE = MaxWattage;
		}
		static void Postfix(BuildingDef __result)
        {
			__result.SelfHeatKilowattsWhenActive = 4f;
        }
	}
}

