using System;

public class Program
{
    public static void Main()
    {
        //  Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
        //•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
        //•	Prints on the console the number in reversed order: dcba (in our example 1102).
        //•	Puts the last digit in the first position: dabc (in our example 1201).
        //•	Exchanges the second and the third digits: acbd (in our example 2101).
        //The number has always exactly 4 digits and cannot start with 0. 

        Console.Write("Please enter the same number: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 1000 || number > 9999) Console.WriteLine("Invalid number!!!");

        string strNumber = Convert.ToString(number);

        SumOfDigits(strNumber);

        ReversedDigit(strNumber);

        string exchangedLasWithFirst = strNumber[3] + "" + strNumber[0] + strNumber[1] + strNumber[2];
        Console.WriteLine("Last digit in front: {0}", exchangedLasWithFirst);

        string exchangedSecondWithThird = strNumber[0] + "" + strNumber[2] + strNumber[1] + strNumber[3];
        Console.WriteLine("Exchanged second with third: {0}", exchangedSecondWithThird);

    }

    private static void ReversedDigit(string strNumber)
    {
        int result = 0;

        for (int i = strNumber.Length - 1; i >= 0; i--)
        {
            if (i == strNumber.Length - 1)
            {
                result += strNumber[i] - 48;
            }
            else
            {
                result = (result * 10) + ((strNumber[i] - 48));
            }
        }

        Console.WriteLine("Reversed digit is: {0}", result);
    }

    private static void SumOfDigits(string strNumber)
    {
        int result = 0;

        for (int i = 0; i < strNumber.Length; i++)
        {
            result += strNumber[i] - 48;
        }

        Console.WriteLine("The sum of digits is: {0}", result);
    }
}
