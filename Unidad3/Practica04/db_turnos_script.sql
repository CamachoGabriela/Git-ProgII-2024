USE [master]
GO
/****** Object:  Database [db_turnos]    Script Date: 29/09/2024 14:42:18 ******/
CREATE DATABASE [db_turnos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_turnos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\db_turnos.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_turnos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSV\MSSQL\DATA\db_turnos_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_turnos] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_turnos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_turnos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_turnos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_turnos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_turnos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_turnos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_turnos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_turnos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_turnos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_turnos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_turnos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_turnos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_turnos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_turnos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_turnos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_turnos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_turnos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_turnos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_turnos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_turnos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_turnos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_turnos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_turnos] SET  MULTI_USER 
GO
ALTER DATABASE [db_turnos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_turnos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_turnos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_turnos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_turnos] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_turnos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_DETALLES_TURNO]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DETALLES_TURNO](
	[id_turno] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_T_DETALLES_TURNO] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC,
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_SERVICIOS]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_SERVICIOS](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[costo] [int] NOT NULL,
	[enPromocion] [varchar](1) NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_T_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_TURNOS]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_TURNOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](10) NULL,
	[hora] [varchar](5) NULL,
	[cliente] [varchar](100) NULL,
	[fecha_cancelacion] [datetime] NULL,
	[motivo_cancelacion] [varchar](50) NULL,
 CONSTRAINT [PK_T_TURNOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (0, N'Peinado', 10500, N'N', 0)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (1, N'Lavado de cabello', 500, N'N', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (2, N'Corte', 2000, N'S', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (3, N'Tintura', 3500, N'N', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (4, N'Alisado', 12000, N'N', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (5, N'Nutrición', 12500, N'S', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (6, N'Tratamiento de Keratina', 20000, N'N', 1)
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [activo]) VALUES (7, N'Peinado Evento', 15500, N'N', 1)
SET IDENTITY_INSERT [dbo].[T_TURNOS] ON 

INSERT [dbo].[T_TURNOS] ([id], [fecha], [hora], [cliente], [fecha_cancelacion], [motivo_cancelacion]) VALUES (2, N'22/09/2024', N'17:00', N'Ramon Perez', CAST(N'2024-09-24 00:00:00.000' AS DateTime), N'Trabajo')
INSERT [dbo].[T_TURNOS] ([id], [fecha], [hora], [cliente], [fecha_cancelacion], [motivo_cancelacion]) VALUES (3, N'23/09/2024', N'09:00', N'Nilda Sotomayor', NULL, NULL)
INSERT [dbo].[T_TURNOS] ([id], [fecha], [hora], [cliente], [fecha_cancelacion], [motivo_cancelacion]) VALUES (4, N'30/09/2024', N'18:00', N'Hector Guzman', NULL, NULL)
INSERT [dbo].[T_TURNOS] ([id], [fecha], [hora], [cliente], [fecha_cancelacion], [motivo_cancelacion]) VALUES (5, N'30/09/2024', N'18:00', N'Hector Guzman', NULL, NULL)
SET IDENTITY_INSERT [dbo].[T_TURNOS] OFF
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_SERVICIOS]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_SERVICIOS]
AS
BEGIN
SELECT * from T_SERVICIOS ORDER BY 2;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CONTAR_TURNOS]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONTAR_TURNOS]
 @fecha VARCHAR(10),
 @hora VARCHAR(8),
 @ctd_turnos INT OUTPUT
AS
BEGIN
 SET NOCOUNT ON;
 SELECT @ctd_turnos = COUNT(*)
 FROM T_TURNOS
 WHERE fecha = @fecha AND hora = @hora;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLES]    Script Date: 29/09/2024 14:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLES]
@id_turno int,
@id_servicio int,
@observaciones varchar(200)
AS
BEGIN
INSERT INTO T_DETALLES_TURNO(id_turno,id_servicio, observaciones)
 VALUES (@id_turno,@id_servicio, @observaciones);

END

GO
USE [master]
GO
ALTER DATABASE [db_turnos] SET  READ_WRITE 
GO
