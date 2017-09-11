Public Class IdiomaLogica

    Private _Datos As New DAL.IdiomaDatos

    Public Function ConsultarTodos() As List(Of Estructura.Idioma)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Idioma)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó el Idioma #{0}", pObj.Nombre))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Idioma)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó el Idioma #{0}", pObj.Nombre))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Idioma)
        If pObj.Nombre = "" Then Throw New Exception("El Idioma debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre del Idioma es demasiado largo.")
    End Sub

    Public Function ConsultarPalabrasOriginales() As List(Of Estructura.Palabra)
        Dim _PalabraDatos As New DAL.PalabraDatos
        Return _PalabraDatos.ConsultarTodos
    End Function

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Idioma)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
