USE [blazorTest]
GO

/****** Object: Table [dbo].[Skills] Script Date: 15/3/2023 1:13:55 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Skills] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (100) NULL
);


