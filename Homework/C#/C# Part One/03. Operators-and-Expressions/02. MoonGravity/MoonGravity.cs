using System;

class MoonGravity
{
    static void Main()
    {
        double earthWeight = double.Parse(Console.ReadLine());
        double moonWeightF = earthWeight * (17.0 / 100.0);

       // double round = Math.Round(moonWeightF, 3);

        Console.WriteLine("{0:0.000}", moonWeightF);
    }
}
