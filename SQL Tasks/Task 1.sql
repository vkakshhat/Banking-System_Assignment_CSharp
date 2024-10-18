create database HMBank

use HMBank

create table Customers (
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
DOB DATE,
email VARCHAR(50),
phone_number VARCHAR(10),
personal_address VARCHAR(255)
);

select * from Customers

create table Accounts (
account_id INT PRIMARY KEY,
customer_id INT,
account_type VARCHAR(20),
balance DECIMAL(10, 2),

FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)   
);

select * from Accounts

create table Transactions (
transaction_id INT PRIMARY KEY,
account_id INT,
transaction_type VARCHAR(50),
amount DECIMAL(10, 2),
transaction_date DATE,

FOREIGN KEY (account_id) REFERENCES Accounts(account_id)
);

select * from Transactions

