namespace CompareSimpleMaths
{
    internal class Startup
    {
        private static void Main()
        {
            AdditionTests();
            SubstractionTests();
            IncrementationTests();
            MultiplicationTests();
            DivisionTests();
        }

        private static void AdditionTests()
        {
            ResultsLogger.Log("Addition");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = 300 + 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                var __ = 34534500 + 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                var __ = 2.342342340f + 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = 30.00010d + 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = 30.000030m + 291.9m;
            });
        }

        private static void SubstractionTests()
        {
            ResultsLogger.Log("Square root");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = 300 - 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                var __ = 34534500 - 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                var __ = 2.342342340f - 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = 30.00010d - 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = 30.000030m - 291.9m;
            });
        }

        private static void IncrementationTests()
        {
            ResultsLogger.Log("Incrementation");

            int iNum = 0;
            TimeLogger.LogExecutionTime("Int", () =>
            {
                iNum += 1;
            });

            long lNum = 0;
            TimeLogger.LogExecutionTime("Long", () =>
            {
                lNum += 1;
            });

            float fNum = 0;
            TimeLogger.LogExecutionTime("Float", () =>
            {
                fNum += 1;
            });

            double dNum = 0;
            TimeLogger.LogExecutionTime("Double", () =>
            {
                dNum += 1;
            });

            decimal decNum = 0;
            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decNum += 1;
            });
        }

        private static void MultiplicationTests()
        {
            ResultsLogger.Log("Multiplication");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = 300 * 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                var __ = 34534500 * 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                var __ = 2.342342340f * 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = 30.00010d * 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = 30.000030m * 291.9m;
            });
        }

        private static void DivisionTests()
        {
            ResultsLogger.Log("Division");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                var __ = 300 / 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                var __ = 34534500 / 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                var __ = 2.342342340f / 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                var __ = 30.00010d / 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                var __ = 30.000030m / 291.9m;
            });
        }
    }
}