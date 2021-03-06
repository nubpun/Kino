USE [mayorov_db]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[Film_id] [int] IDENTITY(1, 1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[LengthInMinute] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED 
(
	[Film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Halls]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[Hall_id] [int] IDENTITY(1,1) NOT NULL,
	[HallName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[Hall_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaceInHall]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceInHall](
	[PlaceInHall_id] [int] IDENTITY(1,1) NOT NULL,
	[Hall_id] [int] NOT NULL,
	[coordX] [int] NOT NULL,
	[coordY] [int] NOT NULL,
 CONSTRAINT [PK_PlaceInHall] PRIMARY KEY CLUSTERED 
(
	[PlaceInHall_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Role_id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](10) NOT NULL,
	[RoleLogin] [nvarchar](20) NOT NULL,
	[RolePass] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scheduler]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduler](
	[Schedule_id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[Film_id] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Hall_id] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[Schedule_id] [int] NOT NULL,
	[PlaceInHall_id] [int] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/4/2016 7:34:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](100) NOT NULL,
	[pass] [nvarchar](100) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PlaceInHall]  WITH CHECK ADD  CONSTRAINT [FK_PlaceInHall_Halls] FOREIGN KEY([Hall_id])
REFERENCES [dbo].[Halls] ([Hall_id])
GO
ALTER TABLE [dbo].[PlaceInHall] CHECK CONSTRAINT [FK_PlaceInHall_Halls]
GO
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Films] FOREIGN KEY([Film_id])
REFERENCES [dbo].[Films] ([Film_id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Films]
GO
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Halls] FOREIGN KEY([Hall_id])
REFERENCES [dbo].[Halls] ([Hall_id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Halls]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_PlaceInHall] FOREIGN KEY([PlaceInHall_id])
REFERENCES [dbo].[PlaceInHall] ([PlaceInHall_id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_PlaceInHall]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Scheduler] FOREIGN KEY([Schedule_id])
REFERENCES [dbo].[Scheduler] ([Schedule_id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Scheduler]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([Role_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
