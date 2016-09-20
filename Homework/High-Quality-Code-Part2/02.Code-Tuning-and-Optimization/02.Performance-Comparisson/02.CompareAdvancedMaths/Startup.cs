namespace CompareAdvancedMaths
{
    using System;

    internal class Startup
    {
        private static void Main()
        {
            SquareRootTests();
            NaturalLogarithmTests();
            SinusTests();
        }

        private static void SquareRootTests()
        {
            ResultsLogger.Log("Square root");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = (float)Math.Sqrt(3.04003);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = Math.Sqrt(3.04003);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = (decimal)Math.Sqrt(3.04003);
            });
        }

        private static void NaturalLogarithmTests()
        {
            ResultsLogger.Log("Natural logarithm");

            TimeLogger.LogExecutionTime("Int", () =>
            {

                var __ = (float)Math.Log(3.04003);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = Math.Log(3.04003);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = (decimal)Math.Log(3.04003);
            });
        }

        private static void SinusTests()
        {
            ResultsLogger.Log("Sinus");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = (float)Math.Sin(2.03);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = Math.Sin(2.03);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = (decimal)Math.Sin(2.03);
            });
        }
    }
}
