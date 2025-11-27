using Klei.AI;
using UnityEngine;

namespace EnchancementDrugs
{
    public class Conditions
    {
        public const string none = nameof(none);
        public const string radTreshold = nameof(radTreshold);
        public const string stressTreshold = nameof(stressTreshold);
        public const string staminaTreshold = nameof(staminaTreshold);
        public const string healthTreshold = nameof(healthTreshold);

        public const string bionicRestricted = nameof(bionicRestricted);
        public const string bionicOnly = nameof(bionicOnly);
    }

    public class Compare
    {
        public const bool higher = false;
        public const bool lower = true;
    }
    public class Condition
    {
        private string conditionType;
        private float value;
        private bool compareBy;
        public Condition(string conditionType, float value = 0f, bool compareBy = false)
        {
            this.conditionType = conditionType;
            this.value = value;
            this.compareBy = compareBy;
        }

        public bool checkCondition(GameObject consumer)
        {
            bool bionic = consumer.GetAmounts().Get(Db.Get().Amounts.BionicOxygenTank.Id) != null;
            float radiationBalance = consumer.GetAmounts().Get(Db.Get().Amounts.RadiationBalance.Id).value;
            float stress = consumer.GetAmounts().Get(Db.Get().Amounts.Stress.Id).value;
            float health = consumer.GetAmounts().Get(Db.Get().Amounts.HitPoints.Id).value;
            float stamina = 0f;
            if(!bionic) 
                stamina = consumer.GetAmounts().Get(Db.Get().Amounts.Stamina.Id).value;
            switch (conditionType)
            {
                case Conditions.radTreshold:
                    if (compareBy == Compare.lower)
                        return radiationBalance <= value;
                    return radiationBalance >= value;
                case Conditions.stressTreshold:
                    if (compareBy == Compare.lower)
                        return stress <= value;
                    return stress >= value;
                case Conditions.staminaTreshold:
                    if (compareBy == Compare.lower)
                        return stamina <= value;
                    return stamina >= value;
                case Conditions.healthTreshold:
                    if (compareBy == Compare.lower)
                        return health <= value;
                    return health >= value;
                case Conditions.bionicOnly:
                    return bionic;
                case Conditions.bionicRestricted:
                    return !bionic;

                default:
                    return true;
            }
        }
    }
}
