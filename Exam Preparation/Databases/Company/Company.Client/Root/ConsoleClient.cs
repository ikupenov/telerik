using System;
using System.Collections.Generic;

using Company.Client.Contracts;
using Company.Repositories.Contracts;
using Company.Utilities.DataGenerators.Contracts;
using Console.Data;

namespace Company.Client.Root
{
    internal class ConsoleClient : IClient
    {
        private const int DepartmentsCount = 100;
        private const int EmployeesCount = 1000;
        private const int ProjectsCount = 3000;
        private const int AvgReportPerEmployee = 50;

        private const int EmployeesPercentage = 5;
        private const int ManagersPercentage = 95;

        private readonly DateTime minStartDate = new DateTime(1996, 7, 12, 22, 56, 56);
        private readonly DateTime maxEndtDate = new DateTime(2012, 8, 7, 8, 30, 05);

        private readonly IEmployeeGenerator employeeGenerator;
        private readonly IProjectGenerator projectGenerator;
        private readonly IReportGenerator reportGenerator;
        private readonly IDepartmentGenerator departmentGenerator;
        private readonly ICompanyContext companyContext;
        private readonly IWorkUnit unitOfWork;

        public ConsoleClient(
            IEmployeeGenerator employeeGenerator,
            IProjectGenerator projectGenerator,
            IReportGenerator reportGenerator,
            IDepartmentGenerator departmentGenerator,
            ICompanyContext companyContext,
            IWorkUnit unitOfWork)
        {
            this.employeeGenerator = employeeGenerator;
            this.projectGenerator = projectGenerator;
            this.reportGenerator = reportGenerator;
            this.departmentGenerator = departmentGenerator;
            this.companyContext = companyContext;
            this.unitOfWork = unitOfWork;
        }

        public void Start()
        {
            IEnumerable<Department> departments = this.departmentGenerator.GetDepartments(DepartmentsCount);
            IEnumerable<Employee> employees = this.employeeGenerator.GetEmployees(
                EmployeesCount,
                ManagersPercentage,
                EmployeesPercentage);
            IEnumerable<Project> projects = this.projectGenerator.GetProjects(
                ProjectsCount,
                this.minStartDate,
                this.maxEndtDate);
            IEnumerable<Report> reports = this.reportGenerator.GetReports(
                AvgReportPerEmployee,
                this.minStartDate,
                this.maxEndtDate);

            using (this.unitOfWork)
            {
                this.companyContext.Departments.AddMany(departments);
                this.companyContext.Employees.AddMany(employees);
                this.companyContext.Projects.AddMany(projects);
                this.companyContext.Reports.AddMany(reports);

                this.unitOfWork.Commit();
            }
        }
    }
}