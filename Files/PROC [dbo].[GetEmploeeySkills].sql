﻿USE [blazorTest]
GO

/****** Object: SqlProcedure [dbo].[GetEmploeeySkills] Script Date: 15/3/2023 1:14:01 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[GetEmploeeySkills](  
    @EmployeeId INT
    )   
AS  
BEGIN  

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET NOCOUNT ON;  
   
	--SELECT S.* FROM DBO.Skills S 
	--INNER JOIN DBO.EmployeesAndSkills ES ON S.Id = ES.SkillId 
	--WHERE ES.EmployeeId = @EmployeeId

	SELECT S.ID, S.Name, S.Description,
	CONVERT(bit, isnull((Select 1 from DBO.EmployeesAndSkills ES where S.Id = ES.SkillId and ES.EmployeeId = @EmployeeId),0)) as IsSelected
	FROM DBO.Skills S 
	
END;
