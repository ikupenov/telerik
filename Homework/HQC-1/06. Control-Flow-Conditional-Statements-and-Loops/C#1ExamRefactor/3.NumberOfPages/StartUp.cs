namespace NumberOfPages
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            int numberOfDigitsInPage = int.Parse(Console.ReadLine());
            int sumOfAllDigits = 0;
            int pageNumber = 0;

            while (numberOfDigitsInPage != sumOfAllDigits)
            {
                pageNumber++;
                sumOfAllDigits += pageNumber.ToString().Length;
            }

            Console.WriteLine(pageNumber);
        }
    }
}