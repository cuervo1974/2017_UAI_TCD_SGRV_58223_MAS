<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCliente
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
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.TextBoxCelular = New System.Windows.Forms.TextBox()
        Me.LabelCelular = New System.Windows.Forms.Label()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.LabelTelefono = New System.Windows.Forms.Label()
        Me.TextBoxApellido = New System.Windows.Forms.TextBox()
        Me.LabelApellido = New System.Windows.Forms.Label()
        Me.LabelNombre = New System.Windows.Forms.Label()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.LabelCUIT = New System.Windows.Forms.Label()
        Me.TextBoxCUIT = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
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
        Me.Cancel_Button.Text = "Cancelar"
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxCUIT, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCUIT, 0, 5)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxEmail, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.LabelEmail, 0, 4)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxCelular, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCelular, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxTelefono, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelTelefono, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxApellido, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelApellido, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelNombre, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxNombre, 1, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(342, 180)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxEmail.Location = New System.Drawing.Point(90, 125)
        Me.TextBoxEmail.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxEmail.TabIndex = 9
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelEmail.Location = New System.Drawing.Point(0, 120)
        Me.LabelEmail.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelEmail.Size = New System.Drawing.Size(85, 30)
        Me.LabelEmail.TabIndex = 8
        Me.LabelEmail.Text = "E-Mail"
        Me.LabelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCelular
        '
        Me.TextBoxCelular.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCelular.Location = New System.Drawing.Point(90, 95)
        Me.TextBoxCelular.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxCelular.Name = "TextBoxCelular"
        Me.TextBoxCelular.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxCelular.TabIndex = 7
        '
        'LabelCelular
        '
        Me.LabelCelular.AutoSize = True
        Me.LabelCelular.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCelular.Location = New System.Drawing.Point(0, 90)
        Me.LabelCelular.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCelular.Name = "LabelCelular"
        Me.LabelCelular.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelCelular.Size = New System.Drawing.Size(85, 30)
        Me.LabelCelular.TabIndex = 6
        Me.LabelCelular.Text = "Celular"
        Me.LabelCelular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTelefono.Location = New System.Drawing.Point(90, 65)
        Me.TextBoxTelefono.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxTelefono.TabIndex = 5
        '
        'LabelTelefono
        '
        Me.LabelTelefono.AutoSize = True
        Me.LabelTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTelefono.Location = New System.Drawing.Point(0, 60)
        Me.LabelTelefono.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTelefono.Name = "LabelTelefono"
        Me.LabelTelefono.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelTelefono.Size = New System.Drawing.Size(85, 30)
        Me.LabelTelefono.TabIndex = 4
        Me.LabelTelefono.Text = "Telefono"
        Me.LabelTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'LabelCUIT
        '
        Me.LabelCUIT.AutoSize = True
        Me.LabelCUIT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCUIT.Location = New System.Drawing.Point(0, 150)
        Me.LabelCUIT.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCUIT.Name = "LabelCUIT"
        Me.LabelCUIT.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelCUIT.Size = New System.Drawing.Size(85, 30)
        Me.LabelCUIT.TabIndex = 10
        Me.LabelCUIT.Text = "CUIT"
        Me.LabelCUIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCUIT
        '
        Me.TextBoxCUIT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCUIT.Location = New System.Drawing.Point(90, 155)
        Me.TextBoxCUIT.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxCUIT.Name = "TextBoxCUIT"
        Me.TextBoxCUIT.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxCUIT.TabIndex = 11
        '
        'FormCliente
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(364, 246)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents TextBoxCelular As System.Windows.Forms.TextBox
    Friend WithEvents LabelCelular As System.Windows.Forms.Label
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents LabelTelefono As System.Windows.Forms.Label
    Friend WithEvents TextBoxApellido As System.Windows.Forms.TextBox
    Friend WithEvents LabelApellido As System.Windows.Forms.Label
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCUIT As System.Windows.Forms.TextBox
    Friend WithEvents LabelCUIT As System.Windows.Forms.Label

End Class
