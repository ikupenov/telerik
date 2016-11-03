using System;
using System.Linq;

using Company.Utilities;
using Company.Utilities.DataGenerators;
using Console.Data;

namespace Company.Client
{
    internal class StartUp
    {
        private static void Main()
        {
            var context = new CompanyEntities();

            var numberGenerator = new RandomNumberGenerator();
            var stringGenerator = new RandomStringGenerator(numberGenerator);
            var dateGenerator = new RandomDateGenerator(numberGenerator);

            var startDate = new DateTime(1996, 7, 12, 22, 56, 56);
            var endDate = new DateTime(2012, 8, 7, 8, 30, 05);

            var departments = new DepartmentGenerator(stringGenerator).GetDepartments(100);

            context.Departments.AddRange(departments);

            var employees = new EmployeeGenerator(numberGenerator, stringGenerator, departments.ToList())
                .GetEmployees(100, 5, 95).ToList();

            context.Employees.AddRange(employees);

            var projects = new ProjectGenerator(numberGenerator, stringGenerator, dateGenerator, employees)
                .GetProjects(1000, startDate, endDate);

            context.Projects.AddRange(projects);

            var reports = new ReportGenerator(numberGenerator, dateGenerator, employees)
                .GetReports(50, startDate, endDate);

            context.Reports.AddRange(reports);

            context.SaveChanges();

            var avg = projects.Select(x => x.Employees.Count).Average();

            System.Console.WriteLine();
        }
    }
}