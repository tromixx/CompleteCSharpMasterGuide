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
-- Problem 2: Aggregates and GROUP BY
-- Problem 3: Joining Tables
-- Problem 4: Subqueries
-- Problem 5: Recursive Query and Transactions
