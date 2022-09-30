using IconInfo.Internal;
using IconInfo.Icon;
using System.Globalization;
using System.Reflection;
using Folder = IconInfo.Strings.Terms;

namespace IconInfo.Internal;

internal static class CSV
{
    private static CsvHelper.Configuration.CsvConfiguration GetConfig()
        => new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",", // Enforce ',' as delimiter
            PrepareHeaderForMatch = header => header.Header.ToLower(), // Ignore casing
            MissingFieldFound = null,
            Quote = ';',
            BadDataFound = null
        };

    private static Stream GetCSVStream(string key) => 
        Assembly.GetExecutingAssembly().
        GetManifestResourceStream($"{nameof(IconInfo)}.Resource.{key}.csv");

    private static Dictionary<string, T> GetGenerics<T>(string key) where T : IBasic
    {
        using (var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream(key)), GetConfig()))
        {
            csv.Context.RegisterClassMap<GenericMapper<T>>();
            csv.Context.Configuration.HeaderValidated = null;
            var records = csv.GetRecords<T>();
            return records.ToDictionary(i => i.File);
        }
    }

    public static Dictionary<string, T> GetGenericsWithFolder<T>(string key) where T : IBasic, IFolder
    {
        using (var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream(key)), GetConfig()))
        {
            csv.Context.RegisterClassMap<GenericWithFolderMapper<T>>();
            csv.Context.Configuration.HeaderValidated = null;
            var records = csv.GetRecords<T>();
            return records.ToDictionary(i => i.File);
        }
    }

    #region Generic File name > Name items
    public static Dictionary<string, Portrait> GetPortraits()
        => GetGenericsWithFolder<Portrait>(Folder.Portrait);

    public static Dictionary<string, DailyRitual> GetDailyRituals()
        => GetGenerics<DailyRitual>(Folder.DailyRitual);

    public static Dictionary<string, Emblem> GetEmblems()
        => GetGenerics<Emblem>(Folder.Emblem);

    public static Dictionary<string, StatusEffect> GetStatusEffects()
        => GetGenerics<StatusEffect>(Folder.StatusEffect);
    #endregion

    public static Dictionary<string, Offering> GetOfferings()
        => GetGenericsWithFolder<Offering>(Folder.Offering);

    public static Dictionary<string, Item> GetItems()
        => GetGenericsWithFolder<Item>(Folder.Item);

    public static Dictionary<string, Power> GetPowersFromCSV()
    {
        using (var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream(Folder.Power)), GetConfig()))
        {
            csv.Context.RegisterClassMap<PowerMapper>();
            csv.Context.Configuration.HeaderValidated = null;
            var records = csv.GetRecords<Power>();
            return records.ToDictionary(i => i.File);
        }
    }

    public static Dictionary<string, Addon> GetAddonsFromCSV()
    {
        using (var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream(Folder.Addon)), GetConfig()))
        {
            csv.Context.RegisterClassMap<AddonMapper>();
            csv.Context.Configuration.HeaderValidated = null;
            var records = csv.GetRecords<Addon>();
            return records.ToDictionary(i => $"{(i.Folder is null ? "" : i.Folder)}/{i.File}");
        }
    }

    public static Dictionary<string, Perk> GetPerksFromCSV()
    {
        using (var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream(Folder.Perk)), GetConfig()))
        {
            csv.Context.RegisterClassMap<PerkMapper>();
            csv.Context.Configuration.HeaderValidated = null;
            var records = csv.GetRecords<Perk>();
            return records.ToDictionary(i => i.File);
        }
    }
}
