using System.Collections.Generic;

using Company.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IEmployeeGenerator
    {
        IEnumerable<Employee> GetEmployees(int count, int managersPercentage, int employeesPercentage);
    }
}