using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class ExperimentalPillConfig : PillBaseConfig
    {
        public const string ID = "Experiment_52C";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Experiment 52C";
        public const string description = "Expermiental drug tested by Gravitas Facility bioengineering division";
        public const string recipeDescription = "An experimantal drug";

        public const string effectName = "Boost 52C";
        public const string effectTooltip = "I'm sure this is safe";
        public const float durationCycles = 0.8f;

        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.radiation_vial), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Steel.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Sulfur.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Petroleum.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.EnrichedUranium.CreateTag(), 0.1f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", inputs, outputs), inputs, outputs)
            {
                time = 300f,
                description = recipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                  {
                    (Tag) "Apothecary"
                  },
                requiredTech = requiredTech,
                sortOrder = 6
            };
        }

        public static Effect GetPillEffect()
        {
            float duration = durationCycles * Units.cycles;
            Effect effect = Utility.MakeEffect(effectId, effectName, effectTooltip, duration);
            effect.Add(new AttributeModifier(Attributes.stress, 100f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.stamina, -40f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.radiation, 300f * Units.radsPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.calories, -1000f * Units.caloriesPerCycle, name));

            foreach (string skill in Attributes.skills.ALL_SKILLS)
            {
                effect.Add(new AttributeModifier(skill, 10f * Units.points, name));
            }
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return true;
        }
    }
}
