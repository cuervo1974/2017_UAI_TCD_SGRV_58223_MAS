Public Class SucursalLogica

    Private _Datos As New DAL.SucursalDatos

    Public Function ConsultarTodos() As List(Of Estructura.Sucursal)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Sucursal)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó la Sucursal #{0}", pObj.Nombre))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Sucursal)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó la Sucursal #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Sucursal)
        If pObj.Nombre = "" Then Throw New Exception("La Sucursal debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre de la Sucursal es demasiado largo.")
        If pObj.Direccion = "" Then Throw New Exception("La Sucursal debe tener dirección.")
        If pObj.Direccion.Length > 50 Then Throw New Exception("La dirección de la Sucursal es demasiado larga.")
        If pObj.Ciudad = "" Then Throw New Exception("La Sucursal debe tener ciudad.")
        If pObj.Ciudad.Length > 50 Then Throw New Exception("La ciudad de la Sucursal es demasiado larga.")
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Sucursal)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
