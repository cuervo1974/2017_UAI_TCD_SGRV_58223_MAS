Public Class Sucursal

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pDireccion As String, pCiudad As String)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Direccion = pDireccion
            ._Ciudad = pCiudad
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

    Private _Direccion As String
    <System.ComponentModel.DisplayName("Dirección")>
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Private _Ciudad As String
    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

End Class
