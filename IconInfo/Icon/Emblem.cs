using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Icon;

public partial class Emblem : ObservableObject, IBasic
{
    public Emblem() { }

    [ObservableProperty]
    private string file;

    [ObservableProperty]
    private string name;

    private static (EmblemCategory category, EmblemQuality quality) ClassifiedEmblem(string name)
    {
        var span = name.AsSpan();
        var c = span[(span.IndexOf('_') + 1)..span.LastIndexOf('_')];
        var q = span[(span.LastIndexOf('_') + 1)..];
        var eCategory = Enum.Parse<EmblemCategory>(CapitalizeFirst(c));
        var eQuality = EmblemQuality.None;
        if (name.Contains("platinum"))
            eQuality = EmblemQuality.Iridescent;
        else
            eQuality = Enum.Parse<EmblemQuality>(CapitalizeFirst(q));
        return (eCategory, eQuality);
    }

    /// <summary>
    /// Capitalize first letter
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static string CapitalizeFirst(ReadOnlySpan<char> input) => $"{input[0].ToString().ToUpper()}{input[1..]}";

    private EmblemCategory? category;
    public EmblemCategory Category
    {
        get
        {
            category ??= ClassifiedEmblem(File).category;
            return category.Value;
        }
    }

    private EmblemQuality? quality;
    public EmblemQuality Quality
    {
        get
        {
            quality ??= ClassifiedEmblem(File).quality;
            return quality.Value;
        }
    }
}

public enum EmblemCategory
{
    Lightbringer,
    Unbroken,
    Benevolent,
    Evader,
    Gatekeeper,
    Devout,
    Malicious,
    Chaser
}

public enum EmblemQuality
{
    None,
    Bronze,
    Silver,
    Gold,
    Iridescent
}