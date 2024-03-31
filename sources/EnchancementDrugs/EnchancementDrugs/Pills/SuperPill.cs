using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    /* This is a testing drug
    public class SuperPillConfig : IEntityConfig
    {
        public const string ID = "SuperPill";
        public static ComplexRecipe recipe;
        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, MedicineStations.SelfApplied);
        public static Condition condition;

        public GameObject CreatePrefab()
        {
            condition = new Condition(Conditions.none);
            string name = PILLS.SUPERPILL.NAME;
            string desc = PILLS.SUPERPILL.DESC;
            string recipeDescr = PILLS.SUPERPILL.RECIPE.DESC;
            Kanims.Instantiate();
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, desc, 1f, true, Kanims.pill_1, "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);


            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) SwampLilyFlowerConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = 100f,
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
            return DlcManager.AVAILABLE_ALL_VERSIONS;
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
                string name = PILLS.SUPERPILL.EFFECT.NAME;
                string tooltip = PILLS.SUPERPILL.EFFECT.TOOLTIP;

                float duration = 1f * Units.cycles;
                effect = new Effect(Id, name, tooltip, duration, true, true, false, null, 0.0f, null);
                effect.Add(new AttributeModifier(Attributes.stress, -100f * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.airConsumptionRate, -99f * Units.grams, name));
                effect.Add(new AttributeModifier(Attributes.germResistance, 5f * Units.points, name));
                effect.Add(new AttributeModifier(Attributes.toiletEfficiency, -90f * Units.percent, name));
                effect.Add(new AttributeModifier(Attributes.bladder, -100f * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.hitPoints, 100f * Units.hitPointsPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.stamina, 70f * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.radiationResistance, 99f * Units.percent, name));
                effect.Add(new AttributeModifier(Attributes.radiation, -100f * Units.radsPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.calories, 4000f * Units.caloriesPerCycle, name));

                foreach (string skill in Attributes.skills.ALL_SKILLS)
                {
                    effect.Add(new AttributeModifier(skill, 10f * Units.points, name));
                }
            }
        }
    }
    //*/

}
