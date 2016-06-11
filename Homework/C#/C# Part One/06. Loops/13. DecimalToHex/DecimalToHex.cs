using System;
using System.Numerics;

class DecimalToHex
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        BigInteger rem = 0;
        int next = 0;

        string remToString;

        BigInteger fakeNum = number;
        int counter = 0;

        while (fakeNum > 0) // Array Counter
        {
            counter++;
            fakeNum /= 2;
        }

        string[] result = new string[counter];

        while (number > 0) // Decimal To HEX
        {
            rem = number % 16;

            if (rem == 10) // 10 == A
            {
                result[next] = "A";
                next++;
                number /= 16;
                continue;
            }

            else if (rem == 11) // 11 == B
            {
                result[next] = "B";
                next++;
                number /= 16;
                continue;
            }

            else if (rem == 12) // 12 == C
            {
                result[next] = "C";
                next++;
                number /= 16;
                continue;
            }

            else if (rem == 13) // 13 == D
            {
                result[next] = "D";
                next++;
                number /= 16;
                continue;
            }

            else if (rem == 14) // 14 == E
            {
                result[next] = "E";
                next++;
                number /= 16;
                continue;
            }

            else if (rem == 15) // 15 == F
            {
                result[next] = "F";
                next++;
                number /= 16;
                continue;
            }

            remToString = Convert.ToString(rem);

            result[next] = remToString;

            next++;
            number /= 16;
        }

        Array.Reverse(result);
        Console.WriteLine("{0}", string.Join("", result));
    }
}
