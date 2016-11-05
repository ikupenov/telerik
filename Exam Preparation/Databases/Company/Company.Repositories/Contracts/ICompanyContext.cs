using Company.Data;

namespace Company.Repositories.Contracts
{
    public interface ICompanyContext
    {
        IRepository<Employee> Employees { get; }

        IRepository<Project> Projects { get; }

        IRepository<Report> Reports { get; }

        IRepository<Department> Departments { get; }
    }
}