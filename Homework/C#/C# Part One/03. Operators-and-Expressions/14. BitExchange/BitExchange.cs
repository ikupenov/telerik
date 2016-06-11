using System;

class BitExchange
{
    static void Main()
    {
        uint numOne = uint.Parse(Console.ReadLine());

        uint getFirst3 = (numOne >> 3) & 7;

        uint getSecond3 = (numOne >> 24) & 7;

        uint firstToSecond = getFirst3 << 24;
        uint secondToFirst = getSecond3 << 3;

        numOne = firstToSecond | numOne;
        numOne = secondToFirst | numOne;

        uint deleteFirstNums = 7 << 3;
        uint deleteSecondNums = 7 << 24;

        numOne = ~deleteFirstNums & numOne;
        numOne = ~deleteSecondNums & numOne;

        numOne = numOne | firstToSecond | secondToFirst;

        Console.WriteLine(numOne);
    }
}
