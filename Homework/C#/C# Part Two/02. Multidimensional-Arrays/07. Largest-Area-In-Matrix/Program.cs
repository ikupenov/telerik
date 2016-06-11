using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static int? currentNumber = null;
    public static int currentCount = 0;

    static void FindLargestArea(int?[,] matrix, int x, int y)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        if (x < 0 || y < 0 || x >= n || y >= m)
        {
            return;
        }

        if (matrix[x, y] != currentNumber)
        {
            return;
        }

        else if (matrix[x, y] == currentNumber)
        {
            matrix[x, y] = null;
            currentCount++;
        }

        FindLargestArea(matrix, x + 1, y); //Bottom
        FindLargestArea(matrix, x, y + 1); //Right
        FindLargestArea(matrix, x - 1, y); //Top
        FindLargestArea(matrix, x, y - 1); //Left
    }

    public static int?[,] FillMatrix(string[] input)
    {
        int n = Convert.ToInt32(input[0]);
        int m = Convert.ToInt32(input[1]);

        int?[,] numbers = new int?[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] fill = Console.ReadLine().Split(' ');

            for (int j = 0; j < m; j++)
            {
                numbers[i, j] = Convert.ToInt32(fill[j]);
            }
        }

        return numbers;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int?[,] numbers = FillMatrix(input);

        int n = numbers.GetLength(0);
        int m = numbers.GetLength(1);
        int maxCount = 0;

        for (int rows = 0; rows < n; rows++)
        {
            for (int cols = 0; cols < m; cols++)
            {
                currentNumber = numbers[rows, cols];

                if (currentNumber == null)
                {
                    continue;
                }

                currentCount = 0;
                FindLargestArea(numbers, rows, cols);

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
            }
        }

        Console.WriteLine(maxCount);
    }
}