Public Class Palabra

    Sub New()

    End Sub

    Sub New(pId As Integer, pCadena As String)
        With Me
            _Id = pId
            _Cadena = pCadena
        End With
    End Sub

    Private _Id As Integer
    <System.ComponentModel.DisplayName("Número")>
    Public ReadOnly Property Id() As Integer
        Get
            Return _Id
        End Get
    End Property

    Private _Cadena As String
    Public Property Cadena() As String
        Get
            Return _cadena
        End Get
        Set(ByVal value As String)
            _Cadena = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Cadena
    End Function

End Class
