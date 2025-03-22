-- First, create the employees table based on the CSV structure
CREATE TABLE IF NOT EXISTS employees (
    employee_guid VARCHAR(255) PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    gender VARCHAR(50),
    email VARCHAR(255),
    age INT,
    birthday DATE,
    active BOOLEAN,
    street VARCHAR(255),
    postal VARCHAR(255),
    province VARCHAR(255),
    city VARCHAR(255),
    longitude FLOAT,
    latitude FLOAT,
    package VARCHAR(255),
    vendor VARCHAR(255),
    phone VARCHAR(255),
    package_cost VARCHAR(255),
    contract_start DATE,
    contract_end DATE
);

-- Assuming the CSV has been imported into the 'employees' table
-- Let's create a temporary column to store the updated email addresses

-- MySQL
UPDATE employees
SET email = 
    CONCAT(
        SUBSTRING_INDEX(email, '@', 1),
        '@company.',
        SUBSTRING_INDEX(email, '.', -1)
    );

-- Verify the update worked correctly
SELECT 
    employee_guid,
    first_name,
    last_name,
    email
FROM employees
LIMIT 10;
