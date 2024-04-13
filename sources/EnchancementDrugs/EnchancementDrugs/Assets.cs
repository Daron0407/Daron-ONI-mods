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
        private static KAnimFile GetKanim(string kanim)
        {
            return Assets.GetAnim((HashedString)kanim);
        }
        public static Kanims Instance;

        public static KAnimFile pill_1;
        public static KAnimFile pill_2;
        public static KAnimFile pill_3;
        public static KAnimFile allergy_pill;
        public static KAnimFile diarrhea_pill;
        public static KAnimFile radiation_pill;
        public static KAnimFile serum_vial;
        public static KAnimFile radiation_vial;
        public static KAnimFile med_pack;

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new Kanims();
            }
        }
        public Kanims()
        {
            if (Instance == null)
            {
                pill_1 = GetKanim("pill_1_kanim");
                pill_2 = GetKanim("pill_2_kanim");
                pill_3 = GetKanim("pill_3_kanim");
                allergy_pill = GetKanim("pill_allergies_kanim");
                diarrhea_pill = GetKanim("pill_foodpoisoning_kanim");
                radiation_pill = GetKanim("pill_radiation_kanim");
                serum_vial = GetKanim("vial_spore_kanim");
                radiation_vial = GetKanim("vial_radiation_kanim");
                med_pack = GetKanim("iv_slimelung_kanim");
                Instance = this;
            }
        }
    }

    public class MedicineStations
    {
        public static string SelfApplied = null;
        public static string SickBay = "DoctorStation";
        public static string DiseaseClinic = "AdvancedDoctorStation";
    }
}
