using System;
using System.Numerics;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cages = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
                break;

            cages.Add(int.Parse(input));
        }

        for (int initial = 1; ; initial++)
        {
            if (initial > cages.Count)
                break;

            int S = 0;

            for (int i = 0; i < initial; i++)
            {
                S += cages[i];
            }

            var leftCages = new List<int>();
            for (int i = initial; i < cages.Count; i++)
            {
                leftCages.Add(cages[i]);
            }

            if (S > leftCages.Count)
                break;


            BigInteger sum = 0;
            BigInteger product = 1;

            for (int i = initial; i < S + initial; i++)
            {
                sum += cages[i];
                product *= cages[i];
            }

            //Left after selected
            leftCages.Clear();
            for (int i = S + initial; i < cages.Count; i++)
            {
                leftCages.Add(cages[i]);
            }

            cages.Clear();

            for (int i = 0; i < sum.ToString().Length; i++)
            {
                if (sum.ToString()[i] -'0' != 1 && sum.ToString()[i] - '0' != 0)
                {
                    cages.Add(sum.ToString()[i] - '0');
                }
            }
            for (int i = 0; i < product.ToString().Length; i++)
            {
                if (product.ToString()[i] - '0' != 1 && product.ToString()[i] - '0' != 0)
                {
                    cages.Add(product.ToString()[i] - '0');
                }
            }

            string convert = string.Join("", leftCages);

            for (int i = 0; i < convert.Length; i++)
            {
                if (convert[i] - '0' != 1 && convert[i] - '0' != 0)
                {
                    cages.Add(convert[i] - '0');
                }
            }
        }

        Console.WriteLine(string.Join(" ", cages));
    }
}