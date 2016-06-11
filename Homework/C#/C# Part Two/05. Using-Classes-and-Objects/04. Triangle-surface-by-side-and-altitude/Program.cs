using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        double side = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());

        double A = 0.5 * side * altitude;

        Console.WriteLine("{0:F2}", A);
    }
}