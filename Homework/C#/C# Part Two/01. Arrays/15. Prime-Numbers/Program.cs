using System;
using System.Collections.Generic;
using System.Linq;

class Program
{  
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (!IsPrime(n))
        {
            do
            {
                n--;
                IsPrime(n);
            } while (!IsPrime(n));
        }

        Console.WriteLine(n);
    }

    static bool IsPrime(int num)
    {
        for (int i = 2; i < Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
