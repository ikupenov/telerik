using System;

namespace TaskFour2
{
    class Program
    {
        private static int n;
        private static int[] permutations;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            permutations = new int[n];

            for (int i = 0; i < n; i++)
            {
                permutations[i] = i + 1;
            }

            Permute();
        }

        static void Permute(int index = 0)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            // {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

            for (int i = index + 1; i < n; i++)
            {
                // 1 2 3, 2 1 3, 2 3 1
                Swap(ref permutations[index], ref permutations[i]);
                Permute(index + 1);
                Swap(ref permutations[index], ref permutations[i]);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

}
