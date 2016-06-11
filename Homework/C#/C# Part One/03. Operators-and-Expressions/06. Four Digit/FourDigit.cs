using System;

class FourDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        while (number > 9999 || number < 1000 || number < 0)
        {
            Console.WriteLine("You must enter a positive 4-digit number");
            number = int.Parse(Console.ReadLine());
        }

        int forthDigit = number % 10;
        int thirdDigit = (number / 10) % 10;
        int secondDigit = (number / 100) % 10;
        int firstDigit = (number / 1000) % 10;

        int sum = firstDigit + secondDigit + thirdDigit + forthDigit;

        Console.WriteLine(sum);
        Console.WriteLine("{0}{1}{2}{3}", forthDigit,thirdDigit,secondDigit,firstDigit);
        Console.WriteLine("{0}{1}{2}{3}", forthDigit, firstDigit, secondDigit, thirdDigit);
        Console.WriteLine("{0}{1}{2}{3}", firstDigit, thirdDigit, secondDigit, forthDigit);
    }
}