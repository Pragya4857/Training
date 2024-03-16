use practice
-- Create EMP table
create table EMP (
    EMPNO int primary key,
    ENAME varchar(50),
    JOB varchar(50),
    MGR_ID int,
    HIREDATE date,
    SAL decimal(10, 2),
    COMM decimal(10, 2),
    DEPTNO int
);

-- Create DEPT table
create table DEPT (
    DEPTNO int primary key,
    DNAME varchar(50),
    LOC varchar(50)
);

-- Insert data into EMP table
insert into EMP (EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO)
values
    (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
    (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
    (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
    (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
    (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
    (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
    (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
    (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
    (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
    (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
    (7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
    (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
    (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
    (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

-- Insert data into DEPT table
insert into DEPT (DEPTNO, DNAME, LOC)
values
    (10, 'ACCOUNTING', 'NEW YORK'),
    (20, 'RESEARCH', 'DALLAS'),
    (30, 'SALES', 'CHICAGO'),
    (40, 'OPERATIONS', 'BOSTON');

-- Query 1: List all employees whose name begins with 'A'
select * from EMP where ENAME like 'a%';

-- Query 2: Select all those employees who don't have a manager
select * from EMP where MGR_ID is null;

-- Query 3: List employee name, number, and salary for those employees who earn in the range 1200 to 1400
select ENAME, EMPNO, SAL from EMP where SAL between 1200 and 1400;

-- Query 4: Give all the employees in the RESEARCH department a 10% pay rise
update EMP set SAL = SAL * 1.1 where DEPTNO = 20;
--select sal from emp
-- Query 5: Verify the pay rise for employees in the RESEARCH department
select* from EMP where DEPTNO = 20;

-- Query 6: Find the number of CLERKS employed
select count(*) as "Number of Clerks Employed" from EMP where JOB = 'CLERK';

-- Query 7: Find the average salary for each job type and the number of people employed in each job
select JOB,avg(SAL) as "Average Salary", count(*) as "Number of Employees" from EMP group by JOB;

-- Query 8: List the employees with the lowest and highest salary
select * from EMP where SAL in (select min(SAL) from EMP) or SAL in (select max(SAL) from EMP);

-- Query 9: List full details of departments that don't have any employees
select * from DEPT where DEPTNO not in (select distinct DEPTNO from EMP);

-- Query 10: Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name
select ENAME, SAL from EMP where JOB = 'ANALYST' and SAL > 1200 and DEPTNO = 20 order by ENAME asc;

-- Query 11: For each department, list its name and number together with the total salary paid to employees in that department
select D.DNAME, D.DEPTNO, sum(E.SAL) as "Total Salary" from DEPT D left join EMP E ON D.DEPTNO = E.DEPTNO group by D.DNAME, D.DEPTNO;

-- Query 12: Find out the salary of both MILLER and SMITH
select ENAME, SAL from EMP where ENAME in ('MILLER', 'SMITH');

-- Query 13: Find out the names of the employees whose name begins with ‘A’ or ‘M’
select * from EMP where ENAME like 'a%' or ENAME like 'm%';

-- Query 14: Compute yearly salary of SMITH
select ENAME, SAL * 12 as "Yearly Salary" from EMP where ENAME = 'SMITH';

-- Query 15: List the name and salary for all employees whose salary is not in the range of 1500 and 2850
select ENAME, SAL from EMP where SAL not between 1500 and 2850;
