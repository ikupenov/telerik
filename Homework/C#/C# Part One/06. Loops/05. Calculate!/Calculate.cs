using System;

class Calculate
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());

        double factorialN = 1;
        //double divider = 1;
        double result = 1;

        for (double i = 1; i <= N; i++)
        {
            factorialN *= i;
            x *= i;
            result += factorialN / x;
        }

        Console.WriteLine("{0:F5}", result);
    }
}