create database Assessment
use Assessment

create table book (
    id int primary key,
    title varchar(50),
    author varchar(50),
    isbn varchar(13) unique,
    published_date datetime
);

insert into book (id, title, author, isbn, published_date)
values 
    (1, 'My First SQL Book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
    (2, 'My Second SQL Book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
    (3, 'My Third SQL Book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');
select * from book;

-- Write a query to fetch the details of the books written by author whose name ends with er.
select *
from book
where author like '%er';
---------------------------------------------------------------------------------------------

create table reviews (
    id int primary key,
    book_id int,
    reviewer_name varchar(100),
    content varchar(255),
    rating int,
    published_date datetime
);

insert into reviews (id, book_id, reviewer_name, content, rating, published_date)
values 
    (1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
    (2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
    (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

-- Display the Title ,Author and ReviewerName for all the books from the above table
select b.title, b.author, r.reviewer_name
from book b
join reviews r on b.id = r.book_id;

-- Display the reviewer name who reviewed more than one book.
select reviewer_name
from reviews
group by reviewer_name
having count(distinct book_id) > 1;
---------------------------------------------------------------------------------------------

create table customer (
    id int primary key,
    name varchar(50),
    age int,
    address varchar(100),
    salary decimal(10, 2)
);

insert into customer (id, name, age, address, salary)
values 
    (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
    (2, 'Khilan', 25, 'Delhi', 1500.00),
    (3, 'Kaushik', 23, 'Kota', 2000.00),
    (4, 'Chaitali', 25, 'Mumbai', 6500.00),
    (5, 'Hardik', 27, 'Bhopal', 8500.00),
    (6, 'Komal', 22, 'MP', 4500.00),
    (7, 'Muffy', 24, 'Indore', 10000.00);

-- Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select name
from customer
where address IN (
    select address
    from customer
    group by address
    having count(*) > 1
) and address like'%o%'; -- no one has same address
----------------------------------------------------------------------------------------
create table orders (
    oid int primary key,
    date datetime,
    cust_id int,
    amount decimal(10, 2)
);

insert into orders (oid, date, cust_id, amount)
values 
    (102, '2009-10-08 00:00:00', 3, 3000.00),
    (100, '2009-10-08 00:00:00', 3, 1500.00),
    (101, '2009-11-20 00:00:00', 2, 1560.00),
    (103, '2008-05-20 00:00:00', 4, 2060.00);
-- Write a query to display the Date,Total no of customer placed order on same Date
select date, count(distinct cust_id) as total_customers
from orders
group by date;

select count(distinct cust_id) as total_customers_per_date
from orders
group by date;
---------------------------------------------------------------------


create table emp(
    id int primary key,
    name varchar(50),
    age int,
    address varchar(100),
    salary decimal(10, 2) null
	);

insert into emp(id, name, age, address, salary)
values 
    (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
    (2, 'Khilan', 25, 'Delhi', 1500.00),
    (3, 'Kaushik', 23, 'Kota', 2000.00),
    (4, 'Chaitali', 25, 'Mumbai', 6500.00),
    (5, 'Hardik', 27, 'Bhopal', 8500.00),
    (6, 'Komal', 22, 'MP', null),
    (7, 'Muffy', 24, 'Indore', null);

-- Display employees name in lower case with null salary
select lower(name) as name, salary
from emp
where salary is null;
-------------------------------------------------------------------------------------------------

create table student (
    id int primary key,
    register_no int,
    name varchar(50),
    age int,
    qualification varchar(50),
    mobile_no varchar(15),
    mail_id varchar(50),
    location varchar(50),
    gender char(1)
);

insert into student (id, register_no, name, age, qualification, mobile_no, mail_id, location, gender)
values 
    (1, 2, 'sai', 22, 'B.E.', '9952836777', 'sai@gmail.com', 'Chennai', 'M'),
    (2, 3, 'kumar', 20, 'B.SC', '7890125648', 'kumar@gmail.com', 'Madurai', 'M'),
    (3, 4, 'selvi', 22, 'B.Tech', '8904567342', 'slevi@gmail.com', 'Salem', 'F'),
    (4, 5, 'nisha', 25, 'M.E', '7834672310', 'nisha@gmail.com', 'Theni', 'F'),
    (5, 6, 'sai saran', 21, 'B.A.', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
    (6, 7, 'tom', 23, 'BCA', '8901234675', 'tom@gmail.com', 'Pune', 'M');

-- Write a sql server query to display the Gender,Total no of male and female from the above relation
select gender, count(*) as total_ppl
from student
group by gender;
