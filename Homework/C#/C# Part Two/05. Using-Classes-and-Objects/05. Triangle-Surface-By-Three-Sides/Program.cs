using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double p = (a + b + c) / 2;
        double equation = p * (p - a) * (p - b) * (p - c);

        double A = Math.Sqrt(equation);
        Console.WriteLine("{0:F2}", A);
    }
}
