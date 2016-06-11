using System;

class MMSAOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        n = Math.Abs(n);

        decimal min = decimal.MaxValue;
        decimal max = decimal.MinValue;
        decimal sum = 0;

        for (int i = 1; i <= n; i++)
        {
            decimal sequence = decimal.Parse(Console.ReadLine());

            if (max < sequence) //max value
            {
                max = sequence;
            }
            if (min > sequence) //min value
            {
                min = sequence;
            }
            sum += sequence; //sum
        }
        Console.WriteLine("min={0:0.00}", min);
        Console.WriteLine("max={0:0.00}", max);
        Console.WriteLine("sum={0:0.00}", sum);
        Console.WriteLine("avg={0:0.00} ", sum / n); //average
    }
}