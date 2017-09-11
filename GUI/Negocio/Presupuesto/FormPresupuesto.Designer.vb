<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPresupuesto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxDescuento = New System.Windows.Forms.TextBox()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.LabelDescuento = New System.Windows.Forms.Label()
        Me.ComboBoxProductos = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.LabelProductoCantidad = New System.Windows.Forms.Label()
        Me.LabelProductoNombre = New System.Windows.Forms.Label()
        Me.DataGridProductos = New System.Windows.Forms.DataGridView()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonBuscarCliente = New System.Windows.Forms.Button()
        Me.ComboBoxFormaPago = New System.Windows.Forms.ComboBox()
        Me.LabelFormaPago = New System.Windows.Forms.Label()
        Me.ComboBoxCliente = New System.Windows.Forms.ComboBox()
        Me.LabelCliente = New System.Windows.Forms.Label()
        Me.ButtonCrearCliente = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxDescuento, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCantidad, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelDescuento, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxProductos, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelProductoCantidad, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelProductoNombre, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 70)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(574, 53)
        Me.TableLayoutPanel2.TabIndex = 45
        '
        'TextBoxDescuento
        '
        Me.TextBoxDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescuento.Location = New System.Drawing.Point(379, 29)
        Me.TextBoxDescuento.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxDescuento.Name = "TextBoxDescuento"
        Me.TextBoxDescuento.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxDescuento.TabIndex = 26
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCantidad.Location = New System.Drawing.Point(279, 29)
        Me.TextBoxCantidad.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxCantidad.TabIndex = 25
        '
        'LabelDescuento
        '
        Me.LabelDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDescuento.Location = New System.Drawing.Point(379, 5)
        Me.LabelDescuento.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.LabelDescuento.Name = "LabelDescuento"
        Me.LabelDescuento.Size = New System.Drawing.Size(90, 19)
        Me.LabelDescuento.TabIndex = 23
        Me.LabelDescuento.Text = "Descuento"
        Me.LabelDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxProductos
        '
        Me.ComboBoxProductos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxProductos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxProductos.FormattingEnabled = True
        Me.ComboBoxProductos.Location = New System.Drawing.Point(0, 29)
        Me.ComboBoxProductos.Margin = New System.Windows.Forms.Padding(0, 5, 5, 5)
        Me.ComboBoxProductos.Name = "ComboBoxProductos"
        Me.ComboBoxProductos.Size = New System.Drawing.Size(269, 21)
        Me.ComboBoxProductos.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonAgregar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(474, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel2.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(100, 53)
        Me.Panel1.TabIndex = 24
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonAgregar.Location = New System.Drawing.Point(0, 3)
        Me.ButtonAgregar.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(100, 50)
        Me.ButtonAgregar.TabIndex = 4
        Me.ButtonAgregar.Text = "Agregar Producto"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'LabelProductoCantidad
        '
        Me.LabelProductoCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductoCantidad.Location = New System.Drawing.Point(279, 5)
        Me.LabelProductoCantidad.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.LabelProductoCantidad.Name = "LabelProductoCantidad"
        Me.LabelProductoCantidad.Size = New System.Drawing.Size(90, 19)
        Me.LabelProductoCantidad.TabIndex = 19
        Me.LabelProductoCantidad.Text = "Cantidad"
        Me.LabelProductoCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelProductoNombre
        '
        Me.LabelProductoNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductoNombre.Location = New System.Drawing.Point(0, 5)
        Me.LabelProductoNombre.Margin = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.LabelProductoNombre.Name = "LabelProductoNombre"
        Me.LabelProductoNombre.Size = New System.Drawing.Size(269, 19)
        Me.LabelProductoNombre.TabIndex = 15
        Me.LabelProductoNombre.Text = "Nombre de Producto"
        Me.LabelProductoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridProductos
        '
        Me.DataGridProductos.AllowUserToAddRows = False
        Me.DataGridProductos.AllowUserToDeleteRows = False
        Me.DataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridProductos.Location = New System.Drawing.Point(12, 130)
        Me.DataGridProductos.Name = "DataGridProductos"
        Me.DataGridProductos.ReadOnly = True
        Me.DataGridProductos.RowHeadersVisible = False
        Me.DataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridProductos.Size = New System.Drawing.Size(574, 150)
        Me.DataGridProductos.TabIndex = 44
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Guardar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(440, 290)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 42
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 12
        Me.LineShape1.X2 = 585
        Me.LineShape1.Y1 = 55
        Me.LineShape1.Y2 = 55
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(596, 331)
        Me.ShapeContainer1.TabIndex = 46
        Me.ShapeContainer1.TabStop = False
        '
        'LabelTotal
        '
        Me.LabelTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LabelTotal.Location = New System.Drawing.Point(12, 290)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(425, 29)
        Me.LabelTotal.TabIndex = 47
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 6
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.08348!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.91652!))
        Me.TableLayoutPanel.Controls.Add(Me.ButtonBuscarCliente, 2, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxFormaPago, 5, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelFormaPago, 4, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxCliente, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCliente, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ButtonCrearCliente, 3, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(574, 32)
        Me.TableLayoutPanel.TabIndex = 50
        '
        'ButtonBuscarCliente
        '
        Me.ButtonBuscarCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonBuscarCliente.Image = Global.GUI.My.Resources.Resources.Lupa
        Me.ButtonBuscarCliente.Location = New System.Drawing.Point(234, 4)
        Me.ButtonBuscarCliente.Margin = New System.Windows.Forms.Padding(0, 4, 0, 5)
        Me.ButtonBuscarCliente.Name = "ButtonBuscarCliente"
        Me.ButtonBuscarCliente.Size = New System.Drawing.Size(25, 23)
        Me.ButtonBuscarCliente.TabIndex = 11
        Me.ButtonBuscarCliente.UseVisualStyleBackColor = True
        '
        'ComboBoxFormaPago
        '
        Me.ComboBoxFormaPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFormaPago.FormattingEnabled = True
        Me.ComboBoxFormaPago.Location = New System.Drawing.Point(394, 5)
        Me.ComboBoxFormaPago.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBoxFormaPago.Name = "ComboBoxFormaPago"
        Me.ComboBoxFormaPago.Size = New System.Drawing.Size(175, 21)
        Me.ComboBoxFormaPago.TabIndex = 9
        '
        'LabelFormaPago
        '
        Me.LabelFormaPago.AutoSize = True
        Me.LabelFormaPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelFormaPago.Location = New System.Drawing.Point(289, 0)
        Me.LabelFormaPago.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelFormaPago.Name = "LabelFormaPago"
        Me.LabelFormaPago.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelFormaPago.Size = New System.Drawing.Size(100, 32)
        Me.LabelFormaPago.TabIndex = 8
        Me.LabelFormaPago.Text = "Forma de Pago"
        Me.LabelFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxCliente
        '
        Me.ComboBoxCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCliente.FormattingEnabled = True
        Me.ComboBoxCliente.Location = New System.Drawing.Point(55, 5)
        Me.ComboBoxCliente.Margin = New System.Windows.Forms.Padding(5, 5, 0, 5)
        Me.ComboBoxCliente.Name = "ComboBoxCliente"
        Me.ComboBoxCliente.Size = New System.Drawing.Size(179, 21)
        Me.ComboBoxCliente.TabIndex = 7
        '
        'LabelCliente
        '
        Me.LabelCliente.AutoSize = True
        Me.LabelCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCliente.Location = New System.Drawing.Point(0, 0)
        Me.LabelCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelCliente.Size = New System.Drawing.Size(50, 32)
        Me.LabelCliente.TabIndex = 0
        Me.LabelCliente.Text = "Cliente"
        Me.LabelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonCrearCliente
        '
        Me.ButtonCrearCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCrearCliente.Image = Global.GUI.My.Resources.Resources.Crear
        Me.ButtonCrearCliente.Location = New System.Drawing.Point(259, 4)
        Me.ButtonCrearCliente.Margin = New System.Windows.Forms.Padding(0, 4, 4, 5)
        Me.ButtonCrearCliente.Name = "ButtonCrearCliente"
        Me.ButtonCrearCliente.Size = New System.Drawing.Size(26, 23)
        Me.ButtonCrearCliente.TabIndex = 10
        Me.ButtonCrearCliente.UseVisualStyleBackColor = True
        '
        'FormPresupuesto
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 331)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.LabelTotal)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.DataGridProductos)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPresupuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presupuesto"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxDescuento As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescuento As System.Windows.Forms.Label
    Friend WithEvents ComboBoxProductos As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents LabelProductoCantidad As System.Windows.Forms.Label
    Friend WithEvents LabelProductoNombre As System.Windows.Forms.Label
    Friend WithEvents DataGridProductos As System.Windows.Forms.DataGridView
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents ComboBoxFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFormaPago As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
    Friend WithEvents ButtonCrearCliente As System.Windows.Forms.Button
End Class
