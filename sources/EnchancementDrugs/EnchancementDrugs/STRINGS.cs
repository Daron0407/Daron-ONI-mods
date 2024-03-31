using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchancementDrugs
{
    public class PILLS
    {

        public class SUPERPILL
        {
            public static LocString NAME = "Super Pill";
            public static LocString DESC = "Makes everything way to easy";
            public class RECIPE
            {
                public static LocString DESC = "A Pill that makes everything way to easy";
            }
            public class EFFECT
            {
                public static LocString NAME = "Super Pilled";
                public static LocString TOOLTIP = "Significantly improves well being";
            }
        }
        public class BUFFOUT
        {
            public static LocString NAME = "Buffout";
            public static LocString DESC = "Grants increased physique";
            public class RECIPE
            {
                public static LocString DESC = "A Pill that grants increased physique";
            }
            public class EFFECT
            {
                public static LocString NAME = "Buffed";
                public static LocString TOOLTIP = "Significantly improves buff";
            }
        }
        public class MOODBOOSTER
        {
            public static LocString NAME = "Mood Booster";
            public static LocString DESC = "A duplicant will take this when really stressed out";
            public class RECIPE
            {
                public static LocString DESC = "A Pill that alievieates stress. A duplicant will take this when really stressed out";
            }
            public class EFFECT
            {
                public static LocString NAME = "Chilled Out";
                public static LocString TOOLTIP = "Significantly decreases stress";
            }
        }
        public class SUGAR
        {
            public static LocString NAME = "Sugar";
            public static LocString DESC = "Decreases stress";
            public class RECIPE
            {
                public static LocString DESC = "A treat that decreases stress";
            }
            public class EFFECT
            {
                public static LocString NAME = "Sugared Up";
                public static LocString TOOLTIP = "Decreases stress";
            }
        }
        public class CAFFEINEPILL
        {
            public static LocString NAME = "Caffeine Pill";
            public static LocString DESC = "A duplicant will take this when tired";
            public class RECIPE
            {
                public static LocString DESC = "A pill that decreases tiredness. A duplicant will take this when tired";
            }
            public class EFFECT
            {
                public static LocString NAME = "Caffeinated";
                public static LocString TOOLTIP = "Decreases tiredness";
            }
        }
        public class RADPILL
        {
            public static LocString NAME = "Rad Pill";
            public static LocString DESC = "Increases a Duplicant's natural radiation absorption rate.";
            public class RECIPE
            {
                public static LocString DESC = "A supplement that speeds up the rate at which a Duplicant body absorbs radiation, allowing them to manage increased radiation exposure.";
            }
            public class EFFECT
            {
                public static LocString NAME = "Rad Pill";
                public static LocString TOOLTIP = "Decreases rads";
            }
        }
        public class ADVANCEDRADPILL
        {
            public static LocString NAME = "Advanced Rad Pill";
            public static LocString DESC = "Increases a Duplicant's natural radiation absorption rate.";
            public class RECIPE
            {
                public static LocString DESC = "A supplement that speeds up the rate at which a Duplicant body absorbs radiation, allowing them to manage increased radiation exposure.";
            }
            public class EFFECT
            {
                public static LocString NAME = "Advanced Rad Pill";
                public static LocString TOOLTIP = "Decreases rads";
            }
        }
        public class MENTATS
        {
            public static LocString NAME = "Mentats";
            public static LocString DESC = "Increases mental capacity.";
            public class RECIPE
            {
                public static LocString DESC = "A supplement that increases mental capacity";
            }
            public class EFFECT
            {
                public static LocString NAME = "Insighted";
                public static LocString TOOLTIP = "Incleases science and piloting";
            }
        }
        public class EXPERIMENTALPILL
        {
            public static LocString NAME = "Experiment 52C";
            public static LocString DESC = "Expermiental drug tested by Gravitas Facility bioengineering division";
            public class RECIPE
            {
                public static LocString DESC = "An experimantal drug";
            }
            public class EFFECT
            {
                public static LocString NAME = "Boost 52C";
                public static LocString TOOLTIP = "I'm sure this is safe";
            }
        }
    }

}
