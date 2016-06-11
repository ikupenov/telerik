using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string number = Console.ReadLine();

        int transformation = 0;
        BigInteger result = 0;
        BigInteger product = 1;

        while (transformation < 10)
        {
            number = number.Remove(number.Length - 1);
            result = 0;

            for (int i = 0; i <= number.Length - 1; i++)
            {
                char digit = number[i];

                if (i % 2 != 0)
                {
                    result += (int)char.GetNumericValue(digit);
                }
            }

            if (result != 0)
            {
                product *= result;
            }

            if (number == "")
            {
                transformation++;

                if (transformation == 10)
                {
                    Console.WriteLine(product);
                    return;
                }

                else if (product < 10)
                {
                    Console.WriteLine(transformation);
                    Console.WriteLine(product);
                    return;
                }

                else
                {
                    number = product.ToString();
                    product = 1;
                }
            }
        }
    }
}