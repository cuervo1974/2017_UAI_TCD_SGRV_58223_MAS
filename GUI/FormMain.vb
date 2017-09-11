Public Class FormMain
    Implements InterfaceObservador

    Private _FamiliaLogica As New BLL.FamiliaLogica
    Private _IdiomaLogica As New BLL.IdiomaLogica
    Private _CPatentes As New CPatenteMultiple(Nothing)
    Private Shared _IdiomaObservado As New IdiomaObservado

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AgregarEmpleadoTitulo()
        Me.AgregarPatentes()
        Me.AgregarBotonSalir()
        Me.AgregarIdiomas()
        _IdiomaObservado.Suscribir(Me)
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        BLL.EventoBitacoraLogica.RegistrarEvento("Salió")
    End Sub

    Private Sub AgregarEmpleadoTitulo()
        Me.Text = String.Format("{0} - [{1}]", Me.Text, Estructura.Singleton.Instancia.Empleado)
    End Sub

    Private Sub AgregarPatentes()
        CPatente.RellenarCPatentes(Me._CPatentes, Me._FamiliaLogica.ConsultarPatentes(Estructura.Singleton.Instancia.Empleado.Familia), AddressOf AbrirForm)
        Me._CPatentes.Mostrar(Me.MenuStrip.Items)
    End Sub

    Private Sub AgregarIdiomas()
        Dim IdiomaMenuItem As New ToolStripMenuItem
        IdiomaMenuItem.Name = "CambiarIdioma"
        IdiomaMenuItem.Text = "Cambiar Idioma"
        IdiomaMenuItem.Image = My.Resources.Configuracion
        IdiomaMenuItem.Alignment = ToolStripItemAlignment.Right
        IdiomaMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft
        For Each Idioma As Estructura.Idioma In Me._IdiomaLogica.ConsultarTodos
            Dim NuevoIdioma As New ToolStripMenuItem(Idioma.ToString)
            NuevoIdioma.Tag = Idioma
            IdiomaMenuItem.DropDownItems.Add(NuevoIdioma)
        Next
        AddHandler IdiomaMenuItem.DropDownItemClicked, AddressOf Me.CambiarIdioma
        Me.MenuStrip.Items.Add(IdiomaMenuItem)
    End Sub

    Private Sub AgregarBotonSalir()
        Dim SalirMenuItem As New ToolStripMenuItem
        SalirMenuItem.Text = "Salir"
        SalirMenuItem.Image = My.Resources.Apagar
        SalirMenuItem.Alignment = ToolStripItemAlignment.Right
        AddHandler SalirMenuItem.Click, AddressOf Me.Salir
        Me.MenuStrip.Items.Add(SalirMenuItem)
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub AbrirForm(sender As Object, e As EventArgs)
        Dim FormularioNombre = DirectCast(sender.Tag, Estructura.Patente).Formulario
        If FormularioNombre = "" Then Exit Sub
        Try
            Dim Form As Form = Activator.CreateInstance(Type.GetType(String.Format("{0}.{1}", "GUI", FormularioNombre)))
            With Form
                .MdiParent = Me
                .Show()
            End With
            FormMain.RegistrarForm(Form)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Public Shared Sub RegistrarForm(pForm As Form)
        If TypeOf (pForm) Is InterfaceObservador Then _IdiomaObservado.Suscribir(pForm)
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Private Sub CambiarIdioma(sender As Object, e As ToolStripItemClickedEventArgs)
        _IdiomaObservado.CambiarIdioma(DirectCast(DirectCast(e.ClickedItem, ToolStripMenuItem).Tag, Estructura.Idioma))
    End Sub

End Class