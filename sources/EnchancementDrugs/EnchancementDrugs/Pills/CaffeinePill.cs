using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class CaffeinePillConfig : PillBaseConfig
    {
        public const string ID = "CaffeinePill";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Caffeine Pill";
        public const string description = "A duplicant will take this when tired";
        public const string recipeDescription = "A pill that decreases tiredness. A duplicant will take this when tired";

        public const string effectName = "Caffeinated";
        public const string effectTooltip = "Decreases tiredness";
        public const float durationCycles = Default.pillDuration;

        public const string effectId = "Medicine_" + ID;
        public static Condition tiredCondition;
        public static Condition bionicRestricted;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            tiredCondition = new Condition(Conditions.staminaTreshold, 60f, Compare.lower);
            bionicRestricted = new Condition(Conditions.bionicRestricted);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.pill_1), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) SwampLilyFlowerConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement((Tag) SpiceNutConfig.ID, 1f)
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
            effect.Add(new AttributeModifier(Attributes.stamina, 30f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.stress, 10f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.calories, -200f * Units.caloriesPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.skills.Science, -4f * Units.points, name));
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return tiredCondition.checkCondition(consumer) && bionicRestricted.checkCondition(consumer);
        }
    }
}
