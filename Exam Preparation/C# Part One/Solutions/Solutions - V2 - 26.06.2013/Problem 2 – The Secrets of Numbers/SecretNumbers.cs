using System;
using System.Text.RegularExpressions;

class SecretNumbers
{
    static void Main()
    {
        string enter = Console.ReadLine();

        string number = Regex.Replace(enter, "[^0-9]", "");

        double specialSum = 0;
        int nextCharCounter = 1;
        int oddOrEven = 1;

        int counter = 1;
        bool check = true;

        for (int i = 0; i < number.Length; i++)
        {
            char last = number[number.Length - nextCharCounter];
            double digit = (double)char.GetNumericValue(last);

            if (oddOrEven % 2 == 1)
            {
                specialSum += digit * Math.Pow(counter, 2);
            }

            else if (oddOrEven % 2 == 0)
            {
                specialSum += Math.Pow(digit, 2) * counter;
            }

            nextCharCounter++;
            oddOrEven++;
            counter++;
        }

        double R = specialSum % 26;
        int overflow = 0;
        double length = specialSum % 10;

        Console.WriteLine(specialSum);

        if (length == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }

        else
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i < length; i++)
            {
                int RToInt = (int)R;
                char printChar = 'A';

                if (printChar != 'Z' && check == true)
                {
                    printChar = alpha[RToInt + i];
                    
                    if (printChar == 'Z')
                    {
                        check = false;
                    }
                }

                else 
                {
                    printChar = alpha[overflow];
                    overflow++;
                }

                Console.Write(printChar);
            }
        }

        Console.WriteLine();
    }
}