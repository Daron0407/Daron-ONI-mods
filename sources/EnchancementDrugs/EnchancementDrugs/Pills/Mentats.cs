using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class MentatsConfig : PillBaseConfig
    {
        public const string ID = "Mentats";
        public static string medicineStation = MedicineStations.SelfApplied;
        public static string requiredTech = "MedicineIV";

        public const string name = "Mentats";
        public const string description = "Increases mental capacity.";
        public const string recipeDescription = "A supplement that increases mental capacity";

        public const string effectName = "Insighted";
        public const string effectTooltip = "Increases science and piloting";
        public const float durationCycles = Default.pillDuration;

        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, medicineStation);

        public override GameObject CreatePrefab()
        {
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, description, 1f, true, Kanims.getPillKanimFile(Kanims.Pills.med_pack), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);
            GenerateRecipe();
            return looseEntity;
        }

        public override void GenerateRecipe()
        {
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Lime.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 1f),
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
            effect.Add(new AttributeModifier(Attributes.stamina, -10f * Units.percentPerCycle, name));
            effect.Add(new AttributeModifier(Attributes.skills.Science, 8f * Units.points, name));
            effect.Add(new AttributeModifier(Attributes.skills.Piloting, 8f * Units.points, name));
            return effect;
        }

        public static bool CheckConditions(GameObject consumer)
        {
            return true;
        }
    }
}
