Public Class Empleado

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pApellido As String, pUsername As String, pPassword As String)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Apellido = pApellido
            ._Username = pUsername
            ._Password = pPassword
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

    Private _Apellido As String
    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = value
        End Set
    End Property

    Private _Username As String
    Public Property Username() As String
        Get
            Return _Username
        End Get
        Set(ByVal value As String)
            _Username = value
        End Set
    End Property

    Private _Password As String
    <System.ComponentModel.Browsable(False)>
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Private _Familia As Familia
    Public Property Familia() As Familia
        Get
            Return _Familia
        End Get
        Set(ByVal value As Familia)
            _Familia = value
        End Set
    End Property

    Private _Sucursal As Sucursal
    Public Property Sucursal() As Sucursal
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As Sucursal)
            _Sucursal = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me._Apellido & ", " & Me._Nombre
    End Function

End Class
