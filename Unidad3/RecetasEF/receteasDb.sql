USE [master]
GO
/****** Object:  Database [recetas_db]    Script Date: 02/10/2024 16:29:32 ******/
CREATE DATABASE [recetas_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'recetas_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\recetas_db.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'recetas_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\recetas_db_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [recetas_db] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [recetas_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [recetas_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [recetas_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [recetas_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [recetas_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [recetas_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [recetas_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [recetas_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [recetas_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [recetas_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [recetas_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [recetas_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [recetas_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [recetas_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [recetas_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [recetas_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [recetas_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [recetas_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [recetas_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [recetas_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [recetas_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [recetas_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [recetas_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [recetas_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [recetas_db] SET  MULTI_USER 
GO
ALTER DATABASE [recetas_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [recetas_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [recetas_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [recetas_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [recetas_db] SET DELAYED_DURABILITY = DISABLED 
GO
USE [recetas_db]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 02/10/2024 16:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[id_ingrediente] [int] NOT NULL,
	[n_ingrediente] [varchar](50) NOT NULL,
	[cantidad] [float] NOT NULL,
	[id_receta] [int] NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[id_ingrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recetas]    Script Date: 02/10/2024 16:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recetas](
	[id_receta] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cheff] [varchar](100) NULL,
 CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[id_receta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [cantidad], [id_receta]) VALUES (2, N'Azúcar', 100, 2)
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [cantidad], [id_receta]) VALUES (3, N'Huevo', 5, 2)
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [cantidad], [id_receta]) VALUES (4, N'vainilla', 0.05, 3)
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [cantidad], [id_receta]) VALUES (5, N'Salchichas', 3, 1)
INSERT [dbo].[Ingredientes] ([id_ingrediente], [n_ingrediente], [cantidad], [id_receta]) VALUES (6, N'Manteca', 100, 1)
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff]) VALUES (1, N'Salchipapas', N'Gastón Acurio')
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff]) VALUES (2, N'Alfajor Hojaldre Cacao', N'Mercedes Nazzeta')
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff]) VALUES (3, N'Sponge Cake', N'Osvaldo Gross')
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff]) VALUES (4, N'Sablee de almedras', N'The Gourmand')
INSERT [dbo].[Recetas] ([id_receta], [nombre], [cheff]) VALUES (5, N'Canelle au Rhum', NULL)
ALTER TABLE [dbo].[Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_Ingredientes_Recetas] FOREIGN KEY([id_receta])
REFERENCES [dbo].[Recetas] ([id_receta])
GO
ALTER TABLE [dbo].[Ingredientes] CHECK CONSTRAINT [FK_Ingredientes_Recetas]
GO
USE [master]
GO
ALTER DATABASE [recetas_db] SET  READ_WRITE 
GO
