Create Database TheWatsonTest

use TheWatsonTest

create table Email (
	EmployeeID int not null,
	Address varchar(60) not null
	)
create table Employee (
	EmployeeID int not null,
	Name varchar(60) not null,
	Salary int not null,
	DepartmentId int not null
	)
create table Department (
	DepartmentId int not null,
	Name varchar(60) not null
	)

insert into Email (EmployeeID, Address)
values	(1, 'bob.smith@somewhere.com'),
		(2, 'erik.stansell@somewhere.com'),
		(3, 'jill.brown@somewhere.com'),
		(4, 'bob.smith@somewhere.com')
select * from Email

insert into Employee (EmployeeID, Name, Salary, DepartmentId)
values	(1, 'Erik', 85000, 1),
		(2, 'Jill', 95000, 1),
		(3, 'Bob', 76000, 2),
		(4, 'Emily', 76000, 2),
		(5, 'Sam', 75000, 2)
select * from Employee

insert into Department (DepartmentId, Name)
values	(1, 'Sales'),
		(2, 'Marketing')
select * from Department

-- Duplicate Email Addresses --
select Address from Email
group by Address 
having count(Address) > 1 

-- Department Highest Salaries --
select	Department.Name as 'Department',
		Employee.Name as 'Employee',
		Salary 
from Employee
join Department on Department.DepartmentId = Employee.DepartmentId
where Employee.Salary In (
		select max(Salary)
		from Employee
		group by DepartmentId)
Order by Employee.Salary desc
