using System;
using System.Numerics;

class Trailing0
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        BigInteger lastDigit;
        BigInteger fac = 1;
        int zeroCounter = 0;

        for (int i = 1; i <= number; i++)
        {
            fac *= i;
        }

        while (fac > 0)
        {
            lastDigit = fac % 10;

            if (lastDigit == 0)
            {
                zeroCounter++;
            }

            else 
            {
                break;
            }

            fac /= 10;
        }

        Console.WriteLine(zeroCounter);
    }
}