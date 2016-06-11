/*
Write a program that reads your birthday(in the format MM.DD.YYYY) from the console and 
prints on the console how old you are you now and how old will you be after 10 years.
*/

using System;

class Age
{
    static void Main()
    {
        DateTime birthday = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Now;

        int age = today.Year - birthday.Year;
        int ageAfterTen = (today.Year - birthday.Year) + 10;

       if (today.DayOfYear > birthday.DayOfYear)
        {
            age--;
            ageAfterTen--;
        }

        if (birthday.DayOfYear <= today.DayOfYear)
        {
            age++;
            ageAfterTen++;
        }

        Console.WriteLine(age);
        Console.WriteLine(ageAfterTen);
    }
}
