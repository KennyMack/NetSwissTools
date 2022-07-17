using System;
using System.Linq;

namespace NetSwissTools.Utils
{
    public static class InExtension
    {
        /// <summary>
        /// Checks whether the values are contained in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valor">Value to check</param>
        /// <param name="items">List of values</param>
        /// <returns>System.Boolean</returns>
        public static bool In<T>(this T valor, params T[] items) where T : IComparable
        {
            if (items == null)
                throw new ArgumentNullException("Items are needed");

            return items.Any(r => r != null && r.Equals(valor));
        }
    }
}
