--Aula 9

-- a) Construa um stored procedure que aceite o ssn de um funcionário, que o remova da tabela de funcionários, que remova as suas entradas da tabela works_on e que remova ainda os seus dependentes. Que preocupações adicionais devem ter no storage procedure para além das referidas anteriormente?

DROP PROCEDURE Company.deleteEmployee
CREATE PROCEDURE Company.deleteEmployee @Emp_Code char(9)
AS
	BEGIN
		DELETE FROM Company.Works_on WHERE Essn = @Emp_Code
		DELETE FROM Company.[Dependent] WHERE  Essn = @Emp_Code

		UPDATE Company.Department 
			SET Company.Department.Mgr_ssn  = null
			WHERE Mgr_ssn = @Emp_Code

		UPDATE Company.Employee 
			SET Company.Employee.Super_ssn  = null
			WHERE Super_ssn = @Emp_Code
	
		DELETE FROM Company.Employee WHERE Ssn = @Emp_Code

	END


EXEC Company.deleteEmployee '183623612'


-- b) Crie um stored procedure que retorne um record-set com os funcionários gestores de departamentos, assim como o ssn e número de anos (como gestor) do funcionário mais antigo dessa lista. 

DROP PROCEDURE Company.getManagers
CREATE PROCEDURE Company.getManagers  (@Oldest_ssn char(9) OUTPUT, @Oldest_years int OUTPUT)
AS
	BEGIN
		SELECT * 
		FROM (Company.Employee LEFT OUTER JOIN Company.Department ON Ssn = Mgr_ssn)
		WHERE Mgr_ssn IS NOT NULL
		ORDER BY Mgr_start_date;
		
		SELECT @Oldest_years=min(DATEDIFF(year,Company.Department.Mgr_start_date,getDate())), @Oldest_ssn = Company.Department.Mgr_ssn
		FROM Company.Department
		WHERE Mgr_ssn IS NOT NULL
		GROUP BY Company.Department.Mgr_start_date, Company.Department.Mgr_Ssn

	END

DECLARE @Oldest_ssn char(9);
DECLARE @Oldest_years int;
EXEC Company.getManagers @Oldest_ssn = @Oldest_ssn OUTPUT,
						@Oldest_years = @Oldest_years OUTPUT;
PRINT @Oldest_ssn
PRINT @Oldest_years


-- e) Construa um trigger que não permita que determinado funcionário seja definido como gestor de mais do que um departamento. 

DROP TRIGGER Company.preventManagerOveralp;
CREATE TRIGGER Company.preventManagerOverlap ON Company.Department
AFTER INSERT, UPDATE
	AS

		IF EXISTS(SELECT Mgr_ssn
				  FROM Company.Department
				  WHERE Mgr_ssn IS NOT NULL)
			BEGIN 
				RAISERROR ('Employee is already the manager of a department',16,1); 
				ROLLBACK TRAN;                                               
			END 
	GO

-- e) Crie uma UDF que, para determinado funcionário (ssn), devolva o nome e localização dos projetos em que trabalha

DROP FUNCTION getEmployeeProjects
CREATE FUNCTION getEmployeeProjects (@Emp_ssn char(9)) RETURNS TABLE
AS
	RETURN (SELECT Pname, Plocation
			FROM Company.Project LEFT OUTER JOIN 
					Company.Employee LEFT OUTER JOIN Company.Works_on ON Ssn = Essn
			ON Pnumber = Pno)
GO

EXEC getEmployeeProjects '21312332'