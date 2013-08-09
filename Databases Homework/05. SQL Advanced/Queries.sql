--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
------------------------------------------------------------------------------------------------
select FirstName, Salary 
from Employees
where Salary = 
	(
		select MIN(Salary) 
		from Employees
	);
------------------------------------------------------------------------------------------------

--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
------------------------------------------------------------------------------------------------
select FirstName, Salary 
from Employees
where Salary < 
	(
		select MIN(Salary) * 1.1
		from Employees
	)
order by Salary;
------------------------------------------------------------------------------------------------

--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
------------------------------------------------------------------------------------------------
select e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName as FullName, d.Name, Salary 
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where Salary = 
	(
		select MIN(Salary)
		from Employees
		where DepartmentID = d.DepartmentID
	)

order by d.DepartmentID;
------------------------------------------------------------------------------------------------

--4. Write a SQL query to find the average salary in the department #1.
------------------------------------------------------------------------------------------------
select AVG(Salary) as AverageSalary 
from Employees
where DepartmentID = 1;
------------------------------------------------------------------------------------------------

--5. Write a SQL query to find the average salary  in the "Sales" department.
------------------------------------------------------------------------------------------------
select AVG(Salary) as AverageSalary 
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales';
------------------------------------------------------------------------------------------------

--6. Write a SQL query to find the number of employees in the "Sales" department.
------------------------------------------------------------------------------------------------
select Count(EmployeeID) as AverageSalary 
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales';
------------------------------------------------------------------------------------------------

--7. Write a SQL query to find the number of all employees that have manager.
------------------------------------------------------------------------------------------------
select Count(EmployeeID) 
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where e.ManagerID is not NULL;
------------------------------------------------------------------------------------------------

--8. Write a SQL query to find the number of all employees that have no manager.
------------------------------------------------------------------------------------------------
select Count(EmployeeID) 
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where e.ManagerID is NULL;
------------------------------------------------------------------------------------------------

--9. Write a SQL query to find all departments and the average salary for each of them.
------------------------------------------------------------------------------------------------
select d.Name, AVG(Salary) as AverageDepartmentSalary
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
group by d.Name;
------------------------------------------------------------------------------------------------

--10. Write a SQL query to find the count of all employees in each department and for each town.
------------------------------------------------------------------------------------------------
select d.Name, t.Name, COUNT(EmployeeID)
from Employees e
	join Departments d
	on e.DepartmentID = d.DepartmentID
	join Addresses ad
	on e.AddressID = ad.AddressID
	join Towns t
	on t.TownID = ad.TownID
group by d.Name, t.Name
------------------------------------------------------------------------------------------------

--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
------------------------------------------------------------------------------------------------
select em.FirstName + ' ' + em.LastName as FullName
from Employees e join Employees em
	on e.ManagerID = em.EmployeeID
group by em.FirstName + ' ' + em.LastName
having COUNT(*) = 5;
------------------------------------------------------------------------------------------------

--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".\
------------------------------------------------------------------------------------------------
select em.FirstName as Subordinate, COALESCE(e.FirstName, '(no manager)') as Boss 
from Employees e right outer join Employees em
	on e.EmployeeID = em.ManagerID;
------------------------------------------------------------------------------------------------

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
------------------------------------------------------------------------------------------------
select FirstName + ' ' + LastName as FullName 
from Employees
where LEN(LastName) = 5;
------------------------------------------------------------------------------------------------

--14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
Search in  Google to find how to format dates in SQL Server.
------------------------------------------------------------------------------------------------
select CONVERT(datetime, GETDATE(), 121);
------------------------------------------------------------------------------------------------

--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
Define a check constraint to ensure the password is at least 5 characters long.
------------------------------------------------------------------------------------------------
CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(100) NOT NULL UNIQUE,
  Password_name nvarchar(30) NOT NULL,
  Last_login_date date GETDATE(),
  CONSTRAINT PK_Cities PRIMARY KEY(UserID),
  CONSTRAINT LN_Pass CHECK (LEN(Password_name) >= 5)
)
------------------------------------------------------------------------------------------------

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.
------------------------------------------------------------------------------------------------
CREATE VIEW AllUsers AS
select * from Users
------------------------------------------------------------------------------------------------

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.
------------------------------------------------------------------------------------------------
CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(30) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
)
------------------------------------------------------------------------------------------------

--18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column 
--and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
------------------------------------------------------------------------------------------------
ALTER TABLE Users
ADD GroupID int;
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID);
------------------------------------------------------------------------------------------------

--19. Write SQL statements to insert several records in the Users and Groups tables.
------------------------------------------------------------------------------------------------
INSERT INTO Users(Username, Password_name, Last_login_date)
VALUES ('HASANNNdd', 'MEGAPASS', GETDATE()),
('HASANNN12', 'MEGAPASSasd', GETDATE()),
('HASANNN333dd', 'MEGAPASS2', GETDATE()),
('HASANNN333', 'MEGAPASS33', GETDATE())
INSERT INTO Groups(Name)
VALUES ('Some name67'),
('Some name23'),
('Some name234'),
('Some name11'),
('Some name3'),
('Some name2'),
('Some name5');
------------------------------------------------------------------------------------------------

--20. Write SQL statements to update some of the records in the Users and Groups tables.
------------------------------------------------------------------------------------------------
UPDATE Users
SET Password_name = 'Brown'
WHERE Username = 'HASANNN12'

UPDATE Groups
SET Name = 'Brown'
WHERE GroupID = 4
------------------------------------------------------------------------------------------------

--21. Write SQL statements to delete some of the records from the Users and Groups tables.
------------------------------------------------------------------------------------------------
DELETE FROM Users 
WHERE UserID = 13

DELETE FROM Groups 
WHERE GroupID = 4
------------------------------------------------------------------------------------------------

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
--Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
--Use the same for the password, and NULL for last login time.
------------------------------------------------------------------------------------------------
INSERT INTO Users(Username, Password_name, Last_login_date)
  SELECT SUBSTRING(FirstName, 0, 4) + '' + LOWER(LastName) + 'Magic', SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + 'Magic', NULL
  FROM Employees
------------------------------------------------------------------------------------------------

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
------------------------------------------------------------------------------------------------
UPDATE Users
SET Password_name = NULL
WHERE Last_login_date < '10/03/2020';
------------------------------------------------------------------------------------------------

--24. Write a SQL statement that deletes all users without passwords (NULL password).
------------------------------------------------------------------------------------------------
DELETE FROM Users 
WHERE Password_name is null;
------------------------------------------------------------------------------------------------

--25. Write a SQL query to display the average employee salary by department and job title.
------------------------------------------------------------------------------------------------
select JobTitle, Name, AVG(Salary) as AverageSalary
from Employees e
join Departments d
	on e.DepartmentID = d.DepartmentID
group by JobTitle, Name
order by AverageSalary
------------------------------------------------------------------------------------------------

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
------------------------------------------------------------------------------------------------
select JobTitle, Name, MIN(Salary) as AverageSalary, MIN(FirstName)
from Employees e
join Departments d
	on e.DepartmentID = d.DepartmentID
group by JobTitle, Name
order by AverageSalary
------------------------------------------------------------------------------------------------

--27. Write a SQL query to display the town where maximal number of employees work.
------------------------------------------------------------------------------------------------
select top 1 t.Name, count(e.EmployeeID) as NumberOfEmployees
from Employees e
join Addresses a
	on e.AddressID = a.AddressID
join Towns t
	on t.TownID = a.TownID
group by t.Name
order by NumberOfEmployees desc
------------------------------------------------------------------------------------------------

--28. Write a SQL query to display the number of managers from each town.
------------------------------------------------------------------------------------------------
select t.Name, count(emp.ManagerID) as NumberOfManageres, count(emp.EmployeeID) as NumberOfEmployees
from Employees e 
join Addresses a
	on e.AddressID = a.AddressID
join Towns t
	on t.TownID = a.TownID
join Employees emp
	on e.ManagerID = emp.EmployeeID
group by t.Name 

--NEEDS TESTING
------------------------------------------------------------------------------------------------

--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
--Don't forget to define identity, primary key and appropriate foreign key. 
	--Issue few SQL statements to insert, update and delete of some data in the table.
	--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	--For each change keep the old record data, the new record data and the command (insert / update / delete).
	
------------------------------------------------------------------------------------------------
CREATE TABLE WorkHours(
EmployeeID int IDENTITY,
[Date] datetime,
Task nvarchar(50),
[Hours] int,
Comment nvarchar(50),
CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours(Date, Task, Hours)
VALUES
(getdate(), 'Sample Task1', 23),
(getdate(), 'Sample Task2', 3)

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Sample Task2'

CREATE TABLE WorkHoursLog(
Id int IDENTITY,
OldRecord nvarchar(100) NOT NULL,
NewRecord nvarchar(100) NOT NULL,
Command nvarchar(10) NOT NULL,
EmployeeId int NOT NULL,
CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)

ALTER TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values(' ',
(SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment
FROM Inserted),
'INSERT',
(SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
(SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Inserted),
'UPDATE',
(SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
' ',
'DELETE',
(SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours([Date], Task, Hours, Comment)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')

DELETE FROM WorkHours
WHERE Task = 'Random task3'

UPDATE WorkHours
SET Task = 'Random task12'
WHERE EmployeeID = 8


------------------------------------------------------------------------------------------------

--30. Start a database transaction, delete all employees from the 'Sales' department along with all 
--dependent records from the pother tables. At the end rollback the transaction.
------------------------------------------------------------------------------------------------
BEGIN TRAN

DELETE FROM Employees
FROM Departments
WHERE Name = 'Sales'

DELETE FROM Employees
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN
------------------------------------------------------------------------------------------------

--31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
------------------------------------------------------------------------------------------------
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN
------------------------------------------------------------------------------------------------

--32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
------------------------------------------------------------------------------------------------
CREATE TABLE #TemporaryTable(
EmployeeID int NOT NULL,
ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
SELECT EmployeeID, ProjectID
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
EmployeeID int NOT NULL,
ProjectID int NOT NULL,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable
------------------------------------------------------------------------------------------------