USE [master]
GO

CREATE DATABASE [PharmacyTest]
GO

USE [PharmacyTest]
GO

CREATE TABLE Product(
  Id int IDENTITY(1,1) PRIMARY KEY,
  Name nvarchar(30) NOT NULL UNIQUE
)

CREATE TABLE [Pharmacy](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nchar](30) NOT NULL,
	[Address] [nchar](30) NOT NULL,
	[Phone] [nchar](12)
)

CREATE TABLE [Storage](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[PharmacyId] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	FOREIGN KEY (PharmacyId) REFERENCES [Pharmacy] (Id) ON DELETE CASCADE,
)

CREATE TABLE [Batch](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[ProductId] [int] NOT NULL,
	[StorageId] [int] NOT NULL,
	[Total] [int] NOT NULL,
	FOREIGN KEY (ProductId) REFERENCES [Product] (Id) ON DELETE CASCADE,
	FOREIGN KEY (StorageId) REFERENCES [Storage] (Id) ON DELETE CASCADE,
)


INSERT [Product] ([Name]) VALUES (N'Парацетамол')
INSERT [Product] ([Name]) VALUES (N'Анальгин')
INSERT [Product] ([Name]) VALUES (N'Ринонорм')
INSERT [Product] ([Name]) VALUES (N'Ремантадин')
INSERT [Product] ([Name]) VALUES (N'Компливит')

INSERT [Pharmacy] ([Name], [Address], [Phone]) VALUES (N'Невис','Ул.Пушкина, дом 2', '88005553535')
INSERT [Pharmacy] ([Name], [Address], [Phone]) VALUES (N'Озерки','Ул.Ясная, дом 2', '88005553636')
INSERT [Pharmacy] ([Name], [Address], [Phone]) VALUES (N'Петербургские аптеки','Ул.Горная, дом 2', '88005553737')

INSERT [Storage] ([PharmacyId], [Name]) VALUES (1, N'Гор')
INSERT [Storage] ([PharmacyId], [Name]) VALUES (1, N'Самойлов')
INSERT [Storage] ([PharmacyId], [Name]) VALUES (1, N'Инерский')
INSERT [Storage] ([PharmacyId], [Name]) VALUES (2, N'ВиО')
INSERT [Storage] ([PharmacyId], [Name]) VALUES (3, N'Инер')

INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (1, 1, 200)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (1, 1, 150)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (2, 1, 100)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (3, 1, 300)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (4, 1, 300)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (5, 1, 400)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (5, 1, 200)
INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES (5, 1, 100)
