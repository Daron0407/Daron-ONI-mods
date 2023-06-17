using System.Collections.Generic;
using HarmonyLib;

namespace Renewable_Abyssalite
{
	[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.HardRockDiet))]
	public class StoneHatchAddKatairite
	{
		public static void Postfix(
			Tag poopTag,
			float caloriesPerKg,
			float producedConversionRate,
			string diseaseId,
			float diseasePerKgProduced,
			ref List<Diet.Info> __result)
		{
			__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
			{
					SimHashes.Tungsten.CreateTag()
			}), SimHashes.Katairite.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
		}
	}
}
