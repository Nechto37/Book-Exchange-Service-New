USE [master]
GO
/****** Object:  Database [Сервис обмена книгами]    Script Date: 23.12.2020 20:08:18 ******/
CREATE DATABASE [Сервис обмена книгами]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Сервис обмена книгами', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Сервис обмена книгами.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Сервис обмена книгами_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Сервис обмена книгами_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Сервис обмена книгами] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Сервис обмена книгами].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Сервис обмена книгами] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET ARITHABORT OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Сервис обмена книгами] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Сервис обмена книгами] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Сервис обмена книгами] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Сервис обмена книгами] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Сервис обмена книгами] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Сервис обмена книгами] SET  MULTI_USER 
GO
ALTER DATABASE [Сервис обмена книгами] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Сервис обмена книгами] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Сервис обмена книгами] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Сервис обмена книгами] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Сервис обмена книгами]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Author](
	[Author_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[_name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Author_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[Book_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Book_title] [varchar](70) NOT NULL,
	[Number_of_pages] [smallint] NULL,
	[Publication_date] [date] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book_Author]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Author](
	[BookID] [smallint] NOT NULL,
	[AuthorID] [smallint] NOT NULL,
 CONSTRAINT [PK_Book_Author] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book_Genre]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book_Genre](
	[BookID] [smallint] NOT NULL,
	[GenreName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Book_Genre] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[GenreName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genre](
	[Genre_name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Genre_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Message]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Message_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sender_Id] [smallint] NOT NULL,
	[Receiver_Id] [smallint] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offers]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[User_Id] [smallint] NOT NULL,
	[Book_Id] [smallint] NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Book_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settlement]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Settlement](
	[Settlement_name] [varchar](50) NOT NULL,
	[Type] [varchar](20) NOT NULL,
	[Population] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Settlement_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[_name] [varchar](20) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[Login] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Date_of_birth] [date] NULL,
	[Phone_number] [varchar](15) NULL,
	[Settlement] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wishes]    Script Date: 23.12.2020 20:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishes](
	[User_Id] [smallint] NOT NULL,
	[Book_Id] [smallint] NOT NULL,
 CONSTRAINT [PK_Wishes] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Book_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Book_Genre]    Script Date: 23.12.2020 20:08:19 ******/
CREATE NONCLUSTERED INDEX [IX_Book_Genre] ON [dbo].[Book_Genre]
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book_Author]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author_author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([Author_Id])
GO
ALTER TABLE [dbo].[Book_Author] CHECK CONSTRAINT [FK_Book_Author_author]
GO
ALTER TABLE [dbo].[Book_Author]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([Book_Id])
GO
ALTER TABLE [dbo].[Book_Author] CHECK CONSTRAINT [FK_Book_Author_Book]
GO
ALTER TABLE [dbo].[Book_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([Book_Id])
GO
ALTER TABLE [dbo].[Book_Genre] CHECK CONSTRAINT [FK_Book_Genre_Book]
GO
ALTER TABLE [dbo].[Book_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre_Genre] FOREIGN KEY([GenreName])
REFERENCES [dbo].[Genre] ([Genre_name])
GO
ALTER TABLE [dbo].[Book_Genre] CHECK CONSTRAINT [FK_Book_Genre_Genre]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_ToReceiver] FOREIGN KEY([Receiver_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_ToReceiver]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_ToSender] FOREIGN KEY([Sender_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_ToSender]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Book] FOREIGN KEY([Book_Id])
REFERENCES [dbo].[Book] ([Book_Id])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Book]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Settlement] FOREIGN KEY([Settlement])
REFERENCES [dbo].[Settlement] ([Settlement_name])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Settlement]
GO
ALTER TABLE [dbo].[Wishes]  WITH CHECK ADD  CONSTRAINT [FK_Wishes_Book] FOREIGN KEY([Book_Id])
REFERENCES [dbo].[Book] ([Book_Id])
GO
ALTER TABLE [dbo].[Wishes] CHECK CONSTRAINT [FK_Wishes_Book]
GO
ALTER TABLE [dbo].[Wishes]  WITH CHECK ADD  CONSTRAINT [FK_Wishes_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Wishes] CHECK CONSTRAINT [FK_Wishes_User]
GO
USE [master]
GO
ALTER DATABASE [Сервис обмена книгами] SET  READ_WRITE 
GO
