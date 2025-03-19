using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedrunning
{
    [HarmonyPatch(typeof(DevGeneratorConfig), nameof(DevGeneratorConfig.CreateBuildingDef))]
    public class Generator
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
    [HarmonyPatch(typeof(DevLifeSupportConfig), nameof(DevLifeSupportConfig.CreateBuildingDef))]
    public class LifeSupport
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
    [HarmonyPatch(typeof(DevHEPSpawnerConfig), nameof(DevHEPSpawnerConfig.CreateBuildingDef))]
    public class HEP
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
    [HarmonyPatch(typeof(DevPumpGasConfig), nameof(DevPumpGasConfig.CreateBuildingDef))]
    public class PumpGas
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
    [HarmonyPatch(typeof(DevPumpLiquidConfig), nameof(DevPumpLiquidConfig.CreateBuildingDef))]
    public class Pump
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
    [HarmonyPatch(typeof(DevRadiationGeneratorConfig), nameof(DevRadiationGeneratorConfig.CreateBuildingDef))]
    public class Radiation
    {
        static void Postfix(BuildingDef __result)
        {
            __result.DebugOnly = false;
        }
    }
}
