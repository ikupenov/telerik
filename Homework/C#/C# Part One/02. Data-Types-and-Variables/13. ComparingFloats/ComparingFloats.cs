/*
Write a program that safely compares two floating-point numbers (double) with precision eps = 0.000001.

Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic. 
Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
*/

using System;

class ComparingFloats
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());

        double secondNumber = double.Parse(Console.ReadLine());

        double eps = 0.000001;

        bool sum = (Math.Abs(firstNumber - secondNumber) < eps);

        if (sum)
        {
            Console.WriteLine("true");
        }

        else
        {
            Console.WriteLine("false");
        }

    }

    /* 
    
    if (sum < 0)
     {
         sum = sum * (-1);
     }

     if (sum < eps)
     {
         numCheck = true;
         Console.WriteLine(numCheck);
     }

     else
     {
         numCheck = false;
         Console.WriteLine(numCheck);
     }

     */
}