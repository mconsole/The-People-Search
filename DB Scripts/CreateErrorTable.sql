USE [thepeoplesearch]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 6/14/2019 3:16:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
	[errorId] [int] IDENTITY(1,1) NOT NULL,
	[application] [text] NOT NULL,
	[message] [text] NOT NULL,
	[stackTrace] [text] NOT NULL,
	[createdDtTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[errorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


