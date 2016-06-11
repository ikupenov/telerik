using System;

class OddOrEven
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());

        if ((firstNumber & 1) == 0)
        {
            Console.WriteLine("even {0}", firstNumber);
        }

        else
        {
            Console.WriteLine("odd {0}", firstNumber);
        }




        /*
        if (firstNumber % 2 == 0)
        {
            Console.WriteLine("{0} is even", firstNumber);
        }

        else
        {
            Console.WriteLine("{0} is odd", firstNumber);
        }
        */
    }
}
