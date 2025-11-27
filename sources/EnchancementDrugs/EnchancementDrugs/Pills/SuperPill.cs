using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    /* This is a testing drug
    public class SuperPillConfig : PillBaseConfig
    {
        public const string ID = "SuperPill";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Super Pill";
        public const string description = "Makes everything way too easy";
        public const string recipeDescription = "A Pill that makes everything way too easy";

        public const string effectName = "Super Pilled";
        public const string effectTooltip = "Significantly improves well being";
        public const float durationCycles = 100f;

        public const string effectId = "Medicine_" + ID;
        public static Condition condition;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            condition = new Condition(Conditions.none);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.pill_1), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 1f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", inputs, outputs), inputs, outputs)
            {
                time = 100f,
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
            effect.Add(new AttributeModifier(Attributes.stress, -100f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.hitPoints, 100f * Units.hitPointsPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.radiationResistance, 99f * Units.percent, name));
            effect.Add(new AttributeModifier(Attributes.radiation, -100f * Units.radsPerCycle, name));

            foreach (string skill in Attributes.skills.ALL_SKILLS)
            {
                effect.Add(new AttributeModifier(skill, 40f * Units.points, name));
            }
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return condition.checkCondition(consumer);
        }
    }
    //*/

}
