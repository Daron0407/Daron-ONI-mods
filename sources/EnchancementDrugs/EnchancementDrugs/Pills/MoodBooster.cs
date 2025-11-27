using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class MoodBoosterConfig : PillBaseConfig
    {
        public const string ID = "MoodBooster";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Mood Booster";
        public const string description = "A duplicant will take this when really stressed out";
        public const string recipeDescription = "A Pill that alievieates stress. A duplicant will take this when really stressed out";

        public const string effectName = "Chilled Out";
        public const string effectTooltip = "Significantly decreases stress";
        public const float durationCycles = Default.pillDuration;

        public const string effectId = "Medicine_" + ID;
        public static Condition highStress;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            highStress = new Condition(Conditions.stressTreshold, 60f, Compare.higher);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.pill_3), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) SwampLilyFlowerConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Ethanol.CreateTag(), 1f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", inputs, outputs), inputs, outputs)
            {
                time = Default.fabricationSpeed,
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
            effect.Add(new AttributeModifier(Attributes.stress, -60f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.stamina, -30f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.morale, 2f * Units.points, name));
            effect.Add(new AttributeModifier(Attributes.skills.Strength, -2f * Units.points, name));
            effect.Add(new AttributeModifier(Attributes.skills.Athletics, -2f * Units.points, name));
            effect.Add(new AttributeModifier(Attributes.skills.Science, -2f * Units.points, name));
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return highStress.checkCondition(consumer);
        }
    }

}
