using System.Collections.Generic;

using Console.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IDepartmentGenerator
    {
        IEnumerable<Department> GetDepartments(int count);
    }
}