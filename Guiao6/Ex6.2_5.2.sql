-- CREATE DATABASE aula6ex5_2
-- GO

-- CHECKPOINT

-- GO

USE aula6ex5_2

GO

DROP TABLE item;
DROP TABLE encomenda;
DROP TABLE produto;
DROP TABLE fornecedor;
DROP TABLE tipo_fornecedor;


CREATE TABLE tipo_fornecedor(
	
	codigo	int	PRIMARY KEY,
	designacao	VARCHAR(30),
	
);

CREATE TABLE fornecedor(

	nif	int	PRIMARY KEY,
	nome	VARCHAR(20),
	fax	int NOT NULL,
	endereco	VARCHAR(30) ,
	condpag	int NOT NULL,	
	tipo	int NOT NULL,
	FOREIGN KEY (tipo)	REFERENCES tipo_fornecedor(codigo),

);


CREATE TABLE produto(

	codigo int PRIMARY KEY,
	nome	VARCHAR(30),
	preco DECIMAL(10,2) NOT NULL,
	iva VARCHAR(10),
	unidades int NOT NULL,
	
);

CREATE TABLE encomenda(
	numero int	PRIMARY KEY,
	data date,
	fornecedor int NOT NULL,
	FOREIGN KEY (fornecedor) REFERENCES fornecedor(nif),
);

CREATE TABLE item(
	numEnc int,
	codProd int,
	unidades int NOT NULL,
	PRIMARY KEY (numEnc,codProd),
	FOREIGN KEY (numEnc) REFERENCES encomenda(numero),
	FOREIGN KEY (codProd) REFERENCES produto(codigo),
);
 
insert into tipo_fornecedor values (101,'Carnes');
insert into tipo_fornecedor values (102,'Laticinios');
insert into tipo_fornecedor values (103,'Frutas e Legumes');
insert into tipo_fornecedor values (104,'Mercearia');
insert into tipo_fornecedor values (105,'Bebida');
insert into tipo_fornecedor values (106,'Peixe');
insert into tipo_fornecedor values (107,'Detergentes');
		
insert into fornecedor values (509111222,'LactoSerrano',234872372,NULL,60,102);
insert into fornecedor values (509121212,'FrescoNorte',221234567,'Rua do Complexo Grande - Edf 3',90,102);
insert into fornecedor values (509294734,'PinkDrinks',2123231732,'Rua Poente 723',30,105);
insert into fornecedor values (509827353,'LactoSerrano',234872372,NULL,60,102);
insert into fornecedor values (509836433,'LeviClean',229343284,'Rua Sol Poente 6243',30,107);
insert into fornecedor values (509987654,'MaduTex',234873434,'Estrada da Cincunvalacao 213',30,104);
insert into fornecedor values (590972623,'ConservasMac', 234112233,'Rua da Recta 233',30,104);
				
insert into produto values (10001,'Bife da Pa', 8.75,23,125);
insert into produto values (10002,'Laranja Algarve',1.25,23,1000);
insert into produto values (10003,'Pera Rocha',1.45,23,2000);
insert into produto values (10004,'Secretos de Porco Preto',10.15,23,342);
insert into produto values (10005,'Vinho Rose Plus',2.99,13,5232);
insert into produto values (10006,'Queijo de Cabra da Serra',15.00,23,3243);
insert into produto values (10007,'Queijo Fresco do Dia',0.65,23,452);
insert into produto values (10008,'Cerveja Preta Artesanal',1.65,13,937);
insert into produto values (10009,'Lixivia de Cor', 1.85,23,9382);
insert into produto values (10010,'Amaciador Neutro', 4.05,23,932432);
insert into produto values (10011,'Agua Natural',0.55,6,919323);
insert into produto values (10012,'Pao de Leite',0.15,6,5434);
insert into produto values (10013,'Arroz Agulha',1.00,13,7665);
insert into produto values (10014,'Iogurte Natural',0.40,13,998);
	
insert into encomenda values (1,'2015-03-03',509111222);
insert into encomenda values (2,'2015-03-04',509121212);
insert into encomenda values (3,'2015-03-05',509987654);
insert into encomenda values (4,'2015-03-06',509827353);
insert into encomenda values (5,'2015-03-07',509294734);
insert into encomenda values (6,'2015-03-08',509836433);
insert into encomenda values (7,'2015-03-09',509121212);
insert into encomenda values (8,'2015-03-10',509987654);
insert into encomenda values (9,'2015-03-11',509836433);
insert into encomenda values (10,'2015-03-12',509987654);
			
insert into item values (1,10001,200);
insert into item values (1,10004,300);
insert into item values (2,10002,1200);
insert into item values (2,10003,3200);
insert into item values (3,10013,900);
insert into item values (4,10006,50);
insert into item values (4,10007,40);
insert into item values (4,10014,200);
insert into item values (5,10005,500);
insert into item values (5,10008,10);
insert into item values (5,10011,1000);
insert into item values (6,10009,200);
insert into item values (6,10010,200);
insert into item values (7,10003,1200);
insert into item values (8,10013,350);
insert into item values (9,10009,100);
insert into item values (9,10010,300);
insert into item values (10,10012,200);


-- Queries
/*
-- a) Lista dos fornecedores que nunca tiveram encomendas;
SELECT fornecedor.nome,encomenda.numero AS numeroDeEnc
FROM (fornecedor LEFT OUTER JOIN encomenda ON fornecedor.nif=fornecedor)
WHERE encomenda.numero IS NULL

-- b) Número de prescrições por especialidade médica; 
SELECT item.codProd,unidades
FROM item


-- c) Número de prescrições processadas por farmácia;
SELECT SUM(item.unidades)
FROM item
WHERE numEnc=1;
*/
-- d) Para a farmacêutica com registo número 906, lista dos seus fármacos nunca prescritos;
