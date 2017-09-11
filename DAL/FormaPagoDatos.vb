Public Class FormaPagoDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.FormaPago)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FormaPago", Me._DataSet.Tables.Add("FormaPago"))
        Me._DataSet.Tables("FormaPago").PrimaryKey = {Me._DataSet.Tables("FormaPago").Columns("id_forma_pago")}
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.FormaPago)
        Me.RellenarTablas()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FormaPago", Me._DataSet.Tables("FormaPago"))
        Me._DataSet.Tables("FormaPago").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("FormaPago").DefaultView
            Me._Listado.Add(CrearObjeto(DataRowView.Row))
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.FormaPago)
        Dim DataRow = Me._DataSet.Tables("FormaPago").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("FormaPago").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("FormaPago").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM FormaPago", Me._DataSet.Tables("FormaPago"))
    End Sub

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.FormaPago
        Return New Estructura.FormaPago(
            pDataRow.Item("id_forma_pago"),
            pDataRow.Item("nombre"),
            pDataRow.Item("recargo_tipo"),
            pDataRow.Item("recargo_valor"))
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.FormaPago)
        With pDataRow
            .Item("id_forma_pago") = pObj.Id
            .Item("nombre") = pObj.Nombre
            .Item("recargo_tipo") = pObj.RecargoTipo
            .Item("recargo_valor") = pObj.RecargoValor
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.FormaPago)
        Dim DataRow = Me._DataSet.Tables("FormaPago").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM FormaPago", Me._DataSet.Tables("FormaPago"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.FormaPago)
        Me.RellenarTablas()
        Me._DataSet.Tables("FormaPago").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", pTexto)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
