using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var field = new int[size, size];

        //Matrix Input
        for (int row = 0; row < size; row++)
        {
            var input = Console.ReadLine().Split(' ');

            for (int col = 0; col < size; col++)
            {
                field[row, col] = int.Parse(input[col]);
            }
        }

        int result = 0;

        for (int row = 0; row < size - 4; row++)
        {
            for (int col = 1; col < size; col++)
            {
                int digit = field[row, col];

                if (col >= 2 && digit != 2)
                {
                    switch (digit)
                    {
                        case 1: result += isOne(field, row, col); break;
                        case 3: result += isThree(field, row, col); break;
                        case 4: result += isFour(field, row, col); break;
                        case 5: result += isFive(field, row, col); break;
                        case 6: result += isSix(field, row, col); break;
                        case 7: result += isSeven(field, row, col); break;
                        case 8: result += isEight(field, row, col); break;
                        case 9: result += isNine(field, row, col); break;
                    }
                }

                if (col >= 1 && col < size - 1 && digit == 2)
                {
                    result += isTwo(field, row, col);
                }
            }
        }

        Console.WriteLine(result);
    }

    static int isOne(int[,] field, int row, int col)
    {
        bool isOne = field[row + 1, col] == 1 &&
                     field[row + 2, col] == 1 &&
                     field[row + 3, col] == 1 &&
                     field[row + 4, col] == 1 &&
                     field[row + 1, col - 1] == 1 &&
                     field[row + 2, col - 2] == 1;

        if (isOne)
            return 1;
        else
            return 0;
    }

    static int isTwo(int[,] field, int row, int col)
    {
        bool isTwo = field[row + 1, col - 1] == 2 &&
                     field[row + 1, col + 1] == 2 &&
                     field[row + 2, col + 1] == 2 &&
                     field[row + 3, col] == 2 &&
                     field[row + 4, col - 1] == 2 &&
                     field[row + 4, col + 1] == 2 &&
                     field[row + 4, col] == 2;


        if (isTwo)
            return 2;
        else
            return 0;
    }

    static int isThree(int[,] field, int row, int col)
    {
        bool isThree = field[row, col - 1] == 3 &&
                       field[row, col - 2] == 3 &&
                       field[row + 1, col] == 3 &&
                       field[row + 2, col] == 3 &&
                       field[row + 2, col - 1] == 3 &&
                       field[row + 3, col] == 3 &&
                       field[row + 4, col] == 3 &&
                       field[row + 4, col - 1] == 3 &&
                       field[row + 4, col - 2] == 3;

        if (isThree)
            return 3;
        else
            return 0;
    }

    static int isFour(int[,] field, int row, int col)
    {
        bool isFour = field[row, col - 2] == 4 &&
                      field[row + 1, col] == 4 &&
                      field[row + 1, col - 2] == 4 &&
                      field[row + 2, col] == 4 &&
                      field[row + 2, col - 1] == 4 &&
                      field[row + 2, col - 2] == 4 &&
                      field[row + 3, col] == 4 &&
                      field[row + 4, col] == 4;

        if (isFour)
            return 4;
        else
            return 0;
    }

    static int isFive(int[,] field, int row, int col)
    {
        bool isFive = field[row, col - 1] == 5 &&
                      field[row, col - 2] == 5 &&
                      field[row + 1, col - 2] == 5 &&
                      field[row + 2, col] == 5 &&
                      field[row + 2, col - 1] == 5 &&
                      field[row + 2, col - 2] == 5 &&
                      field[row + 3, col] == 5 &&
                      field[row + 4, col] == 5 &&
                      field[row + 4, col - 1] == 5 &&
                      field[row + 4, col - 2] == 5;

        if (isFive)
            return 5;
        else
            return 0;
    }

    static int isSix(int[,] field, int row, int col)
    {
        bool isSix = field[row, col - 1] == 6 &&
                     field[row, col - 2] == 6 &&
                     field[row + 1, col - 2] == 6 &&
                     field[row + 2, col] == 6 &&
                     field[row + 2, col - 1] == 6 &&
                     field[row + 2, col - 2] == 6 &&
                     field[row + 3, col] == 6 &&
                     field[row + 3, col - 2] == 6 &&
                     field[row + 4, col] == 6 &&
                     field[row + 4, col - 1] == 6 &&
                     field[row + 4, col - 2] == 6;

        if (isSix)
            return 6;
        else
            return 0;
    }

    static int isSeven(int[,] field, int row, int col)
    {
        bool isSeven = field[row, col - 1] == 7 &&
                       field[row, col - 2] == 7 &&
                       field[row + 1, col] == 7 &&
                       field[row + 2, col - 1] == 7 &&
                       field[row + 3, col - 1] == 7 &&
                       field[row + 4, col - 1] == 7;

        if (isSeven)
            return 7;
        else
            return 0;
    }

    static int isEight(int[,] field, int row, int col)
    {
        bool isEight = field[row, col - 1] == 8 &&
                       field[row, col - 2] == 8 &&
                       field[row + 1, col] == 8 &&
                       field[row + 1, col - 2] == 8 &&
                       field[row + 2, col - 1] == 8 &&
                       field[row + 3, col] == 8 &&
                       field[row + 3, col - 2] == 8 &&
                       field[row + 4, col] == 8 &&
                       field[row + 4, col - 1] == 8 &&
                       field[row + 4, col - 2] == 8;

        if (isEight)
            return 8;
        else
            return 0;
    }

    static int isNine(int[,] field, int row, int col)
    {
        bool isNine = field[row, col - 1] == 9 &&
                      field[row, col - 2] == 9 &&
                      field[row + 1, col] == 9 &&
                      field[row + 1, col - 2] == 9 &&
                      field[row + 2, col] == 9 &&
                      field[row + 2, col - 1] == 9 &&
                      field[row + 3, col] == 9 &&
                      field[row + 4, col] == 9 &&
                      field[row + 4, col - 1] == 9 &&
                      field[row + 4, col - 2] == 9;

        if (isNine)
            return 9;
        else
            return 0;
    }
}