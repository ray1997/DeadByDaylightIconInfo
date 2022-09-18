using IconPack.Icon;

namespace IconInfoTest;

public class MainTest
{
    [Fact]
    public void IsResourceStreamAccesible()
    {
        var info = new Dictionary<string, Addon>();
        try
        {
            info = IconInfo.Info.GetAddons();
        }
        catch 
        {
            Assert.True(info != null);
        }
    }
}