using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
