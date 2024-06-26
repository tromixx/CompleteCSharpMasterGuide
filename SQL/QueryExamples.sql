/* Simple query with AND, OR, Not, IN Y ORDER BY */
SELECT *
FROM customers
WHERE (country = 'USA' OR country = 'Canada')  -- OR Operator
  AND age > 25                                  -- AND Operator
  AND NOT city = 'New York'                       -- NOT Operator
  AND discount_rate IN (5, 10, 15)                -- IN Operator
ORDER BY name ASC;                               -- ORDER BY Operator


/* Medium query with Inner Join and Outer Join */

-- Sample tables (assuming these tables exist in your database)
CREATE TABLE IF NOT EXISTS Orders (
  order_id INT PRIMARY KEY,
  customer_id INT,
  order_date DATE
);

CREATE TABLE IF NOT EXISTS Customers (
  customer_id INT PRIMARY KEY,
  customer_name VARCHAR(255)
);

-- Insert some sample data (assuming you have a way to insert data into your tables)
INSERT INTO Orders (customer_id, order_date) VALUES (1, '2024-01-01'), (2, '2024-02-14'), (3, '2024-03-15');
INSERT INTO Customers (customer_id, customer_name) VALUES (1, 'John Doe'), (2, 'Jane Smith');

-- Inner Join: Only customers with orders
SELECT o.order_id, o.order_date, c.customer_name
FROM Orders o
INNER JOIN Customers c ON o.customer_id = c.customer_id;

-- Left Join: All customers, even those without orders
SELECT o.order_id, o.order_date, c.customer_name
FROM Customers c
LEFT JOIN Orders o ON o.customer_id = c.customer_id;


/* Hard query with other stuff */

WITH TopSellingProductsByCategory AS (
  -- Subquery to find top 3 selling products in each category
  SELECT category_id, product_id, SUM(quantity) AS total_sold
  FROM order_items
  GROUP BY category_id, product_id
  ORDER BY category_id, total_sold DESC
  LIMIT 3
)
SELECT c.category_name, p.product_name, topsales.total_sold
FROM categories c
INNER JOIN TopSellingProductsByCategory topsales ON c.category_id = topsales.category_id
INNER JOIN products p ON topsales.product_id = p.product_id
WHERE c.is_active = 1  -- Filter for active categories only
ORDER BY c.category_name, topsales.total_sold DESC;



--test

-- Implement your solution here
SELECT DISTINCT c1.city_name AS layover_city
FROM flights
INNER JOIN airports a1 ON flights.start_port = airports.port_code
INNER JOIN airports a2 ON f1.end_port = a2.port_code
INNER JOIN flights f2 ON f2.start_port = a2.port_code -- Connect flights at the layover city
INNER JOIN airports a3 ON f2.end_port = a3.port_code
WHERE a1.city_name = 'JFK'  -- Start from New York
  AND a3.city_name = 'NRT'       -- Destination is Tokyo
  AND f1.start_port <> f2.end_port -- Ensure flights are different
  AND f1.end_port <> f2.start_port -- Ensure flights are different (avoid same city twice)
ORDER BY layover_city ASC;

