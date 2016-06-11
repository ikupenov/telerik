using System;

class Program
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());

        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * Math.Pow(radius, 2);

        Console.WriteLine("{0:0.00} {1:0.00}", perimeter, area);
    }
}