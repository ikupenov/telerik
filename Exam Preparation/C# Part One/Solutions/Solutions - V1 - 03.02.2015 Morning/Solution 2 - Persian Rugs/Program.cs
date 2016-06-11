using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());

        int width = (2 * N) + 1;

        for (int i = 0; i < N; i++)
        {
            int leftSpace = width - i - i - 2 - 2 - D - D;

            Console.Write(new string('#', i));
            Console.Write('\\');

            if (width - i - i - 2 > D + D + 2)
            {
                Console.Write(new string(' ', D));
                Console.Write('\\');
                Console.Write(new string('.', leftSpace));
                Console.Write('/');
                Console.Write(new string(' ', D));
            }

            else
            {
                if ((width - 2) - (2 * i) > 0)
                {
                    Console.Write(new string(' ', (width - 2) - (2 * i)));
                }
            }

            Console.Write('/');
            Console.Write(new string('#', i));

            Console.WriteLine();
        }

        //MID - TOP
        Console.WriteLine(new string ('#', N) + 'X' + new string ('#', N));
        //MID - BOT

        
        for (int i = N - 1; i >= 0; i--)
        {
            int leftSpace = width - i - i - 2 - 2 - D - D;

            Console.Write(new string('#', i));
            Console.Write('/');

            if (width - i - i - 2 > D + D + 2)
            {
                Console.Write(new string (' ', D));
                Console.Write('/');
                Console.Write(new string ('.', leftSpace ));
                Console.Write('\\');
                Console.Write(new string(' ', D));
            }

            else
            {
                if ((width - 2) - (2 * i) > 0)
                {
                    Console.Write(new string(' ', (width - 2) - (2 * i)));
                }
            }
            
            Console.Write('\\');
            Console.Write(new string('#', i));

            Console.WriteLine();
        }
    }
}