using System;
using System.Text.RegularExpressions;

class GCD
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = Regex.Replace(input, "[^0-9.]", " "); // Removes everything except for digits
        string[] inputSplit = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Input Split

        int first = int.Parse(inputSplit[0]);
        int second = int.Parse(inputSplit[1]);

        if (first == 0 || second == 0) // If input number == 0
        {
            Console.WriteLine(0);
        }

        else                           // GCD
        {
            int min = Math.Min(first, second);

            //------------------------------------ Int Array Size 

            int counterCheck = 0;

            for (int i = 1; i <= min; i++)
            {
                if (first % i == 0 && second % i == 0)
                {
                    counterCheck++;
                }
            }

            //------------------------------------ Int Array Size 

            int[] GCD = new int[counterCheck];
            int counter = 0;

            for (int i = 1; i <= min; i++)
            {
                if (first % i == 0 && second % i == 0)
                {
                    GCD[counter] = i;
                    counter++;
                }
            }

            Console.WriteLine(GCD[counterCheck - 1]);

        }
    }
}