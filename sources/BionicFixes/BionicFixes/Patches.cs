using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace BionicFixes
{
    [HarmonyPatch(typeof(ElectrobankConfig), nameof(ElectrobankConfig.CreatePrefab))]
    public static class PowerBank
    {
        public static void Postfix(ref GameObject __result)
        {
            __result.GetComponent<PrimaryElement>().MassPerUnit = 1f;
        }
    }

    [HarmonyPatch(typeof(DisposableElectrobankConfig), "CreateDisposableElectrobank")]
    public static class EcoPowerBank
    {
        public static void Postfix(ref GameObject __result)
        {
            __result.GetComponent<PrimaryElement>().MassPerUnit = 1f;
        }
    }

    [HarmonyPatch(typeof(EmptyElectrobankConfig), nameof(EmptyElectrobankConfig.CreatePrefab))]
    public static class EmptyPowerBank
    {
        public static void Postfix(ref GameObject __result)
        {
            __result.GetComponent<PrimaryElement>().MassPerUnit = 1f;
        }
    }

}
