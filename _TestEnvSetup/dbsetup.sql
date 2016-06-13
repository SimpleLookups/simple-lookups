CREATE DATABASE SimpleLookups
GO

USE SimpleLookups
GO

CREATE TABLE [dbo].[BusinessType](
	[BusinessTypeId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[BusinessTypeName] [varchar](50) NULL,
	[BusinessTypeCode] [varchar](20) NULL,
	[BusinessTypeDescription] [varchar](1000) NULL,
	[Active] [bit] NULL
)
GO

INSERT INTO [dbo].[BusinessType] ([BusinessTypeName], [BusinessTypeCode], [BusinessTypeDescription], [Active])
SELECT 'Business Type 01', 'BIZTYPE01', 'A business type.', 1 UNION
SELECT 'Business Type 02', 'BIZTYPE02', 'A business type.', 1 UNION
SELECT 'Business Type 03', 'BIZTYPE03', 'A business type.', 1 UNION
SELECT 'Business Type 04', 'BIZTYPE04', 'A business type.', 1 UNION
SELECT 'Business Type 05', 'BIZTYPE05', 'A business type.', 1 UNION
SELECT 'Business Type 06', 'BIZTYPE06', 'A business type.', 1 UNION
SELECT 'Business Type 07', 'BIZTYPE07', 'A business type.', 1 UNION
SELECT 'Business Type 08', 'BIZTYPE08', 'A business type.', 1 UNION
SELECT 'Business Type 09', 'BIZTYPE09', 'A business type.', 1 UNION
SELECT 'Business Type 10', 'BIZTYPE10', 'A business type.', 1 UNION
SELECT 'Business Type 11', 'BIZTYPE11', 'A business type.', 1 UNION
SELECT 'Business Type 12', 'BIZTYPE12', 'A business type.', 1 UNION
SELECT 'Business Type 13', 'BIZTYPE13', 'A business type.', 1 UNION
SELECT 'Business Type 14', 'BIZTYPE14', 'A business type.', 1 UNION
SELECT 'Business Type 15', 'BIZTYPE15', 'A business type.', 1 UNION
SELECT 'Business Type 16', 'BIZTYPE16', 'A business type.', 1 UNION
SELECT 'Business Type 17', 'BIZTYPE17', 'A business type.', 1 UNION
SELECT 'Business Type 18', 'BIZTYPE18', 'A business type.', 1 UNION
SELECT 'Business Type 19', 'BIZTYPE19', 'A business type.', 1 UNION
SELECT 'Business Type 20', 'BIZTYPE20', 'A business type.', 1 UNION
SELECT 'Business Type 21', 'BIZTYPE21', 'A business type.', 1 UNION
SELECT 'Business Type 22', 'BIZTYPE22', 'A business type.', 1 UNION
SELECT 'Business Type 23', 'BIZTYPE23', 'A business type.', 1 UNION
SELECT 'Business Type 24', 'BIZTYPE24', 'A business type.', 1 UNION
SELECT 'Business Type 25', 'BIZTYPE25', 'A business type.', 1 UNION
SELECT 'Business Type 26', 'BIZTYPE26', 'A business type.', 1 UNION
SELECT 'Business Type 27', 'BIZTYPE27', 'A business type.', 1 UNION
SELECT 'Business Type 28', 'BIZTYPE28', 'A business type.', 1 UNION
SELECT 'Business Type 29', 'BIZTYPE29', 'A business type.', 1 UNION
SELECT 'Business Type 30', 'BIZTYPE30', 'A business type.', 1 UNION
SELECT 'Business Type 31', 'BIZTYPE31', 'A business type.', 1 UNION
SELECT 'Business Type 32', 'BIZTYPE32', 'A business type.', 1 UNION
SELECT 'Business Type 33', 'BIZTYPE33', 'A business type.', 1 UNION
SELECT 'Business Type 34', 'BIZTYPE34', 'A business type.', 1 UNION
SELECT 'Business Type 35', 'BIZTYPE35', 'A business type.', 1 UNION
SELECT 'Business Type 36', 'BIZTYPE36', 'A business type.', 1 UNION
SELECT 'Business Type 37', 'BIZTYPE37', 'A business type.', 1 UNION
SELECT 'Business Type 38', 'BIZTYPE38', 'A business type.', 1 UNION
SELECT 'Business Type 39', 'BIZTYPE39', 'A business type.', 1 UNION
SELECT 'Business Type 40', 'BIZTYPE40', 'A business type.', 1 UNION
SELECT 'Business Type 41', 'BIZTYPE41', 'A business type.', 1 UNION
SELECT 'Business Type 42', 'BIZTYPE42', 'A business type.', 1 UNION
SELECT 'Business Type 43', 'BIZTYPE43', 'A business type.', 1 UNION
SELECT 'Business Type 44', 'BIZTYPE44', 'A business type.', 1 UNION
SELECT 'Business Type 45', 'BIZTYPE45', 'A business type.', 1 UNION
SELECT 'Business Type 46', 'BIZTYPE46', 'A business type.', 1 UNION
SELECT 'Business Type 47', 'BIZTYPE47', 'A business type.', 1 UNION
SELECT 'Business Type 48', 'BIZTYPE48', 'A business type.', 1 UNION
SELECT 'Business Type 49', 'BIZTYPE49', 'A business type.', 1 UNION
SELECT 'Business Type 50', 'BIZTYPE50', 'A business type.', 1
GO

CREATE TABLE [dbo].[BusinessTypeCC](
	[BusinessTypeCCId2] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[BusinessTypeCCName2] [varchar](50) NOT NULL,
	[BusinessTypeCCCode2] [varchar](20) NOT NULL,
	[BusinessTypeCCDescription2] [varchar](100) NOT NULL,
	[Active2] [bit] NOT NULL
)
GO

INSERT INTO [dbo].[BusinessTypeCC] ([BusinessTypeCCName2], [BusinessTypeCCCode2], [BusinessTypeCCDescription2], [Active2])
SELECT 'Business Type 01', 'BIZTYPE01', 'A business type.', 1 UNION
SELECT 'Business Type 02', 'BIZTYPE02', 'A business type.', 1 UNION
SELECT 'Business Type 03', 'BIZTYPE03', 'A business type.', 1 UNION
SELECT 'Business Type 04', 'BIZTYPE04', 'A business type.', 1 UNION
SELECT 'Business Type 05', 'BIZTYPE05', 'A business type.', 1 UNION
SELECT 'Business Type 06', 'BIZTYPE06', 'A business type.', 1 UNION
SELECT 'Business Type 07', 'BIZTYPE07', 'A business type.', 1 UNION
SELECT 'Business Type 08', 'BIZTYPE08', 'A business type.', 1 UNION
SELECT 'Business Type 09', 'BIZTYPE09', 'A business type.', 1 UNION
SELECT 'Business Type 10', 'BIZTYPE10', 'A business type.', 1 UNION
SELECT 'Business Type 11', 'BIZTYPE11', 'A business type.', 1 UNION
SELECT 'Business Type 12', 'BIZTYPE12', 'A business type.', 1 UNION
SELECT 'Business Type 13', 'BIZTYPE13', 'A business type.', 1 UNION
SELECT 'Business Type 14', 'BIZTYPE14', 'A business type.', 1 UNION
SELECT 'Business Type 15', 'BIZTYPE15', 'A business type.', 1 UNION
SELECT 'Business Type 16', 'BIZTYPE16', 'A business type.', 1 UNION
SELECT 'Business Type 17', 'BIZTYPE17', 'A business type.', 1 UNION
SELECT 'Business Type 18', 'BIZTYPE18', 'A business type.', 1 UNION
SELECT 'Business Type 19', 'BIZTYPE19', 'A business type.', 1 UNION
SELECT 'Business Type 20', 'BIZTYPE20', 'A business type.', 1 UNION
SELECT 'Business Type 21', 'BIZTYPE21', 'A business type.', 1 UNION
SELECT 'Business Type 22', 'BIZTYPE22', 'A business type.', 1 UNION
SELECT 'Business Type 23', 'BIZTYPE23', 'A business type.', 1 UNION
SELECT 'Business Type 24', 'BIZTYPE24', 'A business type.', 1 UNION
SELECT 'Business Type 25', 'BIZTYPE25', 'A business type.', 1 UNION
SELECT 'Business Type 26', 'BIZTYPE26', 'A business type.', 1 UNION
SELECT 'Business Type 27', 'BIZTYPE27', 'A business type.', 1 UNION
SELECT 'Business Type 28', 'BIZTYPE28', 'A business type.', 1 UNION
SELECT 'Business Type 29', 'BIZTYPE29', 'A business type.', 1 UNION
SELECT 'Business Type 30', 'BIZTYPE30', 'A business type.', 1 UNION
SELECT 'Business Type 31', 'BIZTYPE31', 'A business type.', 1 UNION
SELECT 'Business Type 32', 'BIZTYPE32', 'A business type.', 1 UNION
SELECT 'Business Type 33', 'BIZTYPE33', 'A business type.', 1 UNION
SELECT 'Business Type 34', 'BIZTYPE34', 'A business type.', 1 UNION
SELECT 'Business Type 35', 'BIZTYPE35', 'A business type.', 1 UNION
SELECT 'Business Type 36', 'BIZTYPE36', 'A business type.', 1 UNION
SELECT 'Business Type 37', 'BIZTYPE37', 'A business type.', 1 UNION
SELECT 'Business Type 38', 'BIZTYPE38', 'A business type.', 1 UNION
SELECT 'Business Type 39', 'BIZTYPE39', 'A business type.', 1 UNION
SELECT 'Business Type 40', 'BIZTYPE40', 'A business type.', 1 UNION
SELECT 'Business Type 41', 'BIZTYPE41', 'A business type.', 1 UNION
SELECT 'Business Type 42', 'BIZTYPE42', 'A business type.', 1 UNION
SELECT 'Business Type 43', 'BIZTYPE43', 'A business type.', 1 UNION
SELECT 'Business Type 44', 'BIZTYPE44', 'A business type.', 1 UNION
SELECT 'Business Type 45', 'BIZTYPE45', 'A business type.', 1 UNION
SELECT 'Business Type 46', 'BIZTYPE46', 'A business type.', 1 UNION
SELECT 'Business Type 47', 'BIZTYPE47', 'A business type.', 1 UNION
SELECT 'Business Type 48', 'BIZTYPE48', 'A business type.', 1 UNION
SELECT 'Business Type 49', 'BIZTYPE49', 'A business type.', 1 UNION
SELECT 'Business Type 50', 'BIZTYPE50', 'A business type.', 1
GO

CREATE TABLE [dbo].[BusinessTypeCC2](
	[Id4] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name4] [varchar](50) NOT NULL,
	[Code4] [varchar](20) NOT NULL,
	[Description4] [varchar](100) NOT NULL,
	[Active4] [bit] NOT NULL
)
GO

INSERT INTO [dbo].[BusinessTypeCC2] ([Name4], [Code4], [Description4], [Active4])
SELECT 'Business Type 01', 'BIZTYPE01', 'A business type.', 1 UNION
SELECT 'Business Type 02', 'BIZTYPE02', 'A business type.', 1 UNION
SELECT 'Business Type 03', 'BIZTYPE03', 'A business type.', 1 UNION
SELECT 'Business Type 04', 'BIZTYPE04', 'A business type.', 1 UNION
SELECT 'Business Type 05', 'BIZTYPE05', 'A business type.', 1 UNION
SELECT 'Business Type 06', 'BIZTYPE06', 'A business type.', 1 UNION
SELECT 'Business Type 07', 'BIZTYPE07', 'A business type.', 1 UNION
SELECT 'Business Type 08', 'BIZTYPE08', 'A business type.', 1 UNION
SELECT 'Business Type 09', 'BIZTYPE09', 'A business type.', 1 UNION
SELECT 'Business Type 10', 'BIZTYPE10', 'A business type.', 1 UNION
SELECT 'Business Type 11', 'BIZTYPE11', 'A business type.', 1 UNION
SELECT 'Business Type 12', 'BIZTYPE12', 'A business type.', 1 UNION
SELECT 'Business Type 13', 'BIZTYPE13', 'A business type.', 1 UNION
SELECT 'Business Type 14', 'BIZTYPE14', 'A business type.', 1 UNION
SELECT 'Business Type 15', 'BIZTYPE15', 'A business type.', 1 UNION
SELECT 'Business Type 16', 'BIZTYPE16', 'A business type.', 1 UNION
SELECT 'Business Type 17', 'BIZTYPE17', 'A business type.', 1 UNION
SELECT 'Business Type 18', 'BIZTYPE18', 'A business type.', 1 UNION
SELECT 'Business Type 19', 'BIZTYPE19', 'A business type.', 1 UNION
SELECT 'Business Type 20', 'BIZTYPE20', 'A business type.', 1 UNION
SELECT 'Business Type 21', 'BIZTYPE21', 'A business type.', 1 UNION
SELECT 'Business Type 22', 'BIZTYPE22', 'A business type.', 1 UNION
SELECT 'Business Type 23', 'BIZTYPE23', 'A business type.', 1 UNION
SELECT 'Business Type 24', 'BIZTYPE24', 'A business type.', 1 UNION
SELECT 'Business Type 25', 'BIZTYPE25', 'A business type.', 1 UNION
SELECT 'Business Type 26', 'BIZTYPE26', 'A business type.', 1 UNION
SELECT 'Business Type 27', 'BIZTYPE27', 'A business type.', 1 UNION
SELECT 'Business Type 28', 'BIZTYPE28', 'A business type.', 1 UNION
SELECT 'Business Type 29', 'BIZTYPE29', 'A business type.', 1 UNION
SELECT 'Business Type 30', 'BIZTYPE30', 'A business type.', 1 UNION
SELECT 'Business Type 31', 'BIZTYPE31', 'A business type.', 1 UNION
SELECT 'Business Type 32', 'BIZTYPE32', 'A business type.', 1 UNION
SELECT 'Business Type 33', 'BIZTYPE33', 'A business type.', 1 UNION
SELECT 'Business Type 34', 'BIZTYPE34', 'A business type.', 1 UNION
SELECT 'Business Type 35', 'BIZTYPE35', 'A business type.', 1 UNION
SELECT 'Business Type 36', 'BIZTYPE36', 'A business type.', 1 UNION
SELECT 'Business Type 37', 'BIZTYPE37', 'A business type.', 1 UNION
SELECT 'Business Type 38', 'BIZTYPE38', 'A business type.', 1 UNION
SELECT 'Business Type 39', 'BIZTYPE39', 'A business type.', 1 UNION
SELECT 'Business Type 40', 'BIZTYPE40', 'A business type.', 1 UNION
SELECT 'Business Type 41', 'BIZTYPE41', 'A business type.', 1 UNION
SELECT 'Business Type 42', 'BIZTYPE42', 'A business type.', 1 UNION
SELECT 'Business Type 43', 'BIZTYPE43', 'A business type.', 1 UNION
SELECT 'Business Type 44', 'BIZTYPE44', 'A business type.', 1 UNION
SELECT 'Business Type 45', 'BIZTYPE45', 'A business type.', 1 UNION
SELECT 'Business Type 46', 'BIZTYPE46', 'A business type.', 1 UNION
SELECT 'Business Type 47', 'BIZTYPE47', 'A business type.', 1 UNION
SELECT 'Business Type 48', 'BIZTYPE48', 'A business type.', 1 UNION
SELECT 'Business Type 49', 'BIZTYPE49', 'A business type.', 1 UNION
SELECT 'Business Type 50', 'BIZTYPE50', 'A business type.', 1
GO