-- Task 1
-- Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).

-- Create table
CREATE TABLE Logs (
	LogID int IDENTITY,
	LogDate date NOT NULL,
	LogMessage nvarchar(50) NOT NULL,
)

-- Insert 1 test log
INSERT INTO Logs(LogDate, LogMessage) 
VALUES ('1999/02/02','Sample log message')

GO

-- Insert records Note: This is a bit slow. If you run it you will have to wait 5 - 10 minutes :)
DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogDate, LogMessage)
  SELECT DATEADD(MONTH, @Counter + 3, LogDate), LogMessage + CONVERT(varchar, @Counter) FROM Logs
  SET @Counter = @Counter + 1
END

GO

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

--Test search by date before adding a index
SELECT LogMessage 
FROM Logs 
WHERE LogDate
BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '2002-01-01');

-- Result -> 7 seconds

-- Task 2
-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).

-- Add a index to the date column for faster search
CREATE INDEX IDX_OnLogDateColumn ON Logs(LogDate);

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

--Test search by date after adding a index
SELECT LogMessage 
FROM Logs 
WHERE LogDate
BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '2002-01-01');

-- Result -> less than a 1 second.

-- Task 3
-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.

CREATE FULLTEXT CATALOG FullTextForLogMessages
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogMessage)
KEY INDEX PK_Logs
ON FullTextForLogMessages
WITH CHANGE_TRACKING AUTO

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT * FROM Logs
WHERE LogMessage LIKE '% 1256789'

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT * FROM Logs
WHERE CONTAINS(LogMessage, '1256789')