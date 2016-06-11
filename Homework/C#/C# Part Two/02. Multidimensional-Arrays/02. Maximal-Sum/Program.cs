using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(input[0]);
        int m = Convert.ToInt32(input[1]);

        int[,] numbers = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] arrayFil = Console.ReadLine().Split(' ');

            for (int j = 0; j < m; j++)
            {
                numbers[i, j] = Convert.ToInt32(arrayFil[j]);
            }
        }

        int maxSum = int.MinValue;

        for (int row = 1; row < n - 1; row++)
        {
            for (int col = 1; col < m - 1; col++)
            {
                int sum = 0;
                sum += numbers[row - 1, col] + numbers[row - 1, col - 1] + numbers[row - 1, col + 1];
                sum += numbers[row, col] + numbers[row, col - 1] + numbers[row, col + 1];
                sum += numbers[row + 1, col] + numbers[row + 1, col - 1] + numbers[row + 1, col + 1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }

        Console.WriteLine(maxSum);
    }
}