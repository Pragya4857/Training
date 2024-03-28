use assignment


--1. Write a query to display your birthday( day of week)
select datename(weekday, '2001-08-18') as weekday;
--output : Saturday

--2. Write a query to display your age in days
select datediff(day, '2001-08-18', getdate()) as age;
--output : 8258

--3.	Write a query to display all employees information those who joined before 5 years in the current month
 
--(Hint : If required update some HireDates in your EMP table of the assignment) 

create table emp2 (
    EmployeeID int primary key,
    Name varchar(50),
    HireDate date
);

insert into emp2 (EmployeeID, Name, HireDate) values
(1, 'Suneeta', '2017-03-15'),
(2, 'Ayush', '2016-09-25'),
(3, 'Muskan', '2018-11-10'),
(4, 'Rosy', '2019-02-28'),
(5, 'Shrishti', '2017-08-05');
select *
from emp2
where datediff(year, HireDate, getdate()) >= 5
and month(HireDate) = month(getdate());
--output : 1 suneeta	2017-03-15
--Only suneeta satisfies both conditions. shrishti was not hired in March, so she doesn't meet the second condition. Therefore, only suneeta will be returned by the query.

--4.Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction
	--a. First insert 3 rows 
	--b. Update the second row sal with 15% increment  
    -- c. Delete first row.
--After completing above all actions how to recall the deleted row without losing increment of second row.

create table emp1(
    empno int primary key,
    ename varchar(50),
    sal decimal(10, 2),
    doj date
);

begin transaction;

-- a: Insert 3 rows
insert into emp1 (empno, ename, sal, doj)
values
(1, 'Prithvi', 50000.00, '2018-05-10'),
(2, 'Smita', 60000.00, '2019-02-15'),
(3, 'Tanya', 55000.00, '2020-09-20');

-- b: Update the second row salary with a 15% increment
update emp1
set sal = sal * 1.15
where empno = 2;

-- c: Delete the first row
delete from emp1
where empno = 1;
--output :
--         2	Smita	69000.00	2019-02-15
--         3	Tanya	55000.00	2020-09-20


-- Step to recall the deleted row: Re-insert the deleted row with the incremented salary
insert into emp1 (empno, ename, sal, doj)
values (1, 'Prithvi', 57500.00, '2018-05-10');

commit transaction;
select * from emp1
--output : 1	Prithvi	57500.00	2018-05-10
--         2	Smita	69000.00	2019-02-15
--         3	Tanya	55000.00	2020-09-20

-- 5. Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus

create function calcbon (@job varchar(50), @deptno int, @sal decimal(10, 2))
returns decimal(10, 2)
as
begin
    declare @bonus decimal(10, 2);

    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;

    return @bonus;
end;

select dbo.calcbon('manager', 10, 2450) as Bonus; -- we can also use declare method.
--output : 367.50
