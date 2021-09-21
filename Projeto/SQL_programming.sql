USE Loja_Animais
GO




-- TRIGGERS:



--DROP TRIGGER 



CREATE TRIGGER item_em_stock ON dbo.COMPRA_TEM_ITEM
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Quantidade as int
	DECLARE @ID_compra as int
	DECLARE @ID_item as int

	SELECT @Quantidade = Quantidade,@ID_compra=ID_compra,@ID_item=ID_item from inserted;
	
	IF @Quantidade > (SELECT ITEM.Quantidade FROM ITEM WHERE ITEM.ID=@ID_item )
		RAISERROR ('Quantidade da compra é superior à quantidade do item em stock!',16,1);
	ELSE
		INSERT INTO COMPRA_TEM_ITEM SELECT * FROM inserted
END
GO




CREATE TRIGGER dbo.ClienteTrigger ON CLIENTE
AFTER INSERT
AS PRINT ('Cliente inserido com sucesso')




CREATE TRIGGER dbo.FuncionarioTrigger ON FUNCIONARIO
AFTER INSERT
AS PRINT ('Funcionario inserido com sucesso')




CREATE TRIGGER dbo.ItemTrigger ON ITEM
AFTER INSERT
AS PRINT ('Item inserido com sucesso')




CREATE TRIGGER dbo.FornecedorTrigger ON FORNECEDOR
AFTER INSERT
AS PRINT ('Fornecedor inserido com sucesso')



CREATE TRIGGER dbo.ItemDeleteTrigger ON ITEM
AFTER DELETE
AS PRINT ('Item eliminado com sucesso')



CREATE TRIGGER dbo.FuncionarioDeleteTrigger ON FUNCIONARIO
AFTER DELETE
AS PRINT ('Funcionario eliminado com sucesso')


CREATE TRIGGER dbo.FornecedorDeleteTrigger ON FORNECEDOR
AFTER DELETE
AS PRINT ('Fornecedor eliminado com sucesso')



-- STORED PROCEDURES:


-- DROP PROCEDURE



CREATE PROCEDURE dbo.spCompra
	@Data date,
	@ID int,
	@ID_vendedor int,  
	@NIF_cliente int,                    
	@Total decimal(10,2)
AS
BEGIN
	
	SET NOCOUNT ON;

	insert COMPRA values (@Data,@ID,@ID_vendedor,@NIF_cliente,@Total)

END
GO



CREATE PROCEDURE dbo.spEncomenda
	@ID_encomenda int,
	@ID_item int,  
	@Quantidade int                    
AS
BEGIN
	
	SET NOCOUNT ON;

	insert ENCOMENDA_TEM_ITEM values (@Quantidade,@ID_encomenda,@ID_item)

END
GO




CREATE PROCEDURE dbo.spItens
	@Quantidade int,
	@ID_compra int,  
	@ID_item int                    
AS
BEGIN
	
	SET NOCOUNT ON;

	insert COMPRA_TEM_ITEM values (@Quantidade,@ID_compra,@ID_item)

END
GO


CREATE PROCEDURE dbo.TopClientes
AS
BEGIN
	SELECT NIF,sum(Total) as total_gasto FROM ((CLIENTE JOIN COMPRA ON CLIENTE.NIF = COMPRA.NIF_cliente))
	GROUP BY (NIF)
ORDER BY total_gasto DESC
END
GO
	

DROP PROCEDURE dbo.TipoTratamento
CREATE PROCEDURE dbo.TipoTratamento @ID_tratador int
AS
BEGIN
	SELECT ANIMAL_TEM_TRATAMENTO.ID_tratador,ID_animal,Tipo_tratamento
	FROM ANIMAL_TEM_TRATAMENTO 
	WHERE ID_tratador = @ID_tratador
END
GO