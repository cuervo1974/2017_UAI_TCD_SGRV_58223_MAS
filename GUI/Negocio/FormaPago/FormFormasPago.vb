Public Class FormFormasPago
    Implements InterfaceObservador

    Private _Logica As New BLL.FormaPagoLogica
    Private _Obj As Estructura.FormaPago

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
    End Sub

    Private Sub RellenarDataGrid(pListado As List(Of Estructura.FormaPago))
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
            .AgregarBotonAgregar(AddressOf Agregar)
            .AgregarBotonEditar(AddressOf Editar)
            .AgregarBotonEliminar(AddressOf Eliminar, False)
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
        If IsNothing(Me._Obj) Then Throw New Exception("No se ha seleccionado ninguna Forma de Pago.")
    End Sub

    Private Sub AbrirDialogo()
        Dim Dialogo As New FormFormaPago(Me._Obj)
        With Dialogo
            .TopMost = True
            .Show()
        End With
        FormMain.RegistrarForm(Dialogo)
        AddHandler Dialogo.FormClosed, AddressOf Me.Dialog_FormClosed
    End Sub

    Private Sub Agregar()
        Me._Obj = New Estructura.FormaPago
        Me.AbrirDialogo()
    End Sub

    Private Sub Editar()
        Try
            Me.GetObjSeleccionado()
            Me.AbrirDialogo()
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Eliminar()
        If Not Alertador.Alertar("¿Está seguro que desea eliminar la Forma de Pago?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Eliminar(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
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