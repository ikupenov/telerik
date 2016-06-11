using System;

class BiggestOf3
{
    static void Main()
    {
        float first = float.Parse(Console.ReadLine());
        float second = float.Parse(Console.ReadLine());
        float third = float.Parse(Console.ReadLine());

        if (first > second && first > third)
        {
            Console.WriteLine(first);
        }

        else if (second > first && second > third)
        {
            Console.WriteLine(second);
        }

        else if (third > first && third > second)
        {
            Console.WriteLine(third);
        }

        else
        {
            Console.WriteLine(first);
        }
    }
}