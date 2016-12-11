using System;

namespace DogePlusPlus
{
    class StartUp
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            long[,] field = new long[rows, cols];

            string[] enemiesCoordinates = Console.ReadLine().Split(';');
            foreach (string enemyCoordinate in enemiesCoordinates)
            {
                string[] coordinatesSplit = enemyCoordinate.Split(' ');
                int x = int.Parse(coordinatesSplit[0]);
                int y = int.Parse(coordinatesSplit[1]);

                field[x, y] = -1;
            }

            for (int row = 0; row < rows; row++)
            {
                if (field[row, 0] == -1)
                {
                    break;
                }
                else
                {
                    field[row, 0] = 1;
                }
            }

            for (int col = 0; col < cols; col++)
            {
                if (field[0, col] == -1)
                {
                    break;
                }
                else
                {
                    field[0, col] = 1;
                }
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (field[row, col] == -1)
                    {
                        continue;
                    }

                    long leftValue = field[row, col - 1] == -1 ? 0 : field[row, col - 1];
                    long topValue = field[row - 1, col] == -1 ? 0 : field[row - 1, col];

                    field[row, col] = leftValue + topValue;
                }
            }

            bool isReachable = field[rows - 1, cols - 1] > 0;
            Console.WriteLine(isReachable ? field[rows - 1, cols - 1] : 0);
        }
    }
}