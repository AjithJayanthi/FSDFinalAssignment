USE [ProjectManager]
GO

/****** Object:  Table [dbo].[Project_Table]    Script Date: 30-09-2018 01:04:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_Table](
	[Project_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Project] [varchar](max) NOT NULL,
	[Start_Date] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Project_Table] PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


