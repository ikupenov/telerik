using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int nMinusOne = n - 1; 
        int middleDotsIncreaser = 0;

        int nWidth = n * 3 - 1;

        //top
        for (int i = 1; i <= n + 1; i++)
        {
            Console.Write(".");
        }

        for (int i = 1; i <= n - 1; i++)
        {
            Console.Write("*");
        }

        for (int i = 1; i <= n + 1; i++)
        {
            Console.Write(".");
        }

        Console.WriteLine();


        //top - 2

        for (int i = 0; i < n - 2; i++)
        {
            for (int leftDots = nMinusOne; leftDots >= 1 ; leftDots --)
            {
                Console.Write(".");
            }

            Console.Write("*");


            for (int middleDots = 1; middleDots <= n + 1 + middleDotsIncreaser; middleDots++)
            {
                Console.Write(".");
            }

            Console.Write("*");


            for (int leftDots = nMinusOne; leftDots >= 1; leftDots--)
            {
                Console.Write(".");
            }

            if (nMinusOne > 2)
            {
                nMinusOne -= 2;
            }

            if (middleDotsIncreaser <= (n * 3) - 4 - (n + 1))
            {
                middleDotsIncreaser += 4;
            }

            Console.WriteLine();
        }

        //mid

        //first crack
        Console.Write(".");
        Console.Write("*");

        for (int i = 1; i <= (3 * n) - 3; i++)
        {
            if (i % 2 != 0)
            {
                Console.Write("@");
            }
            else
            {
                Console.Write(".");
            }
        }

        Console.Write("*");
        Console.Write(".");

        Console.WriteLine();

        //second crack
        Console.Write(".");
        Console.Write("*");

        for (int i = 1; i <= (3 * n) - 3; i++)
        {
            if (i % 2 != 0)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write("@");
            }
        }

        Console.Write("*");
        Console.Write(".");

        Console.WriteLine();

        //bot - 2

        int botDotsIncreaser = 1;
        int midDotsUntil = 1;

        for (int i = 0; i < n - 2; i++)
        {
            for (int leftDots = 1; leftDots <= botDotsIncreaser; leftDots++)
            {
                Console.Write(".");
            }

            Console.Write("*");

            for (int botMidDots = n * 3 - 3; botMidDots >= midDotsUntil; botMidDots--)
            {
                Console.Write(".");
            }

            Console.Write("*");

            for (int rightDots = 1; rightDots <= botDotsIncreaser; rightDots++)
            {
                Console.Write(".");
            }

            if (i >= (n / 2) - 2)
            {
                botDotsIncreaser += 2;
                midDotsUntil += 4;
            }

            Console.WriteLine();
        }

        //bot
        for (int i = 1; i <= n + 1; i++)
        {
            Console.Write(".");
        }

        for (int i = 1; i <= n - 1; i++)
        {
            Console.Write("*");
        }

        for (int i = 1; i <= n + 1; i++)
        {
            Console.Write(".");
        }

        Console.WriteLine();
    }
}