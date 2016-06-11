using System;
class PrimeNumbers
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        bool result = false;
        if (!isPrime(n))
        {
            do
            {
                n--;
                result = isPrime(n);

            } while (!result);
        }

        Console.WriteLine(n);


    }

    private static bool isPrime(uint n)
    {
        bool sp = true;
        for (uint i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                sp = false;
        }
        return sp;
    }
}
