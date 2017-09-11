Public Class EmpleadoDatos

    Private _DataSet As New DataSet
    Private _Listado As New List(Of Estructura.Empleado)

    Public Sub New()

    End Sub

    Private Sub RellenarTablas()
        Me._DataSet.Reset()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Empleado", Me._DataSet.Tables.Add("Empleado"))
        Me._DataSet.Tables("Empleado").PrimaryKey = {Me._DataSet.Tables("Empleado").Columns("id_empleado")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Familia", Me._DataSet.Tables.Add("Familia"))
        Me._DataSet.Tables("Familia").PrimaryKey = {Me._DataSet.Tables("Familia").Columns("id_familia")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM FamiliaPatente", Me._DataSet.Tables.Add("FamiliaPatente"))
        Me._DataSet.Tables("FamiliaPatente").PrimaryKey = {Me._DataSet.Tables("FamiliaPatente").Columns("id_familia"), Me._DataSet.Tables("FamiliaPatente").Columns("id_patente")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Patente", Me._DataSet.Tables.Add("Patente"))
        Me._DataSet.Tables("Patente").PrimaryKey = {Me._DataSet.Tables("Patente").Columns("id_patente")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Sucursal", Me._DataSet.Tables.Add("Sucursal"))
        Me._DataSet.Tables("Sucursal").PrimaryKey = {Me._DataSet.Tables("Sucursal").Columns("id_sucursal")}
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM DigitoVerificadorVertical WHERE tabla = 'Empleado'", Me._DataSet.Tables.Add("DigitoVerificadorVertical"))
        Me._DataSet.Tables("DigitoVerificadorVertical").PrimaryKey = {Me._DataSet.Tables("DigitoVerificadorVertical").Columns("tabla")}
        Me._DataSet.Relations.Add("Familia", Me._DataSet.Tables("Familia").Columns("id_familia"), Me._DataSet.Tables("Empleado").Columns("id_familia"))
        Me._DataSet.Relations.Add("FamiliaPatente", Me._DataSet.Tables("Familia").Columns("id_familia"), Me._DataSet.Tables("FamiliaPatente").Columns("id_familia"))
        Me._DataSet.Relations.Add("Patente", Me._DataSet.Tables("Patente").Columns("id_patente"), Me._DataSet.Tables("FamiliaPatente").Columns("id_patente"))
        Me._DataSet.Relations.Add("Sucursal", Me._DataSet.Tables("Sucursal").Columns("id_sucursal"), Me._DataSet.Tables("Empleado").Columns("id_sucursal"))
    End Sub

    Public Function ConsultarTodos() As List(Of Estructura.Empleado)
        Me.RellenarTablas()
        ServiciosDAL.Comando.RellenarDT("SELECT * FROM Empleado", Me._DataSet.Tables("Empleado"))
        Me._DataSet.Tables("Empleado").DefaultView.RowFilter = Nothing
        Me.ActualizarListado()
        Return Me._Listado
    End Function

    Private Sub ActualizarListado()
        Me._Listado.Clear()
        For Each DataRowView As DataRowView In Me._DataSet.Tables("Empleado").DefaultView
            Dim Empleado As Estructura.Empleado = CrearObjeto(DataRowView.Row)
            Dim Familia As Estructura.Familia = FamiliaDatos.CrearObjeto(DataRowView.Row.GetParentRow("Familia"))
            Familia.Patentes = New List(Of Estructura.Patente)
            For Each DataRowFamiliaPatente As DataRow In DataRowView.Row.GetParentRow("Familia").GetChildRows("FamiliaPatente")
                Familia.Patentes.Add(PatenteDatos.CrearObjeto(DataRowFamiliaPatente.GetParentRow("Patente")))
            Next
            Empleado.Familia = Familia
            Dim DataRowSucursal = DataRowView.Row.GetParentRow("Sucursal")
            If Not (IsNothing(DataRowSucursal)) Then Empleado.Sucursal = SucursalDatos.CrearObjeto(DataRowSucursal)
            Me._Listado.Add(Empleado)
        Next
        Me.VerificarDV()
    End Sub

    Public Sub Guardar(pObj As Estructura.Empleado)
        Dim DataRow = Me._DataSet.Tables("Empleado").Rows.Find(pObj.Id)
        If IsNothing(DataRow) Then
            DataRow = Me._DataSet.Tables("Empleado").NewRow
            RellenarDataRow(DataRow, pObj)
            Me._DataSet.Tables("Empleado").Rows.Add(DataRow)
        Else
            RellenarDataRow(DataRow, pObj)
        End If
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Empleado", Me._DataSet.Tables("Empleado"))
        If pObj.Id = 0 Then pObj.Id = Me.GetUltimoId()
        Me.GuardarDVHorizontal(pObj)
        Me.GuardarDVVertical()
        Me.RellenarTablas()
    End Sub

    Private Function GetUltimoId() As Integer
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT TOP 1 * FROM Empleado ORDER BY id_empleado DESC", DataTableAux)
        Dim UltimoCliente As Estructura.Empleado = CrearObjeto(DataTableAux.Rows(0))
        Return UltimoCliente.Id
    End Function

    Public Shared Function CrearObjeto(pDataRow As DataRow) As Estructura.Empleado
        Return New Estructura.Empleado(
            pDataRow.Item("id_empleado"),
            pDataRow.Item("nombre"),
            pDataRow.Item("apellido"),
            pDataRow.Item("username"),
            pDataRow.Item("password")
        )
    End Function

    Public Shared Sub RellenarDataRow(pDataRow As DataRow, pObj As Estructura.Empleado)
        With pDataRow
            .Item("id_empleado") = pObj.Id
            .Item("id_familia") = pObj.Familia.Id
            .Item("id_sucursal") = pObj.Sucursal.Id
            .Item("nombre") = pObj.Nombre
            .Item("apellido") = pObj.Apellido
            .Item("username") = pObj.Username
        End With
        If pObj.Password = "" Then
            pDataRow.Item("password") = GetPasswordViejo(pObj)
        Else
            pDataRow.Item("password") = Seguridad.Hash.Encriptar(pObj.Password)
        End If
    End Sub

    Private Shared Function GetPasswordViejo(pObj As Estructura.Empleado)
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT(String.Format("SELECT password FROM Empleado WHERE id_empleado = {0}", pObj.Id), DataTableAux)
        Return DataTableAux.Rows(0).Item("password")
    End Function

    Public Sub Eliminar(pObj As Estructura.Empleado)
        Dim DataRow = Me._DataSet.Tables("Empleado").Rows.Find(pObj.Id)
        DataRow.Delete()
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Empleado", Me._DataSet.Tables("Empleado"))
    End Sub

    Private Sub VerificarDV()
        For Each DataRow As DataRow In Me._DataSet.Tables("Empleado").Rows
            If Not DataRow.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRow)) Then Throw New Exception("Error en el Digito Verificador")
        Next
        If Not Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(Me._DataSet.Tables("Empleado").Rows) Then Throw New Exception("Error en el Digito Verificador")
    End Sub

    Private Sub GuardarDVVertical()
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT("SELECT digito_verificador FROM Empleado", DataTableAux)
        Me._DataSet.Tables("DigitoVerificadorVertical").Rows(0).Item("digito") = Seguridad.DigitoVerificador.CalcularDV(DataTableAux.Rows)
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM DigitoVerificadorVertical", Me._DataSet.Tables("DigitoVerificadorVertical"))
    End Sub

    Private Sub GuardarDVHorizontal(pObj As Estructura.Empleado)
        Dim DataTableAux As New DataTable
        ServiciosDAL.Comando.RellenarDT(String.Format("SELECT * FROM Empleado WHERE id_empleado = {0}", pObj.Id), DataTableAux)
        Dim DataRowAux As DataRow = DataTableAux.Rows(0)
        DataRowAux.Item("digito_verificador") = Seguridad.DigitoVerificador.CalcularDV(DataRowHelper.DataRow2ArrayList(DataRowAux))
        ServiciosDAL.Comando.ActualizarBase("SELECT * FROM Empleado", DataTableAux)
    End Sub

    Public Function ConsultarCredenciales(pUsername As String) As Estructura.Empleado
        Me.RellenarTablas()
        Me._DataSet.Tables("Empleado").DefaultView.RowFilter = String.Format("Username = '{0}'", pUsername)
        Me.ActualizarListado()
        If Me._Listado.Count > 0 Then
            Return DirectCast(Me._Listado.Item(0), Estructura.Empleado)
        Else
            Return Nothing
        End If
    End Function

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Empleado)
        Me.RellenarTablas()
        Me._DataSet.Tables("Empleado").DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%' OR apellido LIKE '%{1}%'", pTexto, pTexto)
        Me.ActualizarListado()
        Return Me._Listado
    End Function

End Class
