Public Class FormEmpleado
    Implements InterfaceObservador

    Private _Obj As Estructura.Empleado
    Private _FamiliaLogica As New BLL.FamiliaLogica
    Private _SucursalLogica As New BLL.SucursalLogica

    Sub New(ByRef pObj As Estructura.Empleado)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBoxFamilia.DataSource = Me._FamiliaLogica.ConsultarTodos()
        Me.ComboBoxSucursal.DataSource = Me._SucursalLogica.ConsultarTodos()
        With Me
            .TextBoxNombre.Text = ._Obj.Nombre
            .TextBoxApellido.Text = ._Obj.Apellido
            .TextBoxUsuario.Text = ._Obj.Username
        End With
        If Not Me._Obj.Familia Is Nothing Then Me.ComboBoxFamilia.Text = Me._Obj.Familia.ToString
        If Not Me._Obj.Sucursal Is Nothing Then Me.ComboBoxSucursal.Text = Me._Obj.Sucursal.ToString
        Me.LabelLeyendaPassword.Visible = IIf(Me._Obj.Id > 0, True, False)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            With Me
                ._Obj.Nombre = .TextBoxNombre.Text
                ._Obj.Apellido = .TextBoxApellido.Text
                ._Obj.Username = .TextBoxUsuario.Text
                ._Obj.Password = .TextBoxPassword.Text
                ._Obj.Familia = .ComboBoxFamilia.SelectedValue
                ._Obj.Sucursal = .ComboBoxSucursal.SelectedValue
            End With
            BLL.EmpleadoLogica.Validar(Me._Obj)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If Alertador.Alertar("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub
End Class
