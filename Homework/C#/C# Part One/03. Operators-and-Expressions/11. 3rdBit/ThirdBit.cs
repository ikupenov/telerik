using System;

class ThirdBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = 3;

        int mask = 1 << p;
        int maskAndN = mask & n;

        int bit = maskAndN >> p;

        Console.WriteLine(bit);
    }
}