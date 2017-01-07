using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        private static Dictionary<int, int> permutationValues;

        private static int n;
        private static int k;

        static void Main(string[] args)
        {
            permutationValues = new Dictionary<int, int>();

            n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            k = int.Parse(Console.ReadLine());

            int operationsCount = CalculateOperations(numbers);
            Console.WriteLine(operationsCount);
        }

        static int CalculateOperations(int[] startPerm)
        {
            Queue<int[]> permutations = new Queue<int[]>();
            permutations.Enqueue(startPerm);

            permutationValues.Add(GetHashCode(startPerm), 0);

            while (permutations.Count > 0)
            {
                var currPerm = permutations.Dequeue();
                var permValue = permutationValues[GetHashCode(currPerm)];

                if (IsSorted(currPerm))
                {
                    return permValue;
                }

                for (int i = 0; i <= n - k; i++)
                {
                    var tempPerm = currPerm.Clone() as int[];
                    Array.Reverse(tempPerm, i, k);

                    if (!permutationValues.ContainsKey(GetHashCode(tempPerm)))
                    {
                        permutations.Enqueue(tempPerm);
                        permutationValues.Add(GetHashCode(tempPerm), permValue + 1);
                    }
                }
            }

            return -1;
        }

        static int GetHashCode(int[] arr)
        {
            int hashCode = 0;
            foreach (var num in arr)
            {
                hashCode *= 8;
                hashCode += num;
            }

            return hashCode;
        }

        static bool IsSorted(int[] numbers)
        {
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] != i + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
