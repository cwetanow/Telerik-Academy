USE Company
GO

CREATE PROCEDURE uspCreateCachedTable 
AS 
CREATE TABLE CachedTable(
Fullname nvarchar(50), 
		 [Project Name] nvarchar(50),
		 [Department name] nvarchar(50),
		 [Starting Date] datetime,
		 [Ending Date] datetime ,
		 ReportsCount int	
)
GO

EXECUTE uspCreateCachedTable
GO

CREATE PROCEDURE uspFIllCachedTable 
AS 
INSERT INTO CachedTable
SELECT e.Firstname+' '+e.Lastname AS Fullname, 
		p.Name AS [Project Name],
		d.Name [Department name],
		ep.Startdate [Starting Date],
		ep.Enddate [Ending Date],
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
GO

EXECUTE uspFIllCachedTable
GO