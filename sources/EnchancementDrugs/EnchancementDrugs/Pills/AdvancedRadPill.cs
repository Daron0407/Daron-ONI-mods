using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class AdvancedRadPillConfig : PillBaseConfig
    {
        public const string ID = "AdvancedRadPill";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Advanced Rad Pill";
        public const string description = "Increases a Duplicant's natural radiation absorption rate.";
        public const string recipeDescription = "A supplement that speeds up the rate at which a Duplicant body absorbs radiation, allowing them to manage increased radiation exposure.";

        public const string effectName = "Advanced Rad Pill";
        public const string effectTooltip = "Decreases rads";
        public const float durationCycles = Default.pillDuration;


        public const string effectId = "Medicine_" + ID;
        public static Condition highRadiation;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            highRadiation = new Condition(Conditions.radTreshold, 60f, Compare.higher);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.radiation_vial), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) RadPillConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Diamond.CreateTag(), 1f)
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
            effect.Add(new AttributeModifier(Attributes.radiationResistance, 15f * Units.percent, name));
            effect.Add(new AttributeModifier(Attributes.radiation, -150f * Units.radsPerCycle, name));
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return highRadiation.checkCondition(consumer);
        }
    }

}
