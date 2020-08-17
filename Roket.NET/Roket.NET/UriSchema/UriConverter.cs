using System;
using System.Linq;

namespace Roket.NET
{
    public static class UriConverter
    {
        /// <summary>
        /// Combine a specific URI. 
        /// </summary>
        /// <param name="uri">The paramater uri to combine</param>
        /// <param name="path">The parameter path to combine</param>
        /// <returns></returns>
        public static Uri ToCombineUri(this Uri uri, params string[] path) =>
            new Uri(path.Aggregate(uri.AbsoluteUri, (u, p) => string.Format("{0}/{1}", u.TrimEnd('/'), p.TrimStart('/'))));
    }
}
