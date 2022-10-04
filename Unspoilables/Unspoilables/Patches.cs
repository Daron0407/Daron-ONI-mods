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
            base.OnLoad(harmony);
        }
    }
}
