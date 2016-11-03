using System;

namespace Company.Utilities.Contracts
{
    public interface IDateGenerator
    {
        DateTime GetRandomDate(DateTime startDate, DateTime endDate);
    }
}