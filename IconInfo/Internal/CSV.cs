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

    public static Dictionary<string, T> GetGenerics<T>(string key) where T : IBasic
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
            return records.ToDictionary(i => $"{i.Folder ?? i.Folder}/{i.File}");
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

    public static Dictionary<string, Information.MainFolder> GetFoldersFromCSV()
    {
        using var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream("folder")), GetConfig());
        csv.Context.RegisterClassMap<FolderMapper>();
        csv.Context.Configuration.HeaderValidated = null;
        var records = csv.GetRecords<Information.MainFolder>();
        return records.ToDictionary(i => i.Folder);
    }
    public static Dictionary<string, Information.SubFolder> GetSubFoldersFromCSV()
    {
        using var csv = new CsvHelper.CsvReader(new StreamReader(GetCSVStream("folder_dlc")), GetConfig());
        csv.Context.RegisterClassMap<SubFolderMapper>();
        csv.Context.Configuration.HeaderValidated = null;
        var records = csv.GetRecords<Information.SubFolder>();
        return records.ToDictionary(i => i.Folder);
    }
}
