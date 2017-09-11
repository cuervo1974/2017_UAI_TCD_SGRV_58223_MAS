<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductos
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
        Me.DataGridPrincipal = New System.Windows.Forms.DataGridView()
        Me.BotoneraFiltrador = New GUI.BotoneraFiltrador()
        CType(Me.DataGridPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridPrincipal
        '
        Me.DataGridPrincipal.AllowUserToAddRows = False
        Me.DataGridPrincipal.AllowUserToDeleteRows = False
        Me.DataGridPrincipal.AllowUserToResizeRows = False
        Me.DataGridPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridPrincipal.Location = New System.Drawing.Point(0, 35)
        Me.DataGridPrincipal.MultiSelect = False
        Me.DataGridPrincipal.Name = "DataGridPrincipal"
        Me.DataGridPrincipal.ReadOnly = True
        Me.DataGridPrincipal.RowHeadersVisible = False
        Me.DataGridPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridPrincipal.Size = New System.Drawing.Size(709, 276)
        Me.DataGridPrincipal.TabIndex = 4
        '
        'BotoneraFiltrador
        '
        Me.BotoneraFiltrador.Dock = System.Windows.Forms.DockStyle.Top
        Me.BotoneraFiltrador.Location = New System.Drawing.Point(0, 0)
        Me.BotoneraFiltrador.Name = "BotoneraFiltrador"
        Me.BotoneraFiltrador.Size = New System.Drawing.Size(709, 35)
        Me.BotoneraFiltrador.TabIndex = 5
        '
        'FormProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 311)
        Me.Controls.Add(Me.BotoneraFiltrador)
        Me.Controls.Add(Me.DataGridPrincipal)
        Me.Name = "FormProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        CType(Me.DataGridPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BotoneraFiltrador As GUI.BotoneraFiltrador
    Friend WithEvents DataGridPrincipal As System.Windows.Forms.DataGridView
End Class
