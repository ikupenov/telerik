using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Calculate (List<decimal> numbers)
    {
        decimal min = numbers.Min();
        decimal max = numbers.Max();
        decimal sum = numbers.Sum();
        decimal average = numbers.Average();
        decimal product = 1;
        
        for (int i = 0; i < numbers.Count; i++)
        {
            product *= numbers[i];
        }

        Console.WriteLine(min);
        Console.WriteLine(max);
        Console.WriteLine("{0:F2}", average);
        Console.WriteLine(sum);
        Console.WriteLine(product);
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        var numbers = new List<decimal>();

        for (int i = 0; i < input.Length; i++)
        {
            numbers.Add(decimal.Parse(input[i]));
        }

        Calculate(numbers);
    }
}