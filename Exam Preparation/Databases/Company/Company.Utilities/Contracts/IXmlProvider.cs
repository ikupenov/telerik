using System.Xml.Linq;

namespace Company.Utilities.Contracts
{
    public interface IXmlProvider
    {
        //  Get the full name (first name + " " + last name) of every employee and its salary,
        //  for each employee with salary between $100 000 and $150 000, inclusive
        //  Implement paging, i.e. return only a part of all employees, based on the given page
        XElement GetEmployeesWithSalaryBetween(decimal from, decimal to);
        XElement GetEmployeesWithSalaryBetween(decimal from, decimal to, int page);

        //  Get all departments and how many employees there are in each one.
        //  Sort the result by the number of employees in descending order.
        //  Implement paging, i.e. return only a part of all employees, based on the given page
        XElement GetDepartments();
        XElement GetDepartments(int page);

        //  Get each employee’s full name (first name + " " + last name), project’s name, department’s name,
        //  starting and ending date for each employee in project.
        //  Additionally get the number of all reports, which time of reporting is between the start and end date.
        //  Sort the results first by the employee id, then by the project id.
        //  Implement paging, i.e. return only a part of all employees, based on the given page
        XElement GetEmployeesFullInfo();
        XElement GetEmployeesFullInfo(int page);
    }
}