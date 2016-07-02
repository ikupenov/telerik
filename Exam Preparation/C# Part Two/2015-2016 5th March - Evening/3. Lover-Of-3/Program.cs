using System;

class Program
{
    static int[] Direction(string direction)
    {
        int[] diagonalDirection = new int[2];

        //Up-Right Direction
        if (direction == "UR" || direction == "RU")
        {
            diagonalDirection[0] = -1;
            diagonalDirection[1] = +1;
        }

        //Up-Left Direction
        else if (direction == "UL" || direction == "LU")
        {
            diagonalDirection[0] = -1;
            diagonalDirection[1] = -1;
        }

        //Down-Right Direction
        else if (direction == "DR" || direction == "RD")
        {
            diagonalDirection[0] = +1;
            diagonalDirection[1] = +1;
        }

        //Down-Left Direction
        else if (direction == "DL" || direction == "LD")
        {
            diagonalDirection[0] = +1;
            diagonalDirection[1] = -1;
        }

        return diagonalDirection;
    }

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int totalMoves = int.Parse(Console.ReadLine());

        int x = int.Parse(dimensions[0]);
        int y = int.Parse(dimensions[1]);
        int[,] field = new int[x, y];

        //Field fill
        for (int col = 0, colN = 0; col < y; col++, colN += 3)
        {
            for (int row = x - 1, rowN = colN; row >= 0; row--, rowN += 3)
            {
                field[row, col] = rowN;
            }
        }

        long sum = 0;
        int xDirection = 0;
        int yDirection = 0;

        int currentRow = x - 1;
        int currentCol = 0;

        for (int i = 0; i < totalMoves; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string direction = input[0];
            int moves = int.Parse(input[1]);

            int[] diagonalD = Direction(direction);
            xDirection = diagonalD[0];
            yDirection = diagonalD[1];

            for (int j = 0; j < moves - 1; j++)
            {
                int tempRow = currentRow + xDirection;
                int tempCol = currentCol + yDirection;

                if (tempRow < 0 || tempCol < 0 || tempRow > x - 1 || tempCol > y - 1)
                {
                    break;
                }

                currentRow += xDirection;
                currentCol += yDirection;

                sum += field[currentRow, currentCol];
                field[currentRow, currentCol] = 0;
            }
        }

        Console.WriteLine(sum);
    }
}