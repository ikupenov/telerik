using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            ReadNumbers();
        }
        catch (Exception)
        {
            Console.WriteLine("Exception");
        }
    }

    static void ReadNumbers ()
    {
        var numbers = new List<int>();
        numbers.Add(1);

        for (int i = 0; i < 10; i++)
        {
            try
            {
                int second = int.Parse(Console.ReadLine());

                if (second > numbers[i])
                {
                    numbers.Add(second);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        numbers.Add(100);
        Console.WriteLine(string.Join(" < ", numbers));
    }
}