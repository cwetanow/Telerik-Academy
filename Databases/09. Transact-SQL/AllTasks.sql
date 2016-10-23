--01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).

CREATE DATABASE BankSystem
GO

USE BankSystem
GO

CREATE TABLE Persons(
	PersonId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Firstname nvarchar(50) NOT NULL,
	Lastname nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
)
GO

CREATE TABLE Accounts(
	AccountId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Balance money NOT NULL,
	PersonId int NOT NULL,
FOREIGN KEY (PersonId) REFERENCES Persons(PersonId)
)
GO

--	Insert few records for testing.
INSERT INTO Persons(Firstname,Lastname,SSN) 
VALUES 
('Pesho', 'Petrov', '123456'),
('Gosho', 'Petrov', '128796'),
('Mara', 'Lubenova', '129533'),
('Batman', 'BATMAN', '729816')
GO

INSERT INTO Accounts(Balance, PersonId)
VALUES
(22,1),
(22123,2),
(222.5,3),
(12345677,4)
GO

-- Write a stored procedure that selects the full names of all persons.
CREATE PROC dbo.usp_GetFullnames
AS
 SELECT Firstname+' '+Lastname AS [Fullname]
 FROM Persons
GO

-- 02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC dbo.usp_GetPeopleWithHigherBalance (@minimalMoney int) 
AS
 SELECT *
 FROM Persons p
 JOIN Accounts a
 ON p.PersonId=a.PersonId
 WHERE a.Balance>@minimalMoney
 GO

 -- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum.
CREATE FUNCTION ufn_CalculateSumWithInterest (@sum money, @interestRate decimal, @numberMonths int)
 RETURNS money
AS 
BEGIN
 RETURN (@sum + @sum*(@interestRate/100)*@numberMonths/12) 
END
GO

-- Write a SELECT to test whether the function works as expected.
DECLARE @money MONEY = (SELECT Balance FROM Accounts WHERE AccountId=3)
PRINT dbo.ufn_CalculateSumWithInterest(@money, 5, 5)
GO

-- 04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
CREATE PROC dbo.usp_CalculateInterest (@accountId int, @interest decimal)
AS 
DECLARE @money MONEY = (SELECT Balance FROM Accounts WHERE AccountId=@accountId)
UPDATE Accounts
SET Balance = dbo.ufn_CalculateSumWithInterest(@money, @interest, 1)
WHERE AccountId = @accountId
GO
