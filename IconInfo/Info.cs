﻿using IconInfo.Internal;
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

    public static IBasic? GetIcon(string path)
    {
        FileInfo file = new(path);
        bool hasParentDir = file.Directory is not null;
        bool isSubDirectory = false;
        bool isMainDirectory = false;
        if (hasParentDir)
        {
            isSubDirectory = SubFolders.ContainsKey(file.Directory.Name);
            if (!isSubDirectory)
                isMainDirectory = Folders.ContainsKey(file.Directory.Name);
        }
        if (!isSubDirectory && !isMainDirectory)
        {
            System.Diagnostics.Debug.WriteLine("Either SubFolder or MainFolder is outdated");
            return null;
        }

        string name = Path.GetFileNameWithoutExtension(path);
        try
        {
            if (Archives.ContainsKey(name))
                return Archives[name];
            else if (Portraits.ContainsKey(name))
                return Portraits[name];
            else if (DailyRituals.ContainsKey(name))
                return DailyRituals[name];
            else if (Emblems.ContainsKey(name))
                return Emblems[name];
            else if (Offerings.ContainsKey(name))
                return Offerings[name];
            else if (Helps.ContainsKey(name))
                return Helps[name];
            else if (HelpLoadings.ContainsKey(name))
                return HelpLoadings[name];
            else if (Items.ContainsKey(name))
                return Items[name];
            else if (Packs.ContainsKey(name))
                return Packs[name];
            else if (Perks.ContainsKey(name))
                return Perks[name];
            else if (Powers.ContainsKey(name))
                return Powers[name];
            else if (StatusEffects.ContainsKey(name))
                return StatusEffects[name];
            else if (StoreBackgrounds.ContainsKey(name))
                return StoreBackgrounds[name];
            else
            {
                var addons = GetAddon(path);
                if (addons is not null)
                    return addons;
            }
        }
        catch { }
        var smol = name.ToLower();
        if (Archives.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found)
            return Archives[found];
        else if (Portraits.Keys.FirstOrDefault(i => i.ToLower() == smol) is string fp)
            return Portraits[fp];
        else if (DailyRituals.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_dailyritual)
            return DailyRituals[found_dailyritual];
        else if (Emblems.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_emblem)
            return Emblems[found_emblem];
        else if (Offerings.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_offering)
            return Offerings[found_offering];
        else if (Helps.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_help)
            return Helps[found_help];
        else if (HelpLoadings.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_helploading)
            return HelpLoadings[found_helploading];
        else if (Items.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_item)
            return Items[found_item];
        else if (Packs.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_pack)
            return Packs[found_pack];
        else if (Perks.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_perk)
            return Perks[found_perk];
        else if (Powers.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_power)
            return Powers[found_power];
        else if (StatusEffects.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_statuseffect)
            return StatusEffects[found_statuseffect];
        else if (StoreBackgrounds.Keys.FirstOrDefault(i => i.ToLower() == smol) is string found_storebackground)
            return StoreBackgrounds[found_storebackground];
        return null;
    }
}
