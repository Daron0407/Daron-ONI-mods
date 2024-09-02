using System;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace Advanced_Coolers
{
    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        [JsonProperty]
        [Option("Require fullerene to build", "")]
        public bool Fullerene { get; set; }

        [JsonProperty]
        [Option("Space Cooler Cooling", "")]
        [Limit(1, 1024)]
        public int SCCooling { get; set; }

        [JsonProperty]
        [Option("Space Cooler Wattage Cost", "")]
        [Limit(10, 2000)]
        public int SCWattage { get; set; }



        [JsonProperty]
        [Option("Liquid Cooler Cooling", "")]
        [Limit(16, 1024 * 8)]
        public int LCCooling { get; set; }

        [JsonProperty]
        [Option("Liquid Cooler Wattage Cost", "")]
        [Limit(0, 4000)]
        public int LCWattage { get; set; }

        public Config()
        {
            Fullerene = true;
            SCCooling = 64;
            SCWattage = 60;
            LCCooling = 2048;
            LCWattage = 960;
        }
    }
}
