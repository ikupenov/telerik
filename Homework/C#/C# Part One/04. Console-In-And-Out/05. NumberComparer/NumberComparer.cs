using System;

class NumberComparer
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine(Math.Max(firstNumber, secondNumber));
    }
}