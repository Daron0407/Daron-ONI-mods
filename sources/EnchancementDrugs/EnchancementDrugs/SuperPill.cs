using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnchancementDrugs
{
    public class SuperPillConfig : IEntityConfig
    {
        public const string ID = "SuperPill";
        public static ComplexRecipe recipe;
        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo superPill = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, null);

        public GameObject CreatePrefab()
        {
            string name = STRINGS.UI.PILLS.SUPER_PILL.NAME;
            string desc = STRINGS.UI.PILLS.SUPER_PILL.DESC;
            string recipeDescr = STRINGS.UI.PILLS.SUPER_PILL.RECIPE.DESC;
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, desc, 1f, true, Assets.GetAnim((HashedString)"pill_1_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, superPill);


            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) SwampLilyFlowerConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(new Tag("Carbon"), 1f)
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

        public class SuperPillEffect
        {
            public static string Id = effectId;
            public Effect effect;
            public SuperPillEffect() 
            {
                string name = STRINGS.UI.PILLS.SUPER_PILL.EFFECT.NAME;
                string tooltip = STRINGS.UI.PILLS.SUPER_PILL.EFFECT.TOOLTIP;

                float duration = 365f * Units.cycles;
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

}
