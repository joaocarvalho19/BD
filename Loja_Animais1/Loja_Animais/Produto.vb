Public Class Produto
    Inherits Item

    Private Produto_ID As String
    Private Produto_Categoria As String



    Property ProdutoID As String
        Get
            Return Produto_ID
        End Get
        Set(ByVal value As String)
            Produto_ID = value
        End Set
    End Property



    Property ProdutoPreço As String
        Get
            Return ItemPreço
        End Get
        Set(ByVal value As String)
            ItemPreço = value
        End Set
    End Property

    Property ProdutoQuantidade As String
        Get
            Return ItemQuantidade
        End Get
        Set(ByVal value As String)
            ItemQuantidade = value
        End Set
    End Property

    Property ProdutoDescriçao As String
        Get
            Return ItemDescriçao
        End Get
        Set(ByVal value As String)
            ItemDescriçao = value
        End Set
    End Property

    Property ProdutoCategoria As String
        Get
            Return Produto_Categoria
        End Get
        Set(ByVal value As String)
            Produto_Categoria = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return ProdutoID & "   " & ProdutoCategoria
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

End Class
