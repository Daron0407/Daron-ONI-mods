using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using PeterHan.PLib.UI;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace Heaters_Expanded
{

    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        [JsonProperty]
        [Option("Space Heater Heating", "")]
        [Limit(-4096f, 4096f)]
        public float SHheating { get; set; }

        [JsonProperty]
        [Option("Space Heater Wattage Cost", "")]
        [Limit(0f, 2000f)]
        public float SHwattage { get; set; }



        [JsonProperty]
        [Option("Liquid Tepedizer Heating", "")]
        [Limit(-4064f * 16, 4064f * 16)]
        public float LTheating { get; set; }

        [JsonProperty]
        [Option("Liquid Tepedizer Wattage Cost", "")]
        [Limit(0f, 960f * 16f)]
        public float LTwattage { get; set; }

        public Config()
        {
            SHheating = 18f;
            SHwattage = 120f;

            LTwattage = 960f;
            LTheating = 4096f;
        }
    }
}
