Public Class Detalle

    Sub New(ByVal pNombre As String, ByVal pTotal As Double)
        With Me
            ._Nombre = pNombre
            ._Total = pTotal
        End With
    End Sub

    Private _Nombre As String
    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    Private _Total As Double
    Public ReadOnly Property Total() As Double
        Get
            Return _Total
        End Get
    End Property

End Class