using System;

class ThirdBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        int mask = 1 << p;

        int nAndMask = n & mask;

        int bit = nAndMask >> p;

        Console.WriteLine(bit);
    }
}