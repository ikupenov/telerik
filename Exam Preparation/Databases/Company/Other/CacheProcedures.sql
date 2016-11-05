/* Create a “cache” table for the third query from problem 3 and save all the results there
	for future querying. Provide the .sql file, containing the stored procedures 
	which creates the table and inserts the data. You should write two stored procedures –
	one for creating the table and one for updating the data. */

USE Company
GO

CREATE PROC usp_CreateQ3CacheTable
AS
	CREATE TABLE Q3CacheTable
	(
		Employee NVARCHAR(100),
		Department NVARCHAR(50),
		Project NVARCHAR(50),
		StartDate DATETIME,
		EndDate DATETIME,
		ReportsCount INT
	);
GO 

CREATE PROC usp_UpdateQ3CacheTable
AS
	DELETE FROM Q3CacheTable
	INSERT INTO Q3CacheTable
		SELECT
			CONCAT(e.FirstName, ' ', e.LastName) AS [Employee]
			,d.Name AS [Department]
			,p.Name AS [Project]
			,p.StartDate AS [StartDate]
			,p.EndDate AS [EndDate]
			,(SELECT
					COUNT(*)
				FROM Reports r
				WHERE r.Time BETWEEN p.StartDate AND p.EndDate)
			AS [ReportsCount]
		FROM Employees e
		JOIN Departments d
			ON d.Id = e.DepartmentId
		JOIN Employees_Projects ep
			ON e.Id = ep.EmployeeId
		JOIN Projects p
			ON p.Id = ep.ProjectId
GO

EXEC usp_CreateQ3CacheTable
EXEC usp_UpdateQ3CacheTable