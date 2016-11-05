using System.Collections.Generic;

using Company.Data;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;

namespace Company.Utilities.DataGenerators
{
    public class DepartmentGenerator : IDepartmentGenerator
    {
        private const int MinNameLength = 10;
        private const int MaxNameLength = 50;

        private readonly IStringGenerator stringGenerator;

        public DepartmentGenerator(IStringGenerator stringGenerator)
        {
            this.stringGenerator = stringGenerator;
        }

        public IEnumerable<Department> GetDepartments(int count)
        {
            ICollection<Department> departments = new List<Department>(count);

            for (int i = 0; i < count; i++)
            {
                var departmentName = this.stringGenerator.GetRandomString(MinNameLength, MaxNameLength);
                var department = new Department { Name = departmentName };

                departments.Add(department);
            }

            return departments;
        }
    }
}