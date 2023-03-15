USE [blazorTest]
GO

/****** Object: Table [dbo].[EmployeesAndSkills] Script Date: 15/3/2023 1:13:52 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeesAndSkills] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT NOT NULL,
    [SkillId]    INT NOT NULL
);


