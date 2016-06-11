using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger product = 1;
        BigInteger digit = 0;

        int counter = 1;

        for (int i = 0; ; i++)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                Console.WriteLine(product);
                return;
            }

            BigInteger numbers = BigInteger.Parse(input);

            if (i % 2 != 0)
            {
                while (numbers > 0)
                {
                    digit = numbers % 10;

                    if (digit != 0)
                    {
                        product *= digit;
                    }
                    numbers /= 10;
                }
            }

            if (i > 0 && counter % 10 == 0)
            {
                Console.WriteLine(product);
                product = 1;
            }

            counter++;
        }
    }
}
