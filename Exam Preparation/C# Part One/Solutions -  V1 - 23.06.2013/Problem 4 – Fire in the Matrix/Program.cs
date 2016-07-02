using System;

                        //...##...
                        //..#..#..
                        //.#....#.
                        //#......#
                        //#......#
                        //.#....#.
                        //--------
                        //\\\\////
                        //.\\\///.
                        //..\\//..
                        //...\/...


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int addition = 0;

        //top
        for (int i = 1; i <= (n / 2) - 1; i++)
        {
            for (int leftDots = 1; leftDots <= (n / 2) - i; leftDots++)
            {
                Console.Write(".");
            }

            Console.Write("#");

            for (int middleDots = 1; middleDots <= addition; middleDots++)
            {
                Console.Write(".");
            }

            Console.Write("#");

            for (int rightDots = 1; rightDots <= (n / 2) - i; rightDots++)
            {
                Console.Write(".");
            }

            addition += 2;
            Console.WriteLine();
        }

        //top-mid

        for (int j = 1; j <= 1; j++)
        {
            Console.Write("#");

            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(".");
            }

            Console.Write("#");
            Console.WriteLine();
        }


        //top-bot

        int substract = 0;

        for (int i = 0; i < n / 4; i++)
        {
            for (int leftDots = 1; leftDots <= i; leftDots++)
            {
                Console.Write(".");
            }

            Console.Write("#");

            for (int j = 1; j <= (n - 2) - substract; j++)
            {
                Console.Write(".");
            }

            Console.Write("#");


            for (int rightDots = 1; rightDots <= i; rightDots++)
            {
                Console.Write(".");
            }

            substract += 2;
            Console.WriteLine();
        }



        //mid
        for (int i = 1; i <= n; i++)
        {
            Console.Write("-");
        }

        Console.WriteLine();
        //bot

        for (int i = 0; i < n / 2; i++)
        {
            for (int leftDots = 1; leftDots <= i; leftDots++)
            {
                Console.Write(".");
            }


            for (int leftDash = 1; leftDash <= n / 2 - i; leftDash++)
            {
                Console.Write("\\");
            }


            for (int rightDash = 1; rightDash <= n / 2 - i; rightDash++)
            {
                Console.Write("/");
            }

            for (int rightDots = 1; rightDots <= i; rightDots++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}