Public Class FormFactura
    Implements InterfaceObservador

    Private _Obj As Estructura.Factura
    Private _ClienteLogica As New BLL.ClienteLogica
    Private _ProductoLogica As New BLL.ProductoLogica
    Private _FormaPagoLogica As New BLL.FormaPagoLogica
    Private _ClienteAux As New Estructura.Cliente

    Sub New(ByRef pObj As Estructura.Factura)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .ComboBoxCliente.DataSource = ._ClienteLogica.ConsultarTodos
            .ComboBoxFormaPago.DataSource = _FormaPagoLogica.ConsultarTodos
            .ComboBoxProductos.DataSource = _ProductoLogica.ConsultarTodos
        End With
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            BLL.FacturaLogica.Validar(Me._Obj)
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

    Private Sub RellenarDataGrid(pListado As List(Of Estructura.FacturaDetalle))
        Me.DataGridProductos.DataSource = Nothing
        Me.DataGridProductos.Columns.Clear()
        Me.DataGridProductos.Rows.Clear()
        Me.DataGridProductos.DataSource = pListado
        Me.AgregarBotonera()
        Me.DataGridProductos.AutoResizeColumns()
    End Sub

    Private Sub AgregarBotonera()
        Dim Botones() As String = {"Eliminar"}
        For Each BotonLabel As String In Botones
            Dim NuevoBoton As New DataGridViewButtonColumn()
            NuevoBoton.Width = 60
            NuevoBoton.HeaderText = BotonLabel
            NuevoBoton.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            NuevoBoton.Text = BotonLabel
            NuevoBoton.Name = BotonLabel
            NuevoBoton.UseColumnTextForButtonValue = True
            Me.DataGridProductos.Columns.Add(NuevoBoton)
        Next
    End Sub

    Private Sub ButtonAgregarProducto_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click
        Try
            If (IsNothing(Me.ComboBoxProductos.SelectedValue)) Then Throw New Exception("Se debe seleccionar un producto.")
            Dim Producto As Estructura.Producto = Me.ComboBoxProductos.SelectedItem
            Dim Cantidad As Integer
            If Not Integer.TryParse(Me.TextBoxCantidad.Text, Cantidad) Then Throw New Exception("La cantidad debe ser un número.")
            Dim Descuento As Integer
            If String.IsNullOrEmpty(TextBoxDescuento.Text) Then
                Descuento = 0
            Else
                If Not Integer.TryParse(Me.TextBoxDescuento.Text, Descuento) Then Throw New Exception("El descuento debe ser un número.")
            End If
            If Not IsNothing(Me._Obj.FacturaDetalle.Find(Function(x) x.Producto.Id = Producto.Id)) Then Throw New Exception("Ya existe ese Producto en este Factura.")
            Dim FacturaDetalle = New Estructura.FacturaDetalle(Producto.Precio, Cantidad, Descuento)
            FacturaDetalle.Producto = Producto
            Me._Obj.FacturaDetalle.Add(FacturaDetalle)
            Me.RellenarDataGrid(Me._Obj.FacturaDetalle)
            Me.LabelTotal.Text = String.Format("$ {0}", Me._Obj.Total)
            Me.TextBoxCantidad.Text = ""
            Me.TextBoxDescuento.Text = ""
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub DataGridProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridProductos.CellContentClick
        If e.RowIndex = -1 Then Exit Sub
        Dim FacturaDetalle As Estructura.FacturaDetalle = Me.DataGridProductos.Rows(e.RowIndex).DataBoundItem
        Select Case Me.DataGridProductos.Columns(e.ColumnIndex).Name
            Case "Eliminar"
                Me._Obj.FacturaDetalle.Remove(FacturaDetalle)
                Me.RellenarDataGrid(Me._Obj.FacturaDetalle)
                Me.LabelTotal.Text = String.Format("$ {0}", Me._Obj.Total)
        End Select
    End Sub

    Private Sub ComboBoxFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFormaPago.SelectedIndexChanged
        Me._Obj.FormaPago = DirectCast(sender, ComboBox).SelectedValue
        Me.LabelTotal.Text = String.Format("$ {0}", Me._Obj.Total)
    End Sub

    Private Sub ComboBoxCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCliente.SelectedIndexChanged
        Me._Obj.Cliente = DirectCast(sender, ComboBox).SelectedValue
        Me.VerificarCUIT()
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Private Sub ComboBoxTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTipo.SelectedIndexChanged
        Me._Obj.Tipo = DirectCast(sender, ComboBox).Text
        Me.VerificarCUIT()
    End Sub

    Private Sub ButtonCrearCliente_Click(sender As Object, e As EventArgs) Handles ButtonCrearCliente.Click
        Me._ClienteAux = New Estructura.Cliente
        Dim Dialogo As New FormCliente(Me._ClienteAux)
        With Dialogo
            .TopMost = True
            .Show()
        End With
        FormMain.RegistrarForm(Dialogo)
        AddHandler Dialogo.FormClosed, AddressOf Me.DialogCliente_FormClosed
    End Sub

    Private Sub VerificarCUIT()
        If Me._Obj.Cliente Is Nothing Then Exit Sub
        If Me._Obj.Tipo = "A" And Me._Obj.Cliente.CUIT = "" Then
            If Alertador.Alertar("Ops! Parece que el Cliente no tiene CUIT. ¿Desea agregarlo?", "Falta CUIT", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Me._ClienteAux = Me._Obj.Cliente
                Dim Dialogo As New FormCliente(Me._ClienteAux)
                With Dialogo
                    .TopMost = True
                    .Show()
                End With
                FormMain.RegistrarForm(Dialogo)
                AddHandler Dialogo.FormClosed, AddressOf Me.DialogCliente_FormClosed
            End If
        End If
    End Sub

    Private Sub DialogCliente_FormClosed(sender As Object, e As FormClosedEventArgs)
        If DirectCast(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                Me._ClienteLogica.Guardar(Me._ClienteAux)
            Catch ex As Exception
                Alertador.Alertar(ex.Message)
            End Try
            Me.ComboBoxCliente.DataSource = Nothing
            Me.ComboBoxCliente.DataSource = Me._ClienteLogica.ConsultarTodos
        End If
    End Sub

    Private Sub ButtonBuscarCliente_Click(sender As Object, e As EventArgs) Handles ButtonBuscarCliente.Click
        Dim Dialogo As New FormSeleccionarCliente(Me._ClienteAux)
        With Dialogo
            .TopMost = True
            .Show()
        End With
        Me.Hide()
        FormMain.RegistrarForm(Dialogo)
        AddHandler Dialogo.FormClosed, AddressOf Me.DialogBuscarCliente_FormClosed
    End Sub

    Private Sub DialogBuscarCliente_FormClosed(sender As Object, e As FormClosedEventArgs)
        If DirectCast(sender, Form).DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                For Each item In Me.ComboBoxCliente.Items
                    If DirectCast(item, Estructura.Cliente).Id = Me._ClienteAux.Id Then Me.ComboBoxCliente.SelectedItem = item
                Next
            Catch ex As Exception
                Alertador.Alertar(ex.Message)
            End Try
        End If
        Me.Show()
    End Sub

    Private Sub LabelTotal_Click(sender As Object, e As EventArgs) Handles LabelTotal.Click

    End Sub
End Class