## ERD

Based on the provided CSV files, I've designed a SQL database that effectively stores employee data and telecom event details while eliminating redundancies.

![Database ERD](/Database-Challenges/erd-diagram.png)

### EMPLOYEES Table

- Contains all employee information
- **Primary key**: `employee_guid`
- Removed phone, package, vendor, and contract details to eliminate redundancy
- Fields include: first_name, last_name, gender, email, age, birthday, active, street, postal, province, city, longitude, latitude

### VENDORS Table

- Contains information about telecom providers (Cell C, MTN, Vodacom)
- **Primary key**: `vendor_id`
- Normalized the vendor data instead of repeating it
- Fields include: vendor_name

### CONTRACTS Table

- Links employees to their telecom contracts
- **Primary key**: `contract_id`
- **Foreign keys**: `employee_guid`, `vendor_id`
- Contains phone numbers, which serve as identifiers for events
- Fields include: phone, package, package_cost, contract_start, contract_end

### EVENT_TYPES Table

- Normalizes the event types
- **Primary key**: `event_type_id`
- Allows for better categorization and analysis of events
- Fields include: event_name

### EVENTS Table

- Records all telecom events
- **Primary key**: `event_id`
- **Foreign keys**: `phone` (from CONTRACTS), `event_type_id`
- Stores the date and timestamp of each event
- Fields include: event_date, time_stamp

## This design eliminates redundancies by

- Separating employee data from contract data
- Normalizing vendor information
- Creating a central events table that works across all vendors
- Using appropriate relationships between tables
