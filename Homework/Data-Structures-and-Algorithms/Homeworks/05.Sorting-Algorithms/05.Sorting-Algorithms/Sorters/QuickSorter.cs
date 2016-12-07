using System;

namespace SortingAlgorithms.Sorters
{
    public class QuickSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            if (array.Length < 10)
            {
                InsertionSort(array);
            }
            else
            {
                QuickSort(array, 0, array.Length - 1);
            }
        }

        private static void QuickSort(T[] array, int startIndex, int endIndex)
        {
            int middle = startIndex + ((endIndex - startIndex) / 2);
            T pivot = array[middle];

            int left = startIndex;
            int right = endIndex;

            while (left <= right)
            {
                while (array[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (array[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(array, left, right);

                    left++;
                    right--;
                }
            }

            if (startIndex < right)
            {
                QuickSort(array, startIndex, right);
            }

            if (left < endIndex)
            {
                QuickSort(array, left, endIndex);
            }
        }

        private static void InsertionSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i;
                while (index > 0 && array[index - 1].CompareTo(array[index]) > 0)
                {
                    Swap(array, index - 1, index);
                    index--;
                }
            }
        }

        private static void Swap(T[] array, int firstIndex, int secondIndex)
        {
            T temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}