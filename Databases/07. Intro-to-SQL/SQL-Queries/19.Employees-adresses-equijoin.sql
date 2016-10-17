USE TelerikAcademy
GO

SELECT *
FROM Employees e, Addresses a
WHERE e.AddressID=a.AddressID