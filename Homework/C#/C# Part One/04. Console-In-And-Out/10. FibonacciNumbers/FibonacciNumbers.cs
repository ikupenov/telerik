using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger firstNum = 0;
        BigInteger secondNum = 1;

        if (n == 1)
        {
            Console.WriteLine("0");
        }

        else
        {
            Console.Write("0, 1, ");

            for (int i = 2; i < n; i++)
            {
                BigInteger thirdNum = firstNum + secondNum;

                if (i == n - 1)
                {
                    Console.WriteLine("{0}", thirdNum);
                }
                else
                {
                    Console.Write("{0}, ", thirdNum);
                }

                firstNum = secondNum;
                secondNum = thirdNum;
            }
        }
    }
}
