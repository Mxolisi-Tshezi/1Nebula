<!-- # Email Update Script Explanation -->

## Question 2

The complete SQL script is available at: [Email Update Script](/Database-Challenges/email-update-script.sql)

## The SQL Solution

```sql
-- For MySQL
UPDATE employees
SET email =
    CONCAT(
        SUBSTRING_INDEX(email, '@', 1),
        '@company.',
        SUBSTRING_INDEX(email, '.', -1)
    );
```

## How It Works

### Parse and Transform Email Components

The script breaks down and rebuilds each email address using the following logic:

1. **Extract the username part**:

   - Everything before the `@` symbol
   - E.g., from `john.doe@gmail.com` → `john.doe`

2. **Replace the host with "company"**:

   - Replace whatever comes after `@` and before the last `.`
   - E.g., from `@gmail.` → `@company.`

3. **Preserve the domain part**:

   - Keep everything after the last `.`
   - E.g., from `gmail.com` → `.com` is preserved

4. **Concatenate the components**:
   - Join the three parts together to form the new email address
   - E.g., `john.doe` + `@company.` + `com` = `john.doe@company.com`

### Example Transformations

| Original Email          | Updated Email           |
| ----------------------- | ----------------------- |
| john.doe@gmail.com      | john.doe@company.com    |

## Implementation Steps

1. Import the Employee File.csv into your SQL database
2. Run the SQL script for the database
3. Verify the results with a SELECT query:

```sql
SELECT
    employee_guid,
    first_name,
    last_name,
    email
FROM employees
LIMIT 10;
```
