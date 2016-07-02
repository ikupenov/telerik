using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int middleDots = (N / 2) + (N / 2) + (N - 2);

        Console.WriteLine(new string ('.', N / 2) + '*' + new string ('.', middleDots) + '*' + new string ('.', N / 2));

        int secondDotsIncrease = 0;
        int middleDecreaser = 2;

        for (int i = 1; i <= N - 2; i++)
        {
            if (N / 2 - i > 0)
            {
                Console.Write(new string('.', N / 2 - i));
            }

            if (N / 2 + 1 - i > 0)
            {
            Console.Write('*');
            }

            Console.Write(new string('.', i + secondDotsIncrease));

            Console.Write('*');

            Console.Write(new string ('.', middleDots - middleDecreaser));

            Console.Write('*');

            middleDecreaser += 2;
            secondDotsIncrease++;
            Console.WriteLine();
        }
    }
}