USE NORTHWND
GO

-- 01. Create table Cities with (CityId, Name)
CREATE TABLE Cities (
 CityId INT IDENTITY(1,1) PRIMARY KEY,
 Name nvarchar(15)
)
GO

-- 02. Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected)
INSERT INTO Cities(Name)
SELECT DISTINCT Names.City
FROM (
SELECT City
FROM Employees
WHERE City IS NOT NULL
UNION
SELECT City
FROM Suppliers
WHERE City IS NOT NULL
UNION 
SELECT City
FROM Customers
WHERE City IS NOT NULL) AS Names
GO

-- 03. Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities
ALTER TABLE Employees
ADD CityId int
GO
ALTER TABLE Employees
ADD FOREIGN KEY (CityId)
REFERENCES Cities(CityId)
GO

ALTER TABLE Suppliers
ADD CityId int
GO
ALTER TABLE Suppliers
ADD FOREIGN KEY (CityId)
REFERENCES Cities(CityId)
GO

ALTER TABLE Customers
ADD CityId int
GO
ALTER TABLE Customers
ADD FOREIGN KEY (CityId)
REFERENCES Cities(CityId)
GO

-- 04. Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
-- Employees (RESULT: 9 row(s) affected)
-- Suppliers (RESULT: 29 row(s) affected)
-- Customers (RESULT: 91 row(s) affected)
UPDATE Employees
 SET CityId = c.CityId
 FROM Employees e
 JOIN Cities c
 ON c.Name=e.City
 WHERE EmployeeID = e.EmployeeId
GO

UPDATE Suppliers
 SET CityId = c.CityId
 FROM Suppliers s
 JOIN Cities c
 ON c.Name=s.City
 WHERE SupplierID = s.SupplierID
GO

UPDATE Customers
 SET CityId = c.CityId
 FROM Customers e
 JOIN Cities c
 ON c.Name=e.City
 WHERE CustomerID = e.CustomerID
GO

-- 05. Make the column Name in Cities Unique
ALTER TABLE Cities
ADD UNIQUE (Name)
GO

-- 06. Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D (always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected)
INSERT INTO Cities(Name)
SELECT DISTINCT  ShipCity
FROM Orders
WHERE NOT EXISTS(SELECT Name FROM Cities WHERE Cities.Name= Orders.ShipCity)
GO

-- 07. Add CityId column in Orders with Foreign Key to CityId in Cities
ALTER TABLE Orders
ADD CityId int
GO
ALTER TABLE Orders
ADD FOREIGN KEY (CityId)
REFERENCES Cities(CityId)
GO

-- 08. Now rename that column to be ShipCityId to be consistent (use stored procedure :) )
EXEC sp_RENAME 'Orders.ShipCityId' , 'ShipCityId', 'COLUMN'
GO

-- 09. Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)
UPDATE Orders
 SET ShipCityId = c.CityId
 FROM Orders e
 JOIN Cities c
 ON c.Name=e.ShipCity
 WHERE OrderID = e.OrderID
GO

-- 10. Drop column ShipCity from Orders
ALTER TABLE Orders
DROP COLUMN ShipCity
GO

-- 11. Create table Countries with columns CountryId and Name (Unique)
CREATE TABLE Countries (
 CountryId INT IDENTITY(1,1) PRIMARY KEY,
 Name nvarchar(15) UNIQUE
)
GO

-- 12. Add CountryId to Cities with Foreign Key to CountryId in Countries
ALTER TABLE Cities
ADD CountryId int
GO
ALTER TABLE Cities
ADD FOREIGN KEY (CountryId)
REFERENCES Countries(CountryId)
GO

-- 13. Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected)
INSERT INTO Countries(Name)
SELECT DISTINCT Names.Country
FROM (
SELECT Country
FROM Employees
WHERE Country IS NOT NULL
UNION
SELECT Country
FROM Suppliers
WHERE Country IS NOT NULL
UNION 
SELECT ShipCountry
FROM Orders
WHERE ShipCountry IS NOT NULL
UNION
SELECT Country
FROM Customers
WHERE Country IS NOT NULL) AS Names
GO

-- 14. Update CountryId in Cities table with values from Countries table
-- Countries from employees table
UPDATE Cities
 SET countryId = c.CountryId
 FROM Cities e
 JOIN (SELECT e.CityId as id, CountryId
FROM Employees e
 JOIN Countries c
 ON c.Name=e.Country) c
 ON c.id=e.CityId
 WHERE CityId = e.CityId
GO

-- Countries from orders table
UPDATE Cities
 SET countryId=c.CountryId
 FROM Cities e
 JOIN (SELECT e.shipcityId as id, CountryId
FROM Orders e
 JOIN Countries c
 ON c.Name=e.ShipCountry) c
 ON c.id=e.CityId
 WHERE CityId = e.CityId
GO

-- Countries from employees table
UPDATE Cities
 SET countryId = c.CountryId
 FROM Cities e
 JOIN (SELECT e.CityId as id, CountryId
FROM Suppliers e
 JOIN Countries c
 ON c.Name=e.Country) c
 ON c.id=e.CityId
 WHERE CityId = e.CityId
GO

-- Countries from employees table
UPDATE Cities
 SET countryId = c.CountryId
 FROM Cities e
 JOIN (SELECT e.CityId as id, CountryId
FROM Customers e
 JOIN Countries c
 ON c.Name=e.Country) c
 ON c.id=e.CityId
 WHERE CityId = e.CityId
GO

-- 15. Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables
ALTER TABLE Employees
DROP COLUMN City
GO

ALTER TABLE Suppliers
DROP COLUMN City
GO

-- Cannot drop because table depends on city Error msg : The index 'City' is dependent on column 'City'.
ALTER TABLE Customers
DROP COLUMN City
GO

-- 16. Drop column Country and ShipCountry from Employees, Customers, Suppliers and Orders tables
ALTER TABLE Employees
DROP COLUMN Country
GO

ALTER TABLE Customers
DROP COLUMN Country
GO

ALTER TABLE Suppliers
DROP COLUMN Country
GO

ALTER TABLE Orders
DROP COLUMN ShipCountry
GO