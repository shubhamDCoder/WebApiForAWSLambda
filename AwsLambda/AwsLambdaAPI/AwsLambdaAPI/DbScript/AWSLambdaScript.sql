Create DataBase AwsLambda;

Go

Use AwsLambda
USE [AwsLambda]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 09-05-2022 20:51:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] CONSTRAINT [PK_CustomerId] PRIMARY KEY  IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL)
 

GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int]  CONSTRAINT [PK_StudentId] PRIMARY KEY  IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL);
	Go
go
	declare @count int = 1  
declare @max int = 5000  
delete from Customer  
while(@count <= @max)  
Begin  
insert into Customer(Name)  
select 'Name' + CAST(@count as varchar(5))  
set @count = @count + 1  
End  
go
 declare @count int = 1  
declare @max int = 5000  
delete from Student  
while(@count <= @max)  
Begin  
insert into Student(Name)  
select 'Student' + CAST(@count as varchar(5))  
set @count = @count + 1  
End  
go

go
Create Procedure GetData 
(  
 @PageSize int = 500  ,
 @TableName nvarchar(100),
 @PageNumber int=1

)  
As  
Begin 

DECLARE @Sql NVARCHAR(MAX);

SET @Sql = N'SELECT * FROM ' + QUOTENAME(@TableName)
          + N' ORDER BY 1 OFFSET '+Cast(@PageSize*(@PageNumber-1) as Nvarchar)
		  +N' Rows Fetch NEXT '+Cast(@PageSize as Nvarchar)
		  +' ROWS ONLY';

EXECUTE sp_executesql @Sql
End  



