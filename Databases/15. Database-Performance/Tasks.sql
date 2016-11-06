CREATE DATABASE Performance
GO

-- 01. Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).
USE Performance
CREATE TABLE Events (
	Id int Identity(1,1) Primary Key,
	Host nvarchar(100),
	[Date] date
)
GO

SET NOCOUNT ON
DECLARE @ConcertCount int = (SELECT COUNT(*) FROM Events)
-- IMPORTANT
-- Reduce the rowcount variable, or else it takes about two eternities
DECLARE @RowCount int = 10000000
WHILE @RowCount > 0
BEGIN
  DECLARE @Host nvarchar(100) = 
    'Name ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Events(Host, [Date])
  VALUES(@Host, @Date)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF
GO

SELECT COUNT(*)
FROM Events
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- 6 sec
SELECT * 
FROM Events
WHERE [Date] > '10-10-2010'

-- 02. Add an index to speed-up the search by date.
-- Test the search speed (after cleaning the cache).

CREATE INDEX IDX_Event_Date
ON Events([Date])

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- 2 sec
SELECT * 
FROM Events
WHERE [Date] > '10-10-2010'

-- 03. Add a full text index for the text column.
-- Try to search with and without the full-text index and compare the speed.
CREATE FULLTEXT CATALOG HostsCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Events(Host)
KEY INDEX PK_Events on HostsCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- 0 sec
SELECT * FROM Events
WHERE CONTAINS(Host, '123')

-- 6 sec
SELECT * FROM Events
WHERE Host LIKE '%123%'