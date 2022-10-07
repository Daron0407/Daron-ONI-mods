using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using TUNING;

namespace Rocketry_Tune_Up
{
    [HarmonyPatch(typeof(KeroseneEngineClusterConfig), nameof(KeroseneEngineClusterConfig.DoPostConfigureComplete))]
    public class PetroleumEngine
    {
        public static void Postfix(GameObject go)
        {
            RocketModulePerformance RMP = new RocketModulePerformance((float)ROCKETRY.BURDEN.MAJOR, ROCKETRY.FUEL_COST_PER_DISTANCE.HIGH, ROCKETRY.ENGINE_POWER.MID_VERY_STRONG);
            go.GetComponent<RocketModuleCluster>().performanceStats = RMP;
            go.GetComponent<Building>().Def.BuildingUnderConstruction.GetComponent<RocketModuleCluster>().performanceStats = RMP;
        }
    }
    [HarmonyPatch(typeof(HydrogenEngineClusterConfig), nameof(HydrogenEngineClusterConfig.DoPostConfigureComplete))]
    public class HydrogenEngine
    {
        public static void Postfix(GameObject go)
        {
            RocketModulePerformance RMP = new RocketModulePerformance((float)ROCKETRY.BURDEN.MAJOR_PLUS, ROCKETRY.FUEL_COST_PER_DISTANCE.MEDIUM, ROCKETRY.ENGINE_POWER.LATE_VERY_STRONG);
            go.GetComponent<RocketModuleCluster>().performanceStats = RMP;
            go.GetComponent<Building>().Def.BuildingUnderConstruction.GetComponent<RocketModuleCluster>().performanceStats = RMP;
        }
    }
}
