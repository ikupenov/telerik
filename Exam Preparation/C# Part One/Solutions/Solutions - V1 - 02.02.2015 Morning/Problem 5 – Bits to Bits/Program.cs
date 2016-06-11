using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string num = "";
        int repeat = int.Parse(Console.ReadLine());

        int zeroCounter = 0;
        int oneCounter = 0;

        int permZero = 0;
        int permOne = 0;

        for (int i = 1; i <= repeat; i++)
        {
            BigInteger decValue = BigInteger.Parse(Console.ReadLine());

            for (int bit = 29; bit >= 0; bit--)
            {
                BigInteger  mask = 1 << bit;            
                BigInteger result = decValue & mask;
                BigInteger shift = result >> bit;

                num += shift.ToString();
            }
        }

        for (int i = 0; i <= num.Length - 1; i++)
        {
            char digit = num[i];

            if (digit == '1')
            {
                oneCounter++;
            }

            if (i == num.Length - 1)
            {
                if (oneCounter > permOne)
                {
                    permOne = oneCounter;
                }

                oneCounter = 0;
            }

            else if (digit != '1')
            {
                if (oneCounter > permOne)
                {
                    permOne = oneCounter;
                }

                oneCounter = 0;
            }
        }

        for (int i = 0; i <= num.Length - 1; i++)
        {
            char digit = num[i];

            if (digit == '0')
            {
                zeroCounter++;
            }

            if (i == num.Length - 1)
            {
                if (zeroCounter > permZero)
                {
                    permZero = zeroCounter;
                }

                zeroCounter = 0;
            }

            else if (digit != '0')
            {
                if (zeroCounter > permZero)
                {
                    permZero = zeroCounter;
                }

                zeroCounter = 0;
            }
        }

        Console.WriteLine(permZero);
        Console.WriteLine(permOne);
    }
}
