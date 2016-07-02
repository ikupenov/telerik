using System;


class DiamondTrolls
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double beforeRound = (double)n / 2;
        double afterRound = Math.Round(beforeRound, 0, MidpointRounding.AwayFromZero);

        int insideDotsIncrease = 0;
        
        //top

        for (int left = 1; left <= afterRound; left++)
        {
            Console.Write(".");
        }

        for (int mid = 1; mid <= n; mid++)
        {
            Console.Write("*");
        }

        for (int right = 1; right <= afterRound; right++)
        {
            Console.Write(".");
        }


        Console.WriteLine();

        //Second row until middle 

        for (int i = 1; i <= (afterRound - 1); i++)
        {
            for (int left = 1; left <= afterRound - i; left++)
            {
                Console.Write(".");
            }

            for (int inside = 1; inside <= 3; inside++)
            {
                Console.Write("*");

                for (int insideDots = 1; insideDots <= (afterRound - 1) + insideDotsIncrease; insideDots++)
                {
                    if (inside == 3)
                    {
                        continue;
                    }
                    Console.Write(".");
                }
            }

            for (int right = 1; right <= afterRound - i; right++)
            {
                Console.Write(".");
            }

            insideDotsIncrease++;
            Console.WriteLine();
        }

        //middle
        for (int i = 1; i <= (n * 2) + 1; i++)
        {
            Console.Write("*");
        }

        Console.WriteLine();

        //bot first

        int secondInsideDotsIncrease = 2;

        for (int bot = 1; bot <= n - 1; bot++)
        {
            
            for (int left = 1; left <= (n - n) + bot; left++)
            {
                Console.Write(".");
            }

            for (int middle = 1; middle <= 3; middle++)
            {
                Console.Write("*");

                for (int middleDots = 1; middleDots <= n - secondInsideDotsIncrease; middleDots++)
                {
                    if (middle == 3)
                    {
                        continue;
                    }
                    Console.Write(".");
                }
            }

            for (int right = 1; right <= (n - n) + bot; right++)
            {
                Console.Write(".");
            }

            secondInsideDotsIncrease++;
            Console.WriteLine();
        }

        //bot second
        for (int leftDots = 1; leftDots <= n; leftDots++)
        {
            Console.Write(".");
        }

        Console.Write("*");

        for (int rightDots = 1; rightDots <= n; rightDots++)
        {
            Console.Write(".");
        }

        Console.WriteLine();
    }
}
