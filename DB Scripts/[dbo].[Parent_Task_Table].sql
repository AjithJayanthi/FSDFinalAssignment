USE [ProjectManager]
GO

/****** Object:  Table [dbo].[Parent_Task_Table]    Script Date: 27-09-2018 15:20:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parent_Task_Table](
	[Parent_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Parent_Task] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Parent_Task_Table] PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


