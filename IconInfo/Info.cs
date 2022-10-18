using IconInfo.Internal;
using IconInfo.Icon;
using IconInfo.Strings;
using IconInfo.Information;

namespace IconInfo;

public static class Info
{
    public static Dictionary<string, MainFolder> GetFolders() => CSV.GetFoldersFromCSV();
    private static Lazy<Dictionary<string, MainFolder>>? _folders;
    public static Dictionary<string, MainFolder> Folders
    {
        get
        {
            _folders ??= new(CSV.GetFoldersFromCSV());
            return _folders.Value;
        }
    }

    public static Dictionary<string, SubFolder> GetSubFolders() => CSV.GetSubFoldersFromCSV();
    private static Lazy<Dictionary<string, SubFolder>>? _SubFolders;
    public static Dictionary<string, SubFolder> SubFolders
    {
        get
        {
            _SubFolders ??= new(CSV.GetSubFoldersFromCSV());
            return _SubFolders.Value;
        }
    }

    public static Dictionary<string, Portrait> GetPortraits() => CSV.GetGenericsWithFolder<Portrait>(Terms.Portrait);

    private static Lazy<Dictionary<string, Portrait>>? _portraits;
    public static Dictionary<string, Portrait> Portraits
    {
        get
        {
            _portraits ??= new(CSV.GetGenericsWithFolder<Portrait>(Terms.Portrait));
            return _portraits.Value;
        }
    }

    public static Dictionary<string, DailyRitual> GetDailyRituals() => CSV.GetGenerics<DailyRitual>(Terms.DailyRitual);
    private static Lazy<Dictionary<string, DailyRitual>>? _dailyRituals;
    public static Dictionary<string, DailyRitual> DailyRituals
    {
        get
        {
            _dailyRituals ??= new(CSV.GetGenerics<DailyRitual>(Terms.DailyRitual));
            return _dailyRituals.Value;
        }
    }

    public static Dictionary<string, Emblem> GetEmblems() => CSV.GetGenerics<Emblem>(Terms.Emblem);
    private static Lazy<Dictionary<string, Emblem>>? _emblems;
    public static Dictionary<string, Emblem> Emblems
    {
        get
        {
            _emblems ??= new(CSV.GetGenerics<Emblem>(Terms.Emblem));
            return _emblems.Value;
        }
    }

    public static Dictionary<string, StatusEffect> GetStatusEffects() => CSV.GetGenerics<StatusEffect>(Terms.StatusEffect);
    private static Lazy<Dictionary<string, StatusEffect>>? _statusEffects;
    public static Dictionary<string, StatusEffect> StatusEffects
    {
        get
        {
            _statusEffects ??= new(CSV.GetGenerics<StatusEffect>(Terms.StatusEffect));
            return _statusEffects.Value;
        }
    }

    public static Dictionary<string, Offering> GetOfferings() => CSV.GetGenerics<Offering>(Terms.Offering);
    private static Lazy<Dictionary<string, Offering>>? _offerings;
    public static Dictionary<string, Offering> Offerings
    {
        get
        {
            _offerings ??= new(CSV.GetGenerics<Offering>(Terms.Offering));
            return _offerings.Value;
        }
    }

    public static Dictionary<string, Item> GetItems() => CSV.GetGenericsWithFolder<Item>(Terms.Item);
    private static Lazy<Dictionary<string, Item>>? _items;
    public static Dictionary<string, Item> Items
    {
        get
        {
            _items ??= new(CSV.GetGenericsWithFolder<Item>(Terms.Item));
            return _items.Value;
        }
    }

    public static Dictionary<string, Power> GetPowers() => CSV.GetPowersFromCSV();
    private static Lazy<Dictionary<string, Power>>? _powers;
    public static Dictionary<string, Power> Powers
    {
        get
        {
            _powers ??= new(CSV.GetPowersFromCSV());
            return _powers.Value;
        }
    }

    public static Dictionary<string, Addon> GetAddons() => CSV.GetAddonsFromCSV();

