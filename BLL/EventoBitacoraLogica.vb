Public Class EventoBitacoraLogica

    Private _Datos As New DAL.EventoBitacoraDatos

    Public Function ConsultarTodos() As List(Of Estructura.EventoBitacora)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Shared Sub RegistrarEvento(pDesc As String)
        Dim EventoBitacora As New Estructura.EventoBitacora
        With EventoBitacora
            .Fecha = Now
            .Empleado = Estructura.Singleton.Instancia.Empleado
            .Desc = pDesc
        End With
        DAL.EventoBitacoraDatos.RegistrarEvento(EventoBitacora)
    End Sub

    Public Function Filtrar(pDesde As Date, pHasta As Date, pEmpleado As Estructura.Empleado) As List(Of Estructura.EventoBitacora)
        Return Me._Datos.Filtrar(pDesde, pHasta, pEmpleado)
    End Function

End Class
