N-Tier Builder (.NET)
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

N-Tier Builder creates C# code for your object class (e.g. Customer.cs) with a constructor and declares all of it's private properties as well as setters and getters for it's public properties. 
[See Sample](https://github.com/djohnsonkc/ntierbuilder/blob/master/samples/Customer.cs.txt) 

### Data Access Layer

N-Tier Builder creates SQL Server stored procedures for inserting, updating, deleting, and retrieving records in your database. The connection to the Data Access Layer is controlled by your Web.config or Machine.config connection setting. 
[See Sample](https://github.com/djohnsonkc/ntierbuilder/blob/master/samples/StoredProcedures.sql.txt) 

N-Tier Builder also creates "adapters" to load your data into your Domain Object. 
[See Sample](https://github.com/djohnsonkc/ntierbuilder/blob/master/samples/CustomerAdapter.cs.txt) 

N-Tier Builder provides a "base adapter" that all adapters can inherit from and contain most of the actual code for accessing your database. 
[See Sample](https://github.com/djohnsonkc/ntierbuilder/blob/master/samples/BaseAdapter.txt) 

### Presentation Layer

N-Tier Builder creates ASP.NET Web Form HTML and C# code for viewing, adding, editing, and removing objects/records via calls to objects in the Data Access Layer. The code-behind for the Web Forms will instantiate objects and call public methods from the Data Access Layer.
(see examples: List.aspx List.cs View.aspx View.cs Edit.aspx Edit.cs	) 

## Getting Started

Use the following SQL query to generate a table definition that you can use to paste in to N-Tier Builder

	DECLARE @TableName varchar(50)
	SET @TableName = '<Enter Name Here>'

	select
	c.name + ',' As ColumnName,
	st.name + ',' As TypeName,
	IsNull(CAST(c.Prec as varchar(5)), '4000') + ',' As Length,
	c.ColStat

	from syscolumns c,
	sysobjects o,
	systypes st

	where
	c.id = o.id AND
	c.xtype = st.xtype AND
	o.Name = @TableName AND
	NOT st.Name = 'sysname'

	order by o.name, c.colorder


Once the results are pasted in, you will be walked through a simple wizard that will allow you to name things that N-Tier Builder will generate for you. 

These things include:

* Namespaces for your Domain object and Data Adapter objects
* Stored procedure names
* A preferred database user name that should be granted access to the Stored procedures
* Connection string using a preferred database user name

