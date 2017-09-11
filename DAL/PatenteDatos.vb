Public Class PatenteDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Patente)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Patente", Me._DataSet.Tables.Add("Patente"))
        Me._DataSet.Tables("Patente").PrimaryKey = {Me._DataSet.Tables("Patente").Columns("id_patente")}
        Me._DataSet.Relations.Add("Hijos", Me._DataSet.Tables("Patente").Columns("id_patente"), Me._DataSet.Tables("Patente").Columns("id_padre"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Patente)
        Me.RellenarTablas()
        Me._DataSet.Tables("Patente").DefaultView.RowFilter = "id_padre IS NULL"
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Patente").DefaultView
            Me._Listado.Add(Me.ActualizarPatente(DataRowView.Row))
        Next
    End Sub

    Public Function ActualizarPatente(pDataRow As DataRow) As Estructura.Patente
        Dim Patente As Estructura.Patente = CrearObjeto(pDataRow)
        Dim Hijos() As DataRow = pDataRow.GetChildRows("Hijos")
        If Hijos.Length > 0 Then
            Patente.Hijos = New List(Of Estructura.Patente)
            For Each DataRowPatente As DataRow In Hijos
                Patente.Hijos.Add(ActualizarPatente(DataRowPatente))
            Next
        End If
        Return Patente
    End Function

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Patente
        Return New Estructura.Patente(
            pDataRow.Item("id_patente"),
            pDataRow.Item("nombre"),
            Convert.ToString(pDataRow.Item("formulario")),
            Convert.ToString(pDataRow.Item("imagen"))
        )
    End Function

End Class
