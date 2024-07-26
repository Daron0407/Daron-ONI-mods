using System;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace Heaters_Expanded
{

    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        [JsonProperty]
        [Option("Space heater target temperature", "")]
        [Limit(0, 2000)]
        public int SHtarget { get; set; }



        [JsonProperty]
        [Option("Liquid tepedizer heating", "")]
        [Limit(0, 4064 * 16)]
        public int LTheating { get; set; }

        [JsonProperty]
        [Option("Liquid tepedizer wattage cost", "")]
        [Limit(0, 960 * 16)]
        public int LTwattage { get; set; }

        [JsonProperty]
        [Option("Liquid tepedizer target temperature", "")]
        [Limit(0, 2000)]
        public int LTtarget { get; set; }

        public Config()
        {
            SHtarget = 70;

            LTwattage = 960;
            LTheating = 4096;
            LTtarget = 85;
        }
    }
}