    public static Addon GetAddon(string path)
    {
        FileInfo file = new(path);
        var noEXT = Path.GetFileNameWithoutExtension(path);
        if (Addons.ContainsKey($"/{noEXT}"))
            return Addons[$"/{noEXT}"];
        if (file.Directory is null)
            return GetAddon(noEXT, folder: null);
        if (file.Directory is not null && file.Directory.Name == Terms.Addon)
            return GetAddon(noEXT, folder: null); //Root folder addons
        if (SubFolders.ContainsKey(file.Directory.Name))
            return GetAddon(noEXT, file.Directory.Name);
        return GetAddon(noEXT, file.Directory.Name);
    }

    public static Addon GetAddon(string name, string? folder = null)
    {
        if (folder is null)
            return Addons[$"{(!name.StartsWith('/') ? "/" : "")}{name}"];
        return Addons[$"{folder}/{name}"];
    }
    private static Lazy<Dictionary<string, Addon>>? _addons;
    /// <summary>
    /// Due to icon addons having duplicate the key require folder
    /// If it's in folder: Xipre/iconAddon_speedLimiter
    /// if it's not in the folder: /iconAddon_ataxicRespiration
    /// </summary>
    public static Dictionary<string, Addon> Addons
    {
        get
        {
            _addons ??= new(CSV.GetAddonsFromCSV());
            return _addons.Value;
        }
    }

    public static Dictionary<string, Perk> GetPerks() => CSV.GetPerksFromCSV();
    private static Lazy<Dictionary<string, Perk>>? _perks;
    public static Dictionary<string, Perk> Perks
    {
        get
        {
            _perks ??= new(CSV.GetPerksFromCSV());
            return _perks.Value;
        }
    }

    //Newly added generic infos
    public static Dictionary<string, Archive> GetArchives() => CSV.GetGenericsWithFolder<Archive>(Terms.Archive);
    private static Lazy<Dictionary<string, Archive>>? _archives;
    public static Dictionary<string, Archive> Archives
    {
        get
        {
            _archives ??= new(CSV.GetGenericsWithFolder<Archive>(Terms.Archive));
            return _archives.Value;
        }
    }

    public static Dictionary<string, Help> GetHelps() => CSV.GetGenerics<Help>(Terms.Help);
    private static Lazy<Dictionary<string, Help>>? _helps;
    public static Dictionary<string, Help> Helps
    {
        get
        {
            _helps ??= new(CSV.GetGenerics<Help>(Terms.Help));
            return _helps.Value;
        }
    }

    public static Dictionary<string, HelpLoading> GetHelpLoadings() => CSV.GetGenericsWithFolder<HelpLoading>(Terms.HelpLoading);
    private static Lazy<Dictionary<string, HelpLoading>>? _helpLoadings;
    public static Dictionary<string, HelpLoading> HelpLoadings
    {
        get
        {
            _helpLoadings ??= new(CSV.GetGenericsWithFolder<HelpLoading>(Terms.HelpLoading));
            return _helpLoadings.Value;
        }
    }

    public static Dictionary<string, StoreBackground> GetStoreBackgrounds() => CSV.GetGenericsWithFolder<StoreBackground>(Terms.StoreBackground);
    private static Lazy<Dictionary<string, StoreBackground>>? _StoreBackgrounds;
    public static Dictionary<string, StoreBackground> StoreBackgrounds
    {
        get
        {
            _StoreBackgrounds ??= new(CSV.GetGenericsWithFolder<StoreBackground>(Terms.StoreBackground));
            return _StoreBackgrounds.Value;
        }
    }

    public static Dictionary<string, AuricCellPack> GetPacks() => CSV.GetGenerics<AuricCellPack>(Terms.Pack);
    private static Lazy<Dictionary<string, AuricCellPack>>? _packs;
    public static Dictionary<string, AuricCellPack> Packs
    {
        get
        {
            _packs ??= new(CSV.GetGenerics<AuricCellPack>(Terms.Pack));
            return _packs.Value;
        }
    }

}
