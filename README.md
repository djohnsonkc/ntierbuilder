NTierBUilder
=====================================
N-Tier Builder is an object persistence code generator that uses an existing SQL Server table schema to generate a domain object, data access layer and presentation layer for a specified table. 

## What it does

Using a simple table definition like below, N-Tier Builder will help you build your app faster and with much more consistency.

CustomerID, int, 4, 1
Name, varchar, 50, 0
Address, varchar, 50, 0
City, varchar, 50, 0
State, varchar, 50, 0
Zip, varchar, 50, 0
Active, bit, 1, 0
DateCreated, datetime, 8, 0

## Here is a list of things that it will build for you

### Domain Objects

N-Tier Builder creates C# code for your object class (e.g. Customer.cs) with a constructor and declares all of it's private properties as well as setters and getters for it's public properties. (see example) 

### Data Access Layer

N-Tier Builder creates SQL Server stored procedures for inserting, updating, deleting, and retrieving records in your database. The connection to the Data Access Layer is controlled by your Web.config or Machine.config connection setting. (see example)

N-Tier Builder also creates "adapters" to load your data into your Domain Object. (see example)

N-Tier Builder provides a "base adapter" that all adapters can inherit from and contain most of the actual code for accessing your database. (see example)


### Presentation Layer

N-Tier Builder creates ASP.NET Web Form HTML and C# code for viewing, adding, editing, and removing objects/records via calls to objects in the Data Access Layer. The code-behind for the Web Forms will instantiate objects and call public methods from the Data Access Layer.
(see examples: List.aspx List.cs View.aspx View.cs Edit.aspx Edit.cs	) 



