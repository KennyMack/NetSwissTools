using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Models
{
    public static class CloneModel
    {
        /// <summary>
        /// Clone instance of class to another object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Object origin</param>
        /// <returns>Return new object of class instance</returns>
        public static T ToClone<T>(this T entity) where T : class
        {
            var serializer = new BinarySerializer();
            var array = serializer.SerializeToBinary(entity);
            return serializer.DeserializeFromBinary<T>(array);
        }
    }
}
