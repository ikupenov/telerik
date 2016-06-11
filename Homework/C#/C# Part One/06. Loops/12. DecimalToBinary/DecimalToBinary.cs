using System;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int fakeNumber = number;
        int counter = 0;

        int nextNumber = 0; // Array Number 

        while (fakeNumber > 0) // Array Counter
        {
            counter++;
            fakeNumber /= 2;
        }

        int[] reverse = new int[counter];

        while (number > 0) // Decimal To Binary
        {
            if (number % 2 == 0)
            {
                reverse[nextNumber] = 0;
            }

            else if (number % 2 == 1)
            {
                reverse[nextNumber] = 1;
            }

            nextNumber++;
            number /= 2;
        }

        Array.Reverse(reverse);
        Console.WriteLine("{0}", string.Join("", reverse));
    }
}