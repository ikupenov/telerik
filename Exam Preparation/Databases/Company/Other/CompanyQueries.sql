/* 1.	Get the full name (first name + " " + last name) of every employee and its salary, 
		for each employee with salary between $100 000 and $150 000, inclusive. 
		Sort the results by salary in ascending order. */
SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS [Employee]
FROM Employees e
WHERE e.YearSalary >= 100000
AND e.YearSalary <= 150000

/* 2.	Get all departments and how many employees there are in each one. 
		Sort the result by the number of employees in descending order. */
SELECT
	d.Name
	,COUNT(e.Id) AS [Employees]
FROM Departments d
JOIN Employees e
	ON d.Id = e.DepartmentId
GROUP BY d.Name
ORDER BY COUNT(e.Id) DESC

/* 3.	Get each employee’s full name (first name + " " + last name), project’s name, 
		department’s name, starting and ending date for each employee in project. 
		Additionally get the number of all reports, which time of reporting is between the start and end date. 
		Sort the results first by the employee id, then by the project id. */
SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS [Employee]
	,d.Name AS [Department]
	,p.Name AS [Project]
	,p.StartDate AS [StartDate]
	,p.EndDate AS [EndDate]
	,(SELECT
			COUNT(*)
		FROM Reports r
		WHERE r.Time >= p.StartDate
		AND r.Time <= p.EndDate)
	AS [ReportsCount]
FROM Employees e
JOIN Departments d
	ON d.Id = e.DepartmentId
JOIN Employees_Projects ep
	ON e.Id = ep.EmployeeId
JOIN Projects p
	ON p.Id = ep.ProjectId
ORDER BY e.Id, p.Id