using System.Collections.Generic;
using System.Linq;

using Company.Repositories.Contracts;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;

namespace Company.Utilities.DataGenerators
{
    public class EmployeeGenerator : IEmployeeGenerator
    {
        private const int MinFirstNameLength = 5;
        private const int MaxFirstNameLength = 20;

        private const int MinLastNameLength = 5;
        private const int MaxLastNameLength = 20;

        private const int MinYearSalary = 50000;
        private const int MaxYearSalary = 200000;

        private readonly INumberGenerator numberGenerator;
        private readonly IStringGenerator stringGenerator;
        private readonly IRepository<Department> departmentsRepository;

        public EmployeeGenerator(
            INumberGenerator numberGenerator,
            IStringGenerator stringGenerator,
            IRepository<Department> departmentsRepository)
        {
            this.numberGenerator = numberGenerator;
            this.stringGenerator = stringGenerator;
            this.departmentsRepository = departmentsRepository;
        }

        public IEnumerable<Employee> GetEmployees(
            int totalCount,
            int managersPercentage,
            int employeesPercentage)
        {
            int totalManagersCount = (totalCount * managersPercentage) / 100;
            int totalEmployeesCount = (totalCount * employeesPercentage) / 100;

            var employees = this.GenerateEmployees(totalCount, totalManagersCount, totalEmployeesCount);
            return employees;
        }

        private IEnumerable<Employee> GenerateEmployees(
            int totalCount,
            int totalManagersCount,
            int totalEmployeesCount)
        {
            IList<Department> departments = this.departmentsRepository.Entities.ToList();
            IList<Employee> managers = new List<Employee>(totalManagersCount);
            IList<Employee> employees = new List<Employee>(totalEmployeesCount);
            ICollection<Employee> allEmployees = new HashSet<Employee>();

            for (int i = 0; i < totalCount; i++)
            {
                var firstName = this.stringGenerator.GetRandomString(
                    MinFirstNameLength,
                    MaxFirstNameLength);

                var lastName = this.stringGenerator.GetRandomString(
                    MinLastNameLength,
                    MaxLastNameLength);

                var yearSalary = this.numberGenerator.GetRandomInteger(
                    MinYearSalary,
                    MaxYearSalary);

                var departmentPosition = this.numberGenerator.GetRandomInteger(0, departments.Count);
                var department = departments[departmentPosition];

                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    YearSalary = yearSalary,
                    Department = department,
                };

                bool isManager = employees.Count == totalEmployeesCount || managers.Count == 0;
                bool isEmployee = managers.Count == totalManagersCount;

                if (isManager)
                {
                    managers.Add(employee);
                }
                else if (isEmployee)
                {
                    this.AssignManager(employee, managers);
                    employees.Add(employee);
                }
                else
                {
                    isManager = this.numberGenerator.GetRandomInteger(0, 2) == 0 ? true : false;

                    if (isManager)
                    {
                        managers.Add(employee);
                    }
                    else
                    {
                        this.AssignManager(employee, managers);
                        employees.Add(employee);
                    }
                }

                allEmployees.Add(employee);
            }

            return allEmployees;
        }

        private void AssignManager(Employee employee, IList<Employee> managers)
        {
            int managerPosition = this.numberGenerator.GetRandomInteger(0, managers.Count());
            var manager = managers[managerPosition];

            employee.Employee1 = manager;
        }
    }
}