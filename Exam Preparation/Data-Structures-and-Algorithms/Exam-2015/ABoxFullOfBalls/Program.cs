using System;
using System.Linq;

namespace ABoxFullOfBalls
{
    class Program
    {
        static void Main()
        {
            int[] possibleTurns = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] splitInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int a = splitInput[0];
            int b = splitInput[1];

            bool[] isWinCase = new bool[b + 1];
            isWinCase[0] = false;

            for (int currBalls = 1; currBalls <= b; currBalls++)
            {
                foreach (var possibleTurn in possibleTurns)
                {
                    if (possibleTurn > currBalls)
                    {
                        continue;
                    }

                    if (!isWinCase[currBalls - possibleTurn])
                    {
                        isWinCase[currBalls] = true;
                    }
                }
            }

            int totalWins = isWinCase.Where((x, i) => x && i >= a).Count();
            Console.WriteLine(totalWins);
        }
    }
}
