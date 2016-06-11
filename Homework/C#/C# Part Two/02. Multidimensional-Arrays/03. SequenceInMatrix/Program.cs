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

        int finalCounter = 0;

        //====================================HORIZONTAL

        for (int row = 0; row < n; row++)
        {
            int counter = 1;

            for (int col = 0; col < m - 1; col++)
            {
                if (numbers[row, col] == numbers[row, col + 1])
                {
                    counter++;
                }

                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        //====================================VERTICAL

        for (int col = 0; col < m; col++)
        {
            int counter = 1;

            for (int row = 0; row < n - 1; row++)
            {
                if (numbers[row, col] == numbers[row + 1, col])
                {
                    counter++;
                }

                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        //====================================DIAGONAL

        //Bottom-Left->Bottom-Right
        for (int row = n - 1; row >= 0; row--)
        {
            int counter = 1;
            int tempRow = row;

            for (int col = 0; tempRow < n - 1 && col < m - 1; col++, tempRow++)
            {
                if (numbers[tempRow, col] == numbers[tempRow + 1, col + 1])
                {
                    counter++;
                }

                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        //Top-Right->Bottom-Right
        for (int col = 1; col < m - 1; col++)
        {
            int counter = 1;
            int tempCol = col;

            for (int row = 0; tempCol < m - 1 && row < n - 1; row++, tempCol++)
            {
                if (numbers[row, tempCol] == numbers[row + 1, tempCol + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        //====================================DIAGONAL-2

        //Bottom-Right-->Bottom-Left
        for (int row = n - 1; row >= 0; row--)
        {
            int counter = 1;
            int tempRow = row;

            for (int col = m - 1; col >= 1 && tempRow < n - 1; col--, tempRow++)
            {
                if (numbers[tempRow, col] == numbers[tempRow + 1, col - 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        //Top-Right-->Bottom-Left
        
        for (int col = m - 2; col >= 0; col--)
        {
            int counter = 0;
            int tempCol = col;

            for (int row = 0; row < n - 1 && tempCol >= 1; row++, tempCol--)
            {
                if (numbers[row, tempCol] == numbers[row + 1, tempCol - 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > finalCounter)
                {
                    finalCounter = counter;
                }
            }
        }

        Console.WriteLine(finalCounter);
    }
}