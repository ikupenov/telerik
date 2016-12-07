using System;
using System.Collections.Generic;

namespace SearchingAlgorithms.Searchers
{
    public class BinarySearcher<T> : ISearcher<T>
        where T : IComparable<T>
    {
        public int Search(T value, IList<T> collection)
        {
            return BinarySearch(value, collection, 0, collection.Count - 1);
        }

        private static int BinarySearch(T value, IList<T> collection, int startIndex, int endIndex)
        {
            while (startIndex <= endIndex)
            {
                int midIndex = startIndex + ((endIndex - startIndex) / 2);

                if (value.CompareTo(collection[midIndex]) == 0)
                {
                    return midIndex;
                }
                else if (value.CompareTo(collection[midIndex]) < 0)
                {
                    endIndex = midIndex - 1;
                }
                else
                {
                    startIndex = midIndex + 1;
                }
            }

            return -1;
        }
    }
}