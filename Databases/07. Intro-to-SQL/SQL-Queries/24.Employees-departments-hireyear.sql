USE TelerikAcademy
GO

SELECT *
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE (d.Name='Sales' OR d.Name='Finance') AND e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-12-31 00:00:00'
