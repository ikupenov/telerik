using System;
using System.Collections.Generic;

using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;

namespace Company.Utilities.DataGenerators
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly INumberGenerator numberGenerator;
        private readonly IDateGenerator dateGenerator;
        private readonly IEnumerable<Employee> employees;

        public ReportGenerator(
            INumberGenerator numberGenerator,
            IDateGenerator dateGenerator,
            IEnumerable<Employee> employees)
        {
            this.numberGenerator = numberGenerator;
            this.dateGenerator = dateGenerator;
            this.employees = employees;
        }

        public IEnumerable<Report> GetReports(
            int averageReportsPerEmployee,
            DateTime minDate,
            DateTime maxDate)
        {
            var reports = new HashSet<Report>();

            foreach (var employee in employees)
            {
                int minReportsPerEmployee = averageReportsPerEmployee - averageReportsPerEmployee;
                int maxReportsPerEmployee = averageReportsPerEmployee + averageReportsPerEmployee;

                int employeeReports = this.numberGenerator.GetRandomInteger(
                    minReportsPerEmployee,
                    maxReportsPerEmployee);

                for (int i = 0; i < employeeReports; i++)
                {
                    DateTime timeOfReport = this.dateGenerator.GetRandomDate(
                    minDate,
                    maxDate);

                    var report = new Report
                    {
                        Employee = employee,
                        Time = timeOfReport
                    };

                    reports.Add(report);
                }
            }

            return reports;
        }
    }
}