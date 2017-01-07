using System;
using System.Linq;

namespace Portals
{
    class Program
    {
        private static int maxSum;

        private static int[,] matrix;
        private static int matrixRows;
        private static int matrixCols;

        static void Main()
        {
            int[] startIndeces = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startRow = startIndeces[0];
            int startCol = startIndeces[1];

            matrixRows = matrixSize[0];
            matrixCols = matrixSize[1];
            matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = input[col] == "#" ? -1 : int.Parse(input[col]);
                }
            }

            int startSum = matrix[startRow, startCol];
            Traverse(startRow, startCol, startSum);

            Console.WriteLine(maxSum);
        }

        static void Traverse(int currentRow, int currentCol, int currentSum)
        {
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }

            int currentValue = matrix[currentRow, currentCol];
            if (currentValue == -1)
            {
                return;
            }

            int deltaUp = currentRow - currentValue;
            int deltaDown = currentRow + currentValue;
            int deltaLeft = currentCol - currentValue;
            int deltaRight = currentCol + currentValue;

            // Go up
            if (IsValid(deltaUp, currentCol))
            {
                int sum = matrix[deltaUp, currentCol] + currentSum;

                matrix[currentRow, currentCol] = -1;
                Traverse(deltaUp, currentCol, sum);
                matrix[currentRow, currentCol] = currentValue;
            }

            // Go down
            if (IsValid(deltaDown, currentCol))
            {
                int sum = matrix[deltaDown, currentCol] + currentSum;

                matrix[currentRow, currentCol] = -1;
                Traverse(deltaDown, currentCol, sum);
                matrix[currentRow, currentCol] = currentValue;
            }

            // Go left
            if (IsValid(currentRow, deltaLeft))
            {
                int sum = matrix[currentRow, deltaLeft] + currentSum;

                matrix[currentRow, currentCol] = -1;
                Traverse(currentRow, deltaLeft, sum);
                matrix[currentRow, currentCol] = currentValue;
            }

            // Go right
            if (IsValid(currentRow, deltaRight))
            {
                int sum = matrix[currentRow, deltaRight] + currentSum;

                matrix[currentRow, currentCol] = -1;
                Traverse(currentRow, deltaRight, sum);
                matrix[currentRow, currentCol] = currentValue;
            }
        }

        static bool IsValid(int row, int col)
        {
            if (row < 0 || row >= matrixRows ||
                col < 0 || col >= matrixCols)
            {
                return false;
            }

            return true;
        }
    }
}
