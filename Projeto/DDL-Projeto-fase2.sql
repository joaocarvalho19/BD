

--CREATE DATABASE Loja_Animais
--GO


USE Loja_Animais;
GO



-- DROP TABLES:




------------------------------------------- TABELAS : ---------------------------------------------------------




CREATE TABLE CLIENTE (

	Nome varchar(25),
	NIF int NOT NULL PRIMARY KEY,
	Morada varchar(25),                   
	Telemovel int UNIQUE,

)


CREATE TABLE COMPRA (
	
	Data date NOT NULL,
	ID int NOT NULL PRIMARY KEY,
	ID_vendedor int NOT NULL DEFAULT 0,                     -- FK
	NIF_cliente int NOT NULL DEFAULT 0,                     -- FK
	Total decimal(10,2),


)

CREATE TABLE ENCOMENDA (

	ID_funcionario int NOT NULL DEFAULT 0,                  -- FK
	NIF_fornecedor int NOT NULL DEFAULT 0,                  -- FK
	ID int NOT NULL PRIMARY KEY,

)


CREATE TABLE FORNECEDOR (

	Nome varchar(25),
	NIF int NOT NULL PRIMARY KEY,
	Morada varchar(25),
	Telemovel int UNIQUE,

)


CREATE TABLE ITEM (

	ID int NOT NULL PRIMARY KEY,
	Preço decimal(10,2),
	Descriçao varchar(30),
	Quantidade int,

)


CREATE TABLE PRODUTO (
	
	
	ID_item int NOT NULL PRIMARY KEY DEFAULT 0,                       -- FK
	TP_categoria varchar(25) DEFAULT 'Desconhecida',                 -- FK

)


CREATE TABLE TIPO_PRODUTO (

	Categoria varchar(25) PRIMARY KEY,

)


CREATE TABLE ANIMAL (

	Nome varchar(25),
	Genero char(1) NOT NULL, -- F ou M
	Idade int NOT NULL,	
	ID_item int NOT NULL PRIMARY KEY DEFAULT 0,                 -- FK
	TA_especie varchar(10) DEFAULT 'Desconhecida',                     -- FK

)




CREATE TABLE FUNCIONARIO (

	Nome varchar(25),
	ID int NOT NULL PRIMARY KEY,
	Telemovel int UNIQUE,
	Morada varchar(25),
	Super_ID int DEFAULT 0,                -- FK

)


CREATE TABLE TRATADOR (

	ID_funcionario int NOT NULL PRIMARY KEY DEFAULT 0,      -- FK

)


CREATE TABLE VENDEDOR (

	ID_funcionario int NOT NULL PRIMARY KEY DEFAULT 0,      -- FK

)


CREATE TABLE COMPRA_TEM_ITEM (

	Quantidade int NOT NULL,
	ID_compra int NOT NULL DEFAULT 0,                -- FK
	ID_item int NOT NULL DEFAULT 0,                  -- FK
	
	PRIMARY KEY(ID_compra,ID_item)
)



CREATE TABLE ENCOMENDA_TEM_ITEM (

	Quantidade int NOT NULL,
	ID_encomenda int NOT NULL DEFAULT 0,                -- FK
	ID_item int NOT NULL DEFAULT 0,                  -- FK

	PRIMARY KEY(ID_encomenda,ID_item)
)


CREATE TABLE TIPO_ANIMAL (

	Especie varchar(10) PRIMARY KEY,

)


CREATE TABLE TIPO_TRATAMENTO (

	Categoria varchar(15) PRIMARY KEY,

)

CREATE TABLE ANIMAL_TEM_TRATAMENTO (

	ID_animal int NOT NULL DEFAULT 0,                              -- FK
	ID_tratador int NOT NULL DEFAULT 0,                            -- FK
	Tipo_tratamento varchar(15) DEFAULT 'Desconhecido' ,                  -- FK
	
)

CREATE TABLE TRATA (

	Data date NOT NULL,
	ID_funcionario int NOT NULL DEFAULT 0,           -- FK
	ID_item int NOT NULL DEFAULT 0,                  -- FK

	PRIMARY KEY(ID_funcionario,ID_item)
)





---------------------------------------------- FOREIGN KEYS: -----------------------------------------------------------




ALTER TABLE COMPRA  
ADD CONSTRAINT FK_COMPRA

