using System;

class Program
{
    static void Main()
    {
        long numberOne = long.Parse(Console.ReadLine());
        long rounds = long.Parse(Console.ReadLine());
        int counter = 0;

        long mask = 15 << 0;
        long nAndMask = numberOne & mask;
        long lastBits = nAndMask >> 0;

        for (long i = 1; i <= rounds; i++)
        {
            long nextN = long.Parse(Console.ReadLine());
            
            for (int bits = 0; bits <= 26; bits++)
            {
                long secondMask = 15 << bits;
                long secondNAndMask = nextN & secondMask;
                long secondLastBis = secondNAndMask >> bits;

                if (secondLastBis == lastBits)
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }
}