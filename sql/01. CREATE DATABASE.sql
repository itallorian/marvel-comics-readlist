USE [master]
GO

CREATE DATABASE [COMICS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'COMICS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\COMICS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'COMICS_LOG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\COMICS_LOG.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [COMICS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [COMICS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [COMICS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [COMICS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [COMICS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [COMICS] SET ARITHABORT OFF 
GO

ALTER DATABASE [COMICS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [COMICS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [COMICS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [COMICS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [COMICS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [COMICS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [COMICS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [COMICS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [COMICS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [COMICS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [COMICS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [COMICS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [COMICS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [COMICS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [COMICS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [COMICS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [COMICS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [COMICS] SET RECOVERY FULL 
GO

ALTER DATABASE [COMICS] SET  MULTI_USER 
GO

ALTER DATABASE [COMICS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [COMICS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [COMICS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [COMICS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [COMICS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [COMICS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [COMICS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [COMICS] SET  READ_WRITE 
GO


