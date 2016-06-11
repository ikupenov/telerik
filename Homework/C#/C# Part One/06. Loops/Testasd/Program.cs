using System;


class TrailingZeroInFactorial
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        long zeros = 0;
        long divisor = 5;
        long i = 1;

        while (true)
        {
            if (number / divisor < 1)
            {
                break;
            }

            divisor = (long)Math.Pow(5, i);

            double b = Math.Floor((double)number / divisor);

            zeros = zeros + (long)b;

            i++;
        }
        Console.WriteLine(zeros);
    }
}
