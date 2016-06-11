using System;
using System.Numerics;

class BinaryToDecimal
{
    static void Main()

    {
        BigInteger binary = BigInteger.Parse(Console.ReadLine());


        BigInteger rem = 0;
        BigInteger powStatic = 0;
        BigInteger powDynamic = -1;
        BigInteger toDecimal = 0;

        BigInteger i = -1;

        while (binary > 0)
        {
            rem = binary % 10;
            binary = binary / 10;
            powDynamic++;


            for (int DONTNEED = -1; i < powDynamic; i++) // 2^n
            {
                if (2 * powDynamic == 0)
                {
                    powStatic++;
                    continue;
                }

                powStatic *= 2;
            }

            toDecimal += rem * powStatic;

        }

        Console.WriteLine(toDecimal);

    }
}