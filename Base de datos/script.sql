USE [master]
GO
/****** Object:  Database [Sistema_prestamos]    Script Date: 7/16/2020 1:10:41 AM ******/
CREATE DATABASE [Sistema_prestamos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sistema_prestamos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Sistema_prestamos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sistema_prestamos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Sistema_prestamos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Sistema_prestamos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sistema_prestamos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sistema_prestamos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sistema_prestamos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sistema_prestamos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sistema_prestamos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sistema_prestamos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET RECOVERY FULL 
GO
ALTER DATABASE [Sistema_prestamos] SET  MULTI_USER 
GO
ALTER DATABASE [Sistema_prestamos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sistema_prestamos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sistema_prestamos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sistema_prestamos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sistema_prestamos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sistema_prestamos', N'ON'
GO
ALTER DATABASE [Sistema_prestamos] SET QUERY_STORE = OFF
GO
USE [Sistema_prestamos]
GO
/****** Object:  Table [dbo].[Prestamos]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[Monto] [varchar](50) NOT NULL,
	[Interes] [varchar](50) NOT NULL,
	[fecha] [date] NOT NULL,
	[tiempo] [date] NOT NULL,
	[deuda] [money] NOT NULL,
	[cuota] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrar]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cedula] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Prestamos] ON 

INSERT [dbo].[Prestamos] ([Id], [Nombre], [Apellido], [cedula], [telefono], [Monto], [Interes], [fecha], [tiempo], [deuda], [cuota]) VALUES (33, N'Josue', N'Cruz', N'40226291317', N'8095094859', N'52000', N'2', CAST(N'2020-07-14' AS Date), CAST(N'2020-07-26' AS Date), 48600.0000, 4420.0000)
SET IDENTITY_INSERT [dbo].[Prestamos] OFF
SET IDENTITY_INSERT [dbo].[Registrar] ON 

INSERT [dbo].[Registrar] ([Id], [Nombre], [Apellido], [Cedula], [Telefono], [Fecha]) VALUES (10, N'Ciprian', N'Cruz', N'402', N'829', CAST(N'2020-07-14' AS Date))
INSERT [dbo].[Registrar] ([Id], [Nombre], [Apellido], [Cedula], [Telefono], [Fecha]) VALUES (8, N'Mayra', N'Cruz', N'4022629131', N'809509485', CAST(N'2020-06-10' AS Date))
INSERT [dbo].[Registrar] ([Id], [Nombre], [Apellido], [Cedula], [Telefono], [Fecha]) VALUES (7, N'Josue', N'Cruz', N'40226291317', N'8095094859', CAST(N'2020-06-10' AS Date))
INSERT [dbo].[Registrar] ([Id], [Nombre], [Apellido], [Cedula], [Telefono], [Fecha]) VALUES (9, N'david', N'perez', N'4022629132', N'8298167988', CAST(N'2020-06-13' AS Date))
SET IDENTITY_INSERT [dbo].[Registrar] OFF
/****** Object:  StoredProcedure [dbo].[Buscar]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscar]
@Id int
as
begin
select *from Registrar where Id=@Id;
end 
GO
/****** Object:  StoredProcedure [dbo].[buscarPrestamo]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[buscarPrestamo]  
@Cedula varchar(50)

as

 
select *from Prestamos where Cedula=@Cedula;
GO
/****** Object:  StoredProcedure [dbo].[buscarPrestamo1]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[buscarPrestamo1] 
as
select *from Prestamos;
GO
/****** Object:  StoredProcedure [dbo].[buscarPrestamos]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[buscarPrestamos]  
@cedula varchar(50)
as
select *from Prestamos where cedula=@cedula;
GO
/****** Object:  StoredProcedure [dbo].[Busqueda]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Busqueda]
@Cedula varchar(50)
as 
select *from Prestamos where cedula=@cedula;
GO
/****** Object:  StoredProcedure [dbo].[captar]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[captar]
@Cedula varchar(50)
as
begin
select *from Registrar where Cedula=@Cedula;
end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Eliminar]
@Id int 
as
delete from Registrar where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[EliminarPres]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[EliminarPres]
@Cedula varchar(50)
as 
delete from Prestamos where cedula=@cedula;
GO
/****** Object:  StoredProcedure [dbo].[Modificar]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Modificar]
@Nombre varchar(50),
@Apellido varchar(50),
@Cedula varchar(50),
@Telefono varchar(50),
@Fecha date,
@Id int
as 
begin
update Registrar set Nombre = @Nombre, Apellido=@Apellido,Cedula=@Cedula, Telefono=@Telefono,Fecha=@Fecha where id=@Id;
end 
GO
/****** Object:  StoredProcedure [dbo].[MOSTRAR]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[MOSTRAR]
AS
SELECT *FROM prestamos;
GO
/****** Object:  StoredProcedure [dbo].[prestamosRegistro]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[prestamosRegistro]
@Nombre varchar(50),
@Apellido varchar(50),
@Cedula varchar(50),
@Telefono varchar(50),
@Monto varchar(50),
@Interes varchar(50),
@Fecha DATE,
@tiempo date,
@Deuda money,
@Cuota money


as
begin
insert into Prestamos values
(@Nombre,@Apellido,@Cedula,@Telefono,@Monto,@Interes,@Fecha,@tiempo,@Deuda,@Cuota)
end

GO
/****** Object:  StoredProcedure [dbo].[PrestamosUpdate]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[PrestamosUpdate]
@deuda money,
@cedula varchar(50)
as
begin
update Prestamos set deuda=deuda - @deuda  where cedula=@cedula
end;
GO
/****** Object:  StoredProcedure [dbo].[Registrar2]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Registrar2]
as
select *from Registrar;
GO
/****** Object:  StoredProcedure [dbo].[Registro]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Registro]

as select *from Registrar;
GO
/****** Object:  StoredProcedure [dbo].[Registro1]    Script Date: 7/16/2020 1:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Registro1]
@Nombre varchar(50),
@Apellido varchar(50),
@Cedula varchar(50),
@Telefono varchar(50),
@Fecha date 
as 
begin 
insert into Registrar values(@Nombre,@Apellido,@Cedula,@Telefono,@Fecha)
end
GO
USE [master]
GO
ALTER DATABASE [Sistema_prestamos] SET  READ_WRITE 
GO
