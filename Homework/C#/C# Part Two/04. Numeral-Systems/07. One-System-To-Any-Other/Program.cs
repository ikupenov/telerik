using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static BigInteger Power(BigInteger number, BigInteger power)
    {
        BigInteger onPower = 1;

        for (int i = 0; i < power; i++)
        {
            onPower *= number;
        }

        return onPower;
    }

    static void Main()
    {
        BigInteger s = BigInteger.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        BigInteger d = BigInteger.Parse(Console.ReadLine());

        BigInteger numberToInt = 0;

        if (s <= 10)
        {
            numberToInt = BigInteger.Parse(number);
        }

        //If 's' and 'd' numeral system is the same
        if (s == d)
        {
            Console.WriteLine(number);
        }

        //If 's' is decimal number
        else if (s == 10)
        {
            //Decimal To Base 2-9
            if (d < 10)
            {
                DecimalTo_D9(numberToInt, d);
                Console.WriteLine(string.Join("", DecimalTo_D9(numberToInt, d)));
            }

            //Decimal To Base 11-16
            else if (d > 10)
            {
                Console.WriteLine(string.Join("", DecimalTo_D16(numberToInt, d)));
            }
        }

        //If 's' is base 2-9
        else if (s < 10)
        {
            //Base 2-9 To Decimal
            if (d == 10)
            {
                Console.WriteLine(S9_ToDecimal(number, s));
            }

            //Base 2-9 To Base 11-16
            else if (d > 10)
            {
                BigInteger toDecimal = S9_ToDecimal(number, s);
                Console.WriteLine(string.Join("", DecimalTo_D16(toDecimal, d)));
            }

            //Base 2-9 To Base 2-9
            else if (d < 10)
            {
                BigInteger toDecimal = S9_ToDecimal(number, s);
                Console.WriteLine(string.Join("", DecimalTo_D9(toDecimal, d)));
            }
        }

        //if 's' is base 11-16
        else if (s > 10)
        {
            // Base 11-16 To Decimal
            if (d == 10)
            {
                Console.WriteLine(S16_ToDecimal(number, s));
            }

            // Base 11-16 To Base 2-9
            else if (d < 10)
            {
                BigInteger toDecimal = S16_ToDecimal(number, s);
                Console.WriteLine(string.Join("", DecimalTo_D9(toDecimal, d)));
            }

            // Base 11-16 To Base 11-16
            else if (d > 10)
            {
                BigInteger toDecimal = S16_ToDecimal(number, s);
                Console.WriteLine(string.Join("", DecimalTo_D16(toDecimal, d)));
            }
        }
    }

    //Converts Base 2-9 To Decimal
    static BigInteger S9_ToDecimal(string number, BigInteger s)
    {
        BigInteger toInteger = BigInteger.Parse(number);
        BigInteger result = 0;
        BigInteger length = number.Length;

        for (int i = 0; i < length; i++)
        {
            BigInteger lastDigit = toInteger % 10;
            result += lastDigit * Power(s, i);

            toInteger /= 10;
        }

        return result;
    }

    //Converts Base 11-16 To Decimal
    static BigInteger S16_ToDecimal(string number, BigInteger s)
    {
        int lastDigit = number.Length - 1;
        BigInteger result = 0;

        for (int i = 0; lastDigit >= 0; i++)
        {
            char lastSymb = number[lastDigit];
            BigInteger toDigit = 0;

            switch (lastSymb)
            {
                case '0': toDigit = 0; break;
                case '1': toDigit = 1; break;
                case '2': toDigit = 2; break;
                case '3': toDigit = 3; break;
                case '4': toDigit = 4; break;
                case '5': toDigit = 5; break;
                case '6': toDigit = 6; break;
                case '7': toDigit = 7; break;
                case '8': toDigit = 8; break;
                case '9': toDigit = 9; break;
                case 'A': toDigit = 10; break;
                case 'B': toDigit = 11; break;
                case 'C': toDigit = 12; break;
                case 'D': toDigit = 13; break;
                case 'E': toDigit = 14; break;
                case 'F': toDigit = 15; break;
            }

            result += toDigit * Power(s, i);
            lastDigit--;
        }

        return result;
    }

    //Converts Decimal To Base 2-9
    static List<string> DecimalTo_D9(BigInteger decimalN, BigInteger d)
    {
        var result = new List<string>();

        while (true)
        {
            BigInteger remainder = decimalN % d;
            result.Add(remainder.ToString());

            decimalN /= d;
            if (decimalN == 0)
            {
                break;
            }
        }

        var reversed = new List<string>(Enumerable.Reverse(result));
        return reversed;
    }

    //Converts Decimal To Base 11-16
    static List<string> DecimalTo_D16(BigInteger decimalN, BigInteger d)
    {
        var result = new List<string>();

        while (true)
        {
            int remainder = (int)(decimalN % d);

            switch (remainder)
            {
                case 0: result.Add(remainder.ToString()); break;
                case 1: result.Add(remainder.ToString()); break;
                case 2: result.Add(remainder.ToString()); break;
                case 3: result.Add(remainder.ToString()); break;
                case 4: result.Add(remainder.ToString()); break;
                case 5: result.Add(remainder.ToString()); break;
                case 6: result.Add(remainder.ToString()); break;
                case 7: result.Add(remainder.ToString()); break;
                case 8: result.Add(remainder.ToString()); break;
                case 9: result.Add(remainder.ToString()); break;
                case 10: result.Add("A"); break;
            }

            if (d == 12)
            {
                switch (remainder)
                {
                    case 11: result.Add("B"); break;
                }
            }

            else if (d == 13)
            {
                switch (remainder)
                {
                    case 11: result.Add("B"); break;
                    case 12: result.Add("C"); break;
                }
            }

            else if (d == 14)
            {
                switch (remainder)
                {
                    case 11: result.Add("B"); break;
                    case 12: result.Add("C"); break;
                    case 13: result.Add("D"); break;
                }
            }

            else if (d == 15)
            {
                switch (remainder)
                {
                    case 11: result.Add("B"); break;
                    case 12: result.Add("C"); break;
                    case 13: result.Add("D"); break;
                    case 14: result.Add("E"); break;
                }
            }

            else if (d == 16)
            {
                switch (remainder)
                {
                    case 11: result.Add("B"); break;
                    case 12: result.Add("C"); break;
                    case 13: result.Add("D"); break;
                    case 14: result.Add("E"); break;
                    case 15: result.Add("F"); break;
                }
            }

            decimalN /= d;
            if (decimalN == 0)
            {
                break;
            }
        }

        var reversed = new List<string>(Enumerable.Reverse(result));
        return reversed;
    }
}