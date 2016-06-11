using System;

class Program
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal S = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());

        decimal result = (decimal)(N * S) / (decimal)500;
        result *= (decimal)P;

        Console.WriteLine("{0:0.00}", result);
    }
}