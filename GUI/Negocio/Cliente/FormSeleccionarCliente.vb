Public Class FormSeleccionarCliente
    Implements InterfaceObservador

    Private _Logica As New BLL.ClienteLogica
    Private _Obj As Estructura.Cliente

    Sub New(ByRef pCliente As Estructura.Cliente)
        InitializeComponent()
        Me._Obj = pCliente
    End Sub

    Private Sub FormSeleccionarClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridClientes.DataSource = Me._Logica.ConsultarTodos
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me._Obj.Id = DirectCast(Me.DataGridClientes.Rows(Me.DataGridClientes.SelectedCells(0).RowIndex).DataBoundItem, Estructura.Cliente).Id
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If Alertador.Alertar("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Dim visible = False

        For Each row As DataGridViewRow In Me.DataGridClientes.Rows
            visible = False
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value.ToString.Contains(Me.TextBoxFiltro.Text) Then visible = True
            Next
            Try
                row.Visible = visible
            Catch ex As Exception
                Continue For
            End Try
        Next

    End Sub

End Class
