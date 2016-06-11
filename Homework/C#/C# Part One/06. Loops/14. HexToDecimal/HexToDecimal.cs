using System;

class HexToDecimal
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        char[] splitString = hexNumber.ToCharArray();

        int counter = splitString.Length;
        int[] charToInt = new int[counter];
        int arrayCount = 0;

        while (counter > 0)
        {
            if (splitString[arrayCount] == '0')
            {
                charToInt[arrayCount] = 0;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '1')
            {
                charToInt[arrayCount] = 1;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '2')
            {
                charToInt[arrayCount] = 2;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '3')
            {
                charToInt[arrayCount] = 3;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '4')
            {
                charToInt[arrayCount] = 4;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '5')
            {
                charToInt[arrayCount] = 5;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '6')
            {
                charToInt[arrayCount] = 6;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '7')
            {
                charToInt[arrayCount] = 7;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '8')
            {
                charToInt[arrayCount] = 8;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == '9')
            {
                charToInt[arrayCount] = 9;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'A')
            {
                charToInt[arrayCount] = 10;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'B')
            {
                charToInt[arrayCount] = 11;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'C')
            {
                charToInt[arrayCount] = 12;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'D')
            {
                charToInt[arrayCount] = 13;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'E')
            {
                charToInt[arrayCount] = 14;
                counter--;
                arrayCount++;
                continue;
            }

            if (splitString[arrayCount] == 'F')
            {
                charToInt[arrayCount] = 15;
                counter--;
                arrayCount++;
                continue;
            }
        }

        Array.Reverse(charToInt);

        int pow = 0;
        long sixteenPow = 1;
        int intCounter = 0;
        int i = 0;
        long result = 0;
        int charToIntLenghtCopy = charToInt.Length;

        while (charToIntLenghtCopy > 0) // Hex to Decimal
        {
            for (int DONTNEED = -1; pow > i; i++) // 16^n
            {
                if (sixteenPow * pow == 0)
                {
                    sixteenPow++;
                    continue;
                }
                sixteenPow *= 16;
            }

            result += charToInt[intCounter] * sixteenPow;

            pow++;
            intCounter++;
            charToIntLenghtCopy--;
        }

        Console.WriteLine(result);
    }
}
