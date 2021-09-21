use aula4;
go

CREATE SCHEMA SistemaInformacao;
GO
/*DROP TABLE SistemaInformacao.departamento;
DROP TABLE SistemaInformacao.professor;
DROP TABLE SistemaInformacao.estudante_graduado;
DROP TABLE SistemaInformacao.projeto_investigacao;
DROP TABLE SistemaInformacao.p_participa_p;
DROP TABLE SistemaInformacao.e_participa_p;
*/

CREATE TABLE SistemaInformacao.departamento(

	Nome	varchar(15) not null,
	Localizacao	varchar(30),

	PRIMARY KEY (Nome),	

);
CREATE TABLE SistemaInformacao.professor(

	Nmec	int not null,
	Nome	varchar(15),
	Data_Nasc	date,
	Categoria_Prof	varchar,
	Area_Cientifica	varchar,
	Dnome varchar(15),
	Per_Dedicacao int,

	PRIMARY KEY (Nmec),
	FOREIGN KEY (Dnome) REFERENCES SistemaInformacao.departamento(Nome),

);
CREATE TABLE SistemaInformacao.estudante_graduado(

	Nmeca	int not null,
	Nome	varchar(15),
	Data_Nasc	date,
	Grau_Formacao	varchar,
	Dnome varchar(15),
	Supe_Nmec int,

	PRIMARY KEY (Nmeca),
	FOREIGN KEY (Dnome) REFERENCES SistemaInformacao.departamento(Nome),

);
CREATE TABLE SistemaInformacao.projeto_investigacao(

	ID	int not null,
	Orcamento	char,
	Nome	varchar(15),
	Data_Inicio date,
	Data_Termino date,
	Entidade_Fin varchar,

	PRIMARY KEY (ID),

);
CREATE TABLE SistemaInformacao.p_participa_p(

	Pnmec	int,
	PI_ID	int,
	
	FOREIGN KEY (Pnmec) REFERENCES SistemaInformacao.professor(Nmec),
	FOREIGN KEY (PI_ID) REFERENCES SistemaInformacao.projeto_investigacao(ID),

);
CREATE TABLE SistemaInformacao.e_participa_p(

	Pnmec	int,
	PI_ID	int,
	
	FOREIGN KEY (Pnmec) REFERENCES SistemaInformacao.professor(Nmec),
	FOREIGN KEY (PI_ID) REFERENCES SistemaInformacao.projeto_investigacao(ID),

);	
