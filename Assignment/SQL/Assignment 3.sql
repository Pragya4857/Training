use assignment
-- 1. Retrieve a list of MANAGERS
select * from EMP where JOB = 'MANAGER';
--2. Find out the names and salaries of all employees earning more than 1000 per month
select ENAME, SAL from EMP where SAL > 1000;
--3. Display the names and salaries of all employees except JAMES
select ENAME, SAL from EMP where ENAME != 'JAMES';
--select * from EMP
--4. Find out the details of employees whose names begin with ‘S’
select * from EMP where ENAME like 's%';
--5. Find out the names of all employees that have ‘A’ anywhere in their name
select ENAME from EMP where ENAME like '%a%';
--6. Find out the names of all employees that have ‘L’ as their third character in their name
select ENAME from EMP where ENAME LIKE '__l%';
--7. Compute daily salary of JONES
select ENAME, SAL / 30 as "Daily Salary" from EMP where ENAME = 'JONES';

--8. Calculate the total monthly salary of all employees
select sum(SAL) as "Total Monthly Salary" from EMP;
--9. Print the average annual salary
select avg(SAL) * 12 as "Average Annual Salary" from EMP;

--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30
select ENAME, JOB, SAL, DEPTNO from EMP where DEPTNO = 30 and JOB != 'SALESMAN';

--11. List unique departments of the EMP table
select distinct DEPTNO from EMP;

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ENAME as "Employee", SAL as "Monthly Salary" from EMP where SAL > 1500 and (DEPTNO = 10 or DEPTNO = 30);

--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000
select ENAME, JOB, SAL from EMP where (JOB = 'MANAGER' or JOB = 'ANALYST') and SAL not in (1000, 3000, 5000);

--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%
select ENAME, SAL, COMM from EMP where COMM > SAL * 0.1;
--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782
select ENAME from EMP where (ENAME like '%l%l%' and DEPTNO = 30) or MGR_ID = 7782;
--16. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
select ENAME from EMP where year(Getdate()) - year(HIREDATE) between 30 and 40;
select count(*) as TotalEmployees 
from EMP 
where year(getdate()) - year(HIREDATE) between 30 and 40;
--17. Retrieve the names of departments in ascending order and their employees in descending order
select D.DNAME, E.ENAME 
from DEPT D 
LEFT JOIN EMP E on D.DEPTNO = E.DEPTNO 
order by D.DNAME asc, E.ENAME desc;
--18. Find out experience of MILLER. 
select datediff(year, HIREDATE, getdate()) as Experience
from EMP 
where ENAME = 'MILLER';






