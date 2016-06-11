using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        while (true)
        {
            long input = long.Parse(Console.ReadLine());

            if (input == -1)
            {
                return;
            }

            if (input == 0)
            {
                Console.WriteLine(0);
                continue;
            }

            bool isRight = false;
            int mostRight = 0;
            int mostLeft = 0;

            for (int p = 0; p < 32; p++)
            {
                long mask = 1 << p;
                long oneOrNot = (long)input & mask;
                long getBit = oneOrNot >> p;

                if (getBit == 1 && isRight == false)
                {
                    mostRight = p;
                    isRight = true;
                }

                if (getBit == 1)
                {
                    mostLeft = p;
                }
            }

            for (; mostRight <= mostLeft; mostRight++)
            {
                long swapMask = 1 << mostRight;

                if (swapMask == -2147483648)
                {
                    swapMask *= -1;
                }

                input ^= swapMask;
            }

            Console.WriteLine(input);
        }
    }
}