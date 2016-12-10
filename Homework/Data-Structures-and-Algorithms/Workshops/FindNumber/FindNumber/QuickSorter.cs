using System;
using System.Collections.Generic;

namespace FindNumber
{
    public class QuickSorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count > 10)
            {
                QuickSort(collection, 0, collection.Count - 1);
            }
            else
            {
                InsertionSort(collection);
            }
        }

        private static void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            int midIndex = startIndex + ((endIndex - startIndex) / 2);
            T pivot = collection[midIndex];

            int left = startIndex;
            int right = endIndex;

            while (left <= right)
            {
                while (collection[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (collection[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(collection, left, right);

                    left++;
                    right--;
                }
            }

            if (startIndex < right)
            {
                QuickSort(collection, right, startIndex);
            }

            if (left < endIndex)
            {
                QuickSort(collection, left, endIndex);
            }
        }

        private static void InsertionSort(IList<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int index = i;
                while (index > 0 && collection[index].CompareTo(collection[index - 1]) < 0)
                {
                    Swap(collection, index, index - 1);
                    index--;
                }
            }
        }

        private static void Swap(IList<T> collection, int firstElementIndex, int secondElementIndex)
        {
            T temp = collection[firstElementIndex];
            collection[firstElementIndex] = collection[secondElementIndex];
            collection[secondElementIndex] = temp;
        }
    }
}