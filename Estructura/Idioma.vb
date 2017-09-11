Public Class Idioma

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, Optional pPredefinido As Boolean = False)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Predeterminado = pPredefinido
        End With
    End Sub

    Private _Id As Integer
    <System.ComponentModel.Browsable(False)>
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _PalabrasTraducidas As List(Of PalabraTraducida)
    Public Property PalabrasTraducidas() As List(Of PalabraTraducida)
        Get
            Return _PalabrasTraducidas
        End Get
        Set(ByVal value As List(Of PalabraTraducida))
            _PalabrasTraducidas = value
        End Set
    End Property

    Private _Predeterminado As Boolean
    <System.ComponentModel.Browsable(False)>
    Public Property Predeterminado() As Boolean
        Get
            Return _Predeterminado
        End Get
        Set(ByVal value As Boolean)
            _Predeterminado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

End Class
