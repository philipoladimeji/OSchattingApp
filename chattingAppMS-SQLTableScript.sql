USE [LinqChat]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](30) NOT NULL,
	[Lastname] [varchar](30) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Sex] [varchar](1) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 10/19/2020 00:40:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PrivateMessage]    Script Date: 10/19/2020 00:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivateMessage](
	[PrivateMessageID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ToUserID] [int] NOT NULL,
 CONSTRAINT [PK_PrivateMessage] PRIMARY KEY CLUSTERED 
(
	[PrivateMessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoggedInUser]    Script Date: 10/19/2020 00:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoggedInUser](
	[LoggedInUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
 CONSTRAINT [PK_LoggedInUser] PRIMARY KEY CLUSTERED 
(
	[LoggedInUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 10/19/2020 00:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[UserID] [int] NOT NULL,
	[ToUserID] [int] NULL,
	[Text] [varchar](100) NOT NULL,
	[TimeStamp] [datetime] NOT NULL CONSTRAINT [DF_Message_TimeStamp]  DEFAULT (getdate()),
	[Color] [varchar](50) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_PrivateMessage_User]    Script Date: 10/19/2020 00:40:56 ******/
ALTER TABLE [dbo].[PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_PrivateMessage_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[PrivateMessage] CHECK CONSTRAINT [FK_PrivateMessage_User]
GO
/****** Object:  ForeignKey [FK_PrivateMessage_User1]    Script Date: 10/19/2020 00:40:56 ******/
ALTER TABLE [dbo].[PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_PrivateMessage_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[PrivateMessage] CHECK CONSTRAINT [FK_PrivateMessage_User1]
GO
/****** Object:  ForeignKey [FK_Message_Room]    Script Date: 10/19/2020 00:40:59 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Room]
GO
/****** Object:  ForeignKey [FK_Message_User]    Script Date: 10/19/2020 00:40:59 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
/****** Object:  ForeignKey [FK_Message_User1]    Script Date: 10/19/2020 00:40:59 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO
/****** Object:  ForeignKey [FK_LoggedInUser_Room]    Script Date: 10/19/2020 00:41:00 ******/
ALTER TABLE [dbo].[LoggedInUser]  WITH CHECK ADD  CONSTRAINT [FK_LoggedInUser_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[LoggedInUser] CHECK CONSTRAINT [FK_LoggedInUser_Room]
GO
/****** Object:  ForeignKey [FK_LoggedInUser_User]    Script Date: 10/19/2020 00:41:00 ******/
ALTER TABLE [dbo].[LoggedInUser]  WITH CHECK ADD  CONSTRAINT [FK_LoggedInUser_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[LoggedInUser] CHECK CONSTRAINT [FK_LoggedInUser_User]
GO
