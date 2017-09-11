<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticasProductos
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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker()
        Me.LabelHasta = New System.Windows.Forms.Label()
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker()
        Me.LabelDesde = New System.Windows.Forms.Label()
        Me.ButtonFiltrar = New System.Windows.Forms.Button()
        Me.LabelDobleClic = New System.Windows.Forms.Label()
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel.ColumnCount = 7
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.DateTimeHasta, 3, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelHasta, 2, 0)
        Me.TableLayoutPanel.Controls.Add(Me.DateTimeDesde, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelDesde, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ButtonFiltrar, 5, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelDobleClic, 6, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(11, 10)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 1
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(963, 30)
        Me.TableLayoutPanel.TabIndex = 11
        '
        'DateTimeHasta
        '
        Me.DateTimeHasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeHasta.Location = New System.Drawing.Point(285, 5)
        Me.DateTimeHasta.Margin = New System.Windows.Forms.Padding(5)
        Me.DateTimeHasta.Name = "DateTimeHasta"
        Me.DateTimeHasta.Size = New System.Drawing.Size(110, 20)
        Me.DateTimeHasta.TabIndex = 13
        '
        'LabelHasta
        '
        Me.LabelHasta.AutoSize = True
        Me.LabelHasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelHasta.Location = New System.Drawing.Point(205, 5)
        Me.LabelHasta.Margin = New System.Windows.Forms.Padding(5)
        Me.LabelHasta.Name = "LabelHasta"
        Me.LabelHasta.Size = New System.Drawing.Size(70, 20)
        Me.LabelHasta.TabIndex = 12
        Me.LabelHasta.Text = "Hasta"
        Me.LabelHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimeDesde
        '
        Me.DateTimeDesde.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeDesde.Location = New System.Drawing.Point(85, 5)
        Me.DateTimeDesde.Margin = New System.Windows.Forms.Padding(5)
        Me.DateTimeDesde.Name = "DateTimeDesde"
        Me.DateTimeDesde.Size = New System.Drawing.Size(110, 20)
        Me.DateTimeDesde.TabIndex = 8
        '
        'LabelDesde
        '
        Me.LabelDesde.AutoSize = True
        Me.LabelDesde.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDesde.Location = New System.Drawing.Point(5, 5)
        Me.LabelDesde.Margin = New System.Windows.Forms.Padding(5)
        Me.LabelDesde.Name = "LabelDesde"
        Me.LabelDesde.Size = New System.Drawing.Size(70, 20)
        Me.LabelDesde.TabIndex = 7
        Me.LabelDesde.Text = "Desde"
        Me.LabelDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFiltrar.Location = New System.Drawing.Point(420, 0)
        Me.ButtonFiltrar.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(120, 30)
        Me.ButtonFiltrar.TabIndex = 16
        Me.ButtonFiltrar.Text = "Filtrar"
        Me.ButtonFiltrar.UseVisualStyleBackColor = True
        '
        'LabelDobleClic
        '
        Me.LabelDobleClic.AutoSize = True
        Me.LabelDobleClic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDobleClic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDobleClic.Location = New System.Drawing.Point(543, 0)
        Me.LabelDobleClic.Name = "LabelDobleClic"
        Me.LabelDobleClic.Size = New System.Drawing.Size(417, 30)
        Me.LabelDobleClic.TabIndex = 17
        Me.LabelDobleClic.Text = "Haciendo doble clic en el gráfico se modifica su forma."
        Me.LabelDobleClic.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Chart
        '
        Me.Chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.Chart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart.Legends.Add(Legend2)
        Me.Chart.Location = New System.Drawing.Point(11, 44)
        Me.Chart.Name = "Chart"
        Me.Chart.Size = New System.Drawing.Size(963, 256)
        Me.Chart.TabIndex = 10
        Me.Chart.Text = "Chart1"
        '
        'FormEstadisticasProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 311)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.Chart)
        Me.Name = "FormEstadisticasProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadisticas de Productos"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelHasta As System.Windows.Forms.Label
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDesde As System.Windows.Forms.Label
    Friend WithEvents ButtonFiltrar As System.Windows.Forms.Button
    Friend WithEvents Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents LabelDobleClic As System.Windows.Forms.Label
End Class
