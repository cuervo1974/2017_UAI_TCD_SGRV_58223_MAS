<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpleado
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxSucursal = New System.Windows.Forms.ComboBox()
        Me.LabelSucursal = New System.Windows.Forms.Label()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.TextBoxUsuario = New System.Windows.Forms.TextBox()
        Me.LabelUsuario = New System.Windows.Forms.Label()
        Me.TextBoxApellido = New System.Windows.Forms.TextBox()
        Me.LabelApellido = New System.Windows.Forms.Label()
        Me.LabelNombre = New System.Windows.Forms.Label()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.ComboBoxFamilia = New System.Windows.Forms.ComboBox()
        Me.LabelLeyendaPassword = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(206, 205)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
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
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxSucursal, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.LabelSucursal, 0, 5)
        Me.TableLayoutPanel.Controls.Add(Me.LabelEmail, 0, 4)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxPassword, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.LabelPassword, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxUsuario, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelUsuario, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxApellido, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelApellido, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelNombre, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxNombre, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxFamilia, 1, 4)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(10, 12)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(342, 184)
        Me.TableLayoutPanel.TabIndex = 2
        '
        'ComboBoxSucursal
        '
        Me.ComboBoxSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSucursal.FormattingEnabled = True
        Me.ComboBoxSucursal.Location = New System.Drawing.Point(90, 157)
        Me.ComboBoxSucursal.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBoxSucursal.Name = "ComboBoxSucursal"
        Me.ComboBoxSucursal.Size = New System.Drawing.Size(247, 21)
        Me.ComboBoxSucursal.TabIndex = 11
        '
        'LabelSucursal
        '
        Me.LabelSucursal.AutoSize = True
        Me.LabelSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSucursal.Location = New System.Drawing.Point(0, 152)
        Me.LabelSucursal.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelSucursal.Name = "LabelSucursal"
        Me.LabelSucursal.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelSucursal.Size = New System.Drawing.Size(85, 32)
        Me.LabelSucursal.TabIndex = 10
        Me.LabelSucursal.Text = "Sucursal"
        Me.LabelSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelEmail.Location = New System.Drawing.Point(0, 120)
        Me.LabelEmail.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelEmail.Size = New System.Drawing.Size(85, 32)
        Me.LabelEmail.TabIndex = 8
        Me.LabelEmail.Text = "Familia"
        Me.LabelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPassword.Location = New System.Drawing.Point(90, 95)
        Me.TextBoxPassword.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxPassword.TabIndex = 7
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPassword.Location = New System.Drawing.Point(0, 90)
        Me.LabelPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelPassword.Size = New System.Drawing.Size(85, 30)
        Me.LabelPassword.TabIndex = 6
        Me.LabelPassword.Text = "Contraseña"
        Me.LabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUsuario
        '
        Me.TextBoxUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUsuario.Location = New System.Drawing.Point(90, 65)
        Me.TextBoxUsuario.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxUsuario.Name = "TextBoxUsuario"
        Me.TextBoxUsuario.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxUsuario.TabIndex = 5
        '
        'LabelUsuario
        '
        Me.LabelUsuario.AutoSize = True
        Me.LabelUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUsuario.Location = New System.Drawing.Point(0, 60)
        Me.LabelUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelUsuario.Name = "LabelUsuario"
        Me.LabelUsuario.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelUsuario.Size = New System.Drawing.Size(85, 30)
        Me.LabelUsuario.TabIndex = 4
        Me.LabelUsuario.Text = "Usuario"
        Me.LabelUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxApellido
        '
        Me.TextBoxApellido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxApellido.Location = New System.Drawing.Point(90, 35)
        Me.TextBoxApellido.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxApellido.Name = "TextBoxApellido"
        Me.TextBoxApellido.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxApellido.TabIndex = 3
        '
        'LabelApellido
        '
        Me.LabelApellido.AutoSize = True
        Me.LabelApellido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelApellido.Location = New System.Drawing.Point(0, 30)
        Me.LabelApellido.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelApellido.Name = "LabelApellido"
        Me.LabelApellido.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelApellido.Size = New System.Drawing.Size(85, 30)
        Me.LabelApellido.TabIndex = 2
        Me.LabelApellido.Text = "Apellido"
        Me.LabelApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelNombre
        '
        Me.LabelNombre.AutoSize = True
        Me.LabelNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNombre.Location = New System.Drawing.Point(0, 0)
        Me.LabelNombre.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelNombre.Size = New System.Drawing.Size(85, 30)
        Me.LabelNombre.TabIndex = 0
        Me.LabelNombre.Text = "Nombre"
        Me.LabelNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNombre.Location = New System.Drawing.Point(90, 5)
        Me.TextBoxNombre.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxNombre.TabIndex = 1
        '
        'ComboBoxFamilia
        '
        Me.ComboBoxFamilia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFamilia.FormattingEnabled = True
        Me.ComboBoxFamilia.Location = New System.Drawing.Point(90, 125)
        Me.ComboBoxFamilia.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBoxFamilia.Name = "ComboBoxFamilia"
        Me.ComboBoxFamilia.Size = New System.Drawing.Size(247, 21)
        Me.ComboBoxFamilia.TabIndex = 9
        '
        'LabelLeyendaPassword
        '
        Me.LabelLeyendaPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLeyendaPassword.Location = New System.Drawing.Point(12, 205)
        Me.LabelLeyendaPassword.Name = "LabelLeyendaPassword"
        Me.LabelLeyendaPassword.Size = New System.Drawing.Size(191, 29)
        Me.LabelLeyendaPassword.TabIndex = 3
        Me.LabelLeyendaPassword.Text = "Dejar el campo ""Contraseña"" vacío si no se desea modificar."
        Me.LabelLeyendaPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormEmpleado
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(364, 246)
        Me.Controls.Add(Me.LabelLeyendaPassword)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpleado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleado"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxApellido As System.Windows.Forms.TextBox
    Friend WithEvents LabelApellido As System.Windows.Forms.Label
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsuario As System.Windows.Forms.TextBox
    Friend WithEvents LabelUsuario As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSucursal As System.Windows.Forms.Label
    Friend WithEvents LabelLeyendaPassword As System.Windows.Forms.Label

End Class
