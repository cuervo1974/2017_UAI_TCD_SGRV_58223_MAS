Public Class FormEventosBitacora
    Implements InterfaceObservador

    Private _Logica As New BLL.EventoBitacoraLogica
    Private _Obj As Estructura.EventoBitacora

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
        Dim EmpleadoLogica As New BLL.EmpleadoLogica
        Me.ComboBoxEmpleado.DataSource = EmpleadoLogica.ConsultarTodos
    End Sub

    Private Sub RellenarDataGrid(pListado As List(Of Estructura.EventoBitacora))
        With Me.DataGridPrincipal
            .DataSource = Nothing
            .Columns.Clear()
            .Rows.Clear()
            .DataSource = pListado
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub ButtonFiltrar_Click(sender As Object, e As EventArgs) Handles ButtonFiltrar.Click
        Me.RellenarDataGrid(Me._Logica.Filtrar(Me.DateTimeDesde.Text, Me.DateTimeHasta.Text, Me.ComboBoxEmpleado.SelectedValue))
        Me.DataGridPrincipal.AutoResizeColumns()
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

End Class