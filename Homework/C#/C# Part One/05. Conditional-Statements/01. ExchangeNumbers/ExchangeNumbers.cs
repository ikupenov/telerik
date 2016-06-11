using System;
class ExchangeNumbers
{
    static void Main()
    {
        double A = double.Parse(Console.ReadLine());
        double B = double.Parse(Console.ReadLine());
        double C;

        if (A > B)
        {
            C = A;
            A = B;
            B = C;

            Console.Write("{0} {1}", A, B);
            Console.WriteLine();
        }

        else
        {
            Console.Write("{0} {1}", A, B);
            Console.WriteLine();
        }
    }
}