using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace OilWellSizeReduced
{
    [HarmonyPatch(typeof(OilWellCapConfig), nameof(OilWellCapConfig.CreateBuildingDef))]
    public class Patch
    {
        public static void Postfix(ref BuildingDef __result)
        {
            __result.WidthInCells = 1;
            __result.HeightInCells = 1;
        }
    }
}
