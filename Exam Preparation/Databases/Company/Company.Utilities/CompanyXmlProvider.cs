using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Company.Data;
using Company.Repositories.Contracts;
using Company.Utilities.Contracts;

namespace Company.Utilities
{
    public sealed class CompanyXmlProvider : IXmlProvider
    {
        private const int DepartmentsPerPage = 5;
        private const int EmployeesPerPage = 10;

        private readonly IRepository<Department> departmentsRepository;
        private readonly IRepository<Employee> employeesRepository;

        public CompanyXmlProvider(ICompanyContext dbContext)
        {
            this.departmentsRepository = dbContext.Departments;
            this.employeesRepository = dbContext.Employees;
        }

        public XElement GetDepartments()
        {
            IEnumerable<Department> departments = this.departmentsRepository.Entities;

            XElement departmentsXElement = this.CreateDepartmentsXElement(departments);
            return departmentsXElement;

        }

        public XElement GetDepartments(int page)
        {
            IEnumerable<Department> departmentsOnPage = this.departmentsRepository.Entities
                .Skip(page * DepartmentsPerPage)
                .Take(DepartmentsPerPage);

            XElement departmentsXElement = this.CreateDepartmentsXElement(departmentsOnPage);
            return departmentsXElement;
        }

        public XElement GetEmployeesFullInfo()
        {
            IEnumerable<Employee> employees = this.employeesRepository.Entities;

            XElement employeesXElement = this.CreateEmployeesXElement(employees);
            return employeesXElement;
        }

        public XElement GetEmployeesFullInfo(int page)
        {
            IEnumerable<Employee> employeesOnPage = this.employeesRepository.Entities
                .Skip(page * EmployeesPerPage)
                .Take(EmployeesPerPage);

            XElement employeesXElement = this.CreateEmployeesXElement(employeesOnPage);
            return employeesXElement;
        }

        public XElement GetEmployeesWithSalaryBetween(decimal from, decimal to)
        {
            IEnumerable<Employee> employeesWithMatchingSalary = this.employeesRepository.Entities
                .Where(e => e.YearSalary >= from && e.YearSalary <= to);

            XElement employeesXElement = this.CreateEmployeesXElement(employeesWithMatchingSalary);
            return employeesXElement;
        }

        public XElement GetEmployeesWithSalaryBetween(decimal from, decimal to, int page)
        {
            IEnumerable<Employee> employeesWithMatchingSalary = this.employeesRepository.Entities
               .Where(e => e.YearSalary >= from && e.YearSalary <= to)
               .Skip(page * EmployeesPerPage)
               .Take(EmployeesPerPage);

            XElement employeesXElement = this.CreateEmployeesXElement(employeesWithMatchingSalary);
            return employeesXElement;
        }


        private XElement CreateDepartmentsXElement(IEnumerable<Department> departments)
        {
            XElement departmentsXElement =
                new XElement("Departments",
                    new XElement("Department", departments.Select(d =>
                        new XElement("Department",
                            new XElement("Name", d.Name),
                            new XElement("Employees", d.Employees.Select(e =>
                                new XElement("Employee", $"{e.FirstName} {e.LastName}")))))));

            return departmentsXElement;
        }

        private XElement CreateEmployeesXElement(IEnumerable<Employee> employees)
        {
            XElement employeesXElement =
                new XElement("Employees", employees.Select(e =>
                    new XElement("Employee",
                        new XElement("FirstName", e.FirstName),
                        new XElement("LastName", e.LastName),
                        new XElement("YearlySalary", e.YearSalary),
                        new XElement("Department", e.Department?.Name),
                        new XElement("Manager", $"{e.Employee1?.FirstName} {e.Employee1?.LastName}"),
                        new XElement("Projects", e.Projects.Select(p =>
                            new XElement("Project",
                                new XElement("Name", p.Name),
                                new XElement("StartDate", p.StartDate),
                                new XElement("EndDate", p.EndDate)))),
                        new XElement("Reports", e.Reports.Select(r =>
                            new XElement("Report",
                                new XAttribute("Time", r.Time)))))));

            return employeesXElement;
        }
    }
}