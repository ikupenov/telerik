using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static public int getMax (int a, int b)
    {
        int bigger = 0;

        if (a >= b)
            bigger = a;
        else
            bigger = b;

        return bigger;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        int a = Convert.ToInt32(input[0]);
        int b = Convert.ToInt32(input[1]);
        int c = Convert.ToInt32(input[2]);

        if (getMax(a, b) >= c)
        {
            Console.WriteLine(getMax(a, b));
        }
        else
            Console.WriteLine(c);
    }
}
