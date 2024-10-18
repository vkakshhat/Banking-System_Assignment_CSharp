--1. Insert at least 10 sample records into each of the following tables. 
--Customers
--Accounts
--Transactions

INSERT INTO Customers (customer_id, first_name, last_name, DOB, email, phone_number, personal_address) 
VALUES
(1, 'Akash', 'Verma', '1987-06-12', 'akash.verma@email.com', '9876543210', '12B Green Park, Delhi'),
(2, 'Megha', 'Sharma', '1992-05-18', 'megha.sharma@email.com', '8765432109', '45A Lajpat Nagar, Mumbai'),
(3, 'Vikram', 'Singh', '1984-03-22', 'vikram.singh@email.com', '7654321098', '78C Juhu Beach, Mumbai'),
(4, 'Radhika', 'Rao', '1990-10-10', 'radhika.rao@email.com', '6543210987', '90D Banjara Hills, Hyderabad'),
(5, 'Anil', 'Nair', '1985-09-05', 'anil.nair@email.com', '5432109876', '12E Marine Drive, Kochi'),
(6, 'Priya', 'Patel', '1994-07-15', 'priya.patel@email.com', '4321098765', '33F Koregaon Park, Pune'),
(7, 'Suresh', 'Gupta', '1989-12-20', 'suresh.gupta@email.com', '3210987654', '99G Gandhi Nagar, Ahmedabad'),
(8, 'Neha', 'Khan', '1991-11-29', 'neha.khan@email.com', '2109876543', '66H Sector 10, Noida'),
(9, 'Rahul', 'Kapoor', '1982-01-17', 'rahul.kapoor@email.com', '1098765432', '55I Malviya Nagar, Jaipur'),
(10, 'Divya', 'Iyer', '1996-02-26', 'divya.iyer@email.com', '0987654321', '77J Nungambakkam, Chennai');

select * from customers;

insert into Accounts (account_id, customer_id, account_type, balance) 
values
(101, 1, 'savings', 2500.00),
(102, 2, 'current', 4000.75),
(103, 3, 'zero_balance', 0.00),
(104, 4, 'savings', 5000.50),
(105, 5, 'current', 320.00),
(106, 6, 'savings', 10000.00),
(107, 7, 'zero_balance', 0.00),
(108, 8, 'current', 155.50),
(109, 9, 'savings', 7500.00),
(110, 10, 'current', 708.25);

select * from accounts;

insert into Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) 
values
(1001, 101, 'deposit', 1500.00, '2024-09-12'),
(1002, 102, 'withdrawal', 500.75, '2024-09-13'),
(1003, 103, 'deposit', 3000.00, '2024-09-14'),
(1004, 104, 'transfer', 800.50, '2024-09-15'),
(1005, 105, 'deposit', 2000.00, '2024-09-16'),
(1006, 106, 'withdrawal', 1500.00, '2024-09-17'),
(1007, 107, 'deposit', 2500.00, '2024-09-18'),
(1008, 108, 'withdrawal', 700.50, '2024-09-19'),
(1009, 109, 'transfer', 1000.00, '2024-09-20'),
(1010, 110, 'deposit', 500.25, '2024-09-21');

select * from transactions;

--2.Write SQL queries for the following tasks:

--1. Write a SQL query to retrieve the name, account type and email of all customers.
select c.first_name, c.last_name, a.account_type, c.email
from Customers c
JOIN 
    Accounts a on c.customer_id = a.customer_id

--2. Write a SQL query to list all transaction corresponding customer.
select c.customer_id,c.first_name,c.last_name,t.transaction_id,t.account_id, t.transaction_type, t.amount,
    t.transaction_date
from Customers c
join Accounts a ON c.customer_id = a.customer_id
join Transactions t ON a.account_id = t.account_id;

--3. Write a SQL query to increase the balance of a specific account by a certain amount.
update Accounts
set balance = balance+500
where account_id = 101

--4. Write a SQL query to Combine first and last names of customers as a full_name.
alter table Customers
add full_name varchar(100);

update Customers
set full_name = first_name + ' ' + last_name;

--5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.
delete from Accounts
where balance=0 
and account_type='savings'

--6. Write a SQL query to Find customers living in a specific city.
select customer_id, full_name, personal_address
from Customers
where personal_address like '%Mumbai%';

--7. Write a SQL query to Get the account balance for a specific account.
select Accounts.account_id, Accounts.balance
from Accounts
where customer_id=4;

--8. Write a SQL query to List all current accounts with a balance greater than $1,000.
select account_id
from Accounts
where accounts.balance > 1000

--9. Write a SQL query to Retrieve all transactions for a specific account.
select transaction_id, transaction_type, amount, transaction_date
from Transactions
where account_id = 106

select transaction_id, account_id, transaction_type, amount, transaction_date
from Transactions
where account_id in (106, 102)

--10. Write a SQL query to Calculate the interest accured on savings accounts based on a given interest rate
select account_id,balance,(balance * 5/100) as interest_accured
from Accounts
where account_type = 'savings'

--11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit
select account_id,customer_id,account_type, balance
from Accounts
where balance < -500;

--12. Write a SQL query to Find customers not living in a specific city.
select customer_id, full_name, personal_address
from Customers
where personal_address not like '%Mumbai%'