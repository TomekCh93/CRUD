USE master;  
GO  
CREATE DATABASE Crud
go
use Crud;
CREATE TABLE ProductInfo_Tab(
  [ProductID] int NOT NULL IDENTITY,
  [ItemName] nvarchar(50),
  [Design] nvarchar(250),
  [Color] nvarchar(50),
  [InsertDate] datetime,
  PRIMARY KEY ([ProductID])

)  ;


