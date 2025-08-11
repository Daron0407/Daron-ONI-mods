using System;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace Advanced_Coolers
{
    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        private const string cooling_tooltip = "How much KDTU/s will this building remove when operating";
        private const string wattage_tooltip = "How many watts should this building use when working";
        [JsonProperty]
        [Option("Require fullerene to build", "Require space material fullerene to be built", Format ="F0")]
        public bool Fullerene { get; set; }

        [JsonProperty]
        [Option("Space Cooler Cooling", cooling_tooltip, Format = "F0")]
        [Limit(1, 1024)]
        public int SCCooling { get; set; }

        [JsonProperty]
        [Option("Space Cooler Wattage Cost", wattage_tooltip, Format = "F0")]
        [Limit(10, 2000)]
        public int SCWattage { get; set; }


        [JsonProperty]
        [Option("Liquid Cooler Cooling", cooling_tooltip, Format = "F0")]
        [Limit(16, 1024 * 8)]
        public int LCCooling { get; set; }

        [JsonProperty]
        [Option("Liquid Cooler Wattage Cost", wattage_tooltip, Format = "F0")]
        [Limit(10, 4000)]
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
