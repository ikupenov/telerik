using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        input = input.Replace("CHU", "0");
        input = input.Replace("TEL", "1");
        input = input.Replace("OFT", "2");
        input = input.Replace("IVA", "3");
        input = input.Replace("EMY", "4");
        input = input.Replace("VNB", "5");
        input = input.Replace("POQ", "6");
        input = input.Replace("ERI", "7");
        input = input.Replace("CAD", "8");
        input = input.Replace("K-A", "9");
        input = input.Replace("IIA", "A");
        input = input.Replace("YLO", "B");
        input = input.Replace("PLA", "C");

        long toDec = 0;

        for (int i = 0; i < input.Length; i++)
        {
            toDec *= 13;
            char current = input[i];
            
            if (char.IsDigit(current))
            {
                toDec += current - '0';
            }
            else if (char.IsLetter(current))
            {
                toDec += current - 'A' + 10;
            }
        }

        Console.WriteLine(toDec);
    }
}