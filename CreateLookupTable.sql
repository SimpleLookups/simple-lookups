USE SimpleLookups
GO

DECLARE @TypeName NVARCHAR(50) = 'SomeType'

DECLARE @sql NVARCHAR(1000) = 
	N'CREATE TABLE dbo.' + @TypeName + 
	 '(' + 
		 @TypeName +'Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ' + 
		 @TypeName +'Name VARCHAR(50) NOT NULL, ' + 
		 @TypeName +'Code VARCHAR(20) NOT NULL, ' + 
		 @TypeName +'Description VARCHAR(100) NOT NULL, ' +
		'Active BIT NOT NULL'+
	  ')'

EXEC sp_executesql @sql