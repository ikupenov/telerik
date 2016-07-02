using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var matrix = new long[size, size];

        for (int row = 0; row < size; row++)
        {
            var fill = Console.ReadLine().Split(' ');

            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = long.Parse(fill[col]);
            }
        }

        long result = long.MinValue;
        bool found = false;

        for (int row = 0; row <= size - 3; row++)
        {
            for (int col = 0; col <= size - 5; col++)
            {
                long currentNumber = matrix[row, col];
                long tempResult = CheckPatern(matrix, row, col);

                if (tempResult > result)
                {
                    found = true;
                    result = tempResult;
                }
            }
        }

        if (found == true)
        {
            Console.WriteLine("YES {0}", result);
        }
        else
        {
            result = 0;

            for (int rowAndCol = 0; rowAndCol < size; rowAndCol++)
            {
                result += matrix[rowAndCol, rowAndCol];
            }

            Console.WriteLine("NO {0}", result);
        }
    }

    static long CheckPatern(long[,] matrix, int row, int col)
    {
        long A = matrix[row, col];
        long B = matrix[row, col + 1];
        long C = matrix[row, col + 2];
        long D = matrix[row + 1, col + 2];
        long E = matrix[row + 2, col + 2];
        long F = matrix[row + 2, col + 3];
        long G = matrix[row + 2, col + 4];

        long sum = 0;

        bool isSeq = B == A + 1 &&
                     C == B + 1 &&
                     D == C + 1 &&
                     E == D + 1 &&
                     F == E + 1 &&
                     G == F + 1;
        if (isSeq)
        {
            sum = A + B + C + D + E + F + G;
            return sum;
        }
        else
            return long.MinValue;
    }
}