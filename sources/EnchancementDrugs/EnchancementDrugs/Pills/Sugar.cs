using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnchancementDrugs
{
    public class SugarConfig : IEntityConfig
    {
        public const string ID = "Sugar";
        public static ComplexRecipe recipe;
        public const string effectId = "Medicine_" + ID;
        public static MedicineInfo medicineInfo = new MedicineInfo(ID, effectId, MedicineInfo.MedicineType.Booster, MedicineStations.SelfApplied);
        public static Condition condition;

        public GameObject CreatePrefab()
        {
            condition = new Condition(Conditions.none);
            string name = PILLS.SUGAR.NAME;
            string desc = PILLS.SUGAR.DESC;
            string recipeDescr = PILLS.SUGAR.RECIPE.DESC;
            Kanims.Instantiate();
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, name, desc, 1f, true, Kanims.diarrhea_pill, "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
            EntityTemplates.ExtendEntityToMedicine(looseEntity, medicineInfo);


            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[]
            {
                    new ComplexRecipe.RecipeElement((Tag) ID, 10f)
            };
            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = 30f,
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
                string name = PILLS.SUGAR.EFFECT.NAME;
                string tooltip = PILLS.SUGAR.EFFECT.TOOLTIP;

                float duration = 1f * Units.cycles;
                effect = new Effect(Id, name, tooltip, duration, true, true, false, null, 0.0f, null);
                effect.Add(new AttributeModifier(Attributes.stress, -5 * Units.percentPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.calories, 100f * Units.caloriesPerCycle, name));
                effect.Add(new AttributeModifier(Attributes.skills.Athletics, 1f * Units.points, name));
                
            }
        }
    }

}
