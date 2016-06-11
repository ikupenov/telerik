using System;
using System.Numerics;

class CalculateAgain
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger K = BigInteger.Parse(Console.ReadLine());

        BigInteger productN = 1;
        BigInteger productK = 1;

        for (BigInteger i = 1; i <= N; i++)
        {
            productN *= i;          

            if (i <= K)
            {
                productK *= i;

            }
        }

        BigInteger result = productN / productK;

       Console.WriteLine(result);
    }
}