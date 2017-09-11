Public Class FacturaDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Factura)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Factura", Me._DataSet.Tables.Add("Factura"))
        Me._DataSet.Tables("Factura").PrimaryKey = {Me._DataSet.Tables("Factura").Columns("id_factura")}
        Me._DataSet.Tables("Factura").Columns("id_factura").AutoIncrement = True
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Empleado", Me._DataSet.Tables.Add("Empleado"))
        Me._DataSet.Tables("Empleado").PrimaryKey = {Me._DataSet.Tables("Empleado").Columns("id_empleado")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Cliente", Me._DataSet.Tables.Add("Cliente"))
        Me._DataSet.Tables("Cliente").PrimaryKey = {Me._DataSet.Tables("Cliente").Columns("id_cliente")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FacturaDetalle", Me._DataSet.Tables.Add("FacturaDetalle"))
        Me._DataSet.Tables("FacturaDetalle").PrimaryKey = {Me._DataSet.Tables("FacturaDetalle").Columns("factura_id"), Me._DataSet.Tables("FacturaDetalle").Columns("producto_id")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Producto", Me._DataSet.Tables.Add("Producto"))
        Me._DataSet.Tables("Producto").PrimaryKey = {Me._DataSet.Tables("Producto").Columns("id_producto")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FormaPago", Me._DataSet.Tables.Add("FormaPago"))
        Me._DataSet.Tables("FormaPago").PrimaryKey = {Me._DataSet.Tables("FormaPago").Columns("id_forma_producto")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM DigitoVerificadorVertical WHERE tabla = 'Factura'", Me._DataSet.Tables.Add("DigitoVerificadorVertical"))
        Me._DataSet.Tables("DigitoVerificadorVertical").PrimaryKey = {Me._DataSet.Tables("DigitoVerificadorVertical").Columns("tabla")}
        Me._DataSet.Relations.Add("Cliente", Me._DataSet.Tables("Cliente").Columns("id_cliente"), Me._DataSet.Tables("Factura").Columns("id_cliente"))
        Me._DataSet.Relations.Add("Empleado", Me._DataSet.Tables("Empleado").Columns("id_empleado"), Me._DataSet.Tables("Factura").Columns("id_empleado"))
        Me._DataSet.Relations.Add("FormaPago", Me._DataSet.Tables("FormaPago").Columns("id_forma_pago"), Me._DataSet.Tables("Factura").Columns("id_forma_pago"))
        Me._DataSet.Relations.Add("Detalle", Me._DataSet.Tables("Factura").Columns("id_factura"), Me._DataSet.Tables("FacturaDetalle").Columns("id_factura"))
        Me._DataSet.Relations.Add("Producto", Me._DataSet.Tables("Producto").Columns("id_producto"), Me._DataSet.Tables("FacturaDetalle").Columns("id_producto"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Factura)
        Me.RellenarTablas()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Factura", Me._DataSet.Tables("Factura"))
        Me._DataSet.Tables("Factura").DefaultView.Sort = "id_factura DESC"
        Me._DataSet.Tables("Factura").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Factura").DefaultView
            Dim Factura As Estructura.Factura = CrearObjeto(DataRowView.Row)
            Factura.Empleado = EmpleadoDatos.CrearObjeto(DataRowView.Row.GetParentRow("Empleado"))
            Factura.Cliente = ClienteDatos.CrearObjeto(DataRowView.Row.GetParentRow("Cliente"))
            Factura.FormaPago = FormaPagoDatos.CrearObjeto(DataRowView.Row.GetParentRow("FormaPago"))
            Factura.FacturaDetalle = New List(Of Estructura.FacturaDetalle)
            For Each DataRowDetalleFactura As DataRow In DataRowView.Row.GetChildRows("Detalle")
                Dim FacturaDetalle As New Estructura.FacturaDetalle(DataRowDetalleFactura.Item("precio"), DataRowDetalleFactura.Item("cantidad"), DataRowDetalleFactura("descuento"))
                FacturaDetalle.Producto = ProductoDatos.CrearObjeto(DataRowDetalleFactura.GetParentRow("Producto"))
                Factura.FacturaDetalle.Add(FacturaDetalle)
            Next
            Me._Listado.Add(Factura)
        Next
        'Me.VerificarDV()
    End Sub

    Public Sub Guardar(ByRef pObj As Estructura.Factura)
        Dim DataRow As DataRow = Me._DataSet.Tables("Factura").NewRow
        RellenarDataRow(DataRow, pObj)
        Me._DataSet.Tables("Factura").Rows.Add(DataRow)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Factura", Me._DataSet.Tables("Factura"))
        Me.RellenarTablas()
        pObj.Id = Me.GetUltimoId
        For Each FacturaDetalle As Estructura.FacturaDetalle In pObj.FacturaDetalle
            Dim DataRowDetalle As DataRow = Me._DataSet.Tables("FacturaDetalle").NewRow
            RellenarDataRowDetalle(DataRowDetalle, pObj, FacturaDetalle)
            Me._DataSet.Tables("FacturaDetalle").Rows.Add(DataRowDetalle)
        Next
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM FacturaDetalle", Me._DataSet.Tables("FacturaDetalle"))
        Me.GuardarDVHorizontal(pObj)
        Me.GuardarDVVertical()
        Me.RellenarTablas()
    End Sub

    Private Function GetUltimoId() As Integer
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT TOP 1 * FROM Factura ORDER BY id_factura DESC", DataTableAux)
        Dim UltimoFactura As Estructura.Factura = CrearObjeto(DataTableAux.Rows(0))
        Return UltimoFactura.Id
    End Function

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Factura
        Return New Estructura.Factura(
            pDataRow.Item("id_factura"),
            pDataRow.Item("tipo"),
            pDataRow.Item("fecha_creado"),
            pDataRow.Item("anulado")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Factura)
        With pDataRow
            .Item("id_factura") = pObj.Id
            .Item("tipo") = pObj.Tipo
            .Item("id_empleado") = pObj.Empleado.Id
            .Item("id_cliente") = pObj.Cliente.Id
            .Item("id_forma_pago") = pObj.FormaPago.Id
            .Item("fecha_creado") = pObj.FechaCreado
            .Item("anulado") = pObj.Anulado
        End With
    End Sub

    Public Shared Sub RellenarDataRowDetalle(pDataRow As DataRow, pObj As Estructura.Factura, pFacturaDetalle As Estructura.FacturaDetalle)
        With pDataRow
            .Item("id_factura") = pObj.Id
            .Item("id_producto") = pFacturaDetalle.Producto.Id
            .Item("precio") = pFacturaDetalle.Precio
            .Item("cantidad") = pFacturaDetalle.Cantidad
            .Item("descuento") = pFacturaDetalle.Descuento
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Factura)
        Dim DataRow = Me._DataSet.Tables("Factura").Rows.Find(pObj)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Factura", Me._DataSet.Tables("Factura"))
    End Sub

    Private Sub VerificarDV()
        For Each DataRow As DataRow In Me._DataSet.Tables("Factura").Rows
            If Not DataRow.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRow)) Then Throw New Exception("Error en el Digito Verificador")
        Next
        If Not Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(Me._DataSet.Tables("Factura").Rows) Then Throw New Exception("Error en el Digito Verificador")
    End Sub

    Private Sub GuardarDVVertical()
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT digito_verificador FROM Factura", DataTableAux)
        Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(DataTableAux.Rows)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM DigitoVerificadorVertical", Me._DataSet.Tables("DigitoVerificadorVertical"))
    End Sub

    Private Sub GuardarDVHorizontal(pObj As Estructura.Factura)
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT(String.Format("SELECT * FROM Factura WHERE id_factura = {0}", pObj.Id), DataTableAux)
        Dim DataRowAux As DataRow = DataTableAux.Rows(0)
        DataRowAux.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRowAux))
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Factura", DataTableAux)
    End Sub

    Public Sub Anular(pObj As Estructura.Factura)
        Dim DataRow = Me._DataSet.Tables("Factura").Rows.Find(pObj.Id)
        DataRow.Item("anulado") = True
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Factura", Me._DataSet.Tables("Factura"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Factura)
        Me.RellenarTablas()
        Me._DataSet.Tables("Factura").DefaultView.Sort = "id_factura DESC"
        If pTexto = "" Then
            Me._DataSet.Tables("Factura").DefaultView.RowFilter = Nothing
        Else
            Me._DataSet.Tables("Factura").DefaultView.RowFilter = String.Format("id_factura = {0}", Integer.Parse(pTexto))
        End If
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
