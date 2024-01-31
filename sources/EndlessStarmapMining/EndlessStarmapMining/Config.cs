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
        [Limit(1, 10000)]
        public int multiplier { get; set; }

        public Config()
        {
            multiplier = 10;
        }

    }
}
