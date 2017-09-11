Imports System.Data.SqlClient

Public Class EstadisticaDatos

    Private _DataSet As New DataSet

    Public Function ConsultarVentas(pDesde As Date, pHasta As Date, pSucursal As Estructura.Sucursal, pEmpleado As Estructura.Empleado) As Dictionary(Of Date, Integer)

        Dim DTAux As New DataTable
        Dim DicAux As New Dictionary(Of Date, Integer)

        ServiciosDAL.Comando.RellenarDT(Me.CrearSentenciaSQL("Factura", pDesde, pHasta, pSucursal, pEmpleado), DTAux)

        For Each DR As DataRow In DTAux.Rows
            DicAux.Add(DR.Item("fecha_creado"), DR.Item("cantidad"))
        Next

        Return DicAux

    End Function

    Public Function ConsultarPresupuestos(pDesde As Date, pHasta As Date, pSucursal As Estructura.Sucursal, pEmpleado As Estructura.Empleado) As Dictionary(Of Date, Integer)

        Dim DTAux As New DataTable
        Dim DicAux As New Dictionary(Of Date, Integer)

        ServiciosDAL.Comando.RellenarDT(Me.CrearSentenciaSQL("Presupuesto", pDesde, pHasta, pSucursal, pEmpleado), DTAux)

        For Each DR As DataRow In DTAux.Rows
            DicAux.Add(DR.Item("fecha_creado"), DR.Item("cantidad"))
        Next

        Return DicAux

    End Function

    Private Function CrearSentenciaSQL(pTabla As String, pDesde As Date, pHasta As Date, pSucursal As Estructura.Sucursal, pEmpleado As Estructura.Empleado) As String
        Dim Sentencia As String
        Sentencia = String.Format("SELECT fecha_creado, COUNT(*) AS cantidad FROM {0}", pTabla)
        Sentencia &= String.Format(" INNER JOIN Empleado ON {0}.id_empleado = Empleado.id_empleado", pTabla)
        Sentencia &= String.Format(" WHERE fecha_creado BETWEEN '{0}' AND '{1}'", pDesde.ToString("yyyy-MM-dd"), pHasta.ToString("yyyy-MM-dd"))
        If Not pSucursal Is Nothing Then Sentencia &= String.Format(" AND Empleado.id_sucursal = {0}", pSucursal.Id)
        If Not pEmpleado Is Nothing Then Sentencia &= String.Format(" AND {0}.id_empleado = {1}", pTabla, pEmpleado.Id)
        Sentencia &= " GROUP BY fecha_creado ORDER BY fecha_creado"
        Return Sentencia
    End Function

    Function ConsultarProductos(pDesde As Date, pHasta As Date) As Dictionary(Of String, Integer)

        Dim DTAux As New DataTable
        Dim DicAux As New Dictionary(Of String, Integer)

        ServiciosDAL.Comando.RellenarDT("SELECT TOP 10 Producto.nombre, COUNT(*) as cantidad FROM FacturaDetalle" & _
                                        " INNER JOIN Producto ON FacturaDetalle.id_producto = Producto.id_producto" & _
                                        " INNER JOIN Factura ON FacturaDetalle.id_factura = Factura.id_factura" & _
                                        String.Format(" WHERE Factura.fecha_creado BETWEEN '{0}' AND '{1}' ", pDesde.ToString("yyyy-MM-dd"), pHasta.ToString("yyyy-MM-dd")) & _
                                        " GROUP BY Producto.nombre ORDER BY cantidad DESC", DTAux)

        For Each DR As DataRow In DTAux.Rows
            DicAux.Add(DR.Item("nombre"), DR.Item("cantidad"))
        Next

        Return DicAux

    End Function


End Class
