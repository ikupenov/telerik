namespace BitArray
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var firstBitArray = new BitArray64();

            firstBitArray[0] = 1;
            firstBitArray[1] = 1;
            firstBitArray[2] = 0;
            firstBitArray[3] = 1;
            firstBitArray[1] = 0;

            var secondBitArray = new BitArray64();
            secondBitArray[0] = 1;
            secondBitArray[1] = 1;
            secondBitArray[2] = 0;
            secondBitArray[3] = 1;
            secondBitArray[63] = 1;

            Console.WriteLine("First BitArray: \n" + firstBitArray);
            Console.WriteLine("Second BitArray: \n" + secondBitArray);

            bool equalCheck = firstBitArray == secondBitArray;
            Console.WriteLine("\nEqual Check: " + equalCheck);

            Console.WriteLine("First BitArray HashCode: " + firstBitArray.GetHashCode());
            Console.WriteLine("Second BitArray HashCode: " + secondBitArray.GetHashCode());

            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Second BitArray Foreach Test:");

            foreach (var bit in secondBitArray)
            {
                Console.Write(bit);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}