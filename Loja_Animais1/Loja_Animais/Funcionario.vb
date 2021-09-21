<Serializable()> Public Class Funcionario

    Private Funcionario_telemovel As String
    Private Funcionario_Nome As String
    Private Funcionario_ID As String
    Public Funcionario_Super_ID As String
    Private Funcionario_Morada As String



    Property FuncionarioNome() As String
        Get
            FuncionarioNome = Funcionario_Nome
        End Get
        Set(ByVal value As String)
            Funcionario_Nome = value
        End Set
    End Property

    Property FuncionarioMorada() As String
        Get
            FuncionarioMorada = Funcionario_Morada
        End Get
        Set(ByVal value As String)
            Funcionario_Morada = value
        End Set
    End Property





    Property FuncionarioTelemovel As String
        Get
            FuncionarioTelemovel = Funcionario_telemovel
        End Get
        Set(ByVal value As String)
            Funcionario_telemovel = value
        End Set
    End Property

    Property FuncionarioID As String
        Get
            Return Funcionario_ID
        End Get
        Set(ByVal value As String)
            Funcionario_ID = value
        End Set
    End Property

    Property FuncionarioSuper_ID As String
        Get
            Return Funcionario_Super_ID
        End Get
        Set(ByVal value As String)
            Funcionario_Super_ID = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return Funcionario_ID & "   " & Funcionario_Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub
End Class
