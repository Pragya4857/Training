use assignment

create table employee (
    employeeid int primary key,
    name nvarchar(100),
    salary decimal(18, 2)
);

insert into employee (employeeid, name, salary) values
(1, 'Rekha', 50000.00),
(2, 'Rosy', 60000.00),
(3, 'Rudra', 70000.00);

create or alter proc genpayslip 
    @employeeid int
as
begin
    declare @hra decimal(18, 2), @da decimal(18, 2), @pf decimal(18, 2), @it decimal(18, 2)

    select @hra = salary * 0.10, @da = salary * 0.20, @pf = salary * 0.08, @it = salary * 0.05
    from employee
    where employeeid = @employeeid

    select 
        'Employee ID: ' + cast(@employeeid as nvarchar(10)) as [Item],
        'Name: ' + name as [Name],
        'Salary: ' + cast(salary as nvarchar(50)) as [Salary],
        'HRA: ' + cast(@hra as nvarchar(50)) as [HRA],
        'DA: ' + cast(@da as nvarchar(50)) as [DA],
        'PF: ' + cast(@pf as nvarchar(50)) as [PF],
        'IT: ' + cast(@it as nvarchar(50)) as [IT],
        'Deductions: ' + cast((@pf + @it) as nvarchar(50)) as [Deduct],
        'Gross Salary: ' + cast((salary + @hra + @da) as nvarchar(50)) as [GS],
        'Net Salary: ' + cast((salary + @hra + @da - (@pf + @it)) as nvarchar(50)) as [NS]
    from employee
    where employeeid = @employeeid
end;


exec genpayslip @employeeid = 1;
exec genpayslip @employeeid = 2;
exec genpayslip @employeeid = 3;

