--CREATE DATABASE aula6ex5_3
--GO

-- CHECKPOINT

-- GO

USE aula6ex5_3

GO

DROP TABLE presc_farmaco;
DROP TABLE farmaco;
DROP TABLE prescricao;
DROP TABLE farmaceutica;
DROP TABLE paciente;
DROP TABLE farmacia;
DROP TABLE medico;


CREATE TABLE medico(

	numSNS	int not null,
	Nome	varchar(30),
	Especialidade	varchar(30),

	PRIMARY KEY (numSNS),
);

CREATE TABLE farmacia(

	Nome	varchar(30) not null,
	Telefone	int,
	Endereco	varchar(30) ,

	PRIMARY KEY (Nome),
);

CREATE TABLE paciente(
	
	numUtente	int not null,
	Nome	char(30),
	DataNasc	date,
	Endereco	varchar(30),	

	PRIMARY KEY (numUtente),
);

CREATE TABLE prescricao(

	numPresc	int not null,
	numUtente	int,
	numMedico	int,
	farmacia	varchar(30),
	DataProc	date,

	PRIMARY KEY (numPresc),
	FOREIGN KEY (numUtente) REFERENCES paciente(numUtente),
	FOREIGN KEY (numMedico) REFERENCES medico(numSNS),
	FOREIGN KEY (farmacia) REFERENCES farmacia(Nome),
	
);

CREATE TABLE farmaceutica(
	
	numReg	int not null,
	Nome	varchar(30),
	Endereco	varchar(100),

	PRIMARY KEY (numReg),
);

CREATE TABLE farmaco(
	
	numRegFarm	int,
	Nome	varchar(30) not null,
	Formula	varchar(30) not null,
	
	FOREIGN KEY (numRegFarm) REFERENCES farmaceutica(numReg),
	PRIMARY KEY (Nome),

);


CREATE TABLE presc_farmaco(

	numPresc		int,
	numRegFarm	int,
	nomeFarmaco		varchar(30),
	
	FOREIGN KEY (numPresc) REFERENCES prescricao(numPresc),
	FOREIGN KEY (nomeFarmaco) REFERENCES farmaco(Nome),
	FOREIGN KEY (numRegFarm) REFERENCES farmaceutica(numReg),
);

insert into medico values (101,'Joao Pires Lima','Cardiologia');
insert into medico values (102,'Manuel Jose Rosa','Cardiologia');
insert into medico values (103,'Rui Luis Caraca','Pneumologia');
insert into medico values (104,'Sofia Sousa Silva','Radiologia');
insert into medico values (105,'Ana Barbosa', 'Neurologia');
			
insert into paciente values (1,'Renato Manuel Cavaco','1980-01-03','Rua Nova do Pilar 35');
insert into paciente values (2,'Paula Vasco Silva','1972-10-30','Rua Direita 43');
insert into paciente values (3,'Ines Couto Souto','1985-05-12','Rua de Cima 144');
insert into paciente values (4,'Rui Moreira Porto','1970-12-12','Rua Zig Zag 235');
insert into paciente values (5,'Manuel Zeferico Polaco','1990-06-05','Rua da Baira Rio 1135');
			
insert into farmaceutica values (905,'Roche','Estrada Nacional 249');
insert into farmaceutica values (906,'Bayer','Rua da Quinta do Pinheiro 5');
insert into farmaceutica values (907,'Pfizer','Empreendimento Lagoas Park - Edificio 7');
insert into farmaceutica values (908,'Merck', 'Alameda Fernão Lopes 12');
		
insert into farmacia values ('Farmacia BelaVista',221234567,'Avenida Principal 973');
insert into farmacia values ('Farmacia Central',234370500,'Avenida da Liberdade 33');
insert into farmacia values ('Farmacia Peixoto',234375111,'Largo da Vila 523');
insert into farmacia values ('Farmacia Vitalis',229876543,'Rua Visconde Salgado 263');
			
insert into farmaco values (905,'Boa Saude em 3 Dias','XZT9');
insert into farmaco values (906,'Voltaren Spray','PLTZ32');
insert into farmaco values (906,'Xelopironi 350','FRR-34');
insert into farmaco values (906,'Gucolan 1000','VFR-750');
insert into farmaco values (907,'GEROaero Rapid','DDFS-XEN9');
insert into farmaco values (908,'Aspirina 1000','BIOZZ02');

insert into prescricao values (10001,1,105,'Farmacia Central','2015-03-03');
insert into prescricao values (10002,1,105,NULL,NULL);
insert into prescricao values (10003,3,102,'Farmacia Central','2015-01-17');
insert into prescricao values (10004,3,101,'Farmacia BelaVista','2015-02-09');
insert into prescricao values (10005,3,102,'Farmacia Central','2015-01-17');
insert into prescricao values (10006,4,102,'Farmacia Vitalis','2015-02-22');
insert into prescricao values (10007,5,103,NULL,NULL);
insert into prescricao values (10008,1,103,'Farmacia Central','2015-01-02');
insert into prescricao values (10009,3,102,'Farmacia Peixoto','2015-02-02');

insert into presc_farmaco values (10001,905,'Boa Saude em 3 Dias');
insert into presc_farmaco values (10002,907,'GEROaero Rapid');
insert into presc_farmaco values (10003,906,'Voltaren Spray');
insert into presc_farmaco values (10003,906,'Xelopironi 350');
insert into presc_farmaco values (10003,908,'Aspirina 1000');
insert into presc_farmaco values (10004,905,'Boa Saude em 3 Dias');
insert into presc_farmaco values (10004,908,'Aspirina 1000');
insert into presc_farmaco values (10005,906,'Voltaren Spray');
insert into presc_farmaco values (10006,905,'Boa Saude em 3 Dias');
insert into presc_farmaco values (10006,906,'Voltaren Spray');
insert into presc_farmaco values (10006,906,'Xelopironi 350');
insert into presc_farmaco values (10006,908,'Aspirina 1000');
insert into presc_farmaco values (10007,906,'Voltaren Spray');
insert into presc_farmaco values (10008,905,'Boa Saude em 3 Dias');
insert into presc_farmaco values (10008,908,'Aspirina 1000');
insert into presc_farmaco values (10009,905,'Boa Saude em 3 Dias');
insert into presc_farmaco values (10009,906,'Voltaren Spray');
insert into presc_farmaco values (10009,908,'Aspirina 1000');

-- Queries

-- a) Lista de pacientes que nunca tiveram uma prescrição;
SELECT paciente.numUtente,paciente.Nome,DataNasc,Endereco
FROM (paciente LEFT OUTER JOIN prescricao ON paciente.numUtente=prescricao.numUtente) 
WHERE NumPresc IS NULL;

-- b) Número de prescrições por especialidade médica; 
SELECT Especialidade,count(Especialidade) as NumeroPrescricoes
FROM (medico JOIN prescricao ON NumSNS != NumMedico)
GROUP BY Especialidade


-- c) Número de prescrições processadas por farmácia;

SELECT farmacia.Nome,count(farmacia.Nome) as NumeroPrescricoes
FROM (farmacia JOIN prescricao ON farmacia.Nome=prescricao.farmacia)
GROUP BY farmacia.Nome;

-- d) Para a farmacêutica com registo número 906, lista dos seus fármacos nunca prescritos;
SELECT Nome,Formula,farmaco.NumRegFarm
FROM (farmaco LEFT OUTER JOIN presc_Farmaco ON Nome = NomeFarmaco)
Where farmaco.NumRegFarm = 906 AND NumPresc IS NULL;

-- e) Para cada farmácia, o número de fármacos de cada farmacêutica vendidos;
SELECT farmacia.Nome, farmaceutica.Nome,count(farmaco.Nome) as NumFarmacos
FROM (farmaceutica JOIN 
								(farmaco JOIN
														(presc_Farmaco JOIN 
																					(farmacia JOIN prescricao ON farmacia.Nome = prescricao.farmacia)
														ON presc_farmaco.NumPresc = prescricao.NumPresc)
								ON farmaco.Nome = +presc_farmaco.NomeFarmaco)	
		ON NumReg = farmaco.NumRegFarm)
GROUP BY  farmacia.Nome, farmaceutica.Nome



-- f) Pacientes que tiveram prescrições de médicos diferentes.

SELECT paciente.Nome,paciente.NumUtente,count(medico.NumSNS) AS NumMedicos
FROM medico JOIN
		(paciente JOIN prescricao ON paciente.NumUtente = prescricao.NumUtente)
ON medico.NumSNS = prescricao.NumMedico
GROUP BY paciente.Nome,paciente.NumUtente
HAVING count(medico.NumSNS) > 1
