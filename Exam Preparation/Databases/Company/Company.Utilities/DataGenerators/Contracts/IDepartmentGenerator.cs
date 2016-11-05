using System.Collections.Generic;

using Company.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IDepartmentGenerator
    {
        IEnumerable<Department> GetDepartments(int count);
    }
}