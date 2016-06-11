using System;

class Divide
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        bool check = number % 5 == 0 && number % 7 == 0;

        if (check)
        {
            Console.WriteLine("true" + " " + number);
        }
        else
        {
            Console.WriteLine("false" + " " + number);
        }
    }
}
