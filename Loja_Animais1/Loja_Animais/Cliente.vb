<Serializable()> Public Class Cliente

    Private Cliente_telemovel As String
    Private Cliente_Nome As String
    Private Cliente_NIF As String
    Private Cliente_Morada As String



    Property ClienteNome() As String
        Get
            ClienteNome = Cliente_Nome
        End Get
        Set(ByVal value As String)
            Cliente_Nome = value
        End Set
    End Property

    Property ClienteMorada() As String
        Get
            ClienteMorada = Cliente_Morada
        End Get
        Set(ByVal value As String)
            Cliente_Morada = value
        End Set
    End Property





    Property ClienteTelemovel As String
        Get
            ClienteTelemovel = Cliente_telemovel
        End Get
        Set(ByVal value As String)
            Cliente_telemovel = value
        End Set
    End Property

    Property ClienteNIF As String
        Get
            Return Cliente_NIF
        End Get
        Set(ByVal value As String)
            Cliente_NIF = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return Cliente_NIF & "   " & Cliente_Nome
    End Function

        Public Sub New()
            MyBase.New()
        End Sub



End Class
