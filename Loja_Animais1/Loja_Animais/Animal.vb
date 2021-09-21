Public Class Animal

    Inherits Item

    Private Animal_Nome As String
    Private Animal_Genero As String
    Private Animal_Idade As String
    Private Animal_ID As String
    Private Animal_Especie As String
    Private Animal_Preço As String
    Private Animal_Quantidade As String
    Private Animal_Descriçao As String

    Property AnimalNome() As String
        Get
            AnimalNome = Animal_Nome
        End Get
        Set(ByVal value As String)
            Animal_Nome = value
        End Set
    End Property

    Property AnimalGenero() As String
        Get
            AnimalGenero = Animal_Genero
        End Get
        Set(ByVal value As String)
            Animal_Genero = value
        End Set
    End Property


    Property AnimalIdade As String
        Get
            AnimalIdade = Animal_Idade
        End Get
        Set(ByVal value As String)
            Animal_Idade = value
        End Set
    End Property

    Property AnimalID As String
        Get
            Return Animal_ID
        End Get
        Set(ByVal value As String)
            Animal_ID = value
        End Set
    End Property

    Property AnimalEspecie As String
        Get
            Return Animal_Especie
        End Get
        Set(ByVal value As String)
            Animal_Especie = value
        End Set
    End Property


    Property AnimalPreço As String
        Get
            Return ItemPreço
        End Get
        Set(ByVal value As String)
            ItemPreço = value
        End Set
    End Property

    Property AnimalQuantidade As String
        Get
            Return ItemQuantidade
        End Get
        Set(ByVal value As String)
            ItemQuantidade = value
        End Set
    End Property

    Property AnimalDescriçao As String
        Get
            Return ItemDescriçao
        End Get
        Set(ByVal value As String)
            ItemDescriçao = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return AnimalID & "   " & AnimalEspecie
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class
