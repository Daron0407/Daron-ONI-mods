using System.Collections.Generic;

public class Setup
{
    // Already existing
    public static HashSet<Tag> regulaHatchCarbon()
    {
        return new HashSet<Tag>() { SimHashes.Regolith.CreateTag(), SimHashes.Salt.CreateTag() };
    }

    public static List<Tuple<Tag, Tag>> regularHatchMetals()
    {
        List<Tuple<Tag, Tag>> result = new List<Tuple<Tag, Tag>>() {
            new Tuple<Tag, Tag>(SimHashes.Iron.CreateTag(), SimHashes.IronOre.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Copper.CreateTag(), SimHashes.Cuprite.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Gold.CreateTag(), SimHashes.GoldAmalgam.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Aluminum.CreateTag(), SimHashes.AluminumOre.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Tungsten.CreateTag(), SimHashes.Wolframite.CreateTag()),
        };

        if (DlcManager.IsExpansion1Active())
        {
            result.Add(new Tuple<Tag, Tag>(SimHashes.Cobalt.CreateTag(), SimHashes.Cobaltite.CreateTag()));
            result.Add(new Tuple<Tag, Tag>(SimHashes.DepletedUranium.CreateTag(), SimHashes.UraniumOre.CreateTag()));
        }
        if (Game.IsDlcActiveForCurrentSave(DlcManager.DLC2_ID))
        {
            result.Add(new Tuple<Tag, Tag>(SimHashes.SolidMercury.CreateTag(), SimHashes.Cinnabar.CreateTag()));
        }
        if (Game.IsDlcActiveForCurrentSave(DlcManager.DLC3_ID))
        {
            result.Add(new Tuple<Tag, Tag>(SimHashes.Nickel.CreateTag(), SimHashes.NickelOre.CreateTag()));
        }

        return result;
    }

    public static HashSet<Tag> veggieHatchCarbon()
    {
        var result = new HashSet<Tag>()
        {
            SimHashes.Sulfur.CreateTag(),
            SimHashes.Phosphorite.CreateTag(),
            SimHashes.Salt.CreateTag()
        };
        if (DlcManager.IsExpansion1Active())
        {
            result.Add(SimHashes.Mud.CreateTag());
            result.Add(SimHashes.ToxicMud.CreateTag());
        }
        if (Game.IsDlcActiveForCurrentSave(DlcManager.DLC3_ID))
        {
            result.Add(SimHashes.Peat.CreateTag());
        }
        return result;
    }


    public static List<Tuple<Tag, Tag>> stoneHatchHalf()
    {
        return new List<Tuple<Tag, Tag>>()
        {
            new Tuple<Tag, Tag>(SimHashes.Katairite.CreateTag(), SimHashes.Wolframite.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Glass.CreateTag(), SimHashes.Obsidian.CreateTag()),
        };
    }

    public static Tuple<Tag, Tag> stoneHatchQuarter()
    {
        return new Tuple<Tag, Tag>(SimHashes.Fossil.CreateTag(), SimHashes.Lime.CreateTag());
    }

    // Smooth hatch extras
    public static List<Tuple<Tag, Tag>> smoothHatchExtras()
    {
        return new List<Tuple<Tag, Tag>>()
        {
            new Tuple<Tag, Tag>(SimHashes.RefinedCarbon.CreateTag(), SimHashes.Diamond.CreateTag()),
            new Tuple<Tag, Tag>(SimHashes.Rust.CreateTag(), SimHashes.Iron.CreateTag())
        };
    }
}
