using System;

namespace SortingAlgorithms.Sorters
{
    public class SelectionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(ref array[minIndex], ref array[i]);
                }
            }
        }

        private static void Swap(ref T firstValue, ref T secondValue)
        {
            T temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }
    }
}