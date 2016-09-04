namespace PrintStatistics
{
    using System.Linq;

    using Contracts;

    public class Statistics
    {
        private ILogger logger;

        public Statistics(ILogger logger)
        {
            this.logger = logger;
        }

        public void PrintStatistics(double[] values)
        {
            double maxValue = values.Max();
            double minValue = values.Min();
            double avgValue = values.Average();

            this.logger.Print($"The maximum value is: {maxValue}.");
            this.logger.Print($"The minimum value is: {minValue}.");
            this.logger.Print($"The average value is: {avgValue}.");
        }
    }
}