USE [ProjectManager]
GO

/****** Object:  Table [dbo].[Task_Table]    Script Date: 03-10-2018 11:07:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Task_Table](
	[Task_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Parent_ID] [bigint] NULL,
	[Project_ID] [bigint] NULL,
	[Task] [varchar](max) NOT NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Task_Table] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Task_Table]  WITH CHECK ADD  CONSTRAINT [FK_TaskParent] FOREIGN KEY([Parent_ID])
REFERENCES [dbo].[Parent_Task_Table] ([Parent_ID])
GO

ALTER TABLE [dbo].[Task_Table] CHECK CONSTRAINT [FK_TaskParent]
GO


