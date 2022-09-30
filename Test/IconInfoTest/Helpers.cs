using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IconInfo.Icon;

namespace IconInfoTest;
internal static class Helpers
{
    /// <summary>
    /// Return filename without extension
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public static string NameWOExt(this FileInfo info) => 
        Path.GetFileNameWithoutExtension(info.FullName);

    public static string ToText(this EmblemQuality quality)
    {
        if (quality == EmblemQuality.Iridescent)
            return "platinum";
        return quality.ToString().ToLower();
    }
}
