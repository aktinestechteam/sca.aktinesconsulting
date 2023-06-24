CREATE TABLE [dbo].[SCAVersions](
[SCAVersionId] [int] IDENTITY(1,1) NOT NULL,
CreatedOn [Datetime] DEFAULT GETUTCDATE(),
UserId [int]
PRIMARY KEY (SCAVersionId)
FOREIGN KEY (UserId) REFERENCES Users(UserId)
)
