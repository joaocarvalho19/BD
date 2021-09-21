<Serializable()> Public Class Fornecedor


    Private Fornecedor_telemovel As String
    Private Fornecedor_Nome As String
    Private Fornecedor_NIF As String
    Private Fornecedor_Morada As String



    Property FornecedorNome() As String
        Get
            FornecedorNome = Fornecedor_Nome
        End Get
        Set(ByVal value As String)
            Fornecedor_Nome = value
        End Set
    End Property

    Property FornecedorMorada() As String
        Get
            FornecedorMorada = Fornecedor_Morada
        End Get
        Set(ByVal value As String)
            Fornecedor_Morada = value
        End Set
    End Property





    Property FornecedorTelemovel As String
        Get
            FornecedorTelemovel = Fornecedor_telemovel
        End Get
        Set(ByVal value As String)
            Fornecedor_telemovel = value
        End Set
    End Property

    Property FornecedorNIF As String
        Get
            Return Fornecedor_NIF
        End Get
        Set(ByVal value As String)
            Fornecedor_NIF = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return Fornecedor_NIF & "   " & Fornecedor_Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class
