namespace BobbyAvokadoto
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            uint bobbysHead = uint.Parse(Console.ReadLine());
            int totalCombs = int.Parse(Console.ReadLine());

            uint bestComb = 0u;
            uint bestBits = 0u;

            for (int i = 0; i < totalCombs; i++)
            {
                uint nextComb = uint.Parse(Console.ReadLine());

                if ((bobbysHead | nextComb) == bobbysHead + nextComb)
                {
                    uint bits = 0;

                    uint comb = nextComb;

                    while (comb > 0)
                    {
                        bits += comb & 1u;
                        comb >>= 1;
                    }

                    if (bits > bestBits)
                    {
                        bestComb = nextComb;
                        bestBits = bits;
                    }
                }
            }

            Console.WriteLine(bestComb);
        }
    }
}