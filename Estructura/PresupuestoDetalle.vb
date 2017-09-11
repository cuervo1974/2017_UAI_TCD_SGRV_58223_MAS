Public Class PresupuestoDetalle

    Sub New()

    End Sub

    Sub New(pPrecio As Decimal, pCantidad As Integer, pDescuento As Integer)
        With Me
            ._Precio = pPrecio
            ._Cantidad = pCantidad
            ._Descuento = pDescuento
        End With
    End Sub

    Private _Producto As Producto
    Public Property Producto() As Producto
        Get
            Return _Producto
        End Get
        Set(ByVal value As Producto)
            _Producto = value
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

    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property

    Private _Descuento As Integer
    Public Property Descuento() As Integer
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Integer)
            _Descuento = value
        End Set
    End Property

    <System.ComponentModel.DisplayName("Precio")>
    Public ReadOnly Property PrecioDescuento() As Decimal
        Get
            Return IIf(Me._Descuento > 0, Me._Precio - Me._Precio * Me._Descuento / 100, Me._Precio)
        End Get
    End Property

    Public ReadOnly Property Total() As Integer
        Get
            Return Me._Cantidad * Me.PrecioDescuento
        End Get
    End Property

End Class
