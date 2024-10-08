USE [master]
GO
/****** Object:  Database [BancoDb]    Script Date: 27/8/2024 22:18:16 ******/
CREATE DATABASE [BancoDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancoDb', FILENAME = N'F:\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\BancoDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancoDb_log', FILENAME = N'F:\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\BancoDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BancoDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancoDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancoDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancoDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancoDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancoDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancoDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancoDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancoDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancoDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancoDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancoDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancoDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancoDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancoDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancoDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancoDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BancoDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancoDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancoDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancoDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancoDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancoDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BancoDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancoDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BancoDb] SET  MULTI_USER 
GO
ALTER DATABASE [BancoDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancoDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancoDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancoDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancoDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BancoDb] SET QUERY_STORE = OFF
GO
USE [BancoDb]
GO
/****** Object:  User [docentes22]    Script Date: 27/8/2024 22:18:16 ******/
CREATE USER [docentes22] FOR LOGIN [docentes22] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/8/2024 22:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
	[APELLIDO] [varchar](100) NULL,
	[DNI] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUENTA]    Script Date: 27/8/2024 22:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUENTA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CBU] [varchar](100) NULL,
	[SALDO] [decimal](18, 2) NULL,
	[TIPO_CUENTA_ID] [int] NULL,
	[ULTIMO_MOVIMIENTO] [datetime] NULL,
	[CLIENTE_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_CUENTA]    Script Date: 27/8/2024 22:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_CUENTA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (1, N'PEPE', N'PEPITO', N'123456789')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (2, N'JUAN', N'JUANCITO', N'253545646')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (3, N'Diego', N'Pineda', N'23332')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (4, N'ivan', N'jdjdjd', N'454747')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (5, N'nombre', N'apellido', N'12345')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (6, N'federico', N'ventanal', N'43934543')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (7, N'mateo', N'dellacqua', N'42854808')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (8, N'Eze', N'Miarka', N'33478996')
INSERT [dbo].[Cliente] ([ID], [NOMBRE], [APELLIDO], [DNI]) VALUES (9, N'paolo', N'pacheco', N'43450796')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[CUENTA] ON 

INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (1, N'12344343', CAST(2344.00 AS Decimal(18, 2)), 1, CAST(N'2020-08-27T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (2, N'405817171', CAST(1500.50 AS Decimal(18, 2)), 1, CAST(N'2024-08-27T21:14:09.683' AS DateTime), 1)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (3, N'405817171', CAST(1500.50 AS Decimal(18, 2)), 1, CAST(N'2024-08-27T21:28:41.567' AS DateTime), 1)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (4, N'sdfsdfadas', CAST(0.00 AS Decimal(18, 2)), 1, CAST(N'2024-08-27T21:53:28.700' AS DateTime), 7)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (5, N'agus-asdasda', CAST(500.00 AS Decimal(18, 2)), 2, CAST(N'2024-08-27T21:59:36.847' AS DateTime), 7)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (6, N'paolin', CAST(70.00 AS Decimal(18, 2)), 4, CAST(N'2024-08-27T22:00:54.623' AS DateTime), 8)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (7, N'papa-123123asf', CAST(800.00 AS Decimal(18, 2)), 4, CAST(N'2024-08-27T22:04:33.380' AS DateTime), 9)
INSERT [dbo].[CUENTA] ([ID], [CBU], [SALDO], [TIPO_CUENTA_ID], [ULTIMO_MOVIMIENTO], [CLIENTE_ID]) VALUES (8, N'405817171', CAST(1500.50 AS Decimal(18, 2)), 1, CAST(N'2024-08-27T22:08:58.093' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CUENTA] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPO_CUENTA] ON 

INSERT [dbo].[TIPO_CUENTA] ([ID], [NOMBRE]) VALUES (1, N'CREDITO')
INSERT [dbo].[TIPO_CUENTA] ([ID], [NOMBRE]) VALUES (2, N'DEBITO')
INSERT [dbo].[TIPO_CUENTA] ([ID], [NOMBRE]) VALUES (3, N'CHEQUES')
INSERT [dbo].[TIPO_CUENTA] ([ID], [NOMBRE]) VALUES (4, N'MERCADOOOO')
SET IDENTITY_INSERT [dbo].[TIPO_CUENTA] OFF
GO
ALTER TABLE [dbo].[CUENTA]  WITH CHECK ADD FOREIGN KEY([CLIENTE_ID])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[CUENTA]  WITH CHECK ADD FOREIGN KEY([TIPO_CUENTA_ID])
REFERENCES [dbo].[TIPO_CUENTA] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CUENTA]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_CUENTA]
@ID INT,
@CBU VARCHAR(100),
@SALDO DECIMAL(18,2),
@ULTIMO_MOVIMIENTO DATETIME,
@TIPO_CUENTA_ID INT
AS
BEGIN
UPDATE CUENTA SET CBU = @CBU , 
ULTIMO_MOVIMIENTO = @ULTIMO_MOVIMIENTO,
TIPO_CUENTA_ID  = @TIPO_CUENTA_ID
WHERE ID = @ID
END;
GO
/****** Object:  StoredProcedure [dbo].[CREAR_CLIENTE]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREAR_CLIENTE]
@NOMBRE VARCHAR(100),
@APELLIDO VARCHAR(100),
@DNI VARCHAR(100)
AS
BEGIN
INSERT INTO  CLIENTE(NOMBRE,APELLIDO,
DNI)
VALUES(@NOMBRE,@APELLIDO,
@DNI)
END
GO
/****** Object:  StoredProcedure [dbo].[CREAR_CUENTA]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREAR_CUENTA]
@CBU VARCHAR(100),@SALDO DECIMAL(18,2),
@TIPO_CUENTA_ID INT,
@ULTIMO_MOVIMIENTO DATETIME,
@CLIENTE_ID INT
AS
BEGIN
INSERT INTO  CUENTA(CBU,SALDO,
TIPO_CUENTA_ID,ULTIMO_MOVIMIENTO,CLIENTE_ID)
VALUES(@CBU,@SALDO,
@TIPO_CUENTA_ID,@ULTIMO_MOVIMIENTO,@CLIENTE_ID)
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_CLIENTES]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_CLIENTES]
AS
BEGIN
SELECT
ID,NOMBRE,APELLIDO,DNI
FROM CLIENTE
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_CUENTAS]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_CUENTAS]
AS
BEGIN
SELECT
CU.ID,CBU,SALDO,TP.NOMBRE AS NOMBRE_CUENTA , TP.ID AS TIPO_CUENTA_ID , ULTIMO_MOVIMIENTO , CLIENTE_ID
FROM CUENTA CU
JOIN TIPO_CUENTA TP ON TP.ID = CU.TIPO_CUENTA_ID
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_TIPOS_CUENTAS]    Script Date: 27/8/2024 22:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_TIPOS_CUENTAS]
AS
BEGIN
SELECT
ID,NOMBRE
FROM TIPO_CUENTA
END
GO
USE [master]
GO
ALTER DATABASE [BancoDb] SET  READ_WRITE 
GO
