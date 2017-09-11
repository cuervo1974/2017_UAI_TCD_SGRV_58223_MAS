Public Class PalabraTraducida

    Sub New(pIdioma As Idioma, pPalabra As Palabra, pCadenaTraducida As String)
        With Me
            ._Idioma = pIdioma
            ._Palabra = pPalabra
            ._CadenaTraducida = pCadenaTraducida
        End With
    End Sub

    Private _Idioma As Idioma
    Public Property Idioma() As Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Private _Palabra As Palabra
    Public Property Palabra() As Palabra
        Get
            Return _Palabra
        End Get
        Set(ByVal value As Palabra)
            _Palabra = value
        End Set
    End Property

    Private _CadenaTraducida As String
    Public Property CadenaTraducida() As String
        Get
            Return _CadenaTraducida
        End Get
        Set(ByVal value As String)
            _CadenaTraducida = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.CadenaTraducida
    End Function

End Class
