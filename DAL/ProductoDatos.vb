Public Class ProductoDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Producto)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Producto", Me._DataSet.Tables.Add("Producto"))
        Me._DataSet.Tables("Producto").PrimaryKey = {Me._DataSet.Tables("Producto").Columns("id_producto")}
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Producto)
        Me.RellenarTablas()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Producto", Me._DataSet.Tables("Producto"))
        Me._DataSet.Tables("Producto").DefaultView.Sort = "id_producto DESC"
        Me._DataSet.Tables("Producto").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Producto").DefaultView
            Me._Listado.Add(CrearObjeto(DataRowView.Row))
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.Producto)
        Dim DataRow = Me._DataSet.Tables("Producto").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("Producto").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("Producto").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Producto", Me._DataSet.Tables("Producto"))
    End Sub

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Producto
        Return New Estructura.Producto(
            pDataRow.Item("id_producto"),
            pDataRow.Item("nombre"),
            pDataRow.Item("precio"),
            pDataRow.Item("peso")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Producto)
        With pDataRow
            .Item("id_producto") = pObj.Id
            .Item("nombre") = pObj.Nombre
            .Item("precio") = pObj.Precio
            .Item("peso") = pObj.Peso
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Producto)
        Dim DataRow = Me._DataSet.Tables("Producto").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Producto", Me._DataSet.Tables("Producto"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Producto)
        Me.RellenarTablas()
        Me._DataSet.Tables("Producto").DefaultView.Sort = "id_producto DESC"
        If pTexto = "" Then
            Me._DataSet.Tables("Producto").DefaultView.RowFilter = Nothing
        Else
            Me._DataSet.Tables("Producto").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", pTexto)
        End If
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
