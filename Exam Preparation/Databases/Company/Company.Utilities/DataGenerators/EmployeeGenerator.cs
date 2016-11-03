using System.Collections.Generic;
using System.Linq;

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
        private readonly IList<Department> departments;

        public EmployeeGenerator(
            INumberGenerator numberGenerator,
            IStringGenerator stringGenerator,
            IList<Department> departments)
        {
            this.numberGenerator = numberGenerator;
            this.stringGenerator = stringGenerator;
            this.departments = departments.ToList();
        }

        public IEnumerable<Employee> GetEmployees(
            int count,
            int managersPercentage,
            int employeesPercentage)
        {
            int totalManagersCount = (count * managersPercentage) / 100;
            int totalEmployeesCount = (count * employeesPercentage) / 100;

            var employees = this.GenerateEmployees(count, totalManagersCount, totalEmployeesCount);
            return employees;
        }

        private IEnumerable<Employee> GenerateEmployees(
            int count,
            int totalManagersCount,
            int totalEmployeesCount)
        {
            IList<Employee> managers = new List<Employee>(totalManagersCount);
            IList<Employee> employees = new List<Employee>(totalEmployeesCount);
            ICollection<Employee> allEmployees = new HashSet<Employee>();

            for (int i = 0; i < count; i++)
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

                var departmentPosition = this.numberGenerator.GetRandomInteger(0, this.departments.Count);
                var department = this.departments[departmentPosition];

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