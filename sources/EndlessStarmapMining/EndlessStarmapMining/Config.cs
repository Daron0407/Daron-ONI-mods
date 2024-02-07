using Newtonsoft.Json;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStarmapMining
{
    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        [JsonProperty]
        [Option("Mass Multiplier", "mass multiplier")]
        [Limit(1, 1000)]
        public int Massmultiplier { get; set; }

        [JsonProperty]
        [Option("Drillcone Storage Multiplier", "drillcone storage multiplier")]
        [Limit(1, 100)]
        public int drillconeMultiplier { get; set; }


        public Config()
        {
            Massmultiplier = 10;
            drillconeMultiplier = 2;
        }

    }
}
