using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var path = Console.ReadLine()
                          .Split(new char[] { ' ', ',' },
                           StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

        int N = int.Parse(Console.ReadLine());
        long mostCoins = long.MinValue;

        for (int i = 0; i < N; i++)
        {
            var pattern = Console.ReadLine()
                                 .Split(new char[] { ' ', ',' },
                                 StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var tempPath = new int[path.Length];
            for (int k = 0; k < path.Length; k++)
                tempPath[k] = path[k];

            int pathPos = 0;
            long currentCoins = 0;

            for (int j = 0; ; j++)
            {
                currentCoins += tempPath[pathPos];
                tempPath[pathPos] = 1001;

                var patternPos = j % pattern.Length;
                pathPos += pattern[patternPos];

                if (pathPos >= tempPath.Length || pathPos < 0)
                    break;
                else if (tempPath[pathPos] == 1001)
                    break;
            }

            if (currentCoins > mostCoins)
                mostCoins = currentCoins;
        }

        Console.WriteLine(mostCoins);
    }
}