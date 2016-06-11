using System;

class Secret369
{
    static void Main()
    {
        long A = long.Parse(Console.ReadLine());
        long B = long.Parse(Console.ReadLine());
        long C = long.Parse(Console.ReadLine());

        long result = 0;
        long secondRes = 0;

        if (B == 3)
        {
            result = A + C;
        }

        else if (B == 6)
        {
            result = A * C;
        }

        else if (B == 9)
        {
            result = A % C;
        }

        if (result % 3 == 0)
        {
            secondRes = result / 3;
            Console.WriteLine(secondRes);
        }

        else
        {
            secondRes = result % 3;
            Console.WriteLine(secondRes);
        }

        Console.WriteLine(result);
    }
}