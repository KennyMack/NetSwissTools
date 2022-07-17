using System;
using System.Collections.Generic;

namespace NetSwissTools.System.Compare
{
    public class ClassComparer<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> EqualsMethod { get; }
        public Func<T, int> GetHashMethod { get; }

        public ClassComparer(
            Func<T, T, bool> metodoEquals,
            Func<T, int> metodoGetHashCode)
        {
            this.EqualsMethod = metodoEquals;
            this.GetHashMethod = metodoGetHashCode;
        }

        public static ClassComparer<T> Compare(
            Func<T, T, bool> metodoEquals,
            Func<T, int> metodoGetHashCode)
        {
            return new ClassComparer<T>(
                metodoEquals, metodoGetHashCode);
        }

        public bool Equals(T x, T y) =>
            EqualsMethod(x, y);

        public int GetHashCode(T obj) =>
            GetHashMethod(obj);
    }
}
