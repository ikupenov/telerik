using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
               
        int counter = 0;

        foreach (var symb in input)
        {
            if (symb == '(')
                counter++;
            else if (symb == ')')
                counter--;
        }

        if (counter == 0)
            Console.WriteLine("Correct");
        else
            Console.WriteLine("Incorrect");
    }
}