-- ========================
-- SQL Comprehensive Guide
-- ========================

-- ========================
-- Section 1: Introduction
-- ========================
-- USE DATABASE
USE sql_store;

-- ========================
-- Section 2: SQL Basics
-- ========================

-- SELECT Statement
SELECT last_name, points + 100 AS discount
FROM customers
WHERE state = 'VA';

-- Using WHERE with Logical Operators
SELECT last_name, points + 100 AS discount
FROM customers
WHERE birth_date > '1990-01-01' OR points > 1000;

-- Logical Operators: AND, OR, NOT, IN
SELECT *
FROM customers
WHERE (country = 'USA' OR country = 'Canada')  -- OR Operator
  AND age > 25                                  -- AND Operator
  AND NOT city = 'New York'                     -- NOT Operator
  AND discount_rate IN (5, 10, 15)              -- IN Operator
ORDER BY name ASC;                              -- ORDER BY Operator

-- IN Operator
SELECT last_name, points + 100 AS discount
FROM customers
WHERE state IN ('GA', 'VA');

-- BETWEEN Operator
SELECT last_name, points + 100 AS discount
FROM customers
WHERE points BETWEEN 1000 AND 3000;

-- LIKE Operator
SELECT last_name, points + 100 AS discount
FROM customers
WHERE last_name LIKE 'b%' OR last_name LIKE 'b____y';

-- REGEXP Operator
SELECT last_name, points + 100 AS discount
FROM customers
WHERE last_name REGEXP '[a-h]e';

-- ORDER BY Clause
SELECT last_name, points + 100 AS discount
FROM customers
ORDER BY discount;

-- LIMIT Clause
SELECT last_name, points + 100 AS discount
FROM customers
LIMIT 300;

-- ==============================
-- Section 3: Database Modeling
-- ==============================

-- Entity Relationship Example: Inner Join
SELECT order_id, o.customer_id, first_name
FROM orders o
JOIN customers c
    ON o.customer_id = c.customer_id;

-- Joining Multiple Tables
SELECT p.date, p.invoice_id, c.name AS client_name, pm.name AS payment_method
FROM payments p
JOIN clients c
    ON p.client_id = c.client_id
JOIN payment_methods pm
    ON p.payment_method = pm.payment_method_id;

-- LEFT JOIN Example
SELECT c.customer_name, o.order_date
FROM customers c
LEFT JOIN orders o ON c.customer_id = o.customer_id;

-- Using USING to Replace ON
SELECT *
FROM orders o
JOIN customers c
    USING (customer_id);

-- UNION Example
SELECT name AS full_name
FROM shippers
UNION
SELECT first_name
FROM customers;

-- ========================
-- Section 4: CRUD Queries
-- ========================

-- INSERT Statement
INSERT INTO customers
VALUES 
(DEFAULT, 'John', 'Smith', '1990-01-01', NULL, 'address', 'city', 'CA', DEFAULT);

-- UPDATE Statement
UPDATE invoices
SET payment_total = 10, payment_date = '2019-03-01'
WHERE invoice_id = 1;

-- DELETE Statement
DELETE FROM invoices
WHERE invoice_id = 1;

-- ========================
-- Section 5: Advanced SQL
-- ========================

-- Subqueries in WHERE Clause
UPDATE invoices
SET payment_total = 10, payment_date = '2019-03-01'
WHERE client_id IN (
    SELECT client_id
    FROM clients
    WHERE state IN ('CA', 'NY')
);

-- Aggregate Functions (MAX, MIN, AVG, SUM, COUNT)
SELECT MAX(invoice_total) AS highest_total
FROM invoices;

-- GROUP BY with Aggregate Functions
SELECT client_id, SUM(invoice_total) AS total_sales
FROM invoices
GROUP BY client_id;

-- GROUP BY with ROLLUP
SELECT client_id, SUM(invoice_total) AS total_sales
FROM invoices
GROUP BY client_id WITH ROLLUP;

-- Window Functions
SELECT first_name, salary, RANK() OVER (ORDER BY salary DESC) AS rank
FROM employees;

-- Recursive Query
WITH RecursiveCTE AS (
    SELECT employee_id, manager_id
    FROM employees
    WHERE manager_id IS NULL
    UNION ALL
    SELECT e.employee_id, e.manager_id
    FROM employees e
    JOIN RecursiveCTE r ON e.manager_id = r.employee_id
)
SELECT * FROM RecursiveCTE;

-- ================================
-- Section 6: Indexes and Views
-- ================================

-- Index Example
CREATE INDEX idx_employee_name ON Employees (first_name, last_name);

-- Create a View
CREATE VIEW important_query AS
SELECT SUM(invoice_total) AS total_sales
FROM invoices;

-- ================================
-- Section 7: Stored Procedures
-- ================================

-- Create a Stored Procedure
CREATE PROCEDURE GetEmployeeDetails
AS
BEGIN
    SELECT first_name, last_name FROM employees;
END;

-- Stored Procedure with Parameters
CREATE PROCEDURE GetEmployeeByID
    @EmployeeID INT
AS
BEGIN
    SELECT * FROM employees WHERE id = @EmployeeID;
END;

-- ================================
-- Section 8: T-SQL and Optimization
-- ================================

-- Common Table Expression (CTE) with Aggregates
WITH TopSellingProductsByCategory AS (
    SELECT category_id, product_id, SUM(quantity) AS total_sold
    FROM order_items
    GROUP BY category_id, product_id
    ORDER BY category_id, total_sold DESC
    LIMIT 3
)
SELECT c.category_name, p.product_name, topsales.total_sold
FROM categories c
INNER JOIN TopSellingProductsByCategory topsales ON c.category_id = topsales.category_id
INNER JOIN products p ON topsales.product_id = p.product_id;

-- Execution Plan Analysis
SET STATISTICS TIME ON;
SELECT * FROM customers;

-- Dynamic SQL
DECLARE @sql NVARCHAR(MAX) = 'SELECT * FROM customers WHERE state = ''CA''';
EXEC sp_executesql @sql;

-- ================================
-- Section 9: Security and Functions
-- ================================

-- Full-Text Search
SELECT * 
FROM documents 
WHERE CONTAINS(content, 'SQL');

-- User-Defined Function (UDF)
CREATE FUNCTION GetDiscountedPrice (@price DECIMAL, @discount DECIMAL)
RETURNS DECIMAL
AS
BEGIN
    RETURN @price - (@price * @discount / 100);
END;

-- Example Usage of Function
SELECT dbo.GetDiscountedPrice(100, 10) AS DiscountedPrice;

-- ================================
-- Section 10: Problems
-- ================================

-- Problem 1: Basic Query
-- Retrieve the names and email addresses of customers from the customers table 
-- who live in the state of 'CA'. Sort the results alphabetically by last_name.
SELECT first_name, last_name, email
FROM customers
WHERE state = 'CA'
ORDER BY last_name;

-- Problem 2: Aggregates and GROUP BY
-- Find the total number of orders and the average order amount for each customer. 
-- Only include customers who have placed more than 2 orders.
SELECT customer_id, COUNT(order_id) AS total_orders, AVG(order_total) AS avg_order_amount
FROM orders
GROUP BY customer_id
HAVING COUNT(order_id) > 2;

-- Problem 3: Joining Tables
-- Retrieve the names of customers and the names of products they ordered. 
-- Include only customers who have placed at least one order.
SELECT c.first_name, c.last_name, p.name AS product_name
FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
JOIN order_items oi ON o.order_id = oi.order_id
JOIN products p ON oi.product_id = p.product_id;

-- Problem 4: Subqueries
-- Find the names of customers who have spent more than the average total order amount across all customers.
SELECT first_name, last_name
FROM customers c
WHERE customer_id IN (
    SELECT customer_id
    FROM orders
    GROUP BY customer_id
    HAVING SUM(order_total) > (
        SELECT AVG(order_total)
        FROM orders
    )
);

-- Problem 5: T-SQL with CTE and Transactions
-- Create a stored procedure that increases the price of all products in a specific category by 10%.
-- The category name should be passed as a parameter.
CREATE PROCEDURE IncreaseProductPrices
    @CategoryName NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE p
        SET p.price = p.price * 1.10
        FROM products p
        JOIN categories c ON p.category_id = c.category_id
        WHERE c.name = @CategoryName;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH;
END;

-- Usage Example:
EXEC IncreaseProductPrices @CategoryName = 'Electronics';

-- Bonus Problem: Recursive Query
-- Using a WITH clause, retrieve a hierarchy of employees starting from the CEO 
-- (who has manager_id = NULL). Display their name and level in the hierarchy.
WITH EmployeeHierarchy AS (
    SELECT employee_id, first_name, last_name, manager_id, 0 AS level
    FROM employees
    WHERE manager_id IS NULL
    UNION ALL
    SELECT e.employee_id, e.first_name, e.last_name, e.manager_id, eh.level + 1
    FROM employees e
    JOIN EmployeeHierarchy eh ON e.manager_id = eh.employee_id
)
SELECT first_name, last_name, level
FROM EmployeeHierarchy
ORDER BY level, first_name;

-- Problem 6: Full-Text Search and Pattern Matching
-- Find all products where the name contains the word 'Laptop' using full-text search.
SELECT * 
FROM products
WHERE CONTAINS(product_name, 'Laptop');

-- Problem 7: Using Window Functions
-- Retrieve the top 5 highest-paid employees along with their rank.
SELECT first_name, last_name, salary, RANK() OVER (ORDER BY salary DESC) AS rank
FROM employees
ORDER BY rank
LIMIT 5;

-- Problem 8: Working with Date and Time Functions
-- Retrieve all orders placed in the last 30 days and their total amounts.
SELECT order_id, order_date, total_amount
FROM orders
WHERE order_date >= CURDATE() - INTERVAL 30 DAY;

-- Problem 9: Handling NULLs in Queries
-- Retrieve the first name, last name, and discount for customers who have a discount, 
-- or show "No discount" for those who do not.
SELECT first_name, last_name, 
       COALESCE(discount, 'No discount') AS discount_status
FROM customers;

-- Problem 10: Advanced Joins with Multiple Tables
-- Find all customers who have placed orders with a total greater than 100, 
-- and list the product names they purchased, including the order date.
SELECT c.first_name, c.last_name, p.name AS product_name, o.order_date
FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
JOIN order_items oi ON o.order_id = oi.order_id
JOIN products p ON oi.product_id = p.product_id
WHERE o.total_amount > 100;

-- Problem 11: Using HAVING with Aggregate Functions
-- Find the customers who have placed more than 3 orders and their total spending.
SELECT c.first_name, c.last_name, COUNT(o.order_id) AS total_orders, SUM(o.total_amount) AS total_spent
FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
GROUP BY c.customer_id
HAVING COUNT(o.order_id) > 3;

-- Problem 12: Case Statement Example
-- Retrieve the status of orders: If the order total is above $500, label it as "High Value", 
-- otherwise label it as "Low Value".
SELECT order_id, total_amount, 
       CASE 
           WHEN total_amount > 500 THEN 'High Value'
           ELSE 'Low Value'
       END AS order_status
FROM orders;

-- Problem 13: Index Optimization
-- Create a non-clustered index on the 'email' column to speed up email searches.
CREATE NONCLUSTERED INDEX idx_email ON customers (email);

-- Problem 14: Partitioned Tables Example
-- Partition the orders table by the order_date, so that each partition contains orders from a particular year.
CREATE PARTITION FUNCTION orderDatePartition (DATE)
AS RANGE RIGHT FOR VALUES ('2020-01-01', '2021-01-01', '2022-01-01');

-- Partitioned Table Example
CREATE PARTITION SCHEME orderDateScheme
AS PARTITION orderDatePartition
TO (Orders2020, Orders2021, Orders2022);

-- Problem 15: Row-Level Security
-- Restrict access to orders such that only customers can see their own orders.
CREATE SECURITY POLICY OrderAccessPolicy
WITH (STATE = ON)
AS
ADD FILTER PREDICATE dbo.FilterPredicate(customer_id)
ON dbo.orders;

-- ================================
-- Additional Practice Problems
-- ================================

-- Problem 16: String Manipulation
-- Write a query to concatenate the first name and last name of customers and format them as "Last, First".
SELECT CONCAT(last_name, ', ', first_name) AS full_name
FROM customers;

-- Problem 17: Complex Join with Multiple Conditions
-- Retrieve all employees along with their department and manager names, showing only employees who have managers.
SELECT e.first_name AS employee_name, d.department_name, m.first_name AS manager_name
FROM employees e
JOIN departments d ON e.department_id = d.department_id
LEFT JOIN employees m ON e.manager_id = m.employee_id;

-- Problem 18: Calculating the Average Product Price
-- Retrieve the average price of products in each category.
SELECT c.category_name, AVG(p.price) AS average_price
FROM products p
JOIN categories c ON p.category_id = c.category_id
GROUP BY c.category_name;


