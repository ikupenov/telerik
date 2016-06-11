using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void ReverseDigits (string number)
    {
        Console.WriteLine("You Chose: Reverse Digits Of The Number: {0}", number);

        char[] array = number.ToCharArray();
        Console.WriteLine("Reversed: {0}", string.Join("", array.Reverse()));
    }

    static void AverageOfSequence (string[] numbers)
    {
        Console.WriteLine("You Chose: Calculate The Average Of The Sequence: {0}", string.Join(" ", numbers));

        double[] toInt = new double[numbers.Length];
        double result = 0;

        for (int i = 0; i < toInt.Length; i++)
        {
            toInt[i] = Convert.ToInt32(numbers[i]);
            result += toInt[i];
        }

        result /= numbers.Length;

        Console.WriteLine("The Average Of The Sequence Is: {0:F2}", result);
    }

    static void LinearEquation (int a, int b, int x)
    {
        int result = a * x + b;
        Console.WriteLine("The Result Of The Linear Equation {0} * {1} + {2}  Is: {3}",a, x, b, result);
    }

    static void Main()
    {
        Console.WriteLine("Press 1 To Reverse Digits Of A Number");
        Console.WriteLine("Press 2 To Calculate The Average Of A Sequence Of Integers");
        Console.WriteLine("Press 3 To Solve The Linear Equation: a * x + b = 0");
        int select = int.Parse(Console.ReadLine());

        switch (select)
        {
            case 1:
                Console.WriteLine("Enter a single number");
                Console.WriteLine("The number MUST BE positive!");
                ReverseDigits(Console.ReadLine());
                break;

            case 2:
                Console.WriteLine("Enter a sequence of numbers, separated with a single interval");
                Console.WriteLine("The Sequence SHOULD NOT BE Empty!");
                AverageOfSequence(Console.ReadLine().Split(' '));
                break;

            case 3:
                Console.WriteLine(@"Enter ""a"", ""b"" and ""x"", each on a new line");
                Console.WriteLine(@"""a"" SHOULD NOT be equal to zero");

                Console.WriteLine(@"Enter ""a"":");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine(@"Enter ""b"":");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(@"Enter ""x"":");
                int x = int.Parse(Console.ReadLine());

                LinearEquation(a, b, x);
                break;

        }

    }
}