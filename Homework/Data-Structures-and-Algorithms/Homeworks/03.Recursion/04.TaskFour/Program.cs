using System;

namespace TaskFour
{
    class Program
    {
        private static int n;

        private static int[] permutations;
        private static bool[] used;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());

            permutations = new int[n];
            used = new bool[n + 1];

            GeneratePermutations();
        }

        static void GeneratePermutations(int index = 0)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = i;
                    GeneratePermutations(index: index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
