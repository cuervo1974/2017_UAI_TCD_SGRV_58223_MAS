Public Class IdiomaDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Idioma)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Idioma", Me._DataSet.Tables.Add("Idioma"))
        Me._DataSet.Tables("Idioma").PrimaryKey = {Me._DataSet.Tables("Idioma").Columns("id_idioma")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM PalabraTraducida", Me._DataSet.Tables.Add("PalabraTraducida"))
        Me._DataSet.Tables("PalabraTraducida").PrimaryKey = {Me._DataSet.Tables("PalabraTraducida").Columns("id_idioma"), Me._DataSet.Tables("PalabraTraducida").Columns("id_palabra")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Palabra", Me._DataSet.Tables.Add("Palabra"))
        Me._DataSet.Tables("Palabra").PrimaryKey = {Me._DataSet.Tables("Palabra").Columns("id_palabra")}
        Me._DataSet.Relations.Add("PalabraTraducida", Me._DataSet.Tables("Idioma").Columns("id_idioma"), Me._DataSet.Tables("PalabraTraducida").Columns("id_idioma"))
        Me._DataSet.Relations.Add("Palabra", Me._DataSet.Tables("Palabra").Columns("id_palabra"), Me._DataSet.Tables("PalabraTraducida").Columns("id_palabra"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Idioma)
        Me.RellenarTablas()
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        Me._Listado.Add(New Estructura.Idioma(Nothing, "Español", True))
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Idioma").DefaultView
            Dim Idioma As Estructura.Idioma = CrearObjeto(DataRowView.Row)
            Idioma.PalabrasTraducidas = New List(Of Estructura.PalabraTraducida)
            For Each PalabraTraducidaRow As DataRow In DataRowView.Row.GetChildRows("PalabraTraducida")
                Dim PalabraRow As DataRow = PalabraTraducidaRow.GetParentRow("Palabra")
                Dim PalabraTraducida = New Estructura.PalabraTraducida(Idioma, New Estructura.Palabra(PalabraRow.Item("id_palabra"), PalabraRow.Item("cadena")), PalabraTraducidaRow.Item("cadena_traducida"))
                Idioma.PalabrasTraducidas.Add(PalabraTraducida)
            Next
            Me._Listado.Add(Idioma)
        Next
    End Sub

    Public Sub Guardar(pObj As Estructura.Idioma)
        Dim DataRow = Me._DataSet.Tables("Idioma").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("Idioma").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("Idioma").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Idioma", Me._DataSet.Tables("Idioma"))
        Me.RellenarTablas()
        If pObj.Id = 0 Then
            pObj.Id = Me.GetUltimoId
        Else
            Me.ResetearTraducciones(pObj)
        End If
        For Each PalabraTraducida As Estructura.PalabraTraducida In pObj.PalabrasTraducidas
            Dim DataRowPalabraTraducida As DataRow = Me._DataSet.Tables("PalabraTraducida").NewRow
            If String.IsNullOrEmpty(PalabraTraducida.CadenaTraducida) Then Continue For
            With DataRowPalabraTraducida
                .Item("id_idioma") = pObj.Id
                .Item("id_palabra") = PalabraTraducida.Palabra.Id
                .Item("cadena_traducida") = PalabraTraducida.CadenaTraducida
            End With
            Me._DataSet.Tables("PalabraTraducida").Rows.Add(DataRowPalabraTraducida)
        Next
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM PalabraTraducida", Me._DataSet.Tables("PalabraTraducida"))
    End Sub

    Private Sub ResetearTraducciones(pObj As Estructura.Idioma)
        For Each Row As DataRow In Me._DataSet.Tables("PalabraTraducida").Rows
            If Row.Item("id_idioma") = pObj.Id Then Row.Delete()
        Next
    End Sub

    Private Function GetUltimoId() As Integer
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT TOP 1 * FROM Idioma ORDER BY id_idioma DESC", DataTableAux)
        Dim UltimoIdioma As Estructura.Idioma = CrearObjeto(DataTableAux.Rows(0))
        Return UltimoIdioma.Id
    End Function

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Idioma
        Return New Estructura.Idioma(
            pDataRow.Item("id_idioma"),
            pDataRow.Item("nombre")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Idioma)
        With pDataRow
            .Item("id_idioma") = pObj.Id
            .Item("nombre") = pObj.Nombre
        End With
    End Sub

    Public Sub Eliminar(pObj As Estructura.Idioma)
        Dim DataRow = Me._DataSet.Tables("Idioma").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Idioma", Me._DataSet.Tables("Idioma"))
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Idioma)
        Me.RellenarTablas()
        Me._DataSet.Tables("Idioma").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", pTexto)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
