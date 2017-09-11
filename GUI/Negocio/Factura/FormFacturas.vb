Public Class FormFacturas
    Implements InterfaceObservador

    Private _Logica As New BLL.FacturaLogica
    Private _Obj As Estructura.Factura

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
    End Sub

    Private Sub RellenarDataGrid(pListado As List(Of Estructura.Factura))
        With Me.DataGridPrincipal
            .DataSource = Nothing
            .Columns.Clear()
            .Rows.Clear()
            .DataSource = pListado
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub BotoneraFiltrador_Load(sender As Object, e As EventArgs) Handles BotoneraFiltrador.Load
        With Me.BotoneraFiltrador
            .AgregarBoton("Ver", My.Resources.Lupa, AddressOf Ver)
            .AgregarBotonAgregar(AddressOf Agregar)
            .AgregarBoton("Anular", My.Resources.Bloquear, AddressOf Anular)
            .AgregarBoton("Enviar", My.Resources.Email, AddressOf Enviar)
            .AgregarBoton("Imprimir", My.Resources.Impresora, AddressOf Imprimir, False)
            .AgregarManejadorFiltro(AddressOf Me.Filtrar)
        End With
    End Sub

    Private Sub Filtrar()
        Try
            Me.RellenarDataGrid(Me._Logica.Filtrar(Me.BotoneraFiltrador.GetTextoFiltro))
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub GetObjSeleccionado()
        Me._Obj = Me.DataGridPrincipal.Rows(Me.DataGridPrincipal.SelectedCells(0).RowIndex).DataBoundItem
        If IsNothing(Me._Obj) Then Throw New Exception("No se ha seleccionado ninguna Factura.")
    End Sub

    Private Sub AbrirDialogo()
        Dim Dialogo As New FormFactura(Me._Obj)
        With Dialogo
            .TopMost = True
            .Show()
        End With
        FormMain.RegistrarForm(Dialogo)
        AddHandler Dialogo.FormClosed, AddressOf Me.Dialog_FormClosed
    End Sub

    Private Sub Agregar()
        Me._Obj = New Estructura.Factura
        Me._Obj.FacturaDetalle = New List(Of Estructura.FacturaDetalle)
        Me._Obj.Empleado = Estructura.Singleton.Instancia.Empleado
        Me.AbrirDialogo()
    End Sub

    Private Sub Ver()
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Abrir(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Anular()
        If Not Alertador.Alertar("¿Está seguro que desea anular la Factura?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Anular(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
    End Sub

    Private Sub Enviar()
        If Not Alertador.Alertar("¿Está seguro que desea enviar el Factura por e-mail?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Enviar(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Imprimir()
        If Not Alertador.Alertar("¿Está seguro que desea imprimir el Factura?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Imprimir(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Dialog_FormClosed(sender As Object, e As FormClosedEventArgs)
        If DirectCast(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                Me._Logica.Guardar(Me._Obj)
            Catch ex As Exception
                Alertador.Alertar(ex.Message)
            End Try
            Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
        End If
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

End Class