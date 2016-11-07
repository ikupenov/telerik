CREATE PROC usp_GetPuzzleToys
AS
	SELECT
		t.Name
		,t.Price
	FROM Toys t
	WHERE t.Type = 'Puzzle'
	AND t.Price > 10
	ORDER BY t.Price
GO

CREATE PROC usp_SelectManufacturersByToysInAgeRange
AS
	SELECT
		m.Name AS [Manafacturer]
		,COUNT(t.Id) AS [ToysInRange]
	FROM Manufacturers m
	JOIN Toys t
		ON t.ManufacturerId = m.Id
	JOIN AgeRanges ar
		ON t.AgeRangeId = ar.Id
	WHERE ar.MinAge >= 5
	AND ar.MaxAge <= 10
	GROUP BY m.Name
GO

CREATE PROC usp_SelectAllToysForBoys
AS
	SELECT
		t.Name
		,t.Price
		,t.Color
	FROM Toys t
	JOIN Toys_Categories tc
		ON t.Id = tc.ToyId
	JOIN Categories c
		ON c.Id = tc.CategoryId
	WHERE c.Name = 'Boys'
GO