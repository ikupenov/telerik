using System;

namespace TaskTwo
{
    class Program
    {
        private static int n;
        private static int k;
        private static int[] combinations;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            combinations = new int[k];

            GenerateCombinationsWithDuplicates();
        }

        private static void GenerateCombinationsWithDuplicates(int index = 0, int start = 1)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    combinations[index] = i;
                    GenerateCombinationsWithDuplicates(index + 1, i);
                }
            }
        }
    }
}
