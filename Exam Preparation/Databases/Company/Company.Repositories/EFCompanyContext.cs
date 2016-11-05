using System.Data.Entity;

using Company.Data;
using Company.Repositories.Contracts;

namespace Company.Repositories
{
    public class EFCompanyContext : ICompanyContext
    {
        private readonly IRepository<Department> departments;
        private readonly IRepository<Employee> employees;
        private readonly IRepository<Project> projects;
        private readonly IRepository<Report> reports;

        public EFCompanyContext(DbContext context)
        {
            this.departments = new CompanyRepository<Department>(context);
            this.employees = new CompanyRepository<Employee>(context);
            this.projects = new CompanyRepository<Project>(context);
            this.reports = new CompanyRepository<Report>(context);
        }

        public IRepository<Department> Departments
        {
            get { return this.departments; }
        }

        public IRepository<Employee> Employees
        {
            get { return this.employees; }
        }

        public IRepository<Project> Projects
        {
            get { return this.projects; }
        }

        public IRepository<Report> Reports
        {
            get { return this.reports; }
        }
    }
}