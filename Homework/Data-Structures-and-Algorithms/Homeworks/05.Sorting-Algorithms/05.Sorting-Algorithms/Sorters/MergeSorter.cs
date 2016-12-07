using System;

namespace SortingAlgorithms.Sorters
{
    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort(T[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);

                MergeSort(array, leftIndex, midIndex);
                MergeSort(array, midIndex + 1, rightIndex);

                Merge(array, leftIndex, midIndex + 1, rightIndex);
            }
        }

        private static void Merge(T[] array, int leftIndex, int midIndex, int rightIndex)
        {
            int totalElements = rightIndex - leftIndex + 1;
            int leftEnd = midIndex - 1;

            T[] tempArray = new T[array.Length];
            int tempArrayPos = leftIndex;

            while ((leftIndex <= leftEnd) && (midIndex <= rightIndex))
            {
                if (array[leftIndex].CompareTo(array[midIndex]) <= 0)
                {
                    tempArray[tempArrayPos++] = array[leftIndex++];
                }
                else
                {
                    tempArray[tempArrayPos++] = array[midIndex++];
                }
            }

            while (leftIndex <= leftEnd)
            {
                tempArray[tempArrayPos++] = array[leftIndex++];
            }

            while (midIndex <= rightIndex)
            {
                tempArray[tempArrayPos++] = array[midIndex++];
            }

            for (int i = 0; i < totalElements; i++)
            {
                array[rightIndex] = tempArray[rightIndex];
                rightIndex--;
            }
        }
    }
}