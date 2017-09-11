Public Class EstadisticaLogica

    Private _Datos As New DAL.EstadisticaDatos

    Public Function ConsultarVentas(pDesde As Date, pHasta As Date, _
                                    Optional pSucursal As Estructura.Sucursal = Nothing, _
                                    Optional pEmpleado As Estructura.Empleado = Nothing) As Dictionary(Of Date, Integer)
        Return Me._Datos.ConsultarVentas(pDesde, pHasta, pSucursal, pEmpleado)
    End Function

    Public Function ConsultarPresupuestos(pDesde As Date, pHasta As Date, _
                                    Optional pSucursal As Estructura.Sucursal = Nothing, _
                                    Optional pEmpleado As Estructura.Empleado = Nothing) As Dictionary(Of Date, Integer)
        Return Me._Datos.ConsultarPresupuestos(pDesde, pHasta, pSucursal, pEmpleado)
    End Function

    Function ConsultarProductos(pDesde As Date, pHasta As Date) As Dictionary(Of String, Integer)
        Return Me._Datos.ConsultarProductos(pDesde, pHasta)
    End Function

End Class
