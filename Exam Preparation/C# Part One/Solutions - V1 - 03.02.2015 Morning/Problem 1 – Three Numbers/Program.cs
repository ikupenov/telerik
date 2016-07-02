using System;

class Program
{
    static void Main()
    {
        double A = double.Parse(Console.ReadLine());
        double B = double.Parse(Console.ReadLine());
        double C = double.Parse(Console.ReadLine());
        double arithmetic = (A + B + C) / 3;

        Console.WriteLine(Math.Max(Math.Max(A, B), C));
        Console.WriteLine(Math.Min(Math.Min(A, B), C));
        Console.WriteLine("{0:F2}", arithmetic);
    }
}