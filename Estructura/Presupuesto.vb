Public Class Presupuesto

    Sub New()

    End Sub

    Sub New(pId As Integer, pFechaCreado As Date, pFechaVencimiento As Date, pAnulado As Boolean)
        With Me
            ._Id = pId
            ._FechaCreado = pFechaCreado
            ._FechaVencimiento = pFechaVencimiento
            ._Anulado = pAnulado
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

    Private _Empleado As Empleado
    Public Property Empleado() As Empleado
        Get
            Return _Empleado
        End Get
        Set(ByVal value As Empleado)
            _Empleado = value
        End Set
    End Property

    Private _Cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Cliente)
            _Cliente = value
        End Set
    End Property

    Private _FormaPago As FormaPago
    <System.ComponentModel.DisplayName("Forma de Pago")>
    Public Property FormaPago() As FormaPago
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As FormaPago)
            _FormaPago = value
        End Set
    End Property

    Private _FechaCreado As Date
    <System.ComponentModel.DisplayName("Fecha")>
    Public Property FechaCreado() As Date
        Get
            Return _FechaCreado
        End Get
        Set(ByVal value As Date)
            _FechaCreado = value
        End Set
    End Property

    Private _FechaVencimiento As Date
    <System.ComponentModel.DisplayName("Vencimiento")>
    Public Property FechaVencimiento() As Date
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal value As Date)
            _FechaVencimiento = value
        End Set
    End Property

    Private _Anulado As Boolean
    Public Property Anulado() As Boolean
        Get
            Return _Anulado
        End Get
        Set(ByVal value As Boolean)
            _Anulado = value
        End Set
    End Property

    Private _PresupuestoDetalle As List(Of PresupuestoDetalle)
    Public Property PresupuestoDetalle() As List(Of PresupuestoDetalle)
        Get
            Return _PresupuestoDetalle
        End Get
        Set(ByVal value As List(Of PresupuestoDetalle))
            _PresupuestoDetalle = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property SubTotal() As Decimal
        Get
            Dim Sum As Decimal = 0
            If Not IsNothing(Me.PresupuestoDetalle) Then
                For Each Detalle As PresupuestoDetalle In Me.PresupuestoDetalle
                    Sum += Detalle.Total
                Next
            End If
            Return Sum
        End Get
    End Property

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property CostoFormaPago() As Decimal
        Get
            Dim Sum As Decimal = Me.SubTotal
            If IsNothing(Me._FormaPago) Then
                Return 0
            Else
                If FormaPago.RecargoTipo = "P" Then
                    Sum = Sum * Me._FormaPago.RecargoValor / 100
                Else
                    Sum = FormaPago.RecargoValor
                End If
                Return Sum
            End If
        End Get
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Return SubTotal + CostoFormaPago
        End Get
    End Property

End Class
