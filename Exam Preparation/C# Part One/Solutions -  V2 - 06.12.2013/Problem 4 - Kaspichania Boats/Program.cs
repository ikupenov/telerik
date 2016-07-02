using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Console.Write(new string('.', N) + '*' + new string('.', N));

        int middleDots = 0;

        Console.WriteLine();

        for (int i = 1; i < N; i++)
        {
            Console.Write(new string ('.', N - i));

            Console.Write('*' + new string ('.', middleDots) + '*' + new string('.', middleDots) + '*');

            Console.Write(new string('.', N - i));

            if (i > 0)
            {
                middleDots++;
            }

            Console.WriteLine();
        }


        Console.WriteLine(new string ('*', N * 2 + 1));

        int startingDots = N - 2;

        for (int i = 1; i <= (N / 2); i++)
        {
            Console.Write(new string ('.', i));

            Console.Write('*' + new string ('.', startingDots) + '*' + new string ('.', startingDots) + '*');

            Console.Write(new string('.', i));

            startingDots--;
            Console.WriteLine();
        }

        Console.Write(new string ('.', N / 2 + 1) + new string ('*', N) + new string('.', N / 2 + 1));
        Console.WriteLine();
    }
}