USE [thepeoplesearch]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 6/14/2019 2:13:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
	[errorId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[message] [text] NOT NULL,
	[stackTrace] [text] NOT NULL,
	[createdDtTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


