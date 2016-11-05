using System;
using System.Collections.Generic;

using Company.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IReportGenerator
    {
        IEnumerable<Report> GetReports(int count, DateTime minDate, DateTime maxDate);
    }
}