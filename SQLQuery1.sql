USE MASTER
GO

IF DB_ID('School_DB') IS NOT NULL
DROP DATABASE[School_db]
GO

CREATE DATABASE [SChool_db]
GO

USE [School_db]
GO

--Roles For people, Students, Teacher, Working Students, Teacher Students.
CREATE TABLE Roles(
Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
Labels nvarchar(50) NOT NULL,
Role_Description nvarchar(500) NOT NULL,
)
GO

--People in School DB 
CREATE TABLE People(
Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(40) NOT NULL,
LastName nvarchar(40) NOT NULL,
Birth datetime NOT NULL,
Roles int NOT NULL CHECK(Roles > 0) FOREIGN KEY REFERENCES Roles(Id) ON DELETE CASCADE,
)

GO

--Curricular Units
CREATE TABLE Curricular_Units(
Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
Unit_Name nvarchar(120) NOT NULL,
Objectives nvarchar(400) NOT NULL,
)
GO

--Class Details
CREATE TABLE Class_Details(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1), 
Curricular_unit int NOT NULL FOREIGN KEY REFERENCES Curricular_Units(Id) ON DELETE CASCADE,
Class_Name nvarchar (40) NOT NULL,
Class_Year nchar(9) NOT NULL,
Teacher int NOT NULL  FOREIGN KEY REFERENCES People(Id) ON DELETE CASCADE, 
)
GO

--Classes
CREATE TABLE Classes(
CLass_Details int NOT NULL  FOREIGN KEY REFERENCES CLass_Details(Id) ON DELETE CASCADE,
Students int NOT NULL FOREIGN KEY REFERENCES People(Id) ON DELETE CASCADE,
)
GO



SET IDENTITY_INSERT [dbo].People ON;  
GO  

insert into People (Id, FirstName, LastName, Birth, Roles) values (1, 'Maïté', 'Schorah', '9/16/2002', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (2, 'Magdalène', 'Roston', '1/5/2002', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (3, 'Tú', 'Hugh', '8/10/2004', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (4, 'Pål', 'Yushmanov', '8/2/2002', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (5, 'Rébecca', 'Girardez', '4/19/2003', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (6, 'Naéva', 'Georges', '4/1/2003', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (7, 'Dafnée', 'Beaushaw', '3/3/2005', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (8, 'Vénus', 'Knock', '11/29/1999', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (9, 'Marie-thérèse', 'Keatch', '7/15/2002', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (10, 'Mélys', 'Evill', '8/10/2001', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (11, 'Maëlys', 'Duly', '5/26/2001', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (12, 'Clémence', 'Laurie', '3/30/2002', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (13, 'Pénélope', 'Hapgood', '6/8/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (14, 'Bérangère', 'Haldene', '2/19/2004', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (15, 'Marie-thérèse', 'Piperley', '4/25/2003', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (16, 'Lén', 'Matteotti', '10/5/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (17, 'Kallisté', 'Pickin', '6/24/2004', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (18, 'Marylène', 'Huston', '3/31/2003', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (19, 'Maëline', 'Doerling', '1/19/2003', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (20, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (21, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (21, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (202, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (203, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (204, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (206, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (27, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (207, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (208, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (209, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (200, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (2000, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (20000, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (20000, 'Joséphine', 'Okell', '6/13/2000', 1);
insert into People (Id, FirstName, LastName, Birth, Roles) values (200000, 'Joséphine', 'Okell', '6/13/2000', 1);
GO