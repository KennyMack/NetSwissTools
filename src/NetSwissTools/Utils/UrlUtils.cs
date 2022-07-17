using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetSwissTools.Utils
{
    public static class UrlUtils
    {
        public static string UrlEncode(this string url) =>
            Uri.EscapeDataString(url);

        private static string UrlCombine(string pathBase, string pathPartAdd)
        {
            pathBase = $"{pathBase.TrimEnd('/')}/";
            pathPartAdd = pathPartAdd.TrimStart('/');

            return Path.Combine(pathBase, pathPartAdd)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        public static string UrlPathCombine(this string pathBase, params string[] pathParts)
        {
            pathBase = $"{pathBase.TrimEnd('/')}/";
            foreach (var s in pathParts)
                pathBase = UrlCombine(pathBase, s).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            return pathBase;
        }

        public static bool HasTrailingSlash(this string url) =>
            url != null && url.EndsWith("/");
    }
}
