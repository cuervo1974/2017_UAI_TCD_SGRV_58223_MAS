Public Class SucursalDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Sucursal)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Sucursal", Me._DataSet.Tables.Add("Sucursal"))
        Me._DataSet.Tables("Sucursal").PrimaryKey = {Me._DataSet.Tables("Sucursal").Columns("id_sucursal")}
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Sucursal)
        Me.RellenarTablas()
        Me._DataSet.Tables("Sucursal").DefaultView.Sort = "id_sucursal DESC"
        Me._DataSet.Tables("Sucursal").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Sucursal").DefaultView
            Me._Listado.Add(CrearObjeto(DataRowView.Row))
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.Sucursal)
        Dim DataRow = Me._DataSet.Tables("Sucursal").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("Sucursal").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("Sucursal").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Sucursal", Me._DataSet.Tables("Sucursal"))
    End Sub

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Sucursal
        Return New Estructura.Sucursal(
            pDataRow.Item("id_sucursal"),
            pDataRow.Item("nombre"),
            pDataRow.Item("direccion"),
            pDataRow.Item("ciudad")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Sucursal)
        With pDataRow
            .Item("id_sucursal") = pObj.Id
            .Item("nombre") = pObj.Nombre
            .Item("direccion") = pObj.Direccion
            .Item("ciudad") = pObj.Ciudad
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Sucursal)
        Dim DataRow = Me._DataSet.Tables("Sucursal").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Sucursal", Me._DataSet.Tables("Sucursal"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Sucursal)
        Me.RellenarTablas()
        Me._DataSet.Tables("Sucursal").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", pTexto)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
