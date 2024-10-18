--1. Retrieve the customer(s) with the highest account balance.
select first_name,last_name,balance
from Customers c
join 
Accounts a on c.customer_id = a.customer_id
where balance = (select MAX(balance) from Accounts)

--2.Calculate the average account balance for customers who have more than one account.
select customer_id,
AVG(balance) as average_balance
from Accounts
group by customer_id
having COUNT(account_id) > 1

--3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
select account_id,transaction_id, amount
from Transactions
where amount > (select AVG(amount) from Transactions)

--4. Identify customers who have no recorded transactions.
select customer_id,first_name,last_name
from Customers c
where not exists (SELECT 1 FROM Accounts a 
join Transactions t ON a.account_id = t.account_id WHERE a.customer_id = c.customer_id)

--5. Calculate the total balance of accounts with no recorded transactions.
select SUM(balance) as total_balance_no_transactions
from Accounts a
where not exists (select 1 from Transactions t where t.account_id = a.account_id)

--6. Retrieve transactions for accounts with the lowest balance.
select transaction_id, account_id, amount, transaction_date
from Transactions
where account_id IN (select account_id from Accounts 
where balance = (SELECT MIN(balance) FROM Accounts))

--7. Identify customers who have accounts of multiple types.
select customer_id,first_name,last_name
from Customers c
where customer_id in (select customer_id 
from Accounts group by customer_id having COUNT(distinct account_type) > 1)

--8.Calculate the percentage of each account type out of the total number of accounts.
select account_type, COUNT(*) * 100.0 / (select COUNT(*) from Accounts) as percentage
from Accounts
group by account_type

--9.Retrieve all transactions for a customer with a given customer_id.
select t.transaction_id, t.account_id, t.amount, t.transaction_date
from Transactions t
join 
Accounts a on t.account_id = a.account_id
where a.customer_id = 7

--10. Calculate the total balance for each account type, including a subquery within the SELECT clause
select account_type, (select SUM(balance) 
from Accounts a2 
where a2.account_type = a.account_type) as total_balance
from Accounts a
group by account_type
