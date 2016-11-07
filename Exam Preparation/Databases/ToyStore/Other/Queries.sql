/* 1. Get all toys’s name and price having type of “puzzle” and price above $10.00 ordering them by price */
SELECT
	t.Name
	,t.Price
FROM Toys t
WHERE t.Type = 'Puzzle'
AND t.Price > 10
ORDER BY t.Price

/* 2. Get all manufacturers’ name and how many toys they have in the age range of 5 to 10 years, inclusive */
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

/* 3. Get all toys’ name, price and color from category “boys”  */
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