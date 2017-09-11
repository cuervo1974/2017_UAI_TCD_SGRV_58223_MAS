Public Class FamiliaDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Familia)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Familia", Me._DataSet.Tables.Add("Familia"))
        Me._DataSet.Tables("Familia").PrimaryKey = {Me._DataSet.Tables("Familia").Columns("id_familia")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FamiliaPatente", Me._DataSet.Tables.Add("FamiliaPatente"))
        Me._DataSet.Tables("FamiliaPatente").PrimaryKey = {Me._DataSet.Tables("FamiliaPatente").Columns("id_familia"), Me._DataSet.Tables("FamiliaPatente").Columns("id_patente")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Patente", Me._DataSet.Tables.Add("Patente"))
        Me._DataSet.Tables("Patente").PrimaryKey = {Me._DataSet.Tables("Patente").Columns("id_patente")}
        Me._DataSet.Relations.Add("FamiliaPatente", Me._DataSet.Tables("Familia").Columns("id_familia"), Me._DataSet.Tables("FamiliaPatente").Columns("id_familia"))
        Me._DataSet.Relations.Add("Patente", Me._DataSet.Tables("Patente").Columns("id_patente"), Me._DataSet.Tables("FamiliaPatente").Columns("id_patente"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Familia)
        Me.RellenarTablas()
        Me._DataSet.Tables("Familia").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Familia").DefaultView
            Dim Familia As Estructura.Familia = CrearObjeto(DataRowView.Row)
            Familia.Patentes = New List(Of Estructura.Patente)
            For Each DataRowFamiliaPatente As DataRow In DataRowView.Row.GetChildRows("FamiliaPatente")
                Familia.Patentes.Add(PatenteDatos.CrearObjeto(DataRowFamiliaPatente.GetParentRow("Patente")))
            Next
            Me._Listado.Add(Familia)
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.Familia)
        Dim DataRow = Me._DataSet.Tables("Familia").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("Familia").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("Familia").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Familia", Me._DataSet.Tables("Familia"))
        Me.RellenarTablas()
        If pObj.Id = 0 Then pObj.Id = Me.GetUltimoId()
        Me.ResetearPermisos(pObj)
        For Each Patente As Estructura.Patente In pObj.Patentes
            Dim DataRowFamiliaPatente As DataRow = Me._DataSet.Tables("FamiliaPatente").NewRow
            With DataRowFamiliaPatente
                .Item("id_familia") = pObj.Id
                .Item("id_patente") = Patente.Id
            End With
            Me._DataSet.Tables("FamiliaPatente").Rows.Add(DataRowFamiliaPatente)
        Next
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM FamiliaPatente", Me._DataSet.Tables("FamiliaPatente"))
    End Sub

    Private Function GetUltimoId() As Integer
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT TOP 1 * FROM Familia ORDER BY id_familia DESC", DataTableAux)
        Dim UltimaFamilia As Estructura.Familia = CrearObjeto(DataTableAux.Rows(0))
        Return UltimaFamilia.Id
    End Function

    Private Sub ResetearPermisos(pObj As Estructura.Familia)
        For Each Row As DataRow In Me._DataSet.Tables("FamiliaPatente").Rows
            If Row.Item("id_familia") = pObj.Id Then Row.Delete()
        Next
    End Sub

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Familia
        Return New Estructura.Familia(
            pDataRow.Item("id_familia"),
            pDataRow.Item("nombre")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Familia)
        With pDataRow
            .Item("id_familia") = pObj.Id
            .Item("nombre") = pObj.Nombre
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Familia)
        Dim DataRow = Me._DataSet.Tables("Familia").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Familia", Me._DataSet.Tables("Familia"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Familia)
        Me.RellenarTablas()
        Me._DataSet.Tables("Familia").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", pTexto)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
