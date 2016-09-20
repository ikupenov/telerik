namespace CompareSortAlgorithms.Utils
{
    using System;
    using System.Linq;

    public class RandomArrayGenerator
    {
        public static int[] GenerateIntArray(int minValue, int maxValue)
        {
            var randNum = new Random();
            var randomArray = Enumerable
                .Repeat(0, 5)
                .Select(i => randNum.Next(minValue, maxValue))
                .ToArray();

            return randomArray;
        }

        public static double[] GenerateDoubleArray(int minValue, int maxValue)
        {
            var array = GenerateIntArray(minValue, maxValue)
                .Select(x => (double)(x + 1.01))
                .ToArray();

            return array;
        }
    }
}
