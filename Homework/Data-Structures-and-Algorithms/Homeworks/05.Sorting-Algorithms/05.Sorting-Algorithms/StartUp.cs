using System;
using SortingAlgorithms.Sorters;

namespace SortingAlgorithms
{
    public class StartUp
    {
        static void Main()
        {
            // Selection Sort
            Console.WriteLine("Selection Sort");
            int[] selectionSortArray = new int[] { 7, 10, 54, 8, 54, 176 };
            var selectionSorter = new SelectionSorter<int>();
            Console.WriteLine($"Array before: {string.Join(", ", selectionSortArray)}");
            selectionSorter.Sort(selectionSortArray);
            Console.WriteLine($"Array after: {string.Join(", ", selectionSortArray)}");
            Console.WriteLine();

            // Quick Sort / Insertion Sort
            Console.WriteLine("Quick Sort");
            int[] quickSortArray = new int[] { 7, -10, 3, 8, 64, 1, 20, 88, -10, 0, 79, 300 };
            var quickSorter = new QuickSorter<int>();
            Console.WriteLine($"Array before: {string.Join(", ", quickSortArray)}");
            quickSorter.Sort(quickSortArray);
            Console.WriteLine($"Array after: {string.Join(", ", quickSortArray)}");
            Console.WriteLine();

            // Merge Sort
            Console.WriteLine("Merge Sort");
            int[] mergeSortArray = new int[] { 2011, -3, -3, 49, 24, 42 };
            var mergeSorter = new MergeSorter<int>();
            Console.WriteLine($"Array before: {string.Join(", ", mergeSortArray)}");
            mergeSorter.Sort(mergeSortArray);
            Console.WriteLine($"Array after: {string.Join(", ", mergeSortArray)}");
            Console.WriteLine();
        }
    }
}