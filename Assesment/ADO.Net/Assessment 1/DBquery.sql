Create database EmployeeeEngagement

use EmployeeeEngagement

create table EDetails (
    Eno int primary key,
    EName varchar(50) NOT NULL,
    ESal numeric(10,2) check (ESal >= 25000),
    EType char(1) check (EType IN ('P', 'C'))
);

select * from EDetails

create or alter proc AddEmployee
    @EName varchar(50),
    @ESal numeric(10,2),
    @EType char(1)
as
begin
    declare @Eno int;

    -- Generate Empno
    select @Eno = isnull(max(Eno), 0) + 1 from EDetails;

    -- Insert into table
    insert into EDetails (Eno, EName, ESal, EType)
    values (@Eno, @EName, @ESal, @EType);
end;
--checking proc
exec AddEmployee 'Deepti', 30000, 'P';
--exec AddEmployee 'Raghav', 29000, 'C';


select * from EDetails

--output
--1	Deepti	30000.00	P
--2	Deepak	28000.00	P
--3	Sunidhi	32000.00	C
--4	Rio	    26000.00	C
--5	Rudra	28000.00	C
--6	Dhriti	33000.00	P