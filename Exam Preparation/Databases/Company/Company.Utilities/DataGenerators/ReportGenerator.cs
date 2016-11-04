using System;
using System.Collections.Generic;
using System.Linq;

using Company.Repositories.Contracts;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;

namespace Company.Utilities.DataGenerators
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly INumberGenerator numberGenerator;
        private readonly IDateGenerator dateGenerator;
        private readonly IRepository<Employee> employeesRepository;

        public ReportGenerator(
            INumberGenerator numberGenerator,
            IDateGenerator dateGenerator,
            IRepository<Employee> employeesRepository)
        {
            this.numberGenerator = numberGenerator;
            this.dateGenerator = dateGenerator;
            this.employeesRepository = employeesRepository;
        }

        public IEnumerable<Report> GetReports(
            int averageReportsPerEmployee,
            DateTime minDate,
            DateTime maxDate)
        {
            var reports = new HashSet<Report>();

            foreach (var employee in this.employeesRepository.Entities.ToList())
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