using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooledStorage
{
    public static class Setup
    {
        public static float SimulatedThermalConductivity = 1000f;
        public static float SimulatedHeatCapacity = 10f;
        public static float Overheat = 75f;
        public static class CooledStorage
        {
            public static string name = "Cooled Storage Bin";
            public static string description = "Stores solids in a cooled manner";
            //Cooling
            public static float EnergyUsage = 60f;
            public static float SimulatedTemperature = 20f;
            public static float HeatOutputAC = 1f;
            //EnergySaverMode
            public static float EnergySaverMode = 10f;
            public static float HeatOutputWhenEnergySaving = .125f;
        }
        public static class ChilledStorage
        {
            public static string name = "Chilled Storage Bin";
            public static string description = "Stores solids in a chilled manner";
            //Cooling
            public static float EnergyUsage = 120f;
            public static float SimulatedTemperature = -5f;
            public static float HeatOutputAC = 2f;
            //EnergySaverMode
            public static float EnergySaverMode = 20f;
            public static float HeatOutputWhenEnergySaving = .25f;
        }
        public static class FrozenStorage
        {
            public static string name = "Frozen Storage Bin";
            public static string description = "Stores solids in a frozen manner";
            //Cooling
            public static float EnergyUsage = 240f;
            public static float SimulatedTemperature = -30f;
            public static float HeatOutputAC = 4f;
            //EnergySaverMode
            public static float EnergySaverMode = 40f;
            public static float HeatOutputWhenEnergySaving = .5f;
        }
        public static class CryoStorage
        {
            public static string name = "Cryo Storage Bin";
            public static string description = "Stores solids in a cryogenic manner";
            //Cooling
            public static float EnergyUsage = 480f;
            public static float SimulatedTemperature = -270f;
            public static float HeatOutputAC = 8f;
            //EnergySaverMode
            public static float EnergySaverMode = 80f;
            public static float HeatOutputWhenEnergySaving = 1f;
        }
    }
}
