USE [master]
GO
/****** Object:  Database [dbNet]    Script Date: 21/06/2017 08:36:28 ******/
CREATE DATABASE [dbNet]
 CONTAINMENT = NONE
ALTER DATABASE [dbNet] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbNet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbNet] SET RECOVERY FULL 
GO
ALTER DATABASE [dbNet] SET  MULTI_USER 
GO
ALTER DATABASE [dbNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbNet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbNet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbNet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbNet] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbNet', N'ON'
GO
ALTER DATABASE [dbNet] SET QUERY_STORE = OFF
GO
USE [dbNet]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dbNet]
GO
/****** Object:  Table [dbo].[T_ARTICLE]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ARTICLE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adminID] [int] NOT NULL,
	[creationDate] [datetime] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[nbViews] [int] NOT NULL,
 CONSTRAINT [PK_T_ARTICLE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_ARTICLE_LIKE]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ARTICLE_LIKE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[articleID] [int] NOT NULL,
 CONSTRAINT [PK_T_ARTICLE_LIKE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_ARTICLE_RESOURCES]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ARTICLE_RESOURCES](
	[articleID] [int] NOT NULL,
	[resourceID] [int] NOT NULL,
 CONSTRAINT [PK_T_ARTICLE_RESOURCES] PRIMARY KEY CLUSTERED 
(
	[articleID] ASC,
	[resourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_COMMENT_ARTICLE]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_COMMENT_ARTICLE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[articleID] [int] NOT NULL,
	[creationDate] [datetime] NOT NULL,
	[commentContent] [text] NOT NULL,
 CONSTRAINT [PK_T_COMMENT_ARTICLE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_LANGUAGE]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_LANGUAGE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[language] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_LANGUAGE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_RESOURCES]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_RESOURCES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [text] NOT NULL,
	[path] [varchar](255) NOT NULL,
	[languageID] [int] NOT NULL,
 CONSTRAINT [PK_T_RESOURCES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_ROLE]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ROLE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_ROLE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_TRANSLATION]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TRANSLATION](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[articleID] [int] NOT NULL,
	[translatorID] [int] NOT NULL,
	[language] [int] NOT NULL,
	[translationArticleContent] [text] NOT NULL,
	[translationArticleTitle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_TRADUCTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_USER]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_USER](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pseudo] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[roleID] [int] NOT NULL,
 CONSTRAINT [PK_T_USER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[T_ARTICLE]  WITH CHECK ADD  CONSTRAINT [FK_T_ARTICLE_T_USER] FOREIGN KEY([adminID])
REFERENCES [dbo].[T_USER] ([id])
GO
ALTER TABLE [dbo].[T_ARTICLE] CHECK CONSTRAINT [FK_T_ARTICLE_T_USER]
GO
ALTER TABLE [dbo].[T_ARTICLE_LIKE]  WITH CHECK ADD  CONSTRAINT [FK_T_ARTICLE_LIKE_T_ARTICLE] FOREIGN KEY([articleID])
REFERENCES [dbo].[T_ARTICLE] ([id])
GO
ALTER TABLE [dbo].[T_ARTICLE_LIKE] CHECK CONSTRAINT [FK_T_ARTICLE_LIKE_T_ARTICLE]
GO
ALTER TABLE [dbo].[T_ARTICLE_LIKE]  WITH CHECK ADD  CONSTRAINT [FK_T_ARTICLE_LIKE_T_USER] FOREIGN KEY([userID])
REFERENCES [dbo].[T_USER] ([id])
GO
ALTER TABLE [dbo].[T_ARTICLE_LIKE] CHECK CONSTRAINT [FK_T_ARTICLE_LIKE_T_USER]
GO
ALTER TABLE [dbo].[T_ARTICLE_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_T_ARTICLE_RESOURCES_T_ARTICLE] FOREIGN KEY([articleID])
REFERENCES [dbo].[T_ARTICLE] ([id])
GO
ALTER TABLE [dbo].[T_ARTICLE_RESOURCES] CHECK CONSTRAINT [FK_T_ARTICLE_RESOURCES_T_ARTICLE]
GO
ALTER TABLE [dbo].[T_ARTICLE_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_T_ARTICLE_RESOURCES_T_RESOURCES] FOREIGN KEY([resourceID])
REFERENCES [dbo].[T_RESOURCES] ([id])
GO
ALTER TABLE [dbo].[T_ARTICLE_RESOURCES] CHECK CONSTRAINT [FK_T_ARTICLE_RESOURCES_T_RESOURCES]
GO
ALTER TABLE [dbo].[T_COMMENT_ARTICLE]  WITH CHECK ADD  CONSTRAINT [FK_T_COMMENT_ARTICLE_T_ARTICLE] FOREIGN KEY([articleID])
REFERENCES [dbo].[T_ARTICLE] ([id])
GO
ALTER TABLE [dbo].[T_COMMENT_ARTICLE] CHECK CONSTRAINT [FK_T_COMMENT_ARTICLE_T_ARTICLE]
GO
ALTER TABLE [dbo].[T_COMMENT_ARTICLE]  WITH CHECK ADD  CONSTRAINT [FK_T_COMMENT_ARTICLE_T_USER] FOREIGN KEY([userID])
REFERENCES [dbo].[T_USER] ([id])
GO
ALTER TABLE [dbo].[T_COMMENT_ARTICLE] CHECK CONSTRAINT [FK_T_COMMENT_ARTICLE_T_USER]
GO
ALTER TABLE [dbo].[T_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_T_RESOURCES_T_RESOURCES] FOREIGN KEY([languageID])
REFERENCES [dbo].[T_LANGUAGE] ([id])
GO
ALTER TABLE [dbo].[T_RESOURCES] CHECK CONSTRAINT [FK_T_RESOURCES_T_RESOURCES]
GO
ALTER TABLE [dbo].[T_TRANSLATION]  WITH CHECK ADD  CONSTRAINT [FK_T_TRADUCTION_T_ARTICLE] FOREIGN KEY([articleID])
REFERENCES [dbo].[T_ARTICLE] ([id])
GO
ALTER TABLE [dbo].[T_TRANSLATION] CHECK CONSTRAINT [FK_T_TRADUCTION_T_ARTICLE]
GO
ALTER TABLE [dbo].[T_TRANSLATION]  WITH CHECK ADD  CONSTRAINT [FK_T_TRADUCTION_T_USER] FOREIGN KEY([translatorID])
REFERENCES [dbo].[T_USER] ([id])
GO
ALTER TABLE [dbo].[T_TRANSLATION] CHECK CONSTRAINT [FK_T_TRADUCTION_T_USER]
GO
ALTER TABLE [dbo].[T_TRANSLATION]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANSLATION_T_LANGUAGE] FOREIGN KEY([language])
REFERENCES [dbo].[T_LANGUAGE] ([id])
GO
ALTER TABLE [dbo].[T_TRANSLATION] CHECK CONSTRAINT [FK_T_TRANSLATION_T_LANGUAGE]
GO
ALTER TABLE [dbo].[T_USER]  WITH CHECK ADD  CONSTRAINT [FK_T_USER_T_USER] FOREIGN KEY([roleID])
REFERENCES [dbo].[T_ROLE] ([id])
GO
ALTER TABLE [dbo].[T_USER] CHECK CONSTRAINT [FK_T_USER_T_USER]
GO
/****** Object:  StoredProcedure [dbo].[CreateArticle]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateArticle]
	-- Add the parameters for the stored procedure here
	@adminID int,
	@creationDate datetime,
	@status varchar(50),
	@nbViews int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_ARTICLE(adminID, creationDate, status, nbViews)
	VALUES(@adminID, @creationDate, @status, @nbViews)

	select id from T_ARTICLE where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateArticle_Like]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateArticle_Like]
	-- Add the parameters for the stored procedure here
	@userID int,
	@articleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_ARTICLE_LIKE(userID, articleID)
	VALUES(@userID, @articleID)

	select id from T_ARTICLE_LIKE where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateComment_Article]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateComment_Article]
	-- Add the parameters for the stored procedure here
	@userID int,
	@articleID int,
	@creationDate datetime,
	@commentContent text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_COMMENT_ARTICLE(userID, articleID, creationDate, commentContent)
	VALUES(@userID, @articleID, @creationDate, @commentContent)

	select id from T_COMMENT_ARTICLE where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateLanguage]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateLanguage]
	-- Add the parameters for the stored procedure here
	@language varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
INSERT INTO T_LANGUAGE(language)
	VALUES(@language)

	select id from T_LANGUAGE where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateResources]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateResources]
	-- Add the parameters for the stored procedure here
	@title varchar(50),
	@description text,
	@path varchar(255),
	@languageID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_RESOURCES(title, description, path, languageID)
	VALUES(@title, @description, @path, @languageID)

	select id from T_RESOURCES where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateRole]
	-- Add the parameters for the stored procedure here
	@role varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_ROLE(role)
	VALUES(@role)

	select id from T_ROLE where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateTranslation]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateTranslation]
	-- Add the parameters for the stored procedure here
	@articleID int,
	@translatorID int,
	@language int,
	@translationArticleContent text,
	@translationArticleTitle varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_TRANSLATION(articleID, translatorID, language, translationArticleContent, translationArticleTitle)
	VALUES(@articleID, @translatorID, @language, @translationArticleContent, @translationArticleTitle)

	select id from T_TRANSLATION where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	-- Add the parameters for the stored procedure here
	@pseudo varchar(50),
	@email varchar(50),
	@password varchar(50),
	@roleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO T_USER(pseudo, email, password, roleID)
	VALUES(@pseudo, @email, @password, @roleID)

	select id from T_USER where id  = scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteArticle]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteArticle]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_ARTICLE WHERE @id = id

	SELECT id FROM T_ARTICLE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteArticle_Like]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteArticle_Like]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_ARTICLE_LIKE WHERE @id = id

	SELECT id FROM T_ARTICLE_LIKE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteComment_Article]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteComment_Article]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_COMMENT_ARTICLE WHERE @id = id

	SELECT id FROM T_COMMENT_ARTICLE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteLanguage]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLanguage]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_LANGUAGE WHERE @id = id

	SELECT id FROM T_LANGUAGE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteResources]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteResources]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_RESOURCES WHERE @id = id

	SELECT id FROM T_RESOURCES WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRole]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_ROLE WHERE @id = id

	SELECT id FROM T_ROLE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteTranslation]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTranslation]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_TRANSLATION WHERE @id = id

	SELECT id FROM T_TRANSLATION WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM T_USER WHERE @id = id

	SELECT id FROM T_USER WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetArticle]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetArticle]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_ARTICLE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[GetArticle_Like]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetArticle_Like]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_ARTICLE_LIKE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[GetComment_Article]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetComment_Article]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_COMMENT_ARTICLE WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetLanguage]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLanguage]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_LANGUAGE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[GetResources]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetResources]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_RESOURCES WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRole]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_ROLE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[GetTranslation]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTranslation]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_TRANSLATION WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUser]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM T_USER WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateArticle]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateArticle]
	-- Add the parameters for the stored procedure here
	@id int,
	@adminID int = NULL,
	@creationDate datetime = NULL,
	@status varchar(50) = NULL,
	@nbViews int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_ARTICLE
	SET
		adminID = IsNull(@adminID, adminID),
		creationDate = IsNull(@creationDate, creationDate),
		status = IsNull(@status, status),
		nbViews = isNull(@nbViews, nbViews)
	WHERE @id = id

	SELECT adminID, creationDate, status, nbViews FROM T_ARTICLE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateArticle_Like]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateArticle_Like]
	-- Add the parameters for the stored procedure here
	@id int,
	@userID int = NULL,
	@articleID int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_ARTICLE_LIKE
	SET
		userID = IsNull(@userID, userID),
		articleID = IsNull(@articleID, articleID)
	WHERE @id = id

	SELECT userID, articleID FROM T_ARTICLE_LIKE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateComment_Article]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateComment_Article]
	-- Add the parameters for the stored procedure here
	@id int,
	@userID int = NULL,
	@articleID int = NULL,
	@creationDate datetime = NULL,
	@commentContent text = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_COMMENT_ARTICLE
	SET
		userID = IsNull(@userID, userID),
		articleID = IsNull(@articleID, articleID),
		creationDate = IsNull(@creationDate, creationDate),
		commentContent = isNull(@commentContent, commentContent)
	WHERE @id = id

	SELECT userID, articleID, creationDate, commentContent FROM T_COMMENT_ARTICLE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateLanguage]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLanguage]
	-- Add the parameters for the stored procedure here
	@id int,
	@language varchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_LANGUAGE
	SET
		language = IsNull(@language, language)
	WHERE @id = id

	SELECT language FROM T_LANGUAGE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateResources]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateResources]
	-- Add the parameters for the stored procedure here
	@id int,
	@title varchar(50) = NULL,
	@description text = NULL,
	@path varchar(255) = NULL,
	@languageID int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_RESOURCES
	SET
		title = IsNull(@title, title),
		description = IsNull(@description, description),
		path = IsNull(@path, path),
		languageID = isNull(@languageID, languageID)
	WHERE @id = id

	SELECT title, description, path, languageID FROM T_RESOURCES WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateRole]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRole]
	-- Add the parameters for the stored procedure here
	@id int,
	@role varchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_ROLE
	SET
		role = IsNull(@role, role)
	WHERE @id = id

	SELECT role FROM T_ROLE WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateTranslation]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTranslation]
	-- Add the parameters for the stored procedure here
	@id int,
	@articleID int = NULL,
	@translatorID int = NULL,
	@language int = NULL,
	@translationArticleContent text = NULL,
	@translationArticleTitle varchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_TRANSLATION
	SET
		articleID = IsNull(@articleID, articleID),
		translatorID = IsNull(@translatorID, translatorID),
		language = IsNull(@language, language),
		translationArticleContent = isNull(@translationArticleContent, translationArticleContent),
		translationArticleTitle = isNull(@translationArticleTitle, translationArticleTitle)
	WHERE @id = id

	SELECT articleID, translatorID, language, translationArticleContent, translationArticleTitle FROM T_TRANSLATION WHERE @id = id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 21/06/2017 08:36:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@id int,
	@pseudo varchar(50) = NULL,
	@email varchar(50) = NULL,
	@password varchar(50) = NULL,
	@roleID int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE T_USER
	SET
		pseudo = IsNull(@pseudo, pseudo),
		email = IsNull(@email, email),
		password = IsNull(@password, password),
		roleID = isNull(@roleID, roleID)
	WHERE @id = id

	SELECT pseudo, email, password, roleID FROM T_User WHERE @id = id
END

GO
USE [master]
GO
ALTER DATABASE [dbNet] SET  READ_WRITE 
GO
