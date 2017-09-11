Public Class EventoBitacoraDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.EventoBitacora)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM EventoBitacora", Me._DataSet.Tables.Add("EventoBitacora"))
        Me._DataSet.Tables("EventoBitacora").PrimaryKey = {Me._DataSet.Tables("EventoBitacora").Columns("id_evento_bitacora")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Empleado", Me._DataSet.Tables.Add("Empleado"))
        Me._DataSet.Tables("Empleado").PrimaryKey = {Me._DataSet.Tables("Empleado").Columns("id_empleado")}
        Me._DataSet.Relations.Add("Empleado", Me._DataSet.Tables("Empleado").Columns("id_empleado"), Me._DataSet.Tables("EventoBitacora").Columns("id_empleado"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.EventoBitacora)
        Me.RellenarTablas()
        Me._DataSet.Tables("EventoBitacora").DefaultView.Sort = "id_evento_bitacora DESC"
        Me._DataSet.Tables("EventoBitacora").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("EventoBitacora").DefaultView
            Dim EventoBitacora As Estructura.EventoBitacora = CrearObjeto(DataRowView.Row)
            EventoBitacora.Empleado = EmpleadoDatos.CrearObjeto(DataRowView.Row.GetParentRow("Empleado"))
            Me._Listado.Add(EventoBitacora)
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.EventoBitacora)
        Dim DataRow = Me._DataSet.Tables("EventoBitacora").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("EventoBitacora").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("EventoBitacora").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM EventoBitacora", Me._DataSet.Tables("EventoBitacora"))
    End Sub

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.EventoBitacora
        Return New Estructura.EventoBitacora(
            pDataRow.Item("id_evento_bitacora"),
            pDataRow.Item("fecha"),
            pDataRow.Item("descripcion")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.EventoBitacora)
        With pDataRow
            .Item("id_evento_bitacora") = pObj.Id
            .Item("id_empleado") = pObj.Empleado.Id
            .Item("fecha") = pObj.Fecha
            .Item("descripcion") = pObj.Desc
        End With
    End Sub

    Public Shared Sub RegistrarEvento(pObj As Estructura.EventoBitacora)
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM EventoBitacora", DataTableAux, True)
        Dim DataRowAux As DataRow = DataTableAux.NewRow
        RellenarDataRow(DataRowAux, pObj)
        DataTableAux.Rows.Add(DataRowAux)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM EventoBitacora", DataTableAux)
    End Sub

    Public Function Filtrar(pDesde As Date, pHasta As Date, pObj As Estructura.Empleado) As List(Of Estructura.EventoBitacora)
        Me.RellenarTablas()
        Me._DataSet.Tables("EventoBitacora").DefaultView.Sort = "id_evento_bitacora DESC"
        Me._DataSet.Tables("EventoBitacora").DefaultView.RowFilter = String.Format("fecha >= '{0}' AND fecha <= '{1}'", pDesde, pHasta)
        If Not IsNothing(pObj) Then Me._DataSet.Tables("EventoBitacora").DefaultView.RowFilter &= String.Format(" AND id_empleado = {0}", pObj.Id)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
