USE SimpleLookups
GO

DECLARE @TypeName NVARCHAR(50) = 'BusinessTypeCC2'

DECLARE @sql NVARCHAR(1000) = 
	N'CREATE TABLE dbo.' + @TypeName + 
	 '(' + 
		 'Id4 INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ' + 
		 'Name4 VARCHAR(50) NOT NULL, ' + 
		 'Code4 VARCHAR(20) NOT NULL, ' + 
		 'Description4 VARCHAR(100) NOT NULL, ' +
		'Active4 BIT NOT NULL'+
	  ')'

EXEC sp_executesql @sql