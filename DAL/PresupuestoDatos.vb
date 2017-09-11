Public Class PresupuestoDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Presupuesto)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Presupuesto", Me._DataSet.Tables.Add("Presupuesto"))
        Me._DataSet.Tables("Presupuesto").PrimaryKey = {Me._DataSet.Tables("Presupuesto").Columns("id_presupuesto")}
        Me._DataSet.Tables("Presupuesto").Columns("id_presupuesto").AutoIncrement = True
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Empleado", Me._DataSet.Tables.Add("Empleado"))
        Me._DataSet.Tables("Empleado").PrimaryKey = {Me._DataSet.Tables("Empleado").Columns("id_empleado")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Cliente", Me._DataSet.Tables.Add("Cliente"))
        Me._DataSet.Tables("Cliente").PrimaryKey = {Me._DataSet.Tables("Cliente").Columns("id_cliente")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM PresupuestoDetalle", Me._DataSet.Tables.Add("PresupuestoDetalle"))
        Me._DataSet.Tables("PresupuestoDetalle").PrimaryKey = {Me._DataSet.Tables("PresupuestoDetalle").Columns("presupuesto_id"), Me._DataSet.Tables("PresupuestoDetalle").Columns("producto_id")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Producto", Me._DataSet.Tables.Add("Producto"))
        Me._DataSet.Tables("Producto").PrimaryKey = {Me._DataSet.Tables("Producto").Columns("id_producto")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FormaPago", Me._DataSet.Tables.Add("FormaPago"))
        Me._DataSet.Tables("FormaPago").PrimaryKey = {Me._DataSet.Tables("FormaPago").Columns("id_forma_producto")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM DigitoVerificadorVertical WHERE tabla = 'Presupuesto'", Me._DataSet.Tables.Add("DigitoVerificadorVertical"))
        Me._DataSet.Tables("DigitoVerificadorVertical").PrimaryKey = {Me._DataSet.Tables("DigitoVerificadorVertical").Columns("tabla")}
        Me._DataSet.Relations.Add("Cliente", Me._DataSet.Tables("Cliente").Columns("id_cliente"), Me._DataSet.Tables("Presupuesto").Columns("id_cliente"))
        Me._DataSet.Relations.Add("Empleado", Me._DataSet.Tables("Empleado").Columns("id_empleado"), Me._DataSet.Tables("Presupuesto").Columns("id_empleado"))
        Me._DataSet.Relations.Add("FormaPago", Me._DataSet.Tables("FormaPago").Columns("id_forma_pago"), Me._DataSet.Tables("Presupuesto").Columns("id_forma_pago"))
        Me._DataSet.Relations.Add("Detalle", Me._DataSet.Tables("Presupuesto").Columns("id_presupuesto"), Me._DataSet.Tables("PresupuestoDetalle").Columns("id_presupuesto"))
        Me._DataSet.Relations.Add("Producto", Me._DataSet.Tables("Producto").Columns("id_producto"), Me._DataSet.Tables("PresupuestoDetalle").Columns("id_producto"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Presupuesto)
        Me.RellenarTablas()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Presupuesto", Me._DataSet.Tables("Presupuesto"))
        Me._DataSet.Tables("Presupuesto").DefaultView.Sort = "id_presupuesto DESC"
        Me._DataSet.Tables("Presupuesto").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Presupuesto").DefaultView
            Dim Presupuesto As Estructura.Presupuesto = CrearObjeto(DataRowView.Row)
            Presupuesto.Empleado = EmpleadoDatos.CrearObjeto(DataRowView.Row.GetParentRow("Empleado"))
            Presupuesto.Cliente = ClienteDatos.CrearObjeto(DataRowView.Row.GetParentRow("Cliente"))
            Presupuesto.FormaPago = FormaPagoDatos.CrearObjeto(DataRowView.Row.GetParentRow("FormaPago"))
            Presupuesto.PresupuestoDetalle = New List(Of Estructura.PresupuestoDetalle)
            For Each DataRowDetallePresupuesto As DataRow In DataRowView.Row.GetChildRows("Detalle")
                Dim PresupuestoDetalle As New Estructura.PresupuestoDetalle(DataRowDetallePresupuesto.Item("precio"), DataRowDetallePresupuesto.Item("cantidad"), DataRowDetallePresupuesto("descuento"))
                PresupuestoDetalle.Producto = ProductoDatos.CrearObjeto(DataRowDetallePresupuesto.GetParentRow("Producto"))
                Presupuesto.PresupuestoDetalle.Add(PresupuestoDetalle)
            Next
            Me._Listado.Add(Presupuesto)
        Next
        'Me.VerificarDV()
    End Sub

    Public Sub Guardar(ByRef pObj As Estructura.Presupuesto)
        Dim DataRow As DataRow = Me._DataSet.Tables("Presupuesto").NewRow
        RellenarDataRow(DataRow, pObj)
        Me._DataSet.Tables("Presupuesto").Rows.Add(DataRow)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Presupuesto", Me._DataSet.Tables("Presupuesto"))
        Me.RellenarTablas()
        pObj.Id = Me.GetUltimoId
        For Each PresupuestoDetalle As Estructura.PresupuestoDetalle In pObj.PresupuestoDetalle
            Dim DataRowDetalle As DataRow = Me._DataSet.Tables("PresupuestoDetalle").NewRow
            RellenarDataRowDetalle(DataRowDetalle, pObj, PresupuestoDetalle)
            Me._DataSet.Tables("PresupuestoDetalle").Rows.Add(DataRowDetalle)
        Next
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM PresupuestoDetalle", Me._DataSet.Tables("PresupuestoDetalle"))
        Me.GuardarDVHorizontal(pObj)
        Me.GuardarDVVertical()
        Me.RellenarTablas()
    End Sub

    Private Function GetUltimoId() As Integer
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT TOP 1 * FROM Presupuesto ORDER BY id_presupuesto DESC", DataTableAux)
        Dim UltimoPresupuesto As Estructura.Presupuesto = CrearObjeto(DataTableAux.Rows(0))
        Return UltimoPresupuesto.Id
    End Function

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Presupuesto
        Return New Estructura.Presupuesto(
            pDataRow.Item("id_presupuesto"),
            pDataRow.Item("fecha_creado"),
            pDataRow.Item("fecha_vencimiento"),
            pDataRow.Item("anulado")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Presupuesto)
        With pDataRow
            .Item("id_presupuesto") = pObj.Id
            .Item("id_empleado") = pObj.Empleado.Id
            .Item("id_cliente") = pObj.Cliente.Id
            .Item("id_forma_pago") = pObj.FormaPago.Id
            .Item("fecha_creado") = pObj.FechaCreado
            .Item("fecha_vencimiento") = pObj.FechaVencimiento
            .Item("anulado") = pObj.Anulado
        End With
    End Sub

    Public Shared Sub RellenarDataRowDetalle(pDataRow As DataRow, pObj As Estructura.Presupuesto, pPresupuestoDetalle As Estructura.PresupuestoDetalle)
        With pDataRow
            .Item("id_presupuesto") = pObj.Id
            .Item("id_producto") = pPresupuestoDetalle.Producto.Id
            .Item("precio") = pPresupuestoDetalle.Precio
            .Item("cantidad") = pPresupuestoDetalle.Cantidad
            .Item("descuento") = pPresupuestoDetalle.Descuento
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Presupuesto)
        Dim DataRow = Me._DataSet.Tables("Presupuesto").Rows.Find(pObj)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Presupuesto", Me._DataSet.Tables("Presupuesto"))
    End Sub

    Private Sub VerificarDV()
        For Each DataRow As DataRow In Me._DataSet.Tables("Presupuesto").Rows
            If Not DataRow.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRow)) Then Throw New Exception("Error en el Digito Verificador")
        Next
        If Not Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(Me._DataSet.Tables("Presupuesto").Rows) Then Throw New Exception("Error en el Digito Verificador")
    End Sub

    Private Sub GuardarDVVertical()
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT digito_verificador FROM Presupuesto", DataTableAux)
        Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(DataTableAux.Rows)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM DigitoVerificadorVertical", Me._DataSet.Tables("DigitoVerificadorVertical"))
    End Sub

    Private Sub GuardarDVHorizontal(pObj As Estructura.Presupuesto)
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT(String.Format("SELECT * FROM Presupuesto WHERE id_presupuesto = {0}", pObj.Id), DataTableAux)
        Dim DataRowAux As DataRow = DataTableAux.Rows(0)
        DataRowAux.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRowAux))
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Presupuesto", DataTableAux)
    End Sub

    Public Sub Anular(pObj As Estructura.Presupuesto)
        Dim DataRow = Me._DataSet.Tables("Presupuesto").Rows.Find(pObj.Id)
        DataRow.Item("anulado") = True
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Presupuesto", Me._DataSet.Tables("Presupuesto"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Presupuesto)
        Me.RellenarTablas()
        Me._DataSet.Tables("Presupuesto").DefaultView.Sort = "id_presupuesto DESC"
        If pTexto = "" Then
            Me._DataSet.Tables("Presupuesto").DefaultView.RowFilter = Nothing
        Else
            Me._DataSet.Tables("Presupuesto").DefaultView.RowFilter = String.Format("id_presupuesto = {0}", Integer.Parse(pTexto))
        End If
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
