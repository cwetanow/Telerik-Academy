-- 02. Get all departments and how many employees there are in each one. Sort the result by the number of employees in descending order.

USE Company
GO

SELECT d.Name, COUNT(*) AS Count
FROM Employees e
JOIN Departments d
ON e.DepartmentId=d.DepartmentId
GROUP BY d.Name
ORDER BY COUNT(*) DESC
