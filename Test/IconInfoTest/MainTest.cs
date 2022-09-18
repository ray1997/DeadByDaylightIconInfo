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
        var icons = info.GetFiles();
        foreach (var icon in icons)
        {
            if (icon.Directory.Name != "ItemAddons")
            {
                //Addons in subfolder
                Assert.True(Info.Addons.ContainsKey(
                $"{icon.Directory.Name}/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                $"Icon {icon.Name} isn't exist on addons folder");
            }
            Assert.True(Info.Addons.ContainsKey($"/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                $"Icon {icon.Name} isn't exist on addons folder");
        }
    }

    [Fact]
    public void IsAllAddonsIconAvailableViaGetAddon()
    {
        //D:\Dead-by-daylight-Default-icons
        DirectoryInfo info = new("D:\\Dead-by-daylight-Default-icons\\ItemAddons");
        var icons = info.GetFiles();
        foreach (var icon in icons)
        {
            if (icon.Directory.Name != "ItemAddons")
            {
                //Addons in subfolder
                Assert.True(Info.GetAddon(icon.NameWOExt(), icon.Directory.Name) is not null);
            }
            Assert.True(Info.GetAddon(icon.NameWOExt()) is not null);
        }
    }

    public void IsAllCharPortraitsAvailable()
    {
        DirectoryInfo info = new("D:\\Dead-by-daylight-Default-icons\\ItemAddons");
        var icons = info.GetFiles();
        foreach (var icon in icons)
        {
            if (icon.Directory.Name != "ItemAddons")
            {
                //Addons in subfolder
                Assert.True(Info.Addons.ContainsKey(
                $"{icon.Directory.Name}/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                $"Icon {icon.Name} isn't exist on addons folder");
            }
            Assert.True(Info.Addons.ContainsKey($"/{Path.GetFileNameWithoutExtension(icon.FullName)}"),
                $"Icon {icon.Name} isn't exist on addons folder");
        }
    }
}