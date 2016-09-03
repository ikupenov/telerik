namespace PrintStatistics
{
    public class StartUp
    {
        private static void Main()
        {
            var logger = new Logger();
            var statistics = new Statistics(logger);

            statistics.PrintStatistics(new double[] { 1.3, 3.2, 2.5, 5.4, 4.1 });
        }
    }
}