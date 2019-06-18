CREATE TABLE [dbo].[Errors](
	[errorId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[application] [text] NOT NULL,
	[message] [text] NOT NULL,
	[stackTrace] [text] NOT NULL,
	[createdDtTime] [datetime] NOT NULL
);