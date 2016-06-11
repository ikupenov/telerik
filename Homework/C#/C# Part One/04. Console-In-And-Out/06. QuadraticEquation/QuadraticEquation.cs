using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double D = (Math.Pow(b, 2)) - 4 * a * c;

        if (D < 0)
        {
            Console.WriteLine("no real roots");
            return;
        }

        double sqrtD = Math.Sqrt(D);

        double x1 = ((-b) + sqrtD) / (2 * a);
        double x2 = ((-b) - sqrtD) / (2 * a);

        if (x1 == x2)
        {
            Console.WriteLine("{0:0.00}", x2);
        }

        else
        {
            Console.WriteLine("{0:0.00}", x2);
            Console.WriteLine("{0:0.00}", x1);
        }
    }
}
