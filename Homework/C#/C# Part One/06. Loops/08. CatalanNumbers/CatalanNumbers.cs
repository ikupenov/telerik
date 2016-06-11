using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        BigInteger NCheck = 2 * n;
        BigInteger NPlusOneCheck = n + 1;

        BigInteger twoTimesN = 2 * n;
        BigInteger nPlusOne = n + 1;
        BigInteger nFact = 1;

        BigInteger result = 1;


        if (n == 0)
        {
            Console.WriteLine(result);
        }

        else
        {
            for (int i = 1; i <= NCheck; i++)
            {
                if (i <= n)
                {
                    nFact *= i;
                }

                if (i < NCheck)
                {
                    twoTimesN *= i;
                }

                if (i < NPlusOneCheck)
                {
                    nPlusOne *= i;
                }
            }

            result = twoTimesN / (nPlusOne * nFact);

            Console.WriteLine(result);
        }     
    }
}