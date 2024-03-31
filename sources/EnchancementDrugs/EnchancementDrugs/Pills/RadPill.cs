using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace EnchancementDrugs
{
    public class RadPillConfig : IEntityConfig
    {
        public const string ID = "RadPill";
        public static ComplexRecipe recipe;
        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, MedicineStations.SelfApplied);
        public static Condition condition;

        public GameObject CreatePrefab()
        {
            condition = new Condition(Conditions.radTreshold, 40f, Compare.higher);
            string name = PILLS.RADPILL.NAME;
            string desc = PILLS.RADPILL.DESC;
            string recipeDescr = PILLS.RADPILL.RECIPE.DESC;
            Kanims.Instantiate();
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, desc, 1f, true, Kanims.allergy_pill, "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);


            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) BasicRadPillConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.RefinedCarbon.CreateTag(), 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 1f)
            };
            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = 60f,
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
                string name = PILLS.RADPILL.EFFECT.NAME;
                string tooltip = PILLS.RADPILL.EFFECT.TOOLTIP;

                float duration = 1f * Units.cycles;
                effect = new Effect(Id, name, tooltip, duration, true, true, false, null, 0.0f, null);
                effect.Add(new AttributeModifier(Attributes.radiationResistance, 10f * Units.percent, name));
                effect.Add(new AttributeModifier(Attributes.radiation, -125f * Units.radsPerCycle, name));

            }
        }
    }

}
