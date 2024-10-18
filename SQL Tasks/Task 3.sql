--1. Write a SQL query to Find the average account balance for all customers. 
select sum(balance)/ count(account_id) as average_balance
from Accounts

--2. Write a SQL query to Retrieve the top 10 highest account balances.
select top 10 account_id, balance
from Accounts
order by balance desc;

--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date
select sum(amount) as total_deposits
from Transactions
where transaction_type = 'deposit' 
AND transaction_date = '2024-09-16';

--4. Write a SQL query to Find the Oldest and Newest Customers.
-- Oldest customer
select top 1 customer_id, first_name, last_name, DOB
from Customers
order by DOB asc

-- Newest customer
select top 1 customer_id, first_name, last_name, DOB
from Customers
order by DOB desc

--5. Write a SQL query to Retrieve transaction details along with the account type.
select T.transaction_id, T.account_id, T.transaction_type, T.amount, T.transaction_date, A.account_type
from Transactions T
inner join Accounts A on T.account_id = A.account_id;

--6. Write a SQL query to Get a list of customers along with their account details
select C.customer_id, C.full_name, A.account_id, A.account_type, A.balance
from Customers C
inner join Accounts A on C.customer_id = A.customer_id;

--7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
select T.transaction_id, T.transaction_type, T.amount, T.transaction_date, C.full_name, C.email
from Transactions T
inner join Accounts A on T.account_id = A.account_id
inner join Customers C on A.customer_id = C.customer_id
where T.account_id = 107;

--8. Write a SQL query to Identify customers who have more than one account.
select C.customer_id, C.full_name, count(A.account_id) as account_count
from Customers C
inner join Accounts A on C.customer_id = A.customer_id
group by C.customer_id, C.full_name
having count(A.account_id) > 1;

--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
select  
(select SUM(amount) from Transactions where transaction_type = 'deposit') as Total_Deposit,  
(select SUM(amount) from Transactions where transaction_type = 'withdrawal') as Total_Withdrawal,
(select SUM(amount) from Transactions where transaction_type = 'deposit') - 
(select SUM(amount) from Transactions where transaction_type = 'withdrawal') as Difference

--10. Write a SQL query to Calculate the average daily balance for each account over a specified period.
select A.account_id, avg(T.amount) as Avg_Daily_Balance
from Accounts A
join Transactions T on A.account_id = T.account_id
where T.transaction_date between '2024-09-12' and '2024-09-21'
group by A.account_id

--11. Calculate the total balance for each account type.
select account_type, sum(balance) as total_balance
from Accounts
group by account_type;

--12. Identify accounts with the highest number of transactions order by descending order.
select account_id, count(transaction_id) as transaction_count
from Transactions
group by account_id
order by transaction_count desc;

--13.List customers with high aggregate account balances, along with their account types.
select C.customer_id, C.first_name, C.last_name, SUM(A.Balance) as Total_Balance
from Customers C
join Accounts A on C.customer_id = A.customer_id
group by C.customer_id, C.first_name, C.last_name
order by Total_Balance desc

--14. Identify and list duplicate transactions based on transaction amount, date, and account.
select account_id, amount, transaction_date, 
COUNT(*) as count_duplicates
from Transactions
group by account_id, amount, transaction_date
having COUNT(*) > 1
