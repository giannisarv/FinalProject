
/****** Object:  Database [FinalProject]    Script Date: 14/6/2018 8:39:05 μμ ******/
CREATE DATABASE [FinalProject]
GO
USE [FinalProject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [FinalProject]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14/6/2018 8:39:05 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 14/6/2018 8:39:07 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[ID] [bigint] NOT NULL,
	[ProjectID] [bigint] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 14/6/2018 8:39:07 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Avatar] [nvarchar](255) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonPackage]    Script Date: 14/6/2018 8:39:07 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonPackage](
	[PackageID] [bigint] NOT NULL,
	[PersonID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 14/6/2018 8:39:07 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ID] [bigint] NOT NULL,
	[PersonID] [bigint] NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[HeroURL] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[Goal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Update]    Script Date: 14/6/2018 8:39:07 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Update](
	[ID] [bigint] NOT NULL,
	[ProjectID] [bigint] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DateOfUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Update] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_Project]
GO
ALTER TABLE [dbo].[PersonPackage]  WITH CHECK ADD  CONSTRAINT [FK_PersonPackage_Package] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Package] ([ID])
GO
ALTER TABLE [dbo].[PersonPackage] CHECK CONSTRAINT [FK_PersonPackage_Package]
GO
ALTER TABLE [dbo].[PersonPackage]  WITH CHECK ADD  CONSTRAINT [FK_PersonPackage_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonPackage] CHECK CONSTRAINT [FK_PersonPackage_Person]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Category]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Person]
GO
ALTER TABLE [dbo].[Update]  WITH CHECK ADD  CONSTRAINT [FK_Update_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[Update] CHECK CONSTRAINT [FK_Update_Project]
GO
USE [master]
GO
ALTER DATABASE [FinalProject] SET  READ_WRITE 
GO