FOREIGN KEY (ID_vendedor) REFERENCES VENDEDOR(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (NIF_cliente) REFERENCES CLIENTE(NIF)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE ENCOMENDA 
ADD CONSTRAINT FK_ENCOMENDA

FOREIGN KEY (ID_funcionario) REFERENCES FUNCIONARIO(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (NIF_fornecedor) REFERENCES FORNECEDOR(NIF)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE PRODUTO  
ADD CONSTRAINT FK_PRODUTO

FOREIGN KEY (TP_categoria) REFERENCES TIPO_PRODUTO(Categoria)
ON DELETE SET NULL ON UPDATE CASCADE, 

FOREIGN KEY (ID_item) REFERENCES ITEM(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE ANIMAL  
ADD CONSTRAINT FK_ANIMAL

FOREIGN KEY (ID_item) REFERENCES ITEM(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (TA_especie) REFERENCES TIPO_ANIMAL(Especie)
ON DELETE SET NULl ON UPDATE CASCADE;





ALTER TABLE FUNCIONARIO
ADD CONSTRAINT FK_FUNCIONARIO

FOREIGN KEY (Super_ID) REFERENCES FUNCIONARIO(ID)
ON DELETE SET NULL ON UPDATE CASCADE;





ALTER TABLE TRATADOR
ADD CONSTRAINT FK_TRATADOR

FOREIGN KEY (ID_funcionario) REFERENCES FUNCIONARIO(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE VENDEDOR
ADD CONSTRAINT FK_VENDEDOR

FOREIGN KEY (ID_funcionario) REFERENCES FUNCIONARIO(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;






ALTER TABLE COMPRA_TEM_ITEM
ADD CONSTRAINT FK_COMPRA_TEM_ITEM

FOREIGN KEY (ID_compra) REFERENCES COMPRA(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (ID_item) REFERENCES ITEM(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE ENCOMENDA_TEM_ITEM
ADD CONSTRAINT FK_ENCOMENDA_TEM_ITEM

FOREIGN KEY (ID_encomenda) REFERENCES ENCOMENDA(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (ID_item) REFERENCES ITEM(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;





ALTER TABLE ANIMAL_TEM_TRATAMENTO
ADD CONSTRAINT FK_ANIMAL_TEM_TRATAMENTO

FOREIGN KEY (ID_animal) REFERENCES TRATA(ID_item)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (ID_tratador) REFERENCES TRATA(ID_funcionario)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (Tipo_tratamento) REFERENCES TIPO_TRATAMENTO(Categoria)
ON DELETE SET NULL ON UPDATE CASCADE;






ALTER TABLE TRATA
ADD CONSTRAINT FK_TRATA
FOREIGN KEY (ID_funcionario) REFERENCES TRATADOR(ID_funcionario)
ON DELETE SET DEFAULT ON UPDATE CASCADE,

FOREIGN KEY (ID_item) REFERENCES ITEM(ID)
ON DELETE SET DEFAULT ON UPDATE CASCADE;

GO




-------------------------------- INSERÇÃO DE VALORES NAS TABELAS: ---------------------------------------------------------





insert CLIENTE 
	values('Paula Sousa',183623619,'Rua da FRENTE',961257123)
insert CLIENTE
	values('Alberto Lopes',283628629,'Rua XPTO',967825711)
insert CLIENTE
	values('Francisco Almeida',213663325,'Rua ABC',917164892)
insert CLIENTE
	values('Luis Gomes',123623211,'Rua de CIMA',938153379)
insert CLIENTE
	values('Diogo Silva',260673014,'Rua Dr. José',968186654)
insert CLIENTE
	values('Diogo Matos',263613314,'Rua Dr. José',912345267)

GO

insert COMPRA
	values('2019-03-11',18362,12026,123623211,14.60)
insert COMPRA
	values('2019-01-01',28362,12026,183623619,40.20)
insert COMPRA
	values('2019-02-11',21366,17280,213663325,62.10)
insert COMPRA
	values('2019-02-01',12362,17280,263613314,39.20)
insert COMPRA
	values('2019-01-01',26361,29726,283628629,22.20)

GO

insert ENCOMENDA
	values(14278,81716892,22527)
insert ENCOMENDA
	values(84670,81716892,19838)
insert ENCOMENDA
	values(17280,255123805,13297)
insert ENCOMENDA
	values(12026,611315711,11781)

GO

insert FORNECEDOR
	values('Jorge Antunes',773157123,'Avenida do Vale',914542689)
insert FORNECEDOR
	values('Laura Cerdeira',611315711,'Rua da Capela',934542511)
insert FORNECEDOR
	values('Rui Silva',81716892,'Rua do Alto',918625490)
insert FORNECEDOR
	values('Mário Sousa',255123805,'Avenida da Pedra',931236389)

GO

insert ITEM
	values(73962,7.00,'update mais tarde',1)
insert ITEM
	values(10293,5.50,'update mais tarde',2)
insert ITEM
	values(12325,3.00,'update mais tarde',1)
insert ITEM
	values(98678,30.50,'update mais tarde',4)
insert ITEM
	values(12257,25.99,'update mais tarde',1)

insert ITEM
	values(87291,7.00,'update mais tarde',2)
insert ITEM
	values(12345,5.50,'update mais tarde',1)
insert ITEM
	values(09876,3.00,'update mais tarde',1)
insert ITEM
	values(87659,30.50,'update mais tarde',4)
insert ITEM
	values(72985,25.99,'update mais tarde',2)
GO

insert PRODUTO
	values(10293,'Higiene')
insert PRODUTO
	values(12257,'Manutençao')
insert PRODUTO
	values(98678,'Higiene')
insert PRODUTO
	values(73962,'Diversao')
insert PRODUTO
	values(12325,'Diversao')

GO

insert TIPO_PRODUTO
	values('Higiene')
insert TIPO_PRODUTO
	values('Manutençao')
insert TIPO_PRODUTO
	values('Diversao')

GO

insert ANIMAL
	values('Max','M',4,87291,'Cão')
insert ANIMAL
	values('Lu','M',2,12345,'Passaro')
insert ANIMAL
	values('Fofinha','F',1,09876,'Gato')
insert ANIMAL
	values('Pantufa','M',2,87659,'Cão')
insert ANIMAL
	values('Assembly','F',1,72985,'Hamster')

GO




insert FUNCIONARIO
	values('Nelson Silva',14278,917752998,'Avenida da Beira',17280)
insert FUNCIONARIO
	values('Fabiana Santos',84670,931011753,'Rua do Altar',12026)
insert FUNCIONARIO
	values('Sara Nunes',17280,961885267,'Avenida do Pinheiro',78493)
insert FUNCIONARIO
	values('Ana Gonçalves',12026,912376890,'Rua da Calçada',14278)
insert FUNCIONARIO
	values('Ana Pinheiro',29726,912376891,'Rua da Rua',14278)

GO

insert TRATADOR
	values(29726)
insert TRATADOR
	values(14278)
insert TRATADOR
	values(84670)

GO

insert VENDEDOR
	values(17280)
insert VENDEDOR
	values(12026)
insert VENDEDOR
	values(29726)

GO


insert COMPRA_TEM_ITEM
	values(2,28362,10293)
insert COMPRA_TEM_ITEM
	values(1,21366,12257)
insert COMPRA_TEM_ITEM
	values(1,26361,73962)
insert COMPRA_TEM_ITEM
	values(1,21366,87291)

GO

insert ENCOMENDA_TEM_ITEM
	values(1,11781,10293)
insert ENCOMENDA_TEM_ITEM
	values(1,11781,72985)
insert ENCOMENDA_TEM_ITEM
	values(4,13297,12257)
insert ENCOMENDA_TEM_ITEM
	values(4,13297,12325)
insert ENCOMENDA_TEM_ITEM
	values(3,19838,87659)
insert ENCOMENDA_TEM_ITEM
	values(3,22527,98678)
insert ENCOMENDA_TEM_ITEM
	values(3,88578,73962)

GO

insert TIPO_ANIMAL
	values('Cão')
insert TIPO_ANIMAL
	values('Gato')
insert TIPO_ANIMAL
	values('Passaro')
insert TIPO_ANIMAL
	values('Hamster')

GO

insert TIPO_TRATAMENTO
	values('Vacinaçao')
insert TIPO_TRATAMENTO
	values('Alimentaçao')
insert TIPO_TRATAMENTO
	values('Tosquia')
insert TIPO_TRATAMENTO
	values('Higiene')
GO

insert ANIMAL_TEM_TRATAMENTO
	values(87291,14278,'Vacinaçao')
insert ANIMAL_TEM_TRATAMENTO
	values(09876,78493,'Alimentaçao')
insert ANIMAL_TEM_TRATAMENTO
	values(87659,84670,'Vacinaçao')
insert ANIMAL_TEM_TRATAMENTO
	values(12345,84670,'Alimentaçao')
insert ANIMAL_TEM_TRATAMENTO
	values(12345,78493,'Vacinaçao')
insert ANIMAL_TEM_TRATAMENTO
	values(87659,14278,'Higiene')

GO

insert TRATA
	values('2019-05-20',78493,09876)
insert TRATA
	values('2019-05-23',14278,87291)
insert TRATA
	values('2019-05-23',84670,87659)
GO




------------------------------ QUERIES ----------------------------------------------------------------



-- LISTAR TODAS AS TABELAS:

SELECT * FROM PRODUTO;
SELECT * FROM ANIMAL;
SELECT * FROM ANIMAL_TEM_TRATAMENTO;
SELECT * FROM CLIENTE;
SELECT * FROM COMPRA;
SELECT * FROM COMPRA_TEM_ITEM;
SELECT * FROM ENCOMENDA;
SELECT * FROM ENCOMENDA_TEM_ITEM;
SELECT * FROM FORNECEDOR;
SELECT * FROM FUNCIONARIO;
SELECT * FROM ITEM;
SELECT * FROM TIPO_ANIMAL;
SELECT * FROM TIPO_PRODUTO;
SELECT * FROM TIPO_TRATAMENTO;
SELECT * FROM TRATA;
SELECT * FROM TRATADOR;
SELECT * FROM VENDEDOR;


SELECT ID,ITEM.Quantidade as quantidade_permitida FROM ITEM JOIN COMPRA_TEM_ITEM ON ITEM.ID=COMPRA_TEM_ITEM.ID_item;

-- LISTA DE ITENS DO TIPO ANIMAL

SELECT ITEM.Descriçao,ITEM.Quantidade,ITEM.Preço,ITEM.ID,ANIMAL.Genero,ANIMAL.Idade,ANIMAL.Nome,ANIMAL.TA_especie
FROM (ITEM JOIN ANIMAL ON ITEM.ID=ANIMAL.ID_item)

-- LISTA DE ITENS DO TIPO PRODUTO

SELECT ITEM.Descriçao,ITEM.Quantidade,ITEM.Preço,ITEM.ID,PRODUTO.TP_categoria
FROM (ITEM JOIN PRODUTO ON ITEM.ID=PRODUTO.ID_item)
	 
-- LISTA DOS NOMES DOS ANIMAIS E O NOME E ID DO RESPETIVO TRATADOR

SELECT ANIMAL.Nome,FUNCIONARIO.Nome,TRATADOR.ID_funcionario
FROM ((FUNCIONARIO JOIN TRATADOR ON FUNCIONARIO.ID = TRATADOR.ID_funcionario) JOIN TRATA ON TRATA.ID_funcionario = TRATADOR.ID_funcionario) JOIN ANIMAL ON ANIMAL.ID_item = TRATA.ID_item

-- Lista dos fornecedores que nunca tiveram encomendas;

SELECT FORNECEDOR.Nome,ENCOMENDA.ID AS numeroDeEnc
FROM (FORNECEDOR LEFT OUTER JOIN ENCOMENDA ON FORNECEDOR.NIF = NIF_fornecedor)
WHERE ENCOMENDA.ID IS NULL


-- LISTA DE NOMES DOS CÃES

SELECT ANIMAL.TA_especie,ANIMAL.Nome
FROM ANIMAL
WHERE ANIMAL.TA_especie = 'Cão'


-- TOTAL DOS CLIENTES GASTO NA LOJA

SELECT NIF,sum(Total) as total_gasto FROM ((CLIENTE JOIN COMPRA ON CLIENTE.NIF = COMPRA.NIF_cliente))
GROUP BY (NIF);







--------------------------- UPDATES: ----------------------------------------------------------------------------




UPDATE ITEM
SET Descriçao = 'Labrador branco'
WHERE ID=87659;

UPDATE ITEM
SET Descriçao = 'Brinquedo para gatos'
WHERE ID=73962;

UPDATE ITEM
SET Descriçao = 'Caturra amarela e azul'
WHERE ID=12345;
