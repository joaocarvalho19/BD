CREATE SCHEMA MEDICAMENTOS;
GO
--DROP TABLE MEDICAMENTOS.medico;
/*DROP TABLE MEDICAMENTOS.prescricao;
DROP TABLE MEDICAMENTOS.paciente;
DROP TABLE MEDICAMENTOS.farmaco;
DROP TABLE MEDICAMENTOS.farmaceutica;
DROP TABLE MEDICAMENTOS.farmacia;
DROP TABLE MEDICAMENTOS.tem;
*/


CREATE TABLE MEDICAMENTOS.medico(

	Nome	varchar(15),
	Especialidade	char,
	Num_ID	int not null,

	PRIMARY KEY (Num_ID),
);

CREATE TABLE MEDICAMENTOS.farmacia(

	Nome	varchar(15),
	Endereco	varchar(30) ,
	Tele	int not null,

	PRIMARY KEY (Tele),
);

CREATE TABLE MEDICAMENTOS.paciente(

	Nome_Ut	char,
	Endereco_Pa	varchar(30),
	Data_Nasc	date,
	Num_Ut	int not null,

	PRIMARY KEY (Num_Ut),
);

CREATE TABLE MEDICAMENTOS.prescricao(

	Pnum	int,
	Ftele	int ,
	Mnum	int ,
	Num_prescricao	int not null,

	PRIMARY KEY (Num_prescricao),
	FOREIGN KEY (Mnum) REFERENCES MEDICAMENTOS.medico(Num_ID),
	FOREIGN KEY (Ftele) REFERENCES MEDICAMENTOS.farmacia(Tele),
	FOREIGN KEY (Pnum) REFERENCES MEDICAMENTOS.paciente(Num_Ut),

);

CREATE TABLE MEDICAMENTOS.farmaceutica(

	Nome	varchar(15),
	Endereco_Far	varchar(30),
	Telefone	int,
	Num	int not null,

	PRIMARY KEY (Num),
);

CREATE TABLE MEDICAMENTOS.farmaco(

	Formula	varchar(30) not null,
	Nome	varchar(15) not null,
	Fnum	int,
	FOREIGN KEY (Fnum) REFERENCES MEDICAMENTOS.farmaceutica(Num),
	PRIMARY KEY (Nome),

);


CREATE TABLE MEDICAMENTOS.tem(

	Fnome	varchar(15),
	Pno		int,

	FOREIGN KEY (Fnome) REFERENCES MEDICAMENTOS.farmaco(Nome),
	FOREIGN KEY (Pno) REFERENCES MEDICAMENTOS.prescricao(Num_prescricao),
);