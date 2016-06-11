using System;

class MultiplicationSign
{
    static void Main()
    {
        double first = double.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        double third = double.Parse(Console.ReadLine());

        double result = first * second * third;

        if (result > 0)
        {
            Console.WriteLine("+");
        }

        else if (result == 0)
        {
            Console.WriteLine("0");
        }

        else
        {
            Console.WriteLine("-");
        }
    }
}