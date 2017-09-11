Public Class Cliente

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pApellido As String, pTelefono As String, pCelular As String, pEmail As String, pCUIT As String)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Apellido = pApellido
            ._Telefono = pTelefono
            ._Celular = pCelular
            ._Email = pEmail
            ._CUIT = pCUIT
        End With
    End Sub

    Private _Id As Integer
    <System.ComponentModel.DisplayName("Número")>
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
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

    Private _Telefono As String
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Private _Celular As String
    Public Property Celular() As String
        Get
            Return _Celular
        End Get
        Set(ByVal value As String)
            _Celular = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Private _CUIT As String
    Public Property CUIT() As String
        Get
            Return _CUIT
        End Get
        Set(ByVal value As String)
            _CUIT = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Me._Apellido & ", " & Me._Nombre
    End Function

End Class
