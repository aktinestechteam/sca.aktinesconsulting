CREATE TABLE [dbo].[Users](
	[UserId] [int]IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] NVARCHAR(50) NULL,
	[Email] [varchar](30) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO