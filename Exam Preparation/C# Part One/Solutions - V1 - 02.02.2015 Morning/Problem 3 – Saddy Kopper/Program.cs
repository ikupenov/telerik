using System;
using System.Numerics;

//99999999999999999

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string temp = input;

        int transformation = 0;

        int result = 0;
        BigInteger product = 1;

        while (transformation <= 10)
        {
            if (temp != "")
            {
                temp = temp.Remove(temp.Length - 1);
            }

            for (int evenOrOdd = 0; evenOrOdd < temp.Length; evenOrOdd++)
            {
                char digit = temp[evenOrOdd];

                if (evenOrOdd % 2 == 0)
                {
                    int toInt = (int)char.GetNumericValue(digit);
                    result += toInt;
                }
            }

            if (temp == "")
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
                    temp = Convert.ToString(product);
                    product = 1;
                    result = 0;
                }           
            }

            else if (temp != "")
            {
                product *= result;
                result = 0;
            }
        }
    }
}
