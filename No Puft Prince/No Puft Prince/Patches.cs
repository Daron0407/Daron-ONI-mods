using HarmonyLib;
using TUNING;
using System.Collections.Generic;
using KMod;




namespace No_Puft_Prince
{
    class Globalpatches : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            PuftTuning.EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
              {
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftEgg".ToTag(),
                  weight = 0.8f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftAlphaEgg".ToTag(),
                  weight = 0.0f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftOxyliteEgg".ToTag(),
                  weight = 0.1f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftBleachstoneEgg".ToTag(),
                  weight = 0.1f
                }
              };


              PuftTuning.EGG_CHANCES_OXYLITE = new List<FertilityMonitor.BreedingChance>()
              {
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftEgg".ToTag(),
                  weight = 0.1f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftAlphaEgg".ToTag(),
                  weight = 0.0f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftOxyliteEgg".ToTag(),
                  weight = 0.8f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftBleachstoneEgg".ToTag(),
                  weight = 0.1f
                }
              };

              PuftTuning.EGG_CHANCES_BLEACHSTONE = new List<FertilityMonitor.BreedingChance>()
              {
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftEgg".ToTag(),
                  weight = 0.1f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftAlphaEgg".ToTag(),
                  weight = 0.0f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftOxyliteEgg".ToTag(),
                  weight = 0.1f
                },
                new FertilityMonitor.BreedingChance()
                {
                  egg = "PuftBleachstoneEgg".ToTag(),
                  weight = 0.8f
                }
              };
    }

    }



}