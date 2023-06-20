﻿CREATE TABLE [dbo].[SCAExceptionFields]
(
	[SCAExceptionFieldId] INT NOT NULL PRIMARY KEY,
	[SCAExceptionFieldTypeId] INT NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
	[CreatedBy] INT NULL,
	[CreatedOn] DATETIME NULL,
	[UpdatedBy] INT NULL,
	[UpdatedOn] DATETIME NULL,
	[IsActive] BIT NOT NULL DEFAULT 1, 
    FOREIGN KEY (SCAExceptionFieldTypeId) REFERENCES [dbo].SCAExceptionFieldTypes(SCAExceptionFieldTypeId)
)
