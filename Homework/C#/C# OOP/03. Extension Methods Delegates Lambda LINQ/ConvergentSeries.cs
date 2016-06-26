namespace Homework
{
    using System;

    public static class ConvergentSeries
    {
        public static double InfiniteFactorial(int loops, Func<double, double, double> func)
        {
            double result = 0;
            double previous = 1;

            for (int i = 1; i < loops; i++)
            {
                result += func(previous, i);
                previous = func(previous, i);
            }

            return result;
        }

        public static double InfiniteSeries(int loops, Func<double, double, int, double> func)
        {
            double result = 1;
            double previous = 1;

            int counter = 1;

            for (int i = 2; counter < loops; i *= 2, counter++)
            {
                previous = func(previous, i, counter);
                result += func(previous, i, counter);
            }

            return result;
        }
    }
}
