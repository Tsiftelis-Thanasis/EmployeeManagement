SELECT S.ID, S.Name, S.Description,
isnull((Select 1 from DBO.EmployeesAndSkills ES where S.Id = ES.SkillId and ES.EmployeeId = 1),0) as IsSelected
FROM DBO.Skills S 
	
	