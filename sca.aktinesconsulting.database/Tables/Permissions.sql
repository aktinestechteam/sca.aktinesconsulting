CREATE TABLE [dbo].[Permissions]
(
	[PermissionId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] Varchar(25),
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL
)

