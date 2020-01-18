USE [master]
GO

/****** Object:  Database [RedDragon]    Script Date: 17/01/2020 21:13:39 ******/
CREATE DATABASE [RedDragon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RedDragon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.WEB17\MSSQL\DATA\RedDragon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RedDragon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.WEB17\MSSQL\DATA\RedDragon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [RedDragon] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RedDragon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [RedDragon] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [RedDragon] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [RedDragon] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [RedDragon] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [RedDragon] SET ARITHABORT OFF 
GO

ALTER DATABASE [RedDragon] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [RedDragon] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [RedDragon] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [RedDragon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [RedDragon] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [RedDragon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [RedDragon] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [RedDragon] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [RedDragon] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [RedDragon] SET  DISABLE_BROKER 
GO

ALTER DATABASE [RedDragon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [RedDragon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [RedDragon] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [RedDragon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [RedDragon] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [RedDragon] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [RedDragon] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [RedDragon] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [RedDragon] SET  MULTI_USER 
GO

ALTER DATABASE [RedDragon] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [RedDragon] SET DB_CHAINING OFF 
GO

ALTER DATABASE [RedDragon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [RedDragon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [RedDragon] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [RedDragon] SET QUERY_STORE = OFF
GO

ALTER DATABASE [RedDragon] SET  READ_WRITE 
GO


