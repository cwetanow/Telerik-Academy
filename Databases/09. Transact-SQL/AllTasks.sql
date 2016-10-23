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

-- 05. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney (@accountId INT, @amount MONEY)
AS 
	DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE AccountId=@accountId)
	IF(@balance>@amount)
	BEGIN 
		UPDATE Accounts
		SET Balance = Balance-@amount
		WHERE AccountId=@accountId
	END
	ELSE
		BEGIN 
		PRINT 'Not enough money'
		END
GO

CREATE PROC dbo.usp_DepositMoney (@accountId INT, @amount MONEY)
AS 
	DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE AccountId=@accountId)
	BEGIN 
		UPDATE Accounts
		SET Balance = Balance+@amount
		WHERE AccountId=@accountId
	END	
GO

-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
CREATE TABLE Logs(
	LogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NUll,
	AccountId INT NOT NULL,	
	FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId)
)
GO

-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TRIGGER Tr_AccountChange
 ON Accounts
 FOR UPDATE 
 AS 
	SET NOCOUNT ON
	INSERT INTO Logs
	SELECT i.AccountId, d.Balance, i.Balance
	FROM inserted i, deleted d
GO

-- 07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
CREATE FUNCTION ufn_CheckStringContains (@stringToChekc nvarchar(50), @letters nvarchar(50)) 
RETURNS INT
AS
BEGIN
	DECLARE @i int =1 
	DECLARE @currentChar NVARCHAR(1)
        WHILE (@i <= LEN(@nameToCheck))
			BEGIN
				SET @currentChar = SUBSTRING(@nameToCheck,@i,1)
					IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
						BEGIN  
							RETURN 0
						END
				SET @i = @i + 1
			END
        RETURN 1
END

-- 08. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
USE TelerikAcademy
GO

DECLARE employeeTownCursor CURSOR READ_ONLY FOR
  (SELECT e.FirstName, e.LastName, t.Name
	FROM Employees e
	JOIN Addresses a 
	ON e.AddressID = a.AddressID
	JOIN Towns t 
	ON a.TownID=t.TownID) 

OPEN employeeTownCursor
DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50)

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE employeeTownCursor1 CURSOR READ_ONLY FOR
		(SELECT e.FirstName, e.LastName, t.Name FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID=t.TownID)
	OPEN employeeTownCursor1
		DECLARE @firstName1 NVARCHAR(50), @lastName1 NVARCHAR(50), @town1 NVARCHAR(50)
		FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			WHILE @@FETCH_STATUS = 0
			BEGIN
		
				IF(@town = @town1)
				BEGIN
					PRINT @lastname1 + ': ' + @firstname + ' ' +  @lastname + ' ' + @town + ' ' + @firstname1 
				END

			FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			END

	CLOSE employeeTownCursor1
	DEALLOCATE employeeTownCursor1

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town
END

CLOSE employeeTownCursor
DEALLOCATE employeeTownCursor