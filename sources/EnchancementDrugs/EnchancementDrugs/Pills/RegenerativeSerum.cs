using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class RegenrativeSerumConfig : PillBaseConfig
    {
        public const string ID = "RegenerativeSerum";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Regenerative Serum";
        public const string description = "Lets duplicants heal on the go";
        public const string recipeDescription = "Boosts duplican't natural regeneration ability";

        public const string effectName = "Regenerating";
        public const string effectTooltip = "Helps heal wounds";
        public const float durationCycles = 5f;

        public const string effectId = "Medicine_" + ID;
        public static Condition lowHealth;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            lowHealth = new Condition(Conditions.healthTreshold, 95, Compare.lower);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.med_pack), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement((Tag) SwampLilyFlowerConfig.ID, 1f)
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
            effect.Add(new AttributeModifier(Attributes.hitPoints, 5f * Units.hitPointsPerCycle, name));
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return lowHealth.checkCondition(consumer);
        }
    }
}
