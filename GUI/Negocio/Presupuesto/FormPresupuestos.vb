Imports System.ComponentModel

Public Class FormPresupuestos
    Implements InterfaceObservador

    Private _Logica As New BLL.PresupuestoLogica
    Private _Obj As Estructura.Presupuesto
    Private _ClienteLogica As New BLL.ClienteLogica
    Private WithEvents _WorkerEmail As New BackgroundWorker
    Private _WorkerFormEmail As New FormEnviando

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
    End Sub

    Private Sub RellenarDataGrid(pListado As List(Of Estructura.Presupuesto))
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
        If IsNothing(Me._Obj) Then Throw New Exception("No se ha seleccionado ningún Presupuesto.")
    End Sub

    Private Sub AbrirDialogo()
        Dim Dialogo As New FormPresupuesto(Me._Obj)
        With Dialogo
            .TopMost = True
            .Show()
        End With
        FormMain.RegistrarForm(Dialogo)
        AddHandler Dialogo.FormClosed, AddressOf Me.Dialog_FormClosed
    End Sub

    Private Sub Agregar()
        Me._Obj = New Estructura.Presupuesto
        Me._Obj.PresupuestoDetalle = New List(Of Estructura.PresupuestoDetalle)
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
        If Not Alertador.Alertar("¿Está seguro que desea anular el Presupuesto?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            Me._Logica.Anular(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
        Me.RellenarDataGrid(Me._Logica.ConsultarTodos)
    End Sub

    Private Sub Enviar()
        If Not Alertador.Alertar("¿Está seguro que desea enviar el Presupuesto por e-mail?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Me.GetObjSeleccionado()
            If Me._Obj.Cliente.Email = "" Then
                If Alertador.Alertar("Ops! Parece que el Cliente no tiene E-Mail. ¿Desea agregarlo?", "Falta CUIT", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Dim Dialogo As New FormCliente(Me._Obj.Cliente)
                    With Dialogo
                        .TopMost = True
                        .Show()
                    End With
                    FormMain.RegistrarForm(Dialogo)
                    AddHandler Dialogo.FormClosed, AddressOf Me.DialogCliente_FormClosed
                Else
                    Throw New Exception("No se puede enviar el Email")
                End If
            Else
                Me._WorkerFormEmail.Show()
                Me._WorkerEmail.RunWorkerAsync()
            End If
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub DialogCliente_FormClosed(sender As Object, e As FormClosedEventArgs)
        If DirectCast(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                Me._ClienteLogica.Guardar(Me._Obj.Cliente)
                Me._WorkerFormEmail.Show()
                Me._WorkerEmail.RunWorkerAsync()
            Catch ex As Exception
                Alertador.Alertar(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Imprimir()
        If Not Alertador.Alertar("¿Está seguro que desea imprimir el Presupuesto?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub
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

    Private Sub _WorkerEmail_DoWork(sender As Object, e As DoWorkEventArgs) Handles _WorkerEmail.DoWork
        Try
            Me._Logica.Enviar(Me._Obj)
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
            Me._WorkerEmail.CancelAsync()
        End Try
    End Sub

    Private Sub _WorkerEmail_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _WorkerEmail.RunWorkerCompleted
        Me._WorkerFormEmail.Hide()
        If e.Cancelled = False Then Alertador.Alertar("El E-Mail ha sido enviado correctamente.")
    End Sub

End Class