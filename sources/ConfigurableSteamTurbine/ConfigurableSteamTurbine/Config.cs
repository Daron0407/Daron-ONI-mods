using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using PeterHan.PLib.UI;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using KMod;
using Newtonsoft.Json;

namespace ConfigurableSteamTurbine
{

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
		[Option("Temperature Difference", "How much of a difference should there be beetween output water temperature and max building temperature (default 5)")]
		[Limit(-100f, 1000f)]
		public float tempDiff { get; set; }

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
			tempDiff = 5f;
			SelfExhaustKilowattsWhenActive = 4f;
			PumpKGRate = 2f;
		}
	}
}
