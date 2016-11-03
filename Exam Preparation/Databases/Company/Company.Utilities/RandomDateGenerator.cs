using System;

using Company.Utilities.Contracts;

namespace Company.Utilities
{
    public class RandomDateGenerator : IDateGenerator
    {
        private readonly INumberGenerator numberGenerator;

        public RandomDateGenerator(INumberGenerator numberGenerator)
        {
            this.numberGenerator = numberGenerator;
        }

        public DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;

            var randomSeconds = this.numberGenerator.GetRandomInteger(0, (int)timeSpan.TotalSeconds);
            DateTime randomDate = startDate.AddSeconds(randomSeconds);

            return randomDate;
        }
    }
}