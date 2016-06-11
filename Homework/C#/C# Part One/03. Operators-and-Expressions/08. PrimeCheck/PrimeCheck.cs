using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        //////////////////////////////////////////////////////////
        bool isWrong = number > 100;

        while (isWrong)
        {
            Console.WriteLine("Number must not be above 100");
            number = int.Parse(Console.ReadLine());

            if (number <= 100)
            {
                isWrong = false;
            }
        }
        ///////////////////////////////////////////////////////////

        bool isPrime = true;

        if (number <= 1)
        {
            isPrime = false;
        }

        else if (number == 2)
        {
            isPrime = true;
        }

        else
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        if (isPrime)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}