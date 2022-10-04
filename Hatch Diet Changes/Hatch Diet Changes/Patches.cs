using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace HatchDietChanges
{
	public class conv
	{
		public const float c140kg = 140f / 140f;
		public const float c100kg = 140f / 100f;
	}
	public class Patches
	{
		[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.BasicRockDiet))]
		public class RegularHatchPatch
		{
			public static bool Prefix(
				Tag poopTag,
				float caloriesPerKg,
				float producedConversionRate,
				string diseaseId,
				float diseasePerKgProduced)
			{
				return true;
			}
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
					SimHashes.Regolith.CreateTag()
				}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Salt.CreateTag()
				}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));

				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Iron.CreateTag()
				}), SimHashes.IronOre.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Gold.CreateTag()
				}), SimHashes.GoldAmalgam.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Copper.CreateTag()
				}), SimHashes.Cuprite.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Tungsten.CreateTag()
				}), SimHashes.Wolframite.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Aluminum.CreateTag()
				}), SimHashes.AluminumOre.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));

				if (DlcManager.IsExpansion1Active())
				{
					__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
					{
					SimHashes.Cobalt.CreateTag()
					}), SimHashes.Cobaltite.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
					__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
					{
					SimHashes.DepletedUranium.CreateTag()
					}), SimHashes.UraniumOre.CreateTag(), caloriesPerKg * conv.c100kg, 0.95f, diseaseId, diseasePerKgProduced));
				}
			}
		}


		[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.VeggieDiet))]
		public class VeggiePatch
		{
			public static bool Prefix(
				Tag poopTag,
				float caloriesPerKg,
				float producedConversionRate,
				string diseaseId,
				float diseasePerKgProduced)
			{
				return true;
			}
			public static void Postfix(
				Tag poopTag,
				float caloriesPerKg,
				float producedConversionRate,
				string diseaseId,
				float diseasePerKgProduced,
				ref List<Diet.Info> __result)
			{
				if (DlcManager.IsExpansion1Active())
				{
					__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
					{
						SimHashes.Mud.CreateTag()
					}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
					__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
					{
						SimHashes.ToxicMud.CreateTag()
					}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				}


				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Sulfur.CreateTag()
				}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Phosphorite.CreateTag()
				}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Salt.CreateTag()
				}), SimHashes.Carbon.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
			}
		}


		[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.HardRockDiet))]
		public class StoneHatch_RemoveObsidian_AddGlass_AddKatairite
		{
			public static bool Prefix(
				Tag poopTag,
				float caloriesPerKg,
				float producedConversionRate,
				string diseaseId,
				float diseasePerKgProduced)
			{
				return true;
			}
			public static void Postfix(
				Tag poopTag,
				float caloriesPerKg,
				float producedConversionRate,
				string diseaseId,
				float diseasePerKgProduced,
				ref List<Diet.Info> __result)
			{
				for (int i = 0; i < __result.Count; i++)
				{
					if (__result[i].consumedTags.Contains(SimHashes.Obsidian.CreateTag()))
					{
						__result[i].consumedTags.Remove(SimHashes.Obsidian.CreateTag());
					}
				}

				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Katairite.CreateTag()
				}), SimHashes.Wolframite.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Glass.CreateTag()
				}), SimHashes.Obsidian.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				{
					SimHashes.Fossil.CreateTag()
				}), SimHashes.Lime.CreateTag(), caloriesPerKg * conv.c100kg, 0.25f, diseaseId, diseasePerKgProduced));
			}
		}

		[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.MetalDiet))]
		public class SmoothHatch_AddRefinedCarbon
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
					SimHashes.RefinedCarbon.CreateTag()
				 }), SimHashes.Diamond.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));
				__result.Add(new Diet.Info(new HashSet<Tag>((IEnumerable<Tag>)new Tag[1]
				 {
					SimHashes.Rust.CreateTag()
				 }), SimHashes.Iron.CreateTag(), caloriesPerKg, producedConversionRate, diseaseId, diseasePerKgProduced));

			}
		}

		[HarmonyPatch(typeof(BaseHatchConfig), nameof(BaseHatchConfig.SetupDiet))]
		public class StoneHatch_RemoveWolframite
		{
			public static bool Prefix(
				GameObject prefab,
				ref List<Diet.Info> diet_infos,
				float referenceCaloriesPerKg,
				float minPoopSizeInKg)
			{
				foreach (Diet.Info e in diet_infos)
				{
					if (e.producedElement.ToString() == "Carbon") //Remove Wolframite from stone hatch
						if (e.consumedTags.Contains(SimHashes.Wolframite.CreateTag()))
							e.consumedTags.Remove(SimHashes.Wolframite.CreateTag());

					if (e.producedConversionRate == TUNING.CREATURES.CONVERSION_EFFICIENCY.BAD_1) //Remove Rust from stone hatch
					{
						if (e.producedElement.ToString().Equals("Iron"))
						{
							if (e.consumedTags.Contains(SimHashes.Rust.CreateTag()))
							{
								e.consumedTags.Remove(SimHashes.Rust.CreateTag());
							}
						}
					}
					if (e.producedConversionRate == TUNING.CREATURES.CONVERSION_EFFICIENCY.BAD_1) //Remove Refined Carbon from stone hatch
					{
						if (e.producedElement.ToString().Equals("Diamond"))
						{
							if (e.consumedTags.Contains(SimHashes.RefinedCarbon.CreateTag()))
							{
								e.consumedTags.Remove(SimHashes.RefinedCarbon.CreateTag());
							}
						}
					}
				}


				return true;
			}
		}
	}
}