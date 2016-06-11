using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int k = 1;
        int nCopy = n;

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine();
            Console.Write(i + " ");

            k++;
            nCopy++;

            for (int j = k; j < nCopy; j++)
            {
                Console.Write(j + " ");       
            }
        }
        Console.WriteLine();
    }
}