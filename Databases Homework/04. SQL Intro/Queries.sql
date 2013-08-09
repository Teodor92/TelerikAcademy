--4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
-------------------------------------------------------------------
select * from Departments;
-------------------------------------------------------------------

--5. Write a SQL query to find all department names.
-------------------------------------------------------------------
select Name from Departments;
-------------------------------------------------------------------

--6. Write a SQL query to find the salary of each employee.
-------------------------------------------------------------------
select FirstName, Salary from Employees;
-------------------------------------------------------------------

--7. Write a SQL to find the full name of each employee.
-------------------------------------------------------------------
select FirstName + ' ' + LastName as FullName from Employees;
-------------------------------------------------------------------

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
-------------------------------------------------------------------
select FirstName + '.' + LastName + '@telerik.com' as FullEmailAddresses from Employees;
-------------------------------------------------------------------

--9. Write a SQL query to find all different employee salaries.
-------------------------------------------------------------------
select distinct Salary from Employees
order by Salary;
-------------------------------------------------------------------

--10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
-------------------------------------------------------------------
select * from Employees
where JobTitle = 'Sales Representative'
order by FirstName;
-------------------------------------------------------------------

--11. Write a SQL query to find the names of all employees whose first name starts with "SA".
-------------------------------------------------------------------
select FirstName + ' ' + LastName as FullName 
from Employees
where FirstName like 'sa%';
-------------------------------------------------------------------

--12. Write a SQL query to find the names of all employees whose last name contains "ei".
-------------------------------------------------------------------
select FirstName + ' ' + LastName as FullName 
from Employees
where LastName like '%ei%';
-------------------------------------------------------------------

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
-------------------------------------------------------------------
select FirstName, Salary 
from Employees
where Salary BETWEEN 20000 AND 30000
order by Salary;
-------------------------------------------------------------------

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
-------------------------------------------------------------------
select FirstName, Salary
from Employees
where Salary in (25000, 14000, 12500, 23600)
order by Salary;
-------------------------------------------------------------------

--15. Write a SQL query to find all employees that do not have manager.
-------------------------------------------------------------------
select FirstName, LastName, ManagerID
from Employees
where ManagerID is NULL
order by FirstName;
-------------------------------------------------------------------

--16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
-------------------------------------------------------------------
select FirstName, Salary
from Employees
where Salary > 50000
order by Salary desc;
-------------------------------------------------------------------

--17. Write a SQL query to find the top 5 best paid employees.
-------------------------------------------------------------------
select top 5 FirstName, Salary 
from Employees
order by Salary desc;
-------------------------------------------------------------------

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
-------------------------------------------------------------------
select e.FirstName, e.LastName, a.AddressText 
from Employees e inner join Addresses a
on e.AddressID = a.AddressID;
-------------------------------------------------------------------

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
-------------------------------------------------------------------
select e.FirstName, e.LastName, a.AddressText 
from Employees e, Addresses a
where e.AddressID = a.AddressID;
-------------------------------------------------------------------

--20. Write a SQL query to find all employees along with their manager.
-------------------------------------------------------------------
select a.FirstName as Subbordinate, e.FirstName as Boss
from Employees e, Employees a
where e.EmployeeID = a.ManagerID;
-------------------------------------------------------------------

--21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
-------------------------------------------------------------------
select m.FirstName as Subbordinate, e.FirstName as Boss, a.AddressText as SubbordinateAddress
from Employees e 
	join Employees m
	on e.EmployeeID = m.ManagerID
	join Addresses a
	on e.AddressID = a.AddressID;
-------------------------------------------------------------------

--22. Write a SQL query to find all departments and all region names, country names and city names as a single list. Use UNION.
-------------------------------------------------------------------
select Name as Name 
from Departments
union
select Name as Name 
from Towns
union 
select AddressText 
from Addresses
order by Name;
-------------------------------------------------------------------

--23. Write a SQL query to find all the employees and the manager for each of them along with the employees 
--that do not have manager. User right outer join. Rewrite the query to use left outer join.
-------------------------------------------------------------------
select a.FirstName as Subbordinate, e.FirstName as Boss
from Employees e full outer join Employees a
on e.EmployeeID = a.ManagerID;

select a.FirstName as Subbordinate, e.FirstName as Boss
from Employees e left outer join Employees a
on e.EmployeeID = a.ManagerID
order by e.FirstName;
-------------------------------------------------------------------

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2000.
-------------------------------------------------------------------
select e.FirstName + '' + e.LastName as FullName, e.HireDate, d.Name
from Employees e join Departments d
on e.DepartmentID = d.DepartmentID
where d.Name in ('Sales', 'Finance') and HireDate > '1995-01-19 00:00:00' and HireDate < '2005-01-19 00:00:00';
-------------------------------------------------------------------

