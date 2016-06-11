using System;

class From1ToN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 1;

        while (counter <= n)
        {
            Console.Write("{0} ", counter);
            counter++;
        }
        Console.WriteLine();
    }
}