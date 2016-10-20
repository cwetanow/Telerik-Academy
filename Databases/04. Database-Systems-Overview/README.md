# Database Systems - Overview
## _Homework_

### Answer following questions in Markdown format (`.md` file)

# 1.  What database models do you know?
 - Hierarchical (tree)
 - Network / graph
 - Relational (table)
 - Object-oriented

# 2.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
 - Creating / altering / deleting tables and relationships between them (database schema)
 - Adding, changing, deleting, searching and retrieving of data stored in the tables
 - Support for the SQL language
 - Transaction management (optional)

# 3.  Define what is "table" in database terms.
 - Database tables consist of data, arranged in rows and columns
 - All rows have the same structure
 - Columns have name and type (number, string, date, image, or other)

# 4.  Explain the difference between a primary and a foreign key.
 - A primary key is a unique column of a table that identifies its rows ( usually a number )
 - A foreign key is an identifier of a record located in another table (usually its primary key)

# 5.  Explain the different kinds of relationships between tables in relational databases.
 - One-to-many: A single record in the first table has many corresponding records in the second table
 - Many-to-many: Records in the first table have many corresponding records in the second one and vice versa
 - One-to-one: A single record in a table corresponds to a single record in the other table 
# 6.  When is a certain database schema normalized?
 - When there is no repeating data

 What are the advantages of normalized databases?
 - Searching, sorting, and creating indexes is faster, since tables are narrower, and more rows fit on a data page.
 - You usually have more tables.
 - You can have more clustered indexes (one per table), so you get more flexibility in tuning queries.
 - Index searching is often faster, since indexes tend to be narrower and shorter.
 - More tables allow better use of segments to control physical placement of data.
 - You usually have fewer indexes per table, so data modification commands are faster.
 - Fewer null values and less redundant data, making your database more compact.
 - Triggers execute more quickly if you are not maintaining redundant data.
 - Data modification anomalies are reduced.
 - Normalization is conceptually cleaner and easier to maintain and change as your needs change.

# 7.  What are database integrity constraints and when are they used?
## Integrity constraints ensure data integrity in the database tables
 - Enforce data rules which cannot be violated
## Primary key constraint
 - Ensures that the primary key of a table has unique value for each table row
## Unique key constraint
 - Ensures that all values in a certain column (or a group of columns) are unique
## Foreign key constraint
 - Ensures that the value in given column is a key from another table
## Check constraint
 - Ensures that values in a certain column meet some predefined condition

# 8.  Point out the pros and cons of using indexes in a database.
 - With indexes searching is faster
 - With indexes adding and removing data is slower

# 9.  What's the main purpose of the SQL language?
 To manipulate relational databases.

# 10.  What are transactions used for?
## Transactions are a sequence of database operations which are executed as a single unit:
 - Either all of them execute successfully
 - Or none of them is executed at all
## Give an example.
 - A bank transfer from one account to another ( witdrawal + deposit )
 - If either the witdrawal or deposit fails the entire operation is canceled

# 11.  What is a NoSQL database?
 - Use document-based model (non-relational)
 - Schema-free document storage
 - Support CRUD operations, indexing, querying, concurrency and transactions
 - Highly optimized for append / retrieve
 - Great performance and scalability

# 12.  Explain the classical non-relational data models.
 - Document model (e.g. MongoDB, CouchDB): 
Set of documents, e.g. JSON strings
 - Key-value model (e.g. Redis)
Set of key-value pairs
 - Hierarchical key-value
Hierarchy of key-value pairs
 - Wide-column model (e.g. Cassandra)
Key-value model with schema
 - Object model (e.g. Cache)
Set of OOP-style objects

# 13.  Give few examples of NoSQL databases and their pros and cons.
 - Flexible Data Model. Unlike relational databases, NoSQL databases easily store and combine any type of data, both structured and unstructured. You can also dynamically update the schema to evolve with changing requirements and without any interruption or downtime to your application.
 - Elastic Scalability. NoSQL databases scale out on low cost, commodity hardware, allowing for almost unlimited growth.
 - High Performance. NoSQL databases are built for great performance, measured in terms of both throughput and latency.
