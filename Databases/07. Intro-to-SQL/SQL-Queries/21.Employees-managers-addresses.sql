USE TelerikAcademy
GO

SELECT e.FirstName+' '+e.LastName AS [Employee Name],
	 a.AddressText AS [Employee Address], 
	 m.FirstName+' '+m.LastName AS [Manager Name],
	 ma.AddressText AS [Manager Address]
FROM Employees e
JOIN Employees m
ON e.ManagerID=m.EmployeeID
JOIN Addresses a
ON e.AddressID=a.AddressID
JOIN Addresses ma
ON m.AddressID=ma.AddressID