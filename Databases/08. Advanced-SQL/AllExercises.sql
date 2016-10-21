USE TelerikAcademy
GO

--01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary=(SELECT MIN(Salary) FROM Employees)

--02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary<=1.1*(SELECT MIN(Salary) FROM Employees)

--03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT e.FirstName+' '+e.LastName AS [Full Name], e.Salary, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE e.Salary=
(SELECT MIN(Salary) FROM Employees em WHERE em.DepartmentID=d.DepartmentID)

--04. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salary]
FROM Departments d
JOIN Employees e
ON d.DepartmentID=e.DepartmentID
WHERE d.DepartmentID=1

--05. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) AS [Average Salary]
FROM Departments d
JOIN Employees e
ON d.DepartmentID=e.DepartmentID
WHERE d.Name='Sales'

--06. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*)
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'

--07. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--08. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*)
FROM Employees e
WHERE e.ManagerID IS NULL

--09. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(Salary) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS Department, t.Name as Town, COUNT(*) AS Count
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
JOIN Addresses a
ON e.AddressID=a.AddressID
JOIN Towns t
ON a.TownID=t.TownID
GROUP BY t.Name, d.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName AS [Manager Name], COUNT(*) AS [Employees]
FROM Employees e
JOIN Employees m
ON e.ManagerID=m.ManagerID
GROUP BY m.FirstName
HAVING COUNT(*) =5

--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName+' '+e.LastName AS [Employee Name],ISNULL(m.FirstName+' '+m.LastName,'No manager') AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID=m.EmployeeID

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees 
WHERE LEN(LastName)=5

--14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(NVARCHAR(50),GETDATE(),104) + ' '
 + CONVERT(NVARCHAR(50),GETDATE(),114) AS [DateTime]

--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
CREATE TABLE Users(
UserId int  NOT NULL IDENTITY(1,1),
Username nvarchar(50),
Pass nvarchar(20),
Fullname nvarchar(50),
LastLogin datetime
)

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
INSERT INTO Users (Username, Pass,LastLogin)
VALUES ('Batman','Arkham',GETDATE()),('Superman','Alien',GETDATE())
GO

CREATE VIEW [UsersLoggedToday] AS
SELECT *
FROM Users
WHERE CONVERT(NVARCHAR(20),LastLogin,104) = CONVERT(NVARCHAR(20),GETDATE(),104)

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
CREATE TABLE Groups (
GroupId int IDENTITY(1,1) PRIMARY KEY,
GroupName nvarchar(50) NOT NULL UNIQUE
)

--18. Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupId int

-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
ADD FOREIGN KEY	(GroupId)
REFERENCES Groups(GroupId)

--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups(GroupName)
VALUES ('Avengers'),('Justice League')
GO

INSERT INTO Users (Username, Pass,LastLogin, GroupId)
VALUES ('Batman','Arkham',GETDATE(),1),('Superman','Alien',GETDATE(),1)
GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET LastLogin=GETDATE()
WHERE Pass IS NULL

--21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username='John'
GO

DELETE FROM Groups
WHERE GroupId=1
GO

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
INSERT INTO Users(Username)
SELECT FirstName
FROM dbo.Employees 

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET Pass = NULL
WHERE LastLogin<='2010/03/10'

--24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Pass IS NULL

--25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(Salary) AS [Average salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d.Name AS Department, e.JobTitle AS [Job Title]
, MIN(e.FirstName+e.LastName) AS Name
, MIN(e.Salary) AS [Minimal Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name, e.JobTitle

--27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*) as [Employees Count]
FROM Employees e
JOIN Addresses a
ON e.AddressID=a.AddressID
JOIN Towns t
ON a.TownID=t.TownID
GROUP BY t.Name
ORDER BY [Employees Count] DESC

--28. Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) AS [Managers Count]
FROM Employees e
JOIN Employees m 
ON e.ManagerID=m.EmployeeID
JOIN Addresses a
ON m.AddressID=a.AddressID
JOIN Towns t
ON t.TownID=a.TownID
GROUP BY t.Name