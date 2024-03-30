using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchancementDrugs
{
    public class Units
    {
        public static float cycles = 600f;
        public static float seconds = 1f;
        public static float percent = .01f;
        public static float percentPerCycle = .01f / 6f;
        public static float points = 1f;
        public static float caloriesPerCycle = 10f / 6f;
        public static float radsPerCycle = 1f / 600f;
        public static float hitPointsPerCycle = .01f / 6f;
        public static float kiloGrams = 1f;
        public static float grams = .001f;
    }
    public class Attributes
    {
        public static string stress = "StressDelta";
        public static string airConsumptionRate = "AirConsumptionRate";
        public static string germResistance = "GermResistance";
        public static string toiletEfficiency = "ToiletEfficiency";
        public static string bladder = "BladderDelta";
        public static string hitPoints = "HitPointsDelta";
        public static string stamina = "StaminaDelta";
        public static string radiationResistance = "RadiationResistance";
        public static string radiation = "RadiationRecovery";
        public static string calories = "CaloriesDelta";
        public class skills
        {
            public static string Athletics = "Athletics";
            public static string Creativity = "Art";
            public static string Science = "Learning";
            public static string Strength = "Strength";
            public static string Medicine = "Caring";
            public static string Construction = "Construction";
            public static string Digging = "Digging";
            public static string Machinery = "Machinery";
            public static string Cooking = "Cooking";
            public static string Farming = "Botanist";
            public static string Ranching = "Ranching";
            public static string Piloting = "SpaceNavigation";
            public static readonly string[] ALL_SKILLS = new string[]
            {
              "Strength",
              "Caring",
              "Construction",
              "Digging",
              "Machinery",
              "Learning",
              "Cooking",
              "Botanist",
              "Art",
              "Ranching",
              "Athletics",
              "SpaceNavigation"
            };
        }

    }
}
