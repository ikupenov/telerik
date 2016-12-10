using System;

namespace FindNumber
{
    class StartUp
    {
        private static int stringIndex;

        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] inputStrings = Console.ReadLine().Split(' ');

            stringIndex = int.Parse(input[1]);

            Sort(inputStrings);

            Console.WriteLine(inputStrings[stringIndex]);
        }

        private static void Sort(string[] collection)
        {
            if (collection.Length > 10)
            {
                QuickSort(collection, 0, collection.Length - 1);
            }
            else
            {
                InsertionSort(collection);
            }
        }

        private static void QuickSort(string[] collection, int startIndex, int endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            var pivot = collection[midIndex];

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

            if (startIndex < right && stringIndex <= right)
            {
                QuickSort(collection, startIndex, right);
            }

            if (left < endIndex && right < stringIndex)
            {
                QuickSort(collection, left, endIndex);
            }
        }

        private static void InsertionSort(string[] collection)
        {
            for (int i = 1; i < collection.Length; i++)
            {
                int index = i;
                while (index > 0 && collection[index].CompareTo(collection[index - 1]) < 0)
                {
                    Swap(collection, index, index - 1);
                    index--;
                }
            }
        }

        private static void Swap(string[] collection, int firstElementIndex, int secondElementIndex)
        {
            var temp = collection[firstElementIndex];
            collection[firstElementIndex] = collection[secondElementIndex];
            collection[secondElementIndex] = temp;
        }
    }
}