Public Class PatenteLogica

    Private _Datos As New DAL.PatenteDatos

    Public Function ConsultarTodos() As List(Of Estructura.Patente)
        Return Me._Datos.ConsultarTodos
    End Function

End Class
