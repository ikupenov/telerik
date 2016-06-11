using System;

class OddAndEvenProduct
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        string enterNumbers = Console.ReadLine();
        long evenProduct = 1;
        long oddProduct = 1;

        string[] numbersSplit = enterNumbers.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        for (long i = 0; i < numbersSplit.Length; i++)
        {
            long stringTolong = long.Parse(numbersSplit[i]);

            if (i % 2 == 0)
            {
                evenProduct *= stringTolong;
            }

            else
            {
                oddProduct *= stringTolong;
            }
        }

        if (evenProduct == oddProduct)
        {
            Console.WriteLine("yes {0}", evenProduct);
        }

        else
        {
            Console.WriteLine("no {0} {1}", evenProduct, oddProduct);
        }

    } 
}