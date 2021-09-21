-- CREATE DATABASE aula6ex5_1
-- GO

-- CHECKPOINT

-- GO

USE aula6ex5_1

GO

DROP TABLE works_on;
DROP TABLE dependente;
DROP TABLE project;
DROP TABLE dept_location;
DROP TABLE employee;
DROP TABLE department;


CREATE TABLE department(

	Dname	varchar(30),
	Dnumber	int not null,
	Mgr_ssn	int,
	Mgr_start_date date,

	PRIMARY KEY (Dnumber),
);
CREATE TABLE employee(

	Fname	varchar(15),
	Minit	char,
	Lname	varchar(15),
	Ssn		int not null,
	Bdate	date,
	Addres	varchar(30),
	Sex		char,
	Salary	int,
	Super_ssn	int,
	Dno		int not null,

	PRIMARY KEY (Ssn),
	FOREIGN KEY (Super_ssn) REFERENCES employee(Ssn),
	FOREIGN KEY (Dno) REFERENCES department(Dnumber),
);



CREATE TABLE dept_location(

	Dnumber	int	,
	Dlocation	varchar(30) not null,

	PRIMARY KEY (Dlocation),
	FOREIGN KEY (Dnumber) REFERENCES department(Dnumber),
);

CREATE TABLE project(

	Pname	varchar(30),
	Pnumber	int not null,
	Plocation	varchar(30),
	Dnum	int,

	PRIMARY KEY (Pnumber),
	FOREIGN KEY (Dnum) REFERENCES department(Dnumber),

);

CREATE TABLE works_on(

	Essn	int,
	Pno	int,
	Hourss	int,

	FOREIGN KEY (Essn) REFERENCES employee(SSn),
	FOREIGN KEY (Pno) REFERENCES project(Pnumber),
);

CREATE TABLE dependente(

	Essn	int,
	Dependent_name	varchar(30) not null,
	Sex	char,
	Bdate date,
	Relacionship varchar(15),
	
	PRIMARY KEY (Dependent_name),
	FOREIGN KEY (Essn) REFERENCES employee(Ssn),
);


insert department values('Investigacao',1,21312332,'2010-08-02')
insert department values('Comercial',2,321233765,'2013-05-16')
insert department values('Logistica',3,41124234,'2013-05-16')
insert department values('Recursos Humanos',4,12652121,'2014-04-02')
insert department values('Desporto',5,NULL,NULL)

GO



insert employee
	values('Paula','A','Sousa',183623619,'2001-08-11','Rua da FRENTE','F',1450.00,NULL,3)
insert employee
	values('Carlos','D','Gomes',21312332,'2000-01-01','Rua XPTO','M',1200.00,NULL,1)
insert employee
	values('Juliana','A','Amaral',321233765,'1980-08-11','Rua BZZZZ','F',1350.00,NULL,3)
insert employee
	values('Maria','I','Pereira',342343432,'2001-05-01','Rua JANOTA','F',1250.00,21312332,2)
insert employee
	values('Joao','G','Costa',41124234,'2001-01-01','Rua YGZ','M',1300.00,21312332,2)
insert employee
	values('Ana','L','Silva',12652121,'1990-03-03','Rua ZIG ZAG','F',1400.00,21312332,2)

GO

insert dependente values(21312332,'Joana Costa','F','2008-04-01', 'Filho')
insert dependente values(21312332,'Maria Costa','F','1990-10-05', 'Neto')
insert dependente values(21312332,'Rui Costa','M','2000-08-04','Neto')
insert dependente values(321233765,'Filho Lindo','M','2001-02-22','Filho')
insert dependente values(342343434,'Rosa Lima','F','2006-03-11','Filho')
insert dependente values(41124234,'Ana Sousa','F','2007-04-13','Neto')
insert dependente values(41124234,'Gaspar Pinto','M','2006-02-08','Sobrinho')

GO

insert dept_location values(2,'Aveiro')
insert dept_location values(3,'Coimbra')

GO

insert project values('Aveiro Digital',1,'Aveiro',3)
insert project values('BD Open Day',2,'Espinho',2)
insert project values('Dicoogle',3,'Aveiro',3)
insert project values('GOPACS',4,'Aveiro',3)

GO

insert works_on values(183623612,1,20.0)
insert works_on values(183623612,3,10.0)
insert works_on values(21312332,1,20.0)
insert works_on values(321233765,1,25.0)
insert works_on values(342343434,1,20.0)
insert works_on values(342343434,4,25.0)
insert works_on values(41124234,2,20.0)
insert works_on values(41124234,3,30.0)

-- Queries

-- a) Obtenha uma lista contendo os projetos e funcionários (ssn e nome completo) que lá trabalham
/*
SELECT project.Pname,employee.Ssn,Fname
FROM (project JOIN employee ON project.Dnum=employee.Dno)

-- b) Obtenha o nome de todos os funcionários supervisionados por ‘Carlos D Gomes’;
SELECT e2.Fname as FnameSuper,e2.Lname as LnameSuper,e1.Fname,e1.Lname
FROM employee AS e1, employee AS e2	
WHERE e1.Super_ssn=e2.Ssn AND e2.Fname LIKE 'Carlos' AND e2.Minit LIKE '%D%' AND e2.Lname LIKE '%Gomes%'

-- c) Para cada projeto, listar o seu nome e o número de horas (por semana) gastos nesse 
--projeto por todos os funcionários;
SELECT works_on.Pno,Essn,Hourss
FROM (works_on JOIN employee ON Essn=Ssn)

-- d) Obter o nome de todos os funcionários do departamento 3 que trabalham mais de 
-- 20 horas por semana no projeto ‘Aveiro Digital’;

-- e) Nome dos funcionários que não trabalham para projetos;
SELECT employee.Fname,works_on.Essn
FROM (works_on FULL OUTER JOIN employee ON works_on.Essn=employee.Ssn)
WHERE Essn IS NULL

-- f)
SELECT Dname, AVG(Salary) as Salary
FROM (department JOIN employee ON Dno=Dnumber)
WHERE Sex='F'
GROUP BY Dname

-- g)
SELECT Fname, Minit, Lname, count(Dependent_name) as Dependent_number
FROM (employee JOIN dependente ON Ssn=Essn)
GROUP BY Fname,Minit, Lname
HAVING count(Dependent_name)>2
*/
