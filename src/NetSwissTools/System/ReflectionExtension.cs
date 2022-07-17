using NetSwissTools.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NetSwissTools.System
{
    public static class ReflectionExtension
    {
        /// <summary>
        /// Iterate all results in datareader and return line by line as a result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">Data reader</param>
        /// <param name="projection">Function to create the object</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<T> Select<T>(this IDataReader reader,
                                          Func<IDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }

        /// <summary>
        /// Try get value from datareader if fails return the default value
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="pProperty">Name of property</param>
        /// <param name="pDefault">Default value</param>
        /// <returns></returns>
        public static object TryGetValue(this IDataReader reader, string pProperty, object pDefault = null)
        {
            try
            {
                return reader[pProperty];
            }
            catch (Exception)
            {

            }
            return pDefault;
        }

        /// <summary>
        /// Copy property values from origin to destination
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TOrigin"></typeparam>
        /// <param name="objDest">Object destination</param>
        /// <param name="objOrig">Object Origin</param>
        /// <exception cref="NetToolException">Can't copy properties</exception>
        public static void CopyProperties<TDestination, TOrigin>(this TDestination objDest, TOrigin objOrig) where TDestination : class where TOrigin : class
        {
            var isNullable = false;
            Type PropType;
            foreach (var attr in objOrig.GetType().GetProperties().Where(p => p.CanRead))
            {
                var propertyInfo = objDest.GetType().GetProperty(attr.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                try
                {
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        PropType = propertyInfo.PropertyType;
                        isNullable = false;
                        if (propertyInfo.PropertyType.Name.IndexOf("Nullable`", StringComparison.Ordinal) > -1)
                        {
                            PropType = Nullable.GetUnderlyingType(PropType);
                            isNullable = true;
                        }

                        var attrVal = attr.GetValue(objOrig, null);

                        if (isNullable && attrVal == null)
                        {
                            propertyInfo.SetValue(objDest, null, null);
                        }
                        else
                        {
                            switch (PropType.Name)
                            {
                                case "Int16":
                                    propertyInfo.SetValue(objDest, Convert.ToInt16(attrVal), null);
                                    break;
                                case "Int32":
                                    propertyInfo.SetValue(objDest, Convert.ToInt32(attrVal), null);
                                    break;
                                case "Int64":
                                    propertyInfo.SetValue(objDest, Convert.ToInt64(attrVal), null);
                                    break;
                                case "SByte":
                                    propertyInfo.SetValue(objDest, Convert.ToSByte(attrVal), null);
                                    break;
                                case "DateTime":
                                    propertyInfo.SetValue(objDest, Convert.ToDateTime(attrVal, new CultureInfo("pt-BR")), null);
                                    break;
                                case "Boolean":
                                    if (attrVal == null)
                                    {
                                        propertyInfo.SetValue(objDest, false, null);
                                        break;
                                    }

                                    if (int.TryParse(attrVal.ToString(), out int val))
                                    {
                                        propertyInfo.SetValue(objDest, val > 0, null);
                                        break;
                                    }

                                    if (bool.TryParse(attrVal.ToString(), out bool valb))
                                    {
                                        propertyInfo.SetValue(objDest, valb, null);
                                        break;
                                    }

                                    propertyInfo.SetValue(objDest, false, null);
                                    break;
                                default:
                                    propertyInfo.SetValue(objDest, attrVal, null);
                                    break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new NetToolException($"Can't copy property {attr.Name} to {propertyInfo.Name} with value '{attr.GetValue(objOrig, null)}' reason: {e.Message}");
                }
            }

        }

        /// <summary>
        /// Get properties from a object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objOrig">Object</param>
        /// <returns>Dictionary<string, object></returns>
        public static Dictionary<string, object> GetProperties<T>(this T objOrig) where T : class
        {
            var valueDict = new Dictionary<string, object>();

            foreach (var attr in objOrig.GetType().GetProperties())
            {
                var value = attr.GetValue(objOrig, null);
                valueDict.Add(attr.Name, value);
            }

            return valueDict;
        }

        /// <summary>
        ///     Gets information from a property of an object.
        ///     <example>var propinfo = ReflectionExtension.GetPropertyInfo(_cfgServico, c => c.DirectorySaveXml);</example>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source">Origin of property</param>
        /// <param name="propertyLambda">Filter of property</param>
        /// <returns>Returns an object of type PropertyInfo with property information such as name, type, etc.</returns>
        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(this TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);

            if (!(propertyLambda.Body is MemberExpression member))
                throw new ArgumentException($"The expression '{propertyLambda}' refers to a method not a property");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"The expression '{propertyLambda}' refers to a field not a property");

            if (propInfo.ReflectedType != null && (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType)))
                throw new ArgumentException($"The expression '{propertyLambda}' refers to a property, but not of type {type}");

            return propInfo;
        }


        /// <summary>
        /// Compares the properties of two objects of the same type and returns if all properties are equal.
        /// </summary>
        /// <param name="objectA">The first object to compare.</param>
        /// <param name="objectB">The second object to compre.</param>
        /// <param name="ignoreList">A list of property names to ignore from the comparison.</param>
        /// <returns><c>true</c> if all property values are equal, otherwise <c>false</c>.</returns>
        public static bool EqualTo(this object objectA, object objectB, params string[] ignoreList)
        {
            bool result;

            if (objectA != null && objectB != null)
            {
                Type objectType;

                objectType = objectA.GetType();

                result = true; // assume by default they are equal

                foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && !ignoreList.Contains(p.Name)))
                {
                    object valueA;
                    object valueB;

                    valueA = propertyInfo.GetValue(objectA, null);
                    valueB = propertyInfo.GetValue(objectB, null);

                    // if it is a primative type, value type or implements IComparable, just directly try and compare the value
                    if (CanDirectlyCompare(propertyInfo.PropertyType))
                    {
                        if (!AreValuesEqual(valueA, valueB))
                        {
                            Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                            result = false;
                        }
                    }
                    // if it implements IEnumerable, then scan any items
                    else if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        IEnumerable<object> collectionItems1;
                        IEnumerable<object> collectionItems2;
                        int collectionItemsCount1;
                        int collectionItemsCount2;

                        // null check
                        if (valueA == null && valueB != null || valueA != null && valueB == null)
                        {
                            Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                            result = false;
                        }
                        else if (valueA != null && valueB != null)
                        {
                            collectionItems1 = ((IEnumerable)valueA).Cast<object>();
                            collectionItems2 = ((IEnumerable)valueB).Cast<object>();
                            collectionItemsCount1 = collectionItems1.Count();
                            collectionItemsCount2 = collectionItems2.Count();

                            // check the counts to ensure they match
                            if (collectionItemsCount1 != collectionItemsCount2)
                            {
                                Console.WriteLine("Collection counts for property '{0}.{1}' do not match.", objectType.FullName, propertyInfo.Name);
                                result = false;
                            }
                            // and if they do, compare each item... this assumes both collections have the same order
                            else
                            {
                                for (int i = 0; i < collectionItemsCount1; i++)
                                {
                                    object collectionItem1;
                                    object collectionItem2;
                                    Type collectionItemType;

                                    collectionItem1 = collectionItems1.ElementAt(i);
                                    collectionItem2 = collectionItems2.ElementAt(i);
                                    collectionItemType = collectionItem1.GetType();

                                    if (CanDirectlyCompare(collectionItemType))
                                    {
                                        if (!AreValuesEqual(collectionItem1, collectionItem2))
                                        {
                                            Console.WriteLine("Item {0} in property collection '{1}.{2}' does not match.", i, objectType.FullName, propertyInfo.Name);
                                            result = false;
                                        }
                                    }
                                    else if (!EqualTo(collectionItem1, collectionItem2, ignoreList))
                                    {
                                        Console.WriteLine("Item {0} in property collection '{1}.{2}' does not match.", i, objectType.FullName, propertyInfo.Name);
                                        result = false;
                                    }
                                }
                            }
                        }
                    }
                    else if (propertyInfo.PropertyType.IsClass)
                    {
                        if (!EqualTo(propertyInfo.GetValue(objectA, null), propertyInfo.GetValue(objectB, null), ignoreList))
                        {
                            Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                            result = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot compare property '{0}.{1}'.", objectType.FullName, propertyInfo.Name);
                        result = false;
                    }
                }
            }
            else
                result = object.Equals(objectA, objectB);

            return result;
        }

        /// <summary>
        /// Determines whether value instances of the specified type can be directly compared.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if this value instances of the specified type can be directly compared; otherwise, <c>false</c>.
        /// </returns>
        private static bool CanDirectlyCompare(Type type)
        {
            return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
        }

        /// <summary>
        /// Compares two values and returns if they are the same.
        /// </summary>
        /// <param name="valueA">The first value to compare.</param>
        /// <param name="valueB">The second value to compare.</param>
        /// <returns><c>true</c> if both values match, otherwise <c>false</c>.</returns>
        private static bool AreValuesEqual(this object valueA, object valueB)
        {
            bool result;
            IComparable selfValueComparer;

            selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!object.Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }

        /// <summary>
        /// Get description from a enumerator
        /// </summary>
        /// <param name="enumerationValue">Enumerator</param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();
            MemberInfo member = type.GetMembers().Where(w => w.Name == Enum.GetName(type, enumerationValue)).FirstOrDefault();
            DescriptionAttribute attribute;

            if (member != null)
            {
                attribute = member.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                return attribute.Description;
            }

            return enumerationValue.ToString();
        }
    }
}
