using System;
using System.Linq;
using System.Numerics;

class Program
{
    static long Modul(long a, long n)
    {
        long result = a % n;

        if ((a < 0 && n > 0) || (a > 0 && n < 0))
            result += n;

        return result;
    }

    static void Main()
    {
        var path = Console.ReadLine()
                          .Split(' ')
                          .Select(long.Parse)
                          .ToArray();

        BigInteger mollyFlowers = 0;
        BigInteger dollyFlowers = 0;

        long mollyIndex = 0;
        long dollyIndex = path.Length - 1;

        bool mollyEmpty = false;
        bool dollyEmpty = false;

        while (true)
        {
            long mollyMoves = path[mollyIndex];
            long dollyMoves = path[dollyIndex];
        
            if (mollyIndex != dollyIndex)
            {
                mollyFlowers += path[mollyIndex];
                dollyFlowers += path[dollyIndex];
            }
            else
            {
                mollyFlowers += path[mollyIndex] / 2;
                dollyFlowers += path[dollyIndex] / 2;
            }

            if (path[mollyIndex] == 0 || path[dollyIndex] == 0)
            {
                if (path[mollyIndex] == 0 && path[dollyIndex] == 0)
                {
                    mollyEmpty = true;
                    dollyEmpty = true;
                }
                else
                {
                    if (path[mollyIndex] == 0)
                        mollyEmpty = true;
                    else
                        dollyEmpty = true;
                }
                break;
            }

            if (mollyIndex != dollyIndex)
            {
                path[mollyIndex] = 0;
                path[dollyIndex] = 0;

            }
            else
            {
                long remainder = path[mollyIndex] % 2;
                path[mollyIndex] = remainder;
            }

            mollyIndex = Modul(mollyIndex + mollyMoves, path.Length);
            dollyIndex = Modul(dollyIndex - dollyMoves, path.Length);
        }


        if (mollyEmpty == true && dollyEmpty == true)
            Console.WriteLine("Draw");
        else
        {
            if (mollyEmpty == true)
                Console.WriteLine("Dolly");
            else
                Console.WriteLine("Molly");
        }

        Console.WriteLine(mollyFlowers + " " + dollyFlowers);
    }
}