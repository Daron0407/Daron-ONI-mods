using HarmonyLib;
using KMod;
using Klei.AI;

namespace Unspoilables
{
    public class Patches : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            TUNING.FOOD.FOOD_TYPES.WORMSUPERFOOD.CanRot = false; //Grub fruit preserve unable to spoil
            TUNING.FOOD.FOOD_TYPES.PICKLEDMEAL.CanRot = false; //Pickled Meal unable to spoil
            TUNING.FOOD.FOOD_TYPES.FRUITCAKE.Quality = TUNING.FOOD.FOOD_QUALITY_AMAZING; //Increase Berry Sludge quality from 3 to 4
            TUNING.FOOD.FOOD_TYPES.BEAN.CanRot = false; //Nosh Bean
            TUNING.FOOD.FOOD_TYPES.COLD_WHEAT_SEED.CanRot = false; // Sleet Wheat Seed
            TUNING.FOOD.FOOD_TYPES.SPICENUT.CanRot = false; // Pincha Peppernut
            base.OnLoad(harmony);
        }
    }
}
