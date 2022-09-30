using System.Diagnostics;
using IconInfo;
using IconInfo.Icon;

namespace IconInfoTest;

public class MainTest
{
    [Fact]
    public void IsResourceStreamAccesible()
    {
        var info = new Dictionary<string, Addon>();
        try
        {
            info = Info.GetAddons();
        }
        catch 
        {
            Assert.True(info != null);
        }
    }

    [Fact]
    public void IsAllAddonsIconAvailable()
    {
        DirectoryInfo info = new("D:\\Dead-by-daylight-Default-icons\\ItemAddons");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            if (icon.Directory.Name != "ItemAddons")
            {
                //Addons in subfolder
                Assert.True(Info.Addons.ContainsKey(
                $"{icon.Directory.Name}/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                $"Icon {icon.FullName} isn't exist on addons folder");
            }
            else
            {
                Assert.True(Info.Addons.ContainsKey($"/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                    $"Icon {icon.FullName} isn't exist on addons folder");
            }
        }
    }

    [Fact]
    public void IsAllAddonsIconAvailableViaGetAddon()
    {
        //D:\Dead-by-daylight-Default-icons
        DirectoryInfo info = new("D:\\Dead-by-daylight-Default-icons\\ItemAddons");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            if (icon.Directory.Name != "ItemAddons")
            {
                //Addons in subfolder
                Assert.True(Info.GetAddon(icon.NameWOExt(), icon.Directory.Name) is not null);
            }
            else
            {
                Assert.True(Info.GetAddon(icon.NameWOExt()) is not null);
            }
        }
    }

    [Fact]
    public void IsAllCharPortraitsAvailable()
    {
        DirectoryInfo info = new("D:\\Dead-by-daylight-Default-icons\\CharPortraits");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            Assert.True(Info.Portraits.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Name} isn't exist on portrait folder");
        }
    }

    [Fact]
    public void IsAllDailyRitualsAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.DailyRitual}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            if (icon.FullName.EndsWith("dailyRitualIcon_Anniversary.png"))
                continue;
            Assert.True(Info.DailyRituals.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Name} isn't exist on daily ritual folder");
        }
    }

    [Fact]
    public void IsAllEmblemAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Emblem}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            Assert.True(Info.Emblems.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Name} isn't exist on emblem folder");
        }
    }

    [Fact]
    public void IsAllOfferingAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Offering}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            Assert.True(Info.Offerings.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Name} isn't exist on offering folder");
        }
    }

    [Fact]
    public void IsAllItemAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Item}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            if (icon.FullName.EndsWith("iconItems_carriedBody.png"))
                continue;
            Assert.True(Info.Items.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Name} isn't exist on item folder");
        }
    }

    [Fact]
    public void IsAllPowerAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Power}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            Assert.True(Info.Powers.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Directory.Name}\\{icon.Name} isn't exist on power folder");
        }
    }

    [Fact]
    public void IsAllPerkAvailable()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Perk}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            Assert.True(Info.Perks.ContainsKey(icon.NameWOExt()),
                $"Icon {icon.Directory.Name}\\{icon.Name} isn't exist on power folder");
        }
    }

    [Fact]
    public void IsAllEmblemClassifiedCorrect()
    {
        DirectoryInfo info = new($"D:\\Dead-by-daylight-Default-icons\\{IconInfo.Strings.Terms.Emblem}");
        var icons = info.GetFiles("*.*", SearchOption.AllDirectories);
        foreach (var icon in icons)
        {
            foreach (var emblem in Info.Emblems.Values)
            {
                Assert.True(emblem.File.Contains(emblem.Category.ToString().ToLower())
                    && emblem.File.Contains(emblem.Quality.ToText()));
            }
        }
    }

    
}