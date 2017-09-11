Public Class FormaPago

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pRecargoTipo As Char, pRecargoValor As Decimal)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._RecargoTipo = pRecargoTipo
            ._RecargoValor = pRecargoValor
        End With
    End Sub

    Private _Id As Integer
    <System.ComponentModel.DisplayName("Número")>
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
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

    Private _RecargoTipo As Char
    <System.ComponentModel.DisplayName("Tipo de Recargo")>
    Public Property RecargoTipo() As Char
        Get
            Return _RecargoTipo
        End Get
        Set(ByVal value As Char)
            _RecargoTipo = value
        End Set
    End Property

    Private _RecargoValor As Decimal
    <System.ComponentModel.DisplayName("Valor de Recargo")>
    Public Property RecargoValor() As Decimal
        Get
            Return _RecargoValor
        End Get
        Set(ByVal value As Decimal)
            _RecargoValor = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me._Nombre
    End Function

End Class
