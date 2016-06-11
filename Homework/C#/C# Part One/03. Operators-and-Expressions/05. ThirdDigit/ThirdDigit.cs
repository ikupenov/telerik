using System;

class ThirdDigit
{
    static void Main()
    {
        int numberCheck = int.Parse(Console.ReadLine());

        int digit = (numberCheck / 100) % 10;

        bool digitCheck = digit == 7;

        while (numberCheck < 0)
        {
            Console.WriteLine("You must enter a positive number");
            numberCheck = int.Parse(Console.ReadLine());
        }

        if (numberCheck == 0)
        {
            Console.WriteLine("false {0}", digit);
        }

        if (numberCheck > 0)
        {
            if (digitCheck)
            {
                Console.Write("true");
            }
            else
            {
                Console.Write("false {0}", digit);
            }
        }
    }
}