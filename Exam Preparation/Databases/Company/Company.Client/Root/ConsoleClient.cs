using System;
using System.Collections.Generic;
using System.Xml.Linq;

using Company.Client.Contracts;
using Company.Data;
using Company.Repositories.Contracts;
using Company.Utilities.Contracts;
using Company.Utilities.DataGenerators.Contracts;

namespace Company.Client.Root
{
    internal class ConsoleClient : IClient
    {
        private const string XmlDirPath = @"..\..\..\XmlOutput";

        private const int DepartmentsCount = 10;
        private const int EmployeesCount = 100;
        private const int ProjectsCount = 300;
        private const int AvgReportPerEmployee = 5;

        private const int EmployeesPercentage = 95;
        private const int ManagersPercentage = 5;

        private readonly DateTime minStartDate = new DateTime(1996, 7, 12, 22, 56, 56);
        private readonly DateTime maxEndtDate = new DateTime(2012, 8, 7, 8, 30, 05);

        private readonly IDepartmentGenerator departmentGenerator;
        private readonly IEmployeeGenerator employeeGenerator;
        private readonly IProjectGenerator projectGenerator;
        private readonly IReportGenerator reportGenerator;
        private readonly ICompanyContext companyContext;
        private readonly IWorkUnit unitOfWork;
        private readonly IXmlProvider xmlProvider;

        public ConsoleClient(
            IDepartmentGenerator departmentGenerator,
            IEmployeeGenerator employeeGenerator,
            IProjectGenerator projectGenerator,
            IReportGenerator reportGenerator,
            ICompanyContext companyContext,
            IWorkUnit unitOfWork,
            IXmlProvider xmlProvider)
        {
            this.departmentGenerator = departmentGenerator;
            this.employeeGenerator = employeeGenerator;
            this.projectGenerator = projectGenerator;
            this.reportGenerator = reportGenerator;
            this.companyContext = companyContext;
            this.unitOfWork = unitOfWork;
            this.xmlProvider = xmlProvider;
        }

        public void Start()
        {
            this.SeedData();
            this.SaveAllDepartmentsToXml();
            this.SaveEmployeesWithHighSalaryToXml();
        }

        private void SeedData()
        {
            using (this.unitOfWork)
            {
                IEnumerable<Department> departments = this.departmentGenerator.GetDepartments(DepartmentsCount);
                this.companyContext.Departments.AddMany(departments);
                this.unitOfWork.Commit();

                IEnumerable<Employee> employees = this.employeeGenerator.GetEmployees(
                    EmployeesCount,
                    ManagersPercentage,
                    EmployeesPercentage);
                this.companyContext.Employees.AddMany(employees);
                this.unitOfWork.Commit();

                IEnumerable<Project> projects = this.projectGenerator.GetProjects(
                    ProjectsCount,
                    this.minStartDate,
                    this.maxEndtDate);
                this.companyContext.Projects.AddMany(projects);
                this.unitOfWork.Commit();

                IEnumerable<Report> reports = this.reportGenerator.GetReports(
                    AvgReportPerEmployee,
                    this.minStartDate,
                    this.maxEndtDate);
                this.companyContext.Reports.AddMany(reports);
                this.unitOfWork.Commit();
            }
        }

        private void SaveAllDepartmentsToXml()
        {
            XElement departments = this.xmlProvider
                .GetDepartments();

            departments.Save($@"{XmlDirPath}\Departments.xml");
        }

        private void SaveEmployeesWithHighSalaryToXml()
        {

            XElement employeesWithHighSalary = this.xmlProvider
                .GetEmployeesWithSalaryBetween(180000, 200000);

            employeesWithHighSalary.Save($@"{XmlDirPath}\EmployeesWithHighSalary.xml");
        }
    }
}