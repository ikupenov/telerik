using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double degrees = double.Parse(Console.ReadLine());

        double radians = degrees * (Math.PI / 180);
        double A = (0.5 * (a * b)) * Math.Sin(radians);

        Console.WriteLine("{0:F2}", A);
    }
}