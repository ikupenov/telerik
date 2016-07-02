using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // TOP

        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(" ");
        }

        for (int i = 1; i <= n; i++)
        {
            Console.Write(":");
        }

        //-------------------------- TOP

        Console.WriteLine();

        // TOP 2

        for (int i = 0; i < n - 2; i++)
        {

            for (int leftSpaces = 0; leftSpaces < (n - 2) - i; leftSpaces++)
            {
                Console.Write(" ");
            }

            Console.Write(":");

            for (int dash = 0; dash < (n - 2); dash++)
            {
                Console.Write("/");
            }

            Console.Write(":");

            for (int x = 1; x <= i; x++)
            {
                Console.Write("X");
            }

            Console.Write(":");

            Console.WriteLine();
        }

        //----------------------TOP 2 

        //TOP 3

        for (int leftDots = 1; leftDots <= n; leftDots++)
        {
            Console.Write(":");
        }

        for (int midX = 1; midX <= n - 2; midX++)
        {
            Console.Write("X");
        }

        Console.Write(":");

        Console.WriteLine();

        //BOT 1
        for (int i = 0; i < n - 2; i++)
        {
            Console.Write(":");

            for (int insideSpace = 1; insideSpace <= n - 2; insideSpace++)
            {
                Console.Write(" ");
            }

            Console.Write(":");

            for (int X = 1; X <= n - 3 - i ; X++)
            {
                Console.Write("X");
            }

            Console.Write(":");
            Console.WriteLine();         
        }
        //--------------------------- BOT 1

        //BOT

        for (int final = 1; final <= n; final++)
        {
            Console.Write(":");
        }

        Console.WriteLine();
    }
}