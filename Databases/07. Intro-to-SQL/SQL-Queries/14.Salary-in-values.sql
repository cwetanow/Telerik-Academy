USE TelerikAcademy
GO

SELECT Firstname, Lastname, Salary
FROM Employees
WHERE Salary IN(25000, 14000, 12500, 23600)