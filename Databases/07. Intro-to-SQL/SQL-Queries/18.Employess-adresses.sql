USE TelerikAcademy
GO

SELECT *
FROM Employees e
JOIN Addresses a
ON e.AddressID=a.AddressID