USE SimpleLookups
GO

DECLARE @TypeName NVARCHAR(50) = 'BusinessTypeCC'

DECLARE @sql NVARCHAR(1000) = 
	N'CREATE TABLE dbo.' + @TypeName + 
	 '(' + 
		 @TypeName +'Id2 INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ' + 
		 @TypeName +'Name2 VARCHAR(50) NOT NULL, ' + 
		 @TypeName +'Code2 VARCHAR(20) NOT NULL, ' + 
		 @TypeName +'Description2 VARCHAR(100) NOT NULL, ' +
		'Active2 BIT NOT NULL'+
	  ')'

EXEC sp_executesql @sql