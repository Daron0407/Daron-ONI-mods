using Klei.AI;

namespace EnchancementDrugs
{
    public class Units
    {
        public static float cycles = 600f;
        public static float seconds = 1f;
        public static float percent = .01f;
        public static float percentPerCycle = 1f / 600f;
        public static float points = 1f;
        public static float caloriesPerCycle = 10f / 6f;
        public static float radsPerCycle = 1f / 600f;
        public static float hitPointsPerCycle = 1f / 600f;
        public static float kilograms = 1f;
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
        public static string morale = "QualityOfLife";
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

    public class Kanims
    {
        public static class Pills
        {
            public static string pill_1 = "pill_1_kanim";
            public static string pill_2 = "pill_2_kanim";
            public static string pill_3 = "pill_3_kanim";
            public static string allergy_pill = "pill_allergies_kanim";
            public static string diarrhea_pill = "pill_foodpoisoning_kanim";
            public static string radiation_pill = "pill_radiation_kanim";
            public static string serum_vial = "vial_spore_kanim";
            public static string radiation_vial = "vial_radiation_kanim";
            public static string med_pack = "iv_slimelung_kanim";
        }

        public static KAnimFile getPillKanimFile(string pill)
        {
            return Assets.GetAnim((HashedString)pill);
        }
    }

    public static class MedicineStations
    {
        public static string SelfApplied = null;
        public static string SickBay = "DoctorStation";
        public static string DiseaseClinic = "AdvancedDoctorStation";
    }


    public static class Utility
    {
        public static Effect MakeEffect(string id, string name, string tooltip, float duration)
        {
            return new Effect(id, name, tooltip, duration, true, true, false, null, 0.0f, null);
        }
    }
}
