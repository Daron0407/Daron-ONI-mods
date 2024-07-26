using HarmonyLib;
using UnityEngine;

namespace Heaters_Expanded
{
    [HarmonyPatch(typeof(SpaceHeaterConfig), nameof(SpaceHeaterConfig.ConfigureBuildingTemplate))]
    public class SpaceHeaterConfig_TargetTemperatureConfig
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {
            SpaceHeater sh = go.GetComponent<SpaceHeater>();
            sh.targetTemperature = globals.temperature(Config.Instance.SHtarget);
        }
    }
}
