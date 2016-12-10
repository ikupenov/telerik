using System;

namespace CountingSort
{
    class StartUp
    {
        static void Main()
        {
            int[] arr = new[] { 3, 7, 109, 3 };

            var countingSorter = new CountingSorter();
            countingSorter.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
