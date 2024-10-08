USE [master]
GO
/****** Object:  Database [db_productos]    Script Date: 02/10/2024 22:44:05 ******/
CREATE DATABASE [db_productos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_productos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\db_productos.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_productos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\db_productos_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_productos] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_productos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_productos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_productos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_productos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_productos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_productos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_productos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_productos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_productos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_productos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_productos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_productos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_productos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_productos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_productos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_productos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_productos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_productos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_productos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_productos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_productos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_productos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_productos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_productos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_productos] SET  MULTI_USER 
GO
ALTER DATABASE [db_productos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_productos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_productos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_productos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_productos] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_productos]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 02/10/2024 22:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
	[precio] [real] NOT NULL,
	[fecha_baja] [datetime] NULL,
	[motivo_baja] [nchar](50) NULL,
 CONSTRAINT [PK_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[PRODUCTOS] ON 

INSERT [dbo].[PRODUCTOS] ([codigo], [nombre], [precio], [fecha_baja], [motivo_baja]) VALUES (1, N'Chicle                                            ', 1000, NULL, NULL)
INSERT [dbo].[PRODUCTOS] ([codigo], [nombre], [precio], [fecha_baja], [motivo_baja]) VALUES (2, N'Gaseosa                                           ', 1500, NULL, NULL)
INSERT [dbo].[PRODUCTOS] ([codigo], [nombre], [precio], [fecha_baja], [motivo_baja]) VALUES (3, N'Sandwich Jamón Serrano                            ', 4000, NULL, NULL)
INSERT [dbo].[PRODUCTOS] ([codigo], [nombre], [precio], [fecha_baja], [motivo_baja]) VALUES (4, N'Café                                              ', 1300, CAST(N'2024-10-02 22:36:37.070' AS DateTime), N'No funciona Máquina                               ')
INSERT [dbo].[PRODUCTOS] ([codigo], [nombre], [precio], [fecha_baja], [motivo_baja]) VALUES (5, N'Cerveza                                           ', 2500, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PRODUCTOS] OFF
USE [master]
GO
ALTER DATABASE [db_productos] SET  READ_WRITE 
GO
