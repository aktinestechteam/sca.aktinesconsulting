CREATE TABLE [dbo].[RolePermissions]
(
	[PermissionId] INT NOT NULL,
	[RoleId] INT NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL, 
    [View] BIT NOT NULL DEFAULT 0, 
    [Create] BIT NOT NULL DEFAULT 0, 
    [Modify] BIT NOT NULL DEFAULT 0, 
    [Delete] BIT NOT NULL DEFAULT 0,
	FOREIGN KEY (PermissionId) REFERENCES [dbo].[Permissions](PermissionId),
	FOREIGN KEY (RoleId) REFERENCES [dbo].[Roles](RoleId)
)

