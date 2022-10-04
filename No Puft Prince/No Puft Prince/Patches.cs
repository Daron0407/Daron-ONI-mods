using HarmonyLib;
using TUNING;
using System.Collections.Generic;
using KMod;




namespace No_Puft_Prince
{
    /*
    [HarmonyPatch]
    public class Patch
    {
        [HarmonyReversePatch(HarmonyReversePatchType.Original)]
        [HarmonyPatch(typeof(TUNING.CREATURES.EGG_CHANCE_MODIFIERS), "CreateTemperatureModifier")]
        public static System.Action MyModifier(
        string id,
        Tag eggTag,
        float minTemp,
        float maxTemp,
        float modifierPerSecond,
        bool alsoInvert)
        {
           throw new System.Exception("Not implemented this stub");
        }
    }*/




    class Globalpatches : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            //System.Reflection.MethodInfo original = typeof(TUNING.CREATURES.EGG_CHANCE_MODIFIERS).GetMethod("CreateTemperatureModifier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //System.Action add1 = (System.Action) original.Invoke(null, new object[] { "PuftOxylite", "PuftOxyliteEgg".ToTag(), 273.15f + 35f, 273.15f + 100f, 8.333333E-05f, false });
            //System.Action add2 = (System.Action) original.Invoke(null, new object[] { "PuftBleachstone", "PuftBleachstoneEgg".ToTag(), 273.15f - 50f, 273.15f + 5f, 8.333333E-05f, false });


            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.RemoveAt(3);
            //TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.Add(add1);
            //TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.Add(add2);
            //TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.Add(Patch.MyModifier("PuftOxylite", "PuftOxyliteEgg".ToTag(), 273.15f + 35f, 273.15f + 100f, 8.333333E-05f, false));
            //TUNING.CREATURES.EGG_CHANCE_MODIFIERS.MODIFIER_CREATORS.Add(Patch.MyModifier("PuftBleachstone", "PuftBleachstoneEgg".ToTag(), 273.15f - 50f, 273.15f + 5f, 8.333333E-05f, false));
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