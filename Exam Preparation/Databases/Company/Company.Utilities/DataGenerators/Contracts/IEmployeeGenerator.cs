using System.Collections.Generic;

using Console.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IEmployeeGenerator
    {
        IEnumerable<Employee> GetEmployees(int count, int managersPercentage, int employeesPercentage);
    }
}