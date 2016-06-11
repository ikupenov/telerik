using System;

class SumOfNNumbers
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());

        double sum = 0;
        double number = 0;

        for (double i = 1; i <= n; i++)
        {
            number = double.Parse(Console.ReadLine());
            sum += number;
        }

        Console.WriteLine(sum);
    }
}