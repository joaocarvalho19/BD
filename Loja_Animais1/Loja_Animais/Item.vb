<Serializable()> Public Class Item

    Private Item_ID As String
    Private Item_Preço As String
    Private Item_Descrição As String
    Private Item_Quantidade As String



    Property ItemID() As String
        Get
            ItemID = Item_ID
        End Get
        Set(ByVal value As String)
            Item_ID = value
        End Set
    End Property

    Property ItemPreço() As String
        Get
            ItemPreço = Item_Preço
        End Get
        Set(ByVal value As String)
            Item_Preço = value
        End Set
    End Property





    Property ItemDescriçao As String
        Get
            ItemDescriçao = Item_Descrição
        End Get
        Set(ByVal value As String)
            Item_Descrição = value
        End Set
    End Property

    Property ItemQuantidade As String
        Get
            Return Item_Quantidade
        End Get
        Set(ByVal value As String)
            Item_Quantidade = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return Item_ID & "   " & Item_Quantidade
    End Function

    Public Sub New()
        MyBase.New()
    End Sub
End Class
