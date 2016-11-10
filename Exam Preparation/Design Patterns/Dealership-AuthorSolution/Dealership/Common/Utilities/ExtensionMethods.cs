using System;
using System.Collections.Generic;

namespace Dealership.Common.Utilities
{
    public static class ExtensionMethods
    {
        public static T ParseToEnum<T>(this string stringToParse)
        {
            T stringAsEnum = (T)Enum.Parse(typeof(T), stringToParse, true);
            return stringAsEnum;
        }

        public static void AddRange<T>(
            this IList<T> destination,
            IEnumerable<T> source)
        {
            List<T> list = destination as List<T>;

            if (list != null)
            {
                list.AddRange(source);
            }
            else
            {
                foreach (T item in source)
                {
                    destination.Add(item);
                }
            }
        }
    }
}