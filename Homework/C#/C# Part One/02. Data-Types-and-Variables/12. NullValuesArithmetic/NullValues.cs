/*
Create a program that assigns null values to an integer and to a double variable.

Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result.
*/

using System;

class NullValues
{
    static void Main()
    {
        int? firstNumber = null;
        double? secondNumber = null;

        int? sum = firstNumber + 1;

        Console.WriteLine(firstNumber + " " + secondNumber + " " + sum);
    }
}
