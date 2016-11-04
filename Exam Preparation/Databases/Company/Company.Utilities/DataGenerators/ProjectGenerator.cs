using System;
using System.Collections.Generic;
using System.Linq;

using Company.Repositories.Contracts;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;

namespace Company.Utilities.DataGenerators
{
    public class ProjectGenerator : IProjectGenerator
    {
        private const int MinProjectNameLength = 5;
        private const int MaxProjectNameLength = 50;

        private const int MinEmployeesOnProject = 2;
        private const int MaxEmployeesOnproject = 20;

        private readonly INumberGenerator numberGenerator;
        private readonly IStringGenerator stringGenerator;
        private readonly IDateGenerator dateGenerator;
        private readonly IRepository<Employee> employeeRepository;

        public ProjectGenerator(
            INumberGenerator numberGenerator,
            IStringGenerator stringGenerator,
            IDateGenerator dateGenerator,
            IRepository<Employee> employeesRepository)
        {
            this.numberGenerator = numberGenerator;
            this.stringGenerator = stringGenerator;
            this.dateGenerator = dateGenerator;
            this.employeeRepository = employeesRepository;
        }

        public IEnumerable<Project> GetProjects(int count, DateTime minDate, DateTime maxDate)
        {
            var projects = new List<Project>(count);

            for (int i = 0; i < count; i++)
            {
                var project = this.CreateProject(minDate, maxDate);
                projects.Add(project);
            }

            return projects;
        }

        private Project CreateProject(DateTime minDate, DateTime maxDate)
        {
            string projectName = this.stringGenerator.GetRandomString(
                MinProjectNameLength,
                MaxProjectNameLength);

            DateTime projectStartDate = this.dateGenerator.GetRandomDate(
                minDate,
                maxDate);

            DateTime projectEndDate = this.dateGenerator.GetRandomDate(
                projectStartDate,
                maxDate);

            var employeesWorkingOnProject = this.GetRandomEmployees().ToList();

            var project = new Project
            {
                Name = projectName,
                StartDate = projectStartDate,
                EndDate = projectEndDate,
                Employees = employeesWorkingOnProject
            };

            return project;
        }

        private IEnumerable<Employee> GetRandomEmployees()
        {
            var employees = this.employeeRepository.Entities.ToList();
            var employeesToImport = new HashSet<Employee>();

            int averageMaxEmployees = this.numberGenerator.GetRandomInteger(MinEmployeesOnProject, MaxEmployeesOnproject);
            int averageEmployees = this.numberGenerator.GetRandomInteger(
                MinEmployeesOnProject,
                averageMaxEmployees);

            for (int i = 0; i < averageEmployees; i++)
            {
                int employeePosition = this.numberGenerator.GetRandomInteger(0, employees.Count);
                Employee employee = employees[employeePosition];

                employeesToImport.Add(employee);
            }

            return employeesToImport;
        }
    }
}