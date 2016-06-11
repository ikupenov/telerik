using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        int oddOrNot = 0;
        int oddCounter = 0;
        int sum = 0;

        foreach (char symb in input)
        {
            if (char.IsDigit(symb))
            {
                if (oddOrNot % 2 != 0)
                {
                    int digit = (int)char.GetNumericValue(symb);
                    sum += digit;
                    oddCounter++;
                }
            }

            oddOrNot++;
        }

        Console.WriteLine("{0} {1}", oddCounter, sum);
    }
}