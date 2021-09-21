<Serializable()> Public Class Tratador

    Private Tratador_telemovel As String
    Private Tratador_Nome As String
    Private Tratador_ID As String
    Public Tratador_Super_ID As String
    Private Tratador_Morada As String
    Private Tratador_Tratamento As String
    Private Tratador_Animal As String



    Property TratadorNome() As String
        Get
            TratadorNome = Tratador_Nome
        End Get
        Set(ByVal value As String)
            Tratador_Nome = value
        End Set
    End Property

    Property TratadorMorada() As String
        Get
            TratadorMorada = Tratador_Morada
        End Get
        Set(ByVal value As String)
            Tratador_Morada = value
        End Set
    End Property





    Property TratadorTelemovel As String
        Get
            TratadorTelemovel = Tratador_telemovel
        End Get
        Set(ByVal value As String)
            Tratador_telemovel = value
        End Set
    End Property

    Property TratadorID As String
        Get
            Return Tratador_ID
        End Get
        Set(ByVal value As String)
            Tratador_ID = value
        End Set
    End Property

    Property TratadorAnimal As String
        Get
            Return Tratador_Animal
        End Get
        Set(ByVal value As String)
            Tratador_Animal = value
        End Set
    End Property

    Property TratadorTratamento As String
        Get
            Return Tratador_Tratamento
        End Get
        Set(ByVal value As String)
            Tratador_Tratamento = value
        End Set
    End Property

    Property TratadorSuper_ID As String
        Get
            Return Tratador_Super_ID
        End Get
        Set(ByVal value As String)
            Tratador_Super_ID = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return Tratador_ID & "   " & Tratador_Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub
End Class

