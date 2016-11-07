using System;

namespace ToyStore.Utilities.Generators
{
    public class NumberGenerator
    {
        private static readonly Random RandomGenerator;

        static NumberGenerator()
        {
            RandomGenerator = new Random();
        }

        public int GetRandomInteger(int minNumber, int maxNumber)
        {
            var result = RandomGenerator.Next(minNumber, maxNumber);
            return result;
        }

        public double GetRandomDouble(double minNumber, double maxNumber)
        {
            var floatingNumber = RandomGenerator.NextDouble();

            var result = minNumber + (floatingNumber * (maxNumber - minNumber));
            return result;
        }
    }
}