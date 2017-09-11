<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSucursal
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
        Me.TextBoxCiudad = New System.Windows.Forms.TextBox()
        Me.LabelCiudad = New System.Windows.Forms.Label()
        Me.TextBoxDireccion = New System.Windows.Forms.TextBox()
        Me.LabelDireccion = New System.Windows.Forms.Label()
        Me.LabelNombre = New System.Windows.Forms.Label()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(206, 110)
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
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxCiudad, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCiudad, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDireccion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelDireccion, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelNombre, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxNombre, 1, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(342, 90)
        Me.TableLayoutPanel.TabIndex = 2
        '
        'TextBoxCiudad
        '
        Me.TextBoxCiudad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCiudad.Location = New System.Drawing.Point(90, 65)
        Me.TextBoxCiudad.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxCiudad.Name = "TextBoxCiudad"
        Me.TextBoxCiudad.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxCiudad.TabIndex = 5
        '
        'LabelCiudad
        '
        Me.LabelCiudad.AutoSize = True
        Me.LabelCiudad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCiudad.Location = New System.Drawing.Point(0, 60)
        Me.LabelCiudad.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCiudad.Name = "LabelCiudad"
        Me.LabelCiudad.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelCiudad.Size = New System.Drawing.Size(85, 30)
        Me.LabelCiudad.TabIndex = 4
        Me.LabelCiudad.Text = "Ciudad"
        Me.LabelCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxDireccion
        '
        Me.TextBoxDireccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDireccion.Location = New System.Drawing.Point(90, 35)
        Me.TextBoxDireccion.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxDireccion.Name = "TextBoxDireccion"
        Me.TextBoxDireccion.Size = New System.Drawing.Size(247, 20)
        Me.TextBoxDireccion.TabIndex = 3
        '
        'LabelDireccion
        '
        Me.LabelDireccion.AutoSize = True
        Me.LabelDireccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDireccion.Location = New System.Drawing.Point(0, 30)
        Me.LabelDireccion.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelDireccion.Name = "LabelDireccion"
        Me.LabelDireccion.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelDireccion.Size = New System.Drawing.Size(85, 30)
        Me.LabelDireccion.TabIndex = 2
        Me.LabelDireccion.Text = "Dirección"
        Me.LabelDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'FormSucursal
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(364, 151)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSucursal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursal"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxCiudad As System.Windows.Forms.TextBox
    Friend WithEvents LabelCiudad As System.Windows.Forms.Label
    Friend WithEvents TextBoxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents LabelDireccion As System.Windows.Forms.Label
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox

End Class
