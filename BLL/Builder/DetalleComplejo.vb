Public Class DetalleComplejo
    Inherits Detalle

    Sub New(ByVal pCodigo As Integer, ByVal pNombre As String, ByVal pPrecio As Double, ByVal pCantidad As Integer, ByVal pTotal As Double)
        MyBase.New(pNombre, pTotal)
        With Me
            ._Codigo = pCodigo
            ._Precio = pPrecio
            ._Cantidad = pCantidad
        End With
    End Sub

    Private _Codigo As Integer
    Public ReadOnly Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
    End Property

    Private _Precio As Double
    Public ReadOnly Property Precio() As Double
        Get
            Return _Precio
        End Get
    End Property

    Private _PrecioSinIVA As Decimal
    Public ReadOnly Property PrecioSinIVA() As Decimal
        Get
            Return _Precio * 0.79
        End Get
    End Property

    Private _IVA As Decimal
    Public ReadOnly Property IVA() As Decimal
        Get
            Return _Precio * 0.21
        End Get
    End Property

    Private _Cantidad As Integer
    Public ReadOnly Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
    End Property

End Class