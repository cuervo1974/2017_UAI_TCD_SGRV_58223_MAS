<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotoneraFiltrador
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ButtonLimpiarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.ButtonFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.TextFiltroTexto = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabelFiltrar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonLimpiarFiltro, Me.ButtonFiltrar, Me.TextFiltroTexto, Me.ToolStripLabelFiltrar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Padding = New System.Windows.Forms.Padding(13, 6, 13, 6)
        Me.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip.Size = New System.Drawing.Size(1336, 43)
        Me.ToolStrip.TabIndex = 2
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ButtonLimpiarFiltro
        '
        Me.ButtonLimpiarFiltro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonLimpiarFiltro.Image = Global.GUI.My.Resources.Resources.Bloquear
        Me.ButtonLimpiarFiltro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonLimpiarFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonLimpiarFiltro.Name = "ButtonLimpiarFiltro"
        Me.ButtonLimpiarFiltro.Size = New System.Drawing.Size(134, 31)
        Me.ButtonLimpiarFiltro.Text = "Limpiar Filtro"
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonFiltrar.Image = Global.GUI.My.Resources.Resources.Lupa
        Me.ButtonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonFiltrar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(78, 31)
        Me.ButtonFiltrar.Text = "Filtrar"
        '
        'TextFiltroTexto
        '
        Me.TextFiltroTexto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TextFiltroTexto.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.TextFiltroTexto.Name = "TextFiltroTexto"
        Me.TextFiltroTexto.Size = New System.Drawing.Size(199, 31)
        '
        'ToolStripLabelFiltrar
        '
        Me.ToolStripLabelFiltrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelFiltrar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabelFiltrar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.ToolStripLabelFiltrar.Name = "ToolStripLabelFiltrar"
        Me.ToolStripLabelFiltrar.Size = New System.Drawing.Size(60, 31)
        Me.ToolStripLabelFiltrar.Text = "Buscar"
        '
        'BotoneraFiltrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BotoneraFiltrador"
        Me.Size = New System.Drawing.Size(1336, 43)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TextFiltroTexto As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ButtonFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonLimpiarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabelFiltrar As System.Windows.Forms.ToolStripLabel

End Class
