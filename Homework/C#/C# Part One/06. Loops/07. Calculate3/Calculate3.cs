using System;
using System.Numerics;

class Calculate3
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger K = BigInteger.Parse(Console.ReadLine());

        //N = Math.Abs(N);
        //K = Math.Abs(K);

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger factorialNK = N - K;
        BigInteger result = 0;

        for (int i = 1; i <= N; i++)
        {
            factorialN *= i;

            if (i <= K)
            {
                factorialK *= i;
            }

            if (i < N - K)
            {
                factorialNK *= i;
            }
        }


        result = factorialN / (factorialK * (factorialNK));

        Console.WriteLine(result);
    }
}
