USE [ProjectManager]
GO

/****** Object:  Table [dbo].[Users_Table]    Script Date: 30-09-2018 01:08:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users_Table](
	[User_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Employee_ID] [varchar](50) NOT NULL,
	[Project_ID] [bigint] NULL,
	[Task_ID] [bigint] NULL,
 CONSTRAINT [PK_Users_Table] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users_Table]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project_Table] ([Project_ID])
GO

ALTER TABLE [dbo].[Users_Table]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project_Table] ([Project_ID])
GO

ALTER TABLE [dbo].[Users_Table]  WITH CHECK ADD FOREIGN KEY([Task_ID])
REFERENCES [dbo].[Task_Table] ([Task_ID])
GO

ALTER TABLE [dbo].[Users_Table]  WITH CHECK ADD FOREIGN KEY([Task_ID])
REFERENCES [dbo].[Task_Table] ([Task_ID])
GO


