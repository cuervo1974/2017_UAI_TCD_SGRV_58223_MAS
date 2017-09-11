Public Class EmpleadoLogica

    Private _Datos As New DAL.EmpleadoDatos

    Public Function ConsultarTodos() As List(Of Estructura.Empleado)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Empleado)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó el Empleado #{0}", pObj.Id))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Empleado)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó el Empleado #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Empleado)
        If pObj.Nombre = "" Then Throw New Exception("El Empleado debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre del Empleado es demasiado largo.")
        If pObj.Apellido = "" Then Throw New Exception("El Empleado debe tener apellido.")
        If pObj.Apellido.Length > 50 Then Throw New Exception("El nombre del Empleado es demasiado largo.")
        If pObj.Username = "" Then Throw New Exception("El Empleado debe tener username.")
        If pObj.Username.Length > 50 Then Throw New Exception("El username del Empleado es demasiado largo.")
        If pObj.Id = 0 And String.IsNullOrEmpty(pObj.Password) Then Throw New Exception("El Empleado debe tener una contraseña")
    End Sub

    Public Sub Login(pUsername As String, pPassword As String)
        Dim PasswordEncriptado As String = Seguridad.Hash.Encriptar(pPassword)
        Dim Empleado As Estructura.Empleado = _Datos.ConsultarCredenciales(pUsername)
        If IsNothing(Empleado) Then
            Throw New Exception("Usuario inexistente.")
        ElseIf Not Empleado.Password = PasswordEncriptado Then
            Throw New Exception("Contraseña incorrecta.")
        Else
            Dim EmpleadoSingleton As Estructura.Singleton = Estructura.Singleton.Instancia
            EmpleadoSingleton.Empleado = Empleado
            EventoBitacoraLogica.RegistrarEvento("Ingresó")
        End If
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Empleado)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
