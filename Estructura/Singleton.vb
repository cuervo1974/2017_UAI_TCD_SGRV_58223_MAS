Public Class Singleton

    Private Sub New()

    End Sub

    Private Shared _Instancia As Singleton
    Public Shared ReadOnly Property Instancia() As Singleton
        Get
            If _Instancia Is Nothing Then
                _Instancia = New Singleton
            End If
            Return _Instancia
        End Get
    End Property

    Private _Empleado As Empleado
    Public Property Empleado() As Empleado
        Get
            If _Empleado Is Nothing Then
                Empleado = New Empleado
            End If
            Return _Empleado
        End Get
        Set(ByVal value As Empleado)
            _Empleado = value
        End Set
    End Property

End Class
