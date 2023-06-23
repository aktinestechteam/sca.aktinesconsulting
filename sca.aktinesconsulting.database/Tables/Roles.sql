CREATE TABLE [dbo].[Roles]
(
	[RoleId] INT NOT NULL PRIMARY KEY,
	[Name] [varchar](15) NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
)
