use aula4;
go

CREATE SCHEMA RENT_A_CAR;
GO


CREATE TABLE RENT_A_CAR.Cliente (
	NIF			CHAR(9) PRIMARY KEY,
	Nome		VARCHAR(30),
	Endereço	VARCHAR(30),		
	Num_Carta	CHAR(9)	NOT NULL,

	UNIQUE(Num_Carta)

);

CREATE TABLE RENT_A_CAR.Balcao (
	Numero_Balcao		INT PRIMARY KEY,
	Nome				VARCHAR(30),
	Endereço			VARCHAR(30),		

);

CREATE TABLE RENT_A_CAR.Aluguer (
	Numero				INT PRIMARY KEY,
	Duracao				INT,
	Data				DATE,		
	Cliente_NIF			CHAR(9) NOT NULL,
	Numero_Balcao		INT NOT NULL,
	Matricula			CHAR(8) NOT NULL,	
	FOREIGN KEY (Cliente_NIF) REFERENCES RENT_A_CAR.Cliente(NIF),	
	FOREIGN KEY (Numero_Balcao) REFERENCES RENT_A_CAR.Balcao(Numero_Balcao),
);


CREATE TABLE RENT_A_CAR.Veiculo (
	Matricula			CHAR(8) PRIMARY KEY,
	Marca				VARCHAR(30),
	Ano					CHAR(4),		
	Codigo				INT NOT NULL,	

);

CREATE TABLE RENT_A_CAR.Tipo_Veiculo (
	Codigo				INT PRIMARY KEY ,
	Ar_Condicionado		BIT,
	Designacao			VARCHAR(30),

);

CREATE TABLE RENT_A_CAR.Similaridade (
	Codigo1	INT,
	Codigo2	INT,

	PRIMARY KEY (Codigo1, Codigo2),
	FOREIGN KEY (Codigo1) REFERENCES RENT_A_CAR.Tipo_Veiculo(Codigo),
	FOREIGN KEY (Codigo2) REFERENCES RENT_A_CAR.Tipo_Veiculo(Codigo),
);

CREATE TABLE RENT_A_CAR.Ligeiro (
	Codigo			INT,
	Num_Lugares		INT,
	Portas			INT,
	Combustivel		VARCHAR(10),

	PRIMARY KEY (Codigo),
	FOREIGN KEY (Codigo) REFERENCES RENT_A_CAR.Tipo_Veiculo(Codigo),
);

CREATE TABLE RENT_A_CAR.Pesado (
	Codigo			INT,
	Peso			INT,
	Passageiros		DECIMAL(7,2),

	PRIMARY KEY (Codigo),
	FOREIGN KEY (Codigo) REFERENCES RENT_A_CAR.Tipo_Veiculo(Codigo),
);
