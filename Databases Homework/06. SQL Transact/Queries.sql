--1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
--and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.
-------------------------------------------------------------------------------------
--NOTE: Run InfoDB.sql
-------------------------------------------------------------------------------------

--2. Create a stored procedure that accepts a number as a parameter and returns all persons who 
--3have more money in their accounts than the supplied number.
-------------------------------------------------------------------------------------
CREATE PROC usp_SelectAllAcountsWithGivenBalance(
  @minBalance int = 0) AS

  SELECT FirstName + ' ' + LastName as FullName, Balance 
  FROM Persons p
  JOIN Accounts a
	on p.id = a.PersonId
	
   WHERE a.Balance > @minBalance
   ORDER BY Balance

   GO

EXEC usp_SelectAllAcountsWithGivenBalance 1000
-------------------------------------------------------------------------------------

--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
-------------------------------------------------------------------------------------
CREATE FUNCTION ufn_CalcIntrest(@balance money, @intrest float)
  RETURNS money
AS
BEGIN
  RETURN @balance * @intrest
END

SELECT dbo.ufn_CalcIntrestForMonths(Balance, 0.1, 2) as Intrest, Balance from Accounts  
-------------------------------------------------------------------------------------

--4. Create a stored procedure that uses the function from the previous example to 
--give an interest to a person's account for one month. 
--It should take the AccountId and the interest rate as parameters.
-------------------------------------------------------------------------------------
CREATE PROC usp_UpdateBalanceWithInterestForOneMonth(@accId int = 0, @intrestRate float = 0) AS
  UPDATE Accounts
  SET Balance = Balance + dbo.ufn_CalcIntrestForMonths(Balance, @intrestRate, 1)
  WHERE id = @accId
 GO

EXEC usp_UpdateBalanceWithInterestForOneMonth 1, 0.1
-------------------------------------------------------------------------------------

--5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
-------------------------------------------------------------------------------------
CREATE PROC usp_WithdrawMoney(@AccountId int = 1, @Sum_Amount money) AS
	BEGIN TRAN
	DECLARE @CurrentAmaount money
	UPDATE Accounts
	SET Balance = Balance - @Sum_Amount,
	@CurrentAmaount = Balance - @Sum_Amount
	WHERE id = @AccountId

	IF(@CurrentAmaount < 0)
		ROLLBACK TRAN
 GO
 
 CREATE PROC usp_DepositMoney(@AccountId int = 1, @Sum_Amount money) AS
	BEGIN TRAN
	DECLARE @CurrentAmaount money
	UPDATE Accounts
	SET Balance = Balance + @Sum_Amount,
	@CurrentAmaount = Balance + @Sum_Amount
	WHERE id = @AccountId

	IF(@CurrentAmaount < 0)
		ROLLBACK TRAN
	ElSE
		COMMIT TRAN
 GO
-------------------------------------------------------------------------------------

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
-------------------------------------------------------------------------------------
CREATE TABLE Logs
(
LogId int
PRIMARY KEY CLUSTERED
IDENTITY(1, 1),
AccountId int
FOREIGN KEY REFERENCES Accounts(id),
OldSum money,
NewSum money
)

CREATE TRIGGER Tranasaction_Logger
ON Accounts
AFTER UPDATE
AS
IF EXISTS(SELECT * FROM DELETED)
BEGIN

DECLARE @personId int, @balanceBefore money, @balanceAfter money
SELECT @personId = del.id, @balanceBefore = del.Balance FROM deleted del
SELECT @balanceAfter = ins.Balance FROM inserted ins

INSERT INTO Logs
VALUES (@personId, @balanceBefore, @balanceAfter)
END

EXEC usp_WithdrawMoney 1, 100
-------------------------------------------------------------------------------------

--7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
--and all town's names that are comprised of given set of letters. Example 'oistmiahf' will 
--return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
-------------------------------------------------------------------------------------
CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
BEGIN

DECLARE @lettersLen int = LEN(@letters),
@matches int = 0,
@currentChar nvarchar(1)

WHILE(@lettersLen > 0)
BEGIN
SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
IF(CHARINDEX(@currentChar, @word, 0) > 0)
BEGIN
SET @matches += 1
SET @lettersLen -= 1
END
ELSE
SET @lettersLen -= 1
END

IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
RETURN 1

RETURN 0
END

GO

CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
RETURNS @ResultTable TABLE
(
Name varchar(50) NOT NULL
)
AS
BEGIN

INSERT INTO @ResultTable
SELECT LastName FROM Employees

INSERT INTO @ResultTable
SELECT FirstName FROM Employees

INSERT INTO @ResultTable
SELECT towns.Name FROM Towns towns

DELETE FROM @ResultTable
WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

RETURN
END

GO

SELECT * FROM dbo.NamesAndTowns('')
-------------------------------------------------------------------------------------

--8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all 
--pairs of employees that live in the same town.
-------------------------------------------------------------------------------------
CREATE PROCEDURE usp_EmployeesInTown @results CURSOR VARYING OUTPUT
AS
BEGIN

SET @results = CURSOR FOR

SELECT emp.LastName, towns.Name FROM Employees emp
JOIN Addresses addr
ON emp.AddressID = addr.AddressID
JOIN Towns towns
ON addr.TownID = towns.TownID
GROUP BY towns.TownID, towns.Name, emp.LastName

OPEN @results
END

GO

DECLARE @employeesInTowns CURSOR
DECLARE @LastName varchar(20), @TownName varchar(20)

EXEC usp_EmployeesInTown @results = @employeesInTowns OUTPUT
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

