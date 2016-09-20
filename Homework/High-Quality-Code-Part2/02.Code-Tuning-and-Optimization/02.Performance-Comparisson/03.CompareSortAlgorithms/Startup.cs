namespace CompareSortAlgorithms
{
    using Models;
    using Utils;

    internal class Startup
    {
        private static void Main()
        {
            StringSorting();
            IntSorting();
            DoubleSorting();
        }

        private static void StringSorting()
        {
            var arrayToSort = new string[]
            {
                "string",
                "string1",
                "string2",
                "string3",
                "string4",
                "string5",
                "stringstring",
                "stringstring1",
                "stringstring2",
                "stringstringstring3",
                "stringstringstringstring4"
            };

            Logger.Log("String array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }

        private static void IntSorting()
        {
            var arrayToSort = RandomArrayGenerator.GenerateIntArray(-30, 23242342);
            Logger.Log("Int array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }

        private static void DoubleSorting()
        {
            var arrayToSort = RandomArrayGenerator.GenerateDoubleArray(-30, 23242342);

            Logger.Log("Double array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }
    }
}