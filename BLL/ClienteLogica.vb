Public Class ClienteLogica

    Private _Datos As New DAL.ClienteDatos

    Public Function ConsultarTodos() As List(Of Estructura.Cliente)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Cliente)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó el Cliente #{0}", pObj.Id))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Cliente)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó el Cliente #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Cliente)
        If pObj.Nombre = "" Then Throw New Exception("El Cliente debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre del Cliente es demasiado largo.")
        If pObj.Apellido = "" Then Throw New Exception("El Cliente debe tener apellido.")
        If pObj.Apellido.Length > 50 Then Throw New Exception("El nombre del Cliente es demasiado largo.")
        If pObj.Telefono.Length > 50 Then Throw New Exception("El telefono del Cliente es demasiado largo.")
        If pObj.Celular.Length > 50 Then Throw New Exception("El celular del Cliente es demasiado largo.")
        If pObj.Email.Length > 50 Then Throw New Exception("El e-mail del Cliente es demasiado largo.")
        If pObj.Email.Length > 0 And Not ServicioValidacion.IsEmail(pObj.Email) Then Throw New Exception("El e-mail es inválido.")
        If pObj.CUIT.Length > 0 And Not ServicioValidacion.IsCUIT(pObj.CUIT) Then Throw New Exception("El CUIT es inválido. Formato:##-########-##.")
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Cliente)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
