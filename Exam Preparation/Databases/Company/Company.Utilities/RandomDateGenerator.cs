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

            var randomDays = this.numberGenerator.GetRandomInteger(0, timeSpan.Days);
            DateTime randomDate = startDate.AddDays(randomDays);

            return randomDate;
        }
    }
}