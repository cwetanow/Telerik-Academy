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


--10. Write a SQL query to find the count of all employees in each department and for each town.


--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

--14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".

--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).

--18. Write a SQL statement to add a column GroupID to the table Users.

-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

--19. Write SQL statements to insert several records in the Users and Groups tables.

--20. Write SQL statements to update some of the records in the Users and Groups tables.

--21. Write SQL statements to delete some of the records from the Users and Groups tables.

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

--24. Write a SQL statement that deletes all users without passwords (NULL password).

--25. Write a SQL query to display the average employee salary by department and job title.

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

--27. Write a SQL query to display the town where maximal number of employees work.

--28. Write a SQL query to display the number of managers from each town.
