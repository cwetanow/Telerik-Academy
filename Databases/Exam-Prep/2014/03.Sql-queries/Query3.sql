-- 03. 3.	Get each employee’s full name (first name + " " + last name), project’s name, department’s name, starting and ending date for each employee in project. Additionally get the number of all reports, which time of reporting is between the start and end date. Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)
USE Company
GO

SELECT e.Firstname+' '+e.Lastname AS Fullname, 
		p.Name,
		d.Name,
		ep.Startdate,
		ep.Enddate,
		(
		SELECT COUNT(*)
		FROM Employees e
		JOIN Reports r
		ON e.EmployeeId=r.EmployeeId
		WHERE r.ReportTime BETWEEN ep.Startdate AND ep.Enddate
		) AS ReportsCount
FROM Employees e
JOIN Departments d
ON e.DepartmentId=d.DepartmentId
JOIN Employees_Projects ep
ON ep.EmployeeId=e.EmployeeId
JOIN Projects p
ON ep.ProjectId=p.ProjectId
ORDER BY e.EmployeeId, p.ProjectId