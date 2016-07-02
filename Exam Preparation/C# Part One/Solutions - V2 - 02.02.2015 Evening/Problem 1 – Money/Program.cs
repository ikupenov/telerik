using System;

class Program
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double s = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());

        double result = 0;

        result = n * s;
        result /= 400;

        result *= p;

        Console.WriteLine("{0:F3}", result);
    }
}