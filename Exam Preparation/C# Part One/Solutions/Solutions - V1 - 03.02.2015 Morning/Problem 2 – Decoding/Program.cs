using System;

class Program
{
    static void Main()
    {
        double SALT = double.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int evenOrOdd = 0;
        double encoded = 0;

        foreach (char symbol in text)
        {
            encoded = 0;

            if (symbol == '@')
            {
                return;
            }

            else if (char.IsLetter(symbol))
            {
                encoded = (symbol * SALT) + 1000;
            }

            else if (char.IsDigit(symbol))
            {
                encoded = symbol + SALT + 500;
            }

            else
            {
                encoded = symbol - SALT;
            }

            if (evenOrOdd % 2 == 0)
            {
                Console.WriteLine("{0:F2}", encoded / 100);
            }
            else
            {
                Console.WriteLine(encoded * 100);
            }

            evenOrOdd++;
        }
    }
}