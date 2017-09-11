Public Class Producto

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pPrecio As Decimal, pPeso As Integer)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Precio = pPrecio
            ._Peso = pPeso
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

    Private _Precio As Decimal
    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Private _Peso As Integer
    Public Property Peso() As Integer
        Get
            Return _Peso
        End Get
        Set(ByVal value As Integer)
            _Peso = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("{0} (COD: {1})", Me._Nombre, Me._Id)
    End Function

End Class
