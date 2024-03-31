using Klei.AI;
using UnityEngine;

namespace EnchancementDrugs
{
    public class Conditions
    {
        public static string none = nameof(none);
        public static string radTreshold = nameof(radTreshold);
        public static string stressTreshold = nameof(stressTreshold);
        public static string staminaTreshold = nameof(staminaTreshold);
    }

    public class Compare
    {
        public static readonly bool higher = false;
        public static readonly bool lower = true;
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

        public bool checkCondition(MedicinalPill pill, GameObject consumer)
        {
            if (conditionType == Conditions.none)
            {
                return true;
            }
            if (conditionType == Conditions.radTreshold)
            {
                if (compareBy == Compare.lower)
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.RadiationBalance.Id).value <= value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.RadiationBalance.Id).value >= value)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (conditionType == Conditions.stressTreshold)
            {
                if (compareBy == Compare.lower)
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.Stress.Id).value <= value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.Stress.Id).value >= value)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (conditionType == Conditions.staminaTreshold)
            {
                if (compareBy == Compare.lower)
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.Stamina.Id).value <= value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.Stamina.Id).value >= value)
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
    }
}
