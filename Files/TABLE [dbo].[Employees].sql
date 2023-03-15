USE [blazorTest]
GO

/****** Object: Table [dbo].[Employees] Script Date: 15/3/2023 1:13:47 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)  NULL,
    [LastName]   NVARCHAR (100) NULL,
    [HiringDate] DATETIME       NULL
);


