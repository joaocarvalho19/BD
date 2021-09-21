Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient



Public Class Form2

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim DR As SqlDataReader
    Dim currentCliente As Integer
    Dim currentFornecedor As Integer
    Dim currentFuncionario As Integer
    Dim currentAnimal As Integer
    Dim currentProduto As Integer
    Dim currentTratador As Integer
    Dim adding As Boolean
    Dim chega As Boolean

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Change this line...
        CN = New SqlConnection("data source=JCARVALHO\SQLEXPRESS;integrated security=true;initial catalog=Loja_Animais")

        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles compra.Click
        PanelData.Visible = False
        PanelItem.Visible = False
        Button28.Visible = True
        Button29.Visible = True
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        PanelInicial.Visible = False
        PanelCompra.Visible = True
        PanelEncomenda.Visible = False

    End Sub




    Private Sub fornecedores_Click(sender As Object, e As EventArgs) Handles fornecedores.Click
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = True
        PanelInicial.Visible = False
        Panel5.Visible = False
        ListBox2.Items.Clear()
        PanelCompra.Visible = False
        PanelEncomenda.Visible = False

    End Sub

    Private Sub PanelEncomenda_Paint(sender As Object, e As PaintEventArgs) Handles PanelEncomenda.Paint

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TELEMOVEL_CLIENTE.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CN.Open()
        CMD.CommandText = "DELETE FROM CLIENTE WHERE NIF='" + NIF_CLIENTE.Text + "'"
        NOME_CLIENTE.Text = ""
        NIF_CLIENTE.Text = ""
        TELEMOVEL_CLIENTE.Text = ""
        MORADA_CLIENTE.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub clientes_Click(sender As Object, e As EventArgs) Handles clientes.Click
        PanelInicial.Visible = False
        DataGridView4.Visible = False
        PanelClientes.Visible = True
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        Panel2.Visible = False
        ListBox1.Items.Clear()
        PanelCompra.Visible = False
        PanelEncomenda.Visible = False
        DataGridView4.Visible = False
        ListBox1.Visible = False

    End Sub

    Private Sub funcionários_Click(sender As Object, e As EventArgs) Handles funcionários.Click
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = True
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        PanelInicial.Visible = False
        PanelVendedor.Visible = False
        PanelTratador.Visible = False
        PanelCompra.Visible = False
        PanelEncomenda.Visible = False
        Button34.Visible = True
        Button35.Visible = True
        Button39.Visible = False
        Button40.Visible = False
        Button11.Visible = False
        Button10.Visible = False
        ListBox3.Items.Clear()

    End Sub

    Private Sub stock_Click(sender As Object, e As EventArgs) Handles stock.Click
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = False
        PanelStock.Visible = True
        PanelFornecedores.Visible = False
        PanelInicial.Visible = False
        PanelAnimais.Visible = False
        PanelProdutos.Visible = False
        ListBox5.Items.Clear()
        PanelCompra.Visible = False
        PanelEncomenda.Visible = False
        Button6.Visible = True
        Button7.Visible = True

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
        DataGridView4.Visible = False
        Button5.Visible = False
        Button4.Visible = True
        Button3.Visible = True
        PanelCompra.Visible = False
        PanelInicial.Visible = False

        CMD.CommandText = "SELECT * FROM CLIENTE"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Cliente
            C.ClienteTelemovel = RDR.Item("TELEMOVEL")
            C.ClienteNIF = RDR.Item("NIF")
            C.ClienteNome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NOME")), "", RDR.Item("NOME")))
            C.ClienteMorada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("MORADA")), "", RDR.Item("MORADA")))

            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentCliente = 0
        SHOWCLIENTE()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = True
        Button4.Visible = False
        Button3.Visible = False
        Button5.Visible = True
        PanelInicial.Visible = False
        DataGridView4.Visible = False
        NOME_CLIENTE.Text = ""
        NIF_CLIENTE.Text = ""
        TELEMOVEL_CLIENTE.Text = ""
        MORADA_CLIENTE.Text = ""

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CN.Open()

        CMD.CommandText = "insert CLIENTE values('" + NOME_CLIENTE.Text + "'," + NIF_CLIENTE.Text + ",'" + MORADA_CLIENTE.Text + "'," + TELEMOVEL_CLIENTE.Text + ")"
        NOME_CLIENTE.Text = ""
        NIF_CLIENTE.Text = ""
        TELEMOVEL_CLIENTE.Text = ""
        MORADA_CLIENTE.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel5.Visible = True
        Button15.Visible = True
        Button16.Visible = False
        Button17.Visible = False

        NOME_FORNECEDOR.Text = ""
        NIF_FORNECEDOR.Text = ""
        MORADA_FORNECEDOR.Text = ""
        TELEMOVEL_FORNECEDOR.Text = ""
    End Sub


    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click

        CN.Open()

        CMD.CommandText = "insert ITEM values(@id,@pr,@desc,@qua)"
        CMD.Parameters.AddWithValue("@id", ID_PRODUTO.Text)
        CMD.Parameters.AddWithValue("@pr", PREÇO_PRODUTO.Text)
        CMD.Parameters.AddWithValue("@desc", DESCRIÇAO_PRODUTO.Text)
        CMD.Parameters.AddWithValue("@qua", QUANTIDADE_PRODUTO.Text)

        CMD.ExecuteNonQuery()
        CN.Close()
        CN.Open()
        CMD.CommandText = "insert PRODUTO values('" + CATEGORIA_PRODUTO.Text + "'," + ID_PRODUTO.Text + ")"
        ID_PRODUTO.Text = ""
        DESCRIÇAO_PRODUTO.Text = ""
        PREÇO_PRODUTO.Text = ""
        QUANTIDADE_PRODUTO.Text = ""
        CATEGORIA_PRODUTO.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles DESCRIÇAO_ANIMAL.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel5.Visible = True
        Button15.Visible = False
        Button16.Visible = True
        Button17.Visible = True

        CMD.CommandText = "SELECT * FROM FORNECEDOR"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While RDR.Read
            Dim C As New Fornecedor
            C.FornecedorTelemovel = RDR.Item("TELEMOVEL")
            C.FornecedorNIF = RDR.Item("NIF")
            C.FornecedorNome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NOME")), "", RDR.Item("NOME")))
            C.FornecedorMorada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("MORADA")), "", RDR.Item("MORADA")))

            ListBox2.Items.Add(C)
        End While
        CN.Close()
        currentFornecedor = 0
        SHOWFORNECEDOR()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Panel4.Visible = True
        Button12.Visible = False
        Button13.Visible = True
        Button14.Visible = True

        CMD.CommandText = "SELECT * FROM (FUNCIONARIO JOIN VENDEDOR ON FUNCIONARIO.ID=VENDEDOR.ID_funcionario)"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While RDR.Read
            Dim C As New Funcionario
            C.FuncionarioTelemovel = RDR.Item("TELEMOVEL")
            C.FuncionarioID = RDR.Item("ID")
            C.FuncionarioSuper_ID = RDR.Item("SUPER_ID")
            C.FuncionarioNome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NOME")), "", RDR.Item("NOME")))
            C.FuncionarioMorada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("MORADA")), "", RDR.Item("MORADA")))

            ListBox3.Items.Add(C)
        End While
        CN.Close()
        currentFuncionario = 0
        SHOWFUNCIONARIO()

    End Sub





    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Panel4.Visible = True
        Button13.Visible = False
        Button14.Visible = False
        Button12.Visible = True

        ID_FUNCIONARIO.Text = ""
        NOME_FUNCIONARIO.Text = ""
        TELEMOVEL_FUNCIONARIO.Text = ""
        MORADA_FUNCIONARIO.Text = ""
        SUPER_ID_FUNCIONARIO.Text = ""
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click

        PanelAnimais.Visible = False
        PanelProdutos.Visible = True
        Button6.Visible = False
        Button7.Visible = False
        Panel6.Visible = False

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Visible = False
        Button7.Visible = False
        PanelAnimais.Visible = True
        PanelProdutos.Visible = False
        Panel8.Visible = False
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Button18.Visible = False
        Panel6.Visible = True
        Button20.Visible = True
        Button19.Visible = True



        CMD.CommandText = "SELECT ITEM.Descriçao,ITEM.Quantidade,ITEM.Preço,ITEM.ID,PRODUTO.TP_categoria FROM (ITEM JOIN PRODUTO ON ITEM.ID=PRODUTO.ID_item)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox4.Items.Clear()
        While RDR.Read
            Dim C As New Produto
            C.ProdutoCategoria = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("TP_CATEGORIA")), "", RDR.Item("TP_CATEGORIA")))
            C.ProdutoID = RDR.Item("ID")
            C.ProdutoDescriçao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("DESCRIÇAO")), "", RDR.Item("DESCRIÇAO")))
            C.ProdutoQuantidade = RDR.Item("QUANTIDADE")
            C.ProdutoPreço = RDR.Item("PREÇO")
            ListBox4.Items.Add(C)
        End While
        CN.Close()
        currentProduto = 0
        SHOWPRODUTO()

    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Panel8.Visible = True
        Button23.Visible = False
        Button25.Visible = True
        Button24.Visible = True

        CMD.CommandText = "SELECT ITEM.Descriçao,ITEM.Quantidade,ITEM.Preço,ITEM.ID,ANIMAL.Genero,ANIMAL.Idade,ANIMAL.Nome,ANIMAL.TA_especie
FROM (ITEM JOIN ANIMAL ON ITEM.ID=ANIMAL.ID_item)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox5.Items.Clear()
        While RDR.Read
            Dim C As New Animal
            C.AnimalEspecie = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("TA_ESPECIE")), "", RDR.Item("TA_ESPECIE")))
            C.AnimalID = RDR.Item("ID")
            C.AnimalIdade = RDR.Item("IDADE")
            C.AnimalNome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NOME")), "", RDR.Item("NOME")))
            C.AnimalGenero = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("GENERO")), "", RDR.Item("GENERO")))
            C.AnimalDescriçao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("DESCRIÇAO")), "", RDR.Item("DESCRIÇAO")))
            C.AnimalQuantidade = RDR.Item("QUANTIDADE")
            C.AnimalPreço = RDR.Item("PREÇO")
            ListBox5.Items.Add(C)
        End While
        CN.Close()
        currentAnimal = 0
        SHOWANIMAL()

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Panel6.Visible = True
        Button18.Visible = True
        Button19.Visible = False
        Button20.Visible = False

        ID_PRODUTO.Text = ""
        DESCRIÇAO_PRODUTO.Text = ""
        PREÇO_PRODUTO.Text = ""
        QUANTIDADE_PRODUTO.Text = ""
        CATEGORIA_PRODUTO.Text = ""

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        CN.Open()
        CMD.CommandText = "DELETE FROM ANIMAL WHERE ID_item='" + ID_ANIMAL.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM ITEM WHERE ID='" + ID_ANIMAL.Text + "'"
        IDADE_ANIMAL.Text = ""
        NOME_ANIMAL.Text = ""
        GENERO_ANIMAL.Text = ""
        ESPECIE_ANIMAL.Text = ""
        QUANTIDADE_ANIMAL.Text = ""
        PREÇO_ANIMAL.Text = ""
        ID_ANIMAL.Text = ""
        DESCRIÇAO_ANIMAL.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Button23.Visible = True
        Button24.Visible = False
        Button25.Visible = False
        Panel8.Visible = True

    End Sub



    Sub SHOWCLIENTE()
        If ListBox1.Items.Count = 0 Or currentCliente < 0 Then Exit Sub
        Dim C As New Cliente
        C = CType(ListBox1.Items.Item(currentCliente), Cliente)
        NOME_CLIENTE.Text = C.ClienteNome
        NIF_CLIENTE.Text = C.ClienteNIF
        MORADA_CLIENTE.Text = C.ClienteMorada
        TELEMOVEL_CLIENTE.Text = C.ClienteTelemovel
    End Sub


    Sub SHOWFORNECEDOR()
        If ListBox2.Items.Count = 0 Or currentFornecedor < 0 Then Exit Sub
        Dim C As New Fornecedor
        C = CType(ListBox2.Items.Item(currentFornecedor), Fornecedor)
        NOME_FORNECEDOR.Text = C.FornecedorNome
        NIF_FORNECEDOR.Text = C.FornecedorNIF
        MORADA_FORNECEDOR.Text = C.FornecedorMorada
        TELEMOVEL_FORNECEDOR.Text = C.FornecedorTelemovel
    End Sub


    Sub SHOWFUNCIONARIO()
        If ListBox3.Items.Count = 0 Or currentFuncionario < 0 Then Exit Sub
        Dim C As New Funcionario
        C = CType(ListBox3.Items.Item(currentFuncionario), Funcionario)
        NOME_FUNCIONARIO.Text = C.FuncionarioNome
        ID_FUNCIONARIO.Text = C.FuncionarioID
        TELEMOVEL_FUNCIONARIO.Text = C.FuncionarioTelemovel
        MORADA_FUNCIONARIO.Text = C.FuncionarioMorada
        SUPER_ID_FUNCIONARIO.Text = C.Funcionario_Super_ID
    End Sub

    Sub SHOWTRATADOR()
        If ListBox6.Items.Count = 0 Or currentTratador < 0 Then Exit Sub
        Dim C As New Tratador
        C = CType(ListBox6.Items.Item(currentFuncionario), Tratador)
        NOME_TRATADOR.Text = C.TratadorNome
        ID_TRATADOR.Text = C.TratadorID
        TELEMOVEL_TRATADOR.Text = C.TratadorTelemovel
        MORADA_TRATADOR.Text = C.TratadorMorada
        SUPER_ID_TRATADOR.Text = C.Tratador_Super_ID
        TRATAMENTO_TRATADOR.Text = C.TratadorTratamento
        ANIMAL_TRATADOR.Text = C.TratadorAnimal
    End Sub

    Sub SHOWANIMAL()
        If ListBox5.Items.Count = 0 Or currentFuncionario < 0 Then Exit Sub
        Dim C As New Animal
        C = CType(ListBox5.Items.Item(currentAnimal), Animal)
        NOME_ANIMAL.Text = C.AnimalNome
        ID_ANIMAL.Text = C.AnimalID
        GENERO_ANIMAL.Text = C.AnimalGenero
        IDADE_ANIMAL.Text = C.AnimalIdade
        ESPECIE_ANIMAL.Text = C.AnimalEspecie
        DESCRIÇAO_ANIMAL.Text = C.AnimalDescriçao
        PREÇO_ANIMAL.Text = C.AnimalPreço
        QUANTIDADE_ANIMAL.Text = C.AnimalQuantidade
    End Sub

    Sub SHOWPRODUTO()
        If ListBox4.Items.Count = 0 Or currentProduto < 0 Then Exit Sub
        Dim C As New Produto
        C = CType(ListBox4.Items.Item(currentProduto), Produto)
        ID_PRODUTO.Text = C.ProdutoID
        DESCRIÇAO_PRODUTO.Text = C.ProdutoDescriçao
        PREÇO_PRODUTO.Text = C.ProdutoPreço
        QUANTIDADE_PRODUTO.Text = C.ProdutoQuantidade
        CATEGORIA_PRODUTO.Text = C.ProdutoCategoria
    End Sub


    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles ID_FUNCIONARIO.TextChanged

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles CATEGORIA_PRODUTO.TextChanged

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles PREÇO_PRODUTO.TextChanged

    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        currentProduto = ListBox4.SelectedIndex
        SHOWPRODUTO()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click

        CN.Open()
        CMD.CommandText = "DELETE FROM COMPRA_TEM_ITEM WHERE ID_item='" + ID_PRODUTO.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM ENCOMENDA_TEM_ITEM WHERE ID_item='" + ID_PRODUTO.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM PRODUTO WHERE ID_item='" + ID_PRODUTO.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM ITEM WHERE ID='" + ID_PRODUTO.Text + "'"
        ID_PRODUTO.Text = ""
        DESCRIÇAO_PRODUTO.Text = ""
        PREÇO_PRODUTO.Text = ""
        QUANTIDADE_PRODUTO.Text = ""
        CATEGORIA_PRODUTO.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CN.Open()
        CMD.CommandText = "UPDATE ITEM SET Descriçao = '" + DESCRIÇAO_PRODUTO.Text + "', Quantidade =" + QUANTIDADE_PRODUTO.Text + ", Preço = '" + PREÇO_PRODUTO.Text + "' WHERE ID = " + ID_PRODUTO.Text
        ID_PRODUTO.Text = ""
        DESCRIÇAO_PRODUTO.Text = ""
        PREÇO_PRODUTO.Text = ""
        QUANTIDADE_PRODUTO.Text = ""
        CATEGORIA_PRODUTO.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        currentCliente = ListBox1.SelectedIndex
        SHOWCLIENTE()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CN.Open()
        CMD.CommandText = "UPDATE CLIENTE SET Nome = '" + NOME_CLIENTE.Text + "', Morada = '" + MORADA_CLIENTE.Text + "', Telemovel = " + TELEMOVEL_CLIENTE.Text + " WHERE NIF = " + NIF_CLIENTE.Text
        NOME_CLIENTE.Text = ""
        NIF_CLIENTE.Text = ""
        TELEMOVEL_CLIENTE.Text = ""
        MORADA_CLIENTE.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        currentFornecedor = ListBox2.SelectedIndex
        SHOWFORNECEDOR()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CN.Open()

        CMD.CommandText = "insert FORNECEDOR values('" + NOME_FORNECEDOR.Text + "'," + NIF_FORNECEDOR.Text + ",'" + MORADA_FORNECEDOR.Text + "'," + TELEMOVEL_FORNECEDOR.Text + ")"
        NOME_FORNECEDOR.Text = ""
        NIF_FORNECEDOR.Text = ""
        MORADA_FORNECEDOR.Text = ""
        TELEMOVEL_FORNECEDOR.Text = ""

        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CN.Open()
        CMD.CommandText = "DELETE FROM FORNECEDOR WHERE NIF='" + NIF_FORNECEDOR.Text + "'"
        NOME_FORNECEDOR.Text = ""
        NIF_FORNECEDOR.Text = ""
        MORADA_FORNECEDOR.Text = ""
        TELEMOVEL_FORNECEDOR.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CN.Open()
        CMD.CommandText = "UPDATE FORNECEDOR SET Nome = '" + NOME_FORNECEDOR.Text + "', Morada = '" + MORADA_FORNECEDOR.Text + "', Telemovel = " + TELEMOVEL_FORNECEDOR.Text + " WHERE NIF = " + NIF_FORNECEDOR.Text
        NOME_FORNECEDOR.Text = ""
        NIF_FORNECEDOR.Text = ""
        MORADA_FORNECEDOR.Text = ""
        TELEMOVEL_FORNECEDOR.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        currentFuncionario = ListBox3.SelectedIndex
        SHOWFUNCIONARIO()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        CN.Open()
        CMD.CommandText = "insert FUNCIONARIO values('" + NOME_FUNCIONARIO.Text + "'," + ID_FUNCIONARIO.Text + "," + TELEMOVEL_FUNCIONARIO.Text + ",'" + MORADA_FUNCIONARIO.Text + "', " + SUPER_ID_FUNCIONARIO.Text + ")"

        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "insert VENDEDOR values(" + ID_FUNCIONARIO.Text + ")"
        CMD.ExecuteNonQuery()
        CN.Close()
        NOME_FUNCIONARIO.Text = ""
        ID_FUNCIONARIO.Text = ""
        MORADA_FUNCIONARIO.Text = ""
        TELEMOVEL_FUNCIONARIO.Text = ""
        SUPER_ID_FUNCIONARIO.Text = ""
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CN.Open()
        CMD.CommandText = "DELETE FROM VENDEDOR WHERE ID_funcionario='" + ID_FUNCIONARIO.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM FUNCIONARIO WHERE ID='" + ID_FUNCIONARIO.Text + "'"
        NOME_FUNCIONARIO.Text = ""
        ID_FUNCIONARIO.Text = ""
        MORADA_FUNCIONARIO.Text = ""
        TELEMOVEL_FUNCIONARIO.Text = ""
        SUPER_ID_FUNCIONARIO.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CN.Open()
        CMD.CommandText = "UPDATE FUNCIONARIO SET Nome = '" + NOME_FUNCIONARIO.Text + "', Morada = '" + MORADA_FUNCIONARIO.Text + "', Telemovel = " + TELEMOVEL_FUNCIONARIO.Text + " WHERE ID = " + ID_FUNCIONARIO.Text
        NOME_FUNCIONARIO.Text = ""
        ID_FUNCIONARIO.Text = ""
        MORADA_FUNCIONARIO.Text = ""
        TELEMOVEL_FUNCIONARIO.Text = ""
        SUPER_ID_FUNCIONARIO.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        currentAnimal = ListBox5.SelectedIndex
        SHOWANIMAL()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click

        CN.Open()
        CMD.CommandText = "insert ITEM values(@id,@pr,@desc,@qua)"
        CMD.Parameters.AddWithValue("@id", ID_ANIMAL.Text)
        CMD.Parameters.AddWithValue("@pr", PREÇO_ANIMAL.Text)
        CMD.Parameters.AddWithValue("@desc", DESCRIÇAO_ANIMAL.Text)
        CMD.Parameters.AddWithValue("@qua", QUANTIDADE_ANIMAL.Text)
        CMD.ExecuteNonQuery()
        CN.Close()
        CN.Open()

        CMD.CommandText = "insert ANIMAL values(" + IDADE_ANIMAL.Text + ", '" + NOME_ANIMAL.Text + "', '" + GENERO_ANIMAL.Text + "', " + ID_ANIMAL.Text + ", '" + ESPECIE_ANIMAL.Text + "')"
        CMD.ExecuteNonQuery()
        IDADE_ANIMAL.Text = ""
        NOME_ANIMAL.Text = ""
        GENERO_ANIMAL.Text = ""
        ESPECIE_ANIMAL.Text = ""
        QUANTIDADE_ANIMAL.Text = ""
        PREÇO_ANIMAL.Text = ""
        ID_ANIMAL.Text = ""
        DESCRIÇAO_ANIMAL.Text = ""
        CN.Close()


    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        CN.Open()
        CMD.CommandText = "UPDATE ANIMAL SET Idade = " + IDADE_ANIMAL.Text + ", Nome = '" + NOME_ANIMAL.Text + "', Genero = '" + GENERO_ANIMAL.Text + "',TA_especie = '" + ESPECIE_ANIMAL.Text + "' WHERE ID_item = " + ID_ANIMAL.Text
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "UPDATE ITEM SET Descriçao = '" + DESCRIÇAO_ANIMAL.Text + "', Quantidade =" + QUANTIDADE_ANIMAL.Text + ", Preço = '" + PREÇO_ANIMAL.Text + "' WHERE ID = " + ID_ANIMAL.Text
        CMD.ExecuteNonQuery()
        IDADE_ANIMAL.Text = ""
        NOME_ANIMAL.Text = ""
        GENERO_ANIMAL.Text = ""
        ESPECIE_ANIMAL.Text = ""
        QUANTIDADE_ANIMAL.Text = ""
        PREÇO_ANIMAL.Text = ""
        ID_ANIMAL.Text = ""
        DESCRIÇAO_ANIMAL.Text = ""
        CN.Close()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        PanelData.Visible = True
        PanelItem.Visible = False
        Button29.Visible = False
        Button28.Visible = False
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Try

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                CN.Open()
                CMD = New SqlCommand
                With CMD
                    .Connection = CN
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "spCompra"
                    .Parameters.AddWithValue("@Data", Convert.ToDateTime(txtData.Text))
                    .Parameters.AddWithValue("@ID", CType(DataGridView1.Rows(i).Cells(0).Value.ToString, Integer))
                    .Parameters.AddWithValue("@ID_vendedor", CType(DataGridView1.Rows(i).Cells(1).Value.ToString, Integer))
                    .Parameters.AddWithValue("@NIF_cliente", CType(DataGridView1.Rows(i).Cells(2).Value.ToString, Integer))
                    .Parameters.AddWithValue("@Total", CDbl(DataGridView1.Rows(i).Cells(3).Value.ToString))
                    .ExecuteNonQuery()

                End With
                CN.Close()
            Next
            LoadCompras()

        Catch ex As Exception
            CN.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub



    Sub LoadCompras()
        DataGridView1.Rows.Clear()
        CN.Open()
        CMD = New SqlCommand("Select * from COMPRA where Data like @Data", CN)
        CMD.Parameters.AddWithValue("@Data", txtData.Text)
        DR = CMD.ExecuteReader
        While DR.Read
            DataGridView1.Rows.Add(DR.Item("ID").ToString, DR.Item("ID_vendedor").ToString, DR.Item("NIF_cliente").ToString, DR.Item("Total").ToString)
        End While
        DR.Close()
        CN.Close()


    End Sub

    Private Sub txtData_TextChanged(sender As Object, e As EventArgs) Handles txtData.TextChanged
        LoadCompras()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtEncomenda.TextChanged
        LoadEncomendas()
    End Sub

    Private Sub Button31_Click_1(sender As Object, e As EventArgs) Handles Button31.Click
        Dim emptyColumns As Integer = 0
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows(i).Cells(0).Value = Nothing Then
                emptyColumns += 1
            End If

        Next


        Try


            For i As Integer = DataGridView2.Rows.Count - emptyColumns - 1 To DataGridView2.Rows.Count - 2
                CN.Open()
                CMD = New SqlCommand
                With CMD
                    .Connection = CN
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "spEncomenda"
                    .Parameters.AddWithValue("@ID_encomenda", txtEncomenda.Text)
                    .Parameters.AddWithValue("@ID_item", CType(DataGridView2.Rows(i).Cells(0).Value.ToString, Integer))
                    .Parameters.AddWithValue("@Quantidade", CType(DataGridView2.Rows(i).Cells(1).Value.ToString, Integer))

                    .ExecuteNonQuery()

                End With
                CN.Close()
            Next


            LoadEncomendas()

        Catch ex As Exception
            CN.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Sub LoadTop5()
        DataGridView2.Rows.Clear()
        CN.Open()
        CMD = New SqlCommand("TopClientes", CN)

        DR = CMD.ExecuteReader
        While DR.Read
            DataGridView4.Rows.Add(DR.Item("NIF").ToString, DR.Item("total_gasto"))
        End While
        DR.Close()
        CN.Close()
        chega = True


    End Sub

    Sub LoadEncomendas()
        DataGridView2.Rows.Clear()
        CN.Open()
        CMD = New SqlCommand("Select * from ENCOMENDA_TEM_ITEM where ID_encomenda like @ID_encomenda", CN)
        CMD.Parameters.AddWithValue("@ID_encomenda", txtEncomenda.Text)
        DR = CMD.ExecuteReader
        While DR.Read
            DataGridView2.Rows.Add(DR.Item("ID_item").ToString, DR.Item("Quantidade"))
        End While
        DR.Close()
        CN.Close()


    End Sub

    Private Sub encomenda_Click(sender As Object, e As EventArgs) Handles encomenda.Click
        PanelEncomenda.Visible = True
        PanelData.Visible = False
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        PanelInicial.Visible = False
        PanelCompra.Visible = False


    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        PanelData.Visible = False
        PanelItem.Visible = True
        Button29.Visible = False
        Button28.Visible = False
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Dim emptyColumns As Integer = 0
        For i As Integer = 0 To DataGridView3.Rows.Count - 1
            If DataGridView3.Rows(i).Cells(0).Value = Nothing Then
                emptyColumns += 1
            End If

        Next


        Try


            For i As Integer = DataGridView3.Rows.Count - emptyColumns - 1 To DataGridView3.Rows.Count - 2
                CN.Open()
                CMD = New SqlCommand
                With CMD
                    .Connection = CN
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "spItens"
                    .Parameters.AddWithValue("@ID_compra", txt_item.Text)
                    .Parameters.AddWithValue("@ID_item", CType(DataGridView3.Rows(i).Cells(0).Value.ToString, Integer))
                    .Parameters.AddWithValue("@Quantidade", CType(DataGridView3.Rows(i).Cells(1).Value.ToString, Integer))

                    .ExecuteNonQuery()

                End With
                CN.Close()
            Next


            LoadItens()

        Catch ex As Exception
            CN.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub


    Sub LoadItens()
        DataGridView3.Rows.Clear()
        CN.Open()
        CMD = New SqlCommand("Select * from COMPRA_TEM_ITEM where ID_compra like @ID_compra", CN)
        CMD.Parameters.AddWithValue("@ID_compra", txt_item.Text)
        DR = CMD.ExecuteReader
        While DR.Read
            DataGridView3.Rows.Add(DR.Item("ID_item").ToString, DR.Item("Quantidade"))
        End While
        DR.Close()
        CN.Close()


    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles txt_item.TextChanged
        LoadItens()
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        'Panel2.Visible = False
        DataGridView4.Visible = True
        If chega = False Then
            LoadTop5()
        End If
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        PanelVendedor.Visible = True
        PanelTratador.Visible = False
        Panel4.Visible = False
        Button35.Visible = False
        Button34.Visible = False
        Button10.Visible = True
        Button11.Visible = True
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        PanelVendedor.Visible = False
        PanelTratador.Visible = True
        Panel4.Visible = False
        Button35.Visible = False
        Button34.Visible = False
        Button39.Visible = True
        Button40.Visible = True
        Panel9.Visible = False
        ListBox6.Items.Clear()
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        Panel9.Visible = True
        Button36.Visible = False
        Button37.Visible = True
        Button38.Visible = True

        CMD.CommandText = "SELECT * FROM (FUNCIONARIO JOIN TRATADOR ON FUNCIONARIO.ID=TRATADOR.ID_funcionario)"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox6.Items.Clear()
        While RDR.Read
            Dim C As New Tratador
            C.TratadorTelemovel = RDR.Item("TELEMOVEL")
            C.TratadorID = RDR.Item("ID")
            C.TratadorSuper_ID = RDR.Item("SUPER_ID")
            C.TratadorNome = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NOME")), "", RDR.Item("NOME")))
            C.TratadorMorada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("MORADA")), "", RDR.Item("MORADA")))



            ListBox6.Items.Add(C)
        End While
        CN.Close()
        currentTratador = 0
        SHOWTRATADOR()
    End Sub

    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged
        currentTratador = ListBox6.SelectedIndex
        SHOWTRATADOR()
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        Panel9.Visible = True
        Button37.Visible = False
        Button38.Visible = False
        Button36.Visible = True

        ID_TRATADOR.Text = ""
        NOME_TRATADOR.Text = ""
        TELEMOVEL_TRATADOR.Text = ""
        MORADA_TRATADOR.Text = ""
        SUPER_ID_TRATADOR.Text = ""
        TRATAMENTO_TRATADOR.Text = ""
        ANIMAL_TRATADOR.Text = ""
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click

        CN.Open()
        CMD.CommandText = "insert FUNCIONARIO values('" + NOME_TRATADOR.Text + "'," + ID_TRATADOR.Text + "," + TELEMOVEL_TRATADOR.Text + ",'" + MORADA_TRATADOR.Text + "', " + SUPER_ID_TRATADOR.Text + ")"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "insert TRATADOR values(" + ID_TRATADOR.Text + ")"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "insert ANIMAL_TEM_TRATAMENTO values(" + ANIMAL_TRATADOR.Text + "," + ID_TRATADOR.Text + ",'" + TRATAMENTO_TRATADOR.Text + "')"
        CMD.ExecuteNonQuery()
        CN.Close()

        NOME_TRATADOR.Text = ""
        ID_TRATADOR.Text = ""
        MORADA_TRATADOR.Text = ""
        TELEMOVEL_TRATADOR.Text = ""
        SUPER_ID_TRATADOR.Text = ""
        ANIMAL_TRATADOR.Text = ""
        TRATAMENTO_TRATADOR.Text = ""
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        CN.Open()
        CMD.CommandText = "DELETE FROM ANIMAL_TEM_TRATAMENTO WHERE ID_tratador='" + ID_TRATADOR.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM TRATADOR WHERE ID_funcionario='" + ID_TRATADOR.Text + "'"
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "DELETE FROM FUNCIONARIO WHERE ID='" + ID_TRATADOR.Text + "'"
        NOME_TRATADOR.Text = ""
        ID_TRATADOR.Text = ""
        MORADA_TRATADOR.Text = ""
        TELEMOVEL_TRATADOR.Text = ""
        SUPER_ID_TRATADOR.Text = ""
        ANIMAL_TRATADOR.Text = ""
        TRATAMENTO_TRATADOR.Text = ""
        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        CN.Open()
        CMD.CommandText = "UPDATE ANIMAL_TEM_TRATAMENTO SET ID_animal = " + ANIMAL_TRATADOR.Text + ", Tipo_tratamento = '" + TRATAMENTO_TRATADOR.Text + "' WHERE ID_tratador = " + ID_TRATADOR.Text
        CMD.ExecuteNonQuery()
        CN.Close()

        CN.Open()
        CMD.CommandText = "UPDATE FUNCIONARIO SET Nome = " + NOME_TRATADOR.Text + ", Telemovel = " + TELEMOVEL_TRATADOR.Text + ", Morada = '" + MORADA_TRATADOR.Text + "',Super_id = '" + SUPER_ID_TRATADOR.Text + "' WHERE ID_funcionario = " + ID_TRATADOR.Text
        CMD.ExecuteNonQuery()
        NOME_TRATADOR.Text = ""
        ID_TRATADOR.Text = ""
        MORADA_TRATADOR.Text = ""
        TELEMOVEL_TRATADOR.Text = ""
        SUPER_ID_TRATADOR.Text = ""
        ANIMAL_TRATADOR.Text = ""
        TRATAMENTO_TRATADOR.Text = ""
        CN.Close()
    End Sub
End Class