using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char symbol = char.Parse(Console.ReadLine());

        int[,] numbers = new int[n, n];

        switch (symbol)
        {
            case 'a': a(numbers); break;
            case 'b': b(numbers); break;
            case 'c': c(numbers); break;
            case 'd': d(numbers); break;
        }
    }

    static void a(int[,] numbers)
    {
        int counter = 1;

        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                numbers[col, row] = counter;
                counter++;
            }
        }

        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                Console.Write(numbers[row, col]);

                if (col + 1 != numbers.GetLength(1))
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }

    static void b(int[,] numbers)
    {
        int counter = 1;

        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    numbers[row, col] = counter;
                    counter++;
                }
            }

            else
            {
                for (int col = numbers.GetLength(1) - 1; col >= 0; col--)
                {
                    numbers[row, col] = counter;
                    counter++;
                }
            }
        }

        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                Console.Write(numbers[col, row]);

                if (col + 1 != numbers.GetLength(1))
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }

    static void c(int[,] numbers)
    {
        int n = numbers.GetLength(0);

        int counter = 1;

        for (int row = n - 1; row >= 0; row--)
        {
            int tempRow = row;

            for (int col = 0; tempRow <= n - 1; col++, tempRow++)
            {
                numbers[tempRow, col] = counter;
                counter++;
            }
        }

        for (int col = 1; col <= n - 1; col++)
        {
            int tempCol = col;

            for (int row = 0; row < n - 1; row++, tempCol++)
            {
                numbers[row, tempCol] = counter;
                counter++;

                if (tempCol == n - 1)
                {
                    break;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(numbers[i, j]);

                if (j + 1 != n)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }

    static void d(int[,] numbers)
    {
        int n = numbers.GetLength(0);

        int posX = 0;
        int posY = 0;
        int direction = 0;

        bool outside = true;

        for (int i = 1; i <= n * n; i++)
        {
            numbers[posX, posY] = i;

            #region outside
            if (outside == true)
            {
                if (direction == 0 && posX == n - 1) //left
                {
                    direction = 1;
                }

                else if (direction == 1 && posY == n - 1) //bot
                {
                    direction = 2;
                }

                else if (direction == 2 && posX == 0) //right
                {
                    direction = 3;
                }

                else if (direction == 3 && numbers[posX, posY - 1] != 0) //top
                {
                    direction = 0;
                    outside = false;
                }
            }
            #endregion

            #region inside
            else
            {
                if (direction == 0 && numbers[posX + 1, posY] != 0) //left
                {
                    direction = 1;
                }

                else if (direction == 1 && numbers[posX, posY + 1] != 0) //bot
                {
                    direction = 2;
                }

                else if (direction == 2 && numbers[posX - 1, posY] != 0) //right
                {
                    direction = 3;
                }

                else if (direction == 3 && numbers[posX, posY - 1] != 0) //top
                {
                    direction = 0;
                }
            }
            #endregion

            switch (direction)
            {
                case 0:
                    posX++;
                    break;

                case 1:
                    posY++;
                    break;

                case 2:
                    posX--;
                    break;

                case 3:
                    posY--;
                    break;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(numbers[i, j]);

                if (j + 1 != n)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}
