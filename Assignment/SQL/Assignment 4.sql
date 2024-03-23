use assignment
--------------------------------------------------------------------------------------------
-- 1 T-SQL Program to find the factorial of a given number
create or alter proc calcfact
    @num int,
    @fact bigint output
as
begin
    declare @cnt int = 1
    set @fact = 1

    while @cnt <= @num
    begin
        set @fact = @fact * @cnt
        set @cnt = @cnt + 1
    end
end
declare @inputnum int = 7
declare @resultfact bigint
exec calcfact @inputnum, @resultfact output
select @resultfact as factorial
--------------------------------------------------------------------------------------------------------
--2 Stored procedure to generate multiplication tables up to a given number
create or alter proc generatemultitab
    @maxnum int
as
begin
    declare @currnum int = 1

    while @currnum <= @maxnum
    begin
        declare @count int = 1

        while @count <= 10
        begin
            print cast(@currnum as varchar) + ' * ' + cast(@count as varchar) + ' = ' + cast(@currnum * @count as varchar)
            set @count= @count + 1
        end

        print '------------------------'
        set @currnum = @currnum + 1
    end
end
exec generatemultitab 7
------------------------------------------------------------------------------------------------------
--3.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manupulate" etc

--Note: Create holiday table as (holiday_date,Holiday_name) store at least 4 holiday details. try to match and stop manipulation 
create table holiday (
    holiday_date date primary key,
    holiday_name varchar(100)
);

insert into holiday (holiday_date, holiday_name) values
('2024-01-26', 'Independence Day'),
('2024-10-27', 'Diwali'),
('2024-12-25', 'Christmas');

create table emp (
    emp_id int primary key,
    emp_name varchar(100),
    emp_salary decimal(10, 2)
);

create or alter trigger restrict_holiday_manipulation
on emp
after insert, update, delete
as
begin
    declare @HolidayName varchar(100);

    select @HolidayName = holiday_name 
    from holiday 
    where holiday_date = convert(date, getdate());

    if @HolidayName is not null
    begin
        raiserror('Due to %s, you cannot manipulate data', 16, 1, @HolidayName) with nowait;
        rollback transaction; 
    end
end;
--before updation of date
insert into emp (emp_id, emp_name, emp_salary)
values (1, 'Dhriti', 50000.00);
delete from emp
where emp_id = 1;

insert into holiday (holiday_date, holiday_name) 
values (GETDATE(), 'Custom Holiday');
--after updation of date
insert into emp (emp_id, emp_name, emp_salary)
values (1, 'Dhriti', 50000.00);
delete from emp
where emp_id = 1;

