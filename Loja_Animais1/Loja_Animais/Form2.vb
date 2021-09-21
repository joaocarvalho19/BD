Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient



Public Class Form2

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentCliente As Integer
    Dim currentFornecedor As Integer
    Dim currentFuncionario As Integer
    Dim currentAnimal As Integer
    Dim currentProduto As Integer
    Dim adding As Boolean
    Public ds As DataSet
    Public bs As BindingSource
    Public message As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Change this line...
        CN = New SqlConnection("data source=JCARVALHO\SQLEXPRESS;integrated security=true;initial catalog=Loja_Animais")

        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles compra.Click

    End Sub




    Private Sub fornecedores_Click(sender As Object, e As EventArgs) Handles fornecedores.Click
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = True
        PanelInicial.Visible = False
        Panel5.Visible = False
        ListBox2.Items.Clear()

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
        PanelClientes.Visible = True
        PanelFuncionarios.Visible = False
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        Panel2.Visible = False
        ListBox1.Items.Clear()

    End Sub

    Private Sub funcionários_Click(sender As Object, e As EventArgs) Handles funcionários.Click
        PanelClientes.Visible = False
        PanelFuncionarios.Visible = True
        PanelStock.Visible = False
        PanelFornecedores.Visible = False
        PanelInicial.Visible = False
        Panel4.Visible = False
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
        Button6.Visible = True
        Button7.Visible = True

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
        Button5.Visible = False
        Button4.Visible = True
        Button3.Visible = True
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

        ID_PRODUTO.Text = ""
        DESCRIÇAO_PRODUTO.Text = ""
        PREÇO_PRODUTO.Text = ""
        QUANTIDADE_PRODUTO.Text = ""
        CATEGORIA_PRODUTO.Text = ""

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
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles ID_PRODUTO.TextChanged

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

        CMD.CommandText = "SELECT * FROM FUNCIONARIO"
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
        NOME_FUNCIONARIO.Text = ""
        ID_FUNCIONARIO.Text = ""
        MORADA_FUNCIONARIO.Text = ""
        TELEMOVEL_FUNCIONARIO.Text = ""
        SUPER_ID_FUNCIONARIO.Text = ""

        CMD.ExecuteNonQuery()
        CN.Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
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
End Class