Public Class FormSucursal
    Implements InterfaceObservador

    Private _Obj As Estructura.Sucursal

    Sub New(ByRef pObj As Estructura.Sucursal)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .TextBoxNombre.Text = ._Obj.Nombre
            .TextBoxDireccion.Text = ._Obj.Direccion
            .TextBoxCiudad.Text = ._Obj.Ciudad
        End With
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            With Me
                ._Obj.Nombre = .TextBoxNombre.Text
                ._Obj.Direccion = .TextBoxDireccion.Text
                ._Obj.Ciudad = .TextBoxCiudad.Text
            End With
            BLL.SucursalLogica.Validar(Me._Obj)
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
