using System;
using System.Collections.Generic;
using System.Linq;

namespace NetSwissTools.System.Compare
{
    public static class DistinctExtension
    {
        public static IEnumerable<TSource> DistinctClasse<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, bool> metodoEquals,
            Func<TSource, int> metodoGetHashCode)
                => source.Distinct(
                    ClassComparer<TSource>.Compare(
                        metodoEquals,
                        metodoGetHashCode)
                        );
    }
}
