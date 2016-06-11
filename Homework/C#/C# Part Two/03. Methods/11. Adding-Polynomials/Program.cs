using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void PolynomCalc(int[] firstPolynom, int[] secondPolynom)
    {
        int[] sumResult = new int[firstPolynom.Length];
        int[] substractResult = new int[firstPolynom.Length];
        int[] multiplyResult = new int[firstPolynom.Length];


        for (int i = 0; i < firstPolynom.Length; i++)
        {
            sumResult[i] = firstPolynom[i] + secondPolynom[i];
            substractResult[i] = firstPolynom[i] - secondPolynom[i];
            multiplyResult[i] = firstPolynom[i] * secondPolynom[i];
        }

        Console.WriteLine(string.Join(" ", sumResult));

    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] firstPolynom = Console.ReadLine().Split(' ');
        int[] firstArray = new int[n];

        string[] secondPolynom = Console.ReadLine().Split(' ');
        int[] secondArray = new int[n];

        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = Convert.ToInt32(firstPolynom[i]);
            secondArray[i] = Convert.ToInt32(secondPolynom[i]);
        }

        PolynomCalc(firstArray, secondArray);
    }
}