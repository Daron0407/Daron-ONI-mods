using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class ExperimentalPillConfig : IEntityConfig
    {
        public const string ID = "Experiment_52C";
        public static ComplexRecipe recipe;
        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, MedicineStations.SelfApplied);
        public static Condition condition;

        public GameObject CreatePrefab()
        {
            condition = new Condition(Conditions.none);
            string name = PILLS.EXPERIMENTALPILL.NAME;
            string desc = PILLS.EXPERIMENTALPILL.DESC;
            string recipeDescr = PILLS.EXPERIMENTALPILL.RECIPE.DESC;
            Kanims.Instantiate();
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, desc, 1f, true, Kanims.radiation_vial, "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);


            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Steel.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Resin.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Sulfur.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Petroleum.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.EnrichedUranium.CreateTag(), .1f),
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = 500f,
                description = recipeDescr,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                  {
                    (Tag) "Apothecary"
                  },
                requiredTech = "MedicineIV",
                sortOrder = 6
            };

            return looseEntity;
        }

        public string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_EXPANSION1_ONLY;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }

        public class PillEffect
        {
            public static string Id = effectId;
            public Effect effect;
            public PillEffect()
            {
                string name = PILLS.EXPERIMENTALPILL.EFFECT.NAME;
                string tooltip = PILLS.EXPERIMENTALPILL.EFFECT.TOOLTIP;

                float duration = .8f * Units.cycles;
                effect = new Effect(Id, name, tooltip, duration, true, true, false, null, 0.0f, null);
                effect.Add(new AttributeModifier(Attributes.stress, 125f * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.germResistance, 5f * Units.points, name));
                effect.Add(new AttributeModifier(Attributes.hitPoints, 100f * Units.hitPointsPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.stamina, 200f * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.radiation, 300f * Units.radsPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.calories, 2000f * Units.caloriesPerCycle, name));

                foreach (string skill in Attributes.skills.ALL_SKILLS)
                {
                    effect.Add(new AttributeModifier(skill, 3f * Units.points, name));
                }
            }
        }
    }
}
