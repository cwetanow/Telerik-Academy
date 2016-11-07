-- 01. Get the full name (first name + " " + last name) of every employee and its salary, for each employee with salary between $100 000 and $150 000, inclusive. Sort the results by salary in ascending order.

USE Company
GO

SELECT Firstname+' '+Lastname AS Fullname, Salary
FROM Employees 
WHERE Salary >=100000 AND Salary<=150000
ORDER BY Salary 