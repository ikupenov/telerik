using System;

class BiggestOf5
{
    static void Main()
    {
        double first = double.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        double third = double.Parse(Console.ReadLine());
        double forth = double.Parse(Console.ReadLine());
        double fifth = double.Parse(Console.ReadLine());

        if (first > second && first > third && first > forth && first > fifth)
        {
            Console.WriteLine(first);
        }

        else if (second > first && second > third && second > forth && second > fifth)
        {
            Console.WriteLine(second);
        }

        else if (third > first && third > second && third > forth && third > fifth)
        {
            Console.WriteLine(third);
        }

        else if (forth > first && forth > second && forth > third && forth > fifth)
        {
            Console.WriteLine(forth);
        }

        else if (fifth > first && fifth > second && fifth > third && fifth > forth)
        {
            Console.WriteLine(fifth);
        }

        else
        {
            Console.WriteLine(first);
        }
    }
}