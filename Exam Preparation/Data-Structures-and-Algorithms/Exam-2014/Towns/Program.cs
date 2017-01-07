using System;
using System.Linq;

namespace Towns
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] population = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                population[i] = int.Parse(input[0]);
            }

            var increasingSubseq = FindLIS(population);
            var decreasingSubseq = FindLIS(population.Reverse().ToArray()).Reverse().ToArray();

            int maxSum = 0;
            for (int i = 0; i < n; i++)
            {
                int currentSum = (increasingSubseq[i] + decreasingSubseq[i]) - 1;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            Console.WriteLine(maxSum);
        }

        static int[] FindLIS(int[] arr)
        {
            int n = arr.Length;
            int[] lis = new int[n];

            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                    }
                }
            }

            return lis;
        }
    }
}