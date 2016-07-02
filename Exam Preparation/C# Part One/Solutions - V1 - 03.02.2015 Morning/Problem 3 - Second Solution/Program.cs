using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger product = 1;
        ulong tempProduct = 1;
        ulong digit = 0;

        for (int i = 0; ; i++)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                Console.WriteLine(product);
                return;
            }

            else if (i % 2 != 0)
            {
                tempProduct = 1;
                for (int k = 0; k < input.Length; k++)
                {
                    char num = input[k];

                    if (num != '0')
                    {
                        digit = (ulong)char.GetNumericValue(num);
                        tempProduct *= digit;
                    }
                }
                product *= tempProduct;
            }

            if ((i + 1) - 10 == 0)
            {
                Console.WriteLine(product);
                product = 1;
            }
        }
    }
}
