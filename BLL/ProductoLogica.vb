Public Class ProductoLogica

    Private _Datos As New DAL.ProductoDatos

    Public Function ConsultarTodos() As List(Of Estructura.Producto)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Producto)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó el Producto #{0}", pObj.Nombre))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Producto)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó el Producto #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Producto)
        If pObj.Nombre = "" Then Throw New Exception("El Producto debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre del Producto es demasiado largo.")
        If Not pObj.Precio > 1 Then Throw New Exception("El Producto debe tener precio.")
        If Not pObj.Peso > 1 Then Throw New Exception("El Producto debe tener peso.")
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Producto)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
