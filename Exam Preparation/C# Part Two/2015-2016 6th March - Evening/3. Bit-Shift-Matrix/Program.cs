using System;
using System.Linq;
using System.Numerics;

class Program
{
    static public BigInteger[,] field;
    static public BigInteger sum = 0;
    static public int currRow;
    static public int currCol;

    static void FillArray(int R, int C)
    {
        field = new BigInteger[R, C];

        //Fill last row only
        for (int row = R - 1; row == R - 1; row--)
        {
            field[R - 1, 0] = 1;
            for (int col = 1; col < C; col++)
            {
                field[row, col] = field[row, col - 1] * 2;
            }
        }

        //Fill the rest of the matrix
        for (int col = 0; col < C; col++)
        {
            for (int row = R - 2; row >= 0; row--)
            {
                field[row, col] = field[row + 1, col] * 2;
            }
        }
    }

    static void Main()
    {
        int R = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        var CODEs = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();

        FillArray(R, C);

        int COEF = Math.Max(R, C);
        currRow = R - 1;
        currCol = 0;

        for (int i = 0; i < N; i++)
        {
            int toCol = CODEs[i] % COEF;
            FindColSum(toCol);

            int toRow = CODEs[i] / COEF;
            FindRowSum(toRow);
        }

        Console.WriteLine(sum);
    }

    static void FindColSum(int toCol)
    {
        if (toCol >= currCol)
        {
            for (int col = currCol; col <= toCol; col++)
            {
                sum += field[currRow, col];
                field[currRow, col] = 0;
            }
        }
        else if (toCol < currCol)
        {
            for (int col = currCol; col >= toCol; col--)
            {
                sum += field[currRow, col];
                field[currRow, col] = 0;
            }
        }

        currCol = toCol;
    }

    static void FindRowSum(int toRow)
    {
        if (toRow >= currRow)
        {
            for (int row = currRow; row <= toRow; row++)
            {
                sum += field[row, currCol];
                field[row, currCol] = 0;
            }
        }
        else if (toRow < currRow)
        {
            for (int row = currRow; row >= toRow; row--)
            {
                sum += field[row, currCol];
                field[row, currCol] = 0;
            }
        }

        currRow = toRow;
    }
}
