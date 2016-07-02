using System;

class Program
{
    static void Main()
    {
        double A = double.Parse(Console.ReadLine());
        double B = double.Parse(Console.ReadLine());
        double C = double.Parse(Console.ReadLine());

        double result = 0;

        if (B == 2)
        {
            result = A % C;
        }

        else if (B == 4)
        {
            result = A + C;
        }

        else if (B == 8)
        {
            result = A * C;
        }

        double resultNoMod = result;

        if (result % 4 == 0)
        {
            result /= 4;
            Console.WriteLine(result);
        }
        else
        {
            result %= 4;
            Console.WriteLine(result);
        }

        Console.WriteLine(resultNoMod);
    }
}