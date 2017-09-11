<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticasPresupuestosYVentas
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxSucursal = New System.Windows.Forms.ComboBox()
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker()
        Me.LabelHasta = New System.Windows.Forms.Label()
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker()
        Me.LabelDesde = New System.Windows.Forms.Label()
        Me.LabelEmpleado = New System.Windows.Forms.Label()
        Me.ComboBoxEmpleado = New System.Windows.Forms.ComboBox()
        Me.ButtonFiltrar = New System.Windows.Forms.Button()
        Me.LabelSucursal = New System.Windows.Forms.Label()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart
        '
        Me.Chart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.Chart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart.Legends.Add(Legend1)
        Me.Chart.Location = New System.Drawing.Point(12, 43)
        Me.Chart.Name = "Chart"
        Me.Chart.Size = New System.Drawing.Size(963, 256)
        Me.Chart.TabIndex = 6
        Me.Chart.Text = "Chart1"
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel.ColumnCount = 9
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxSucursal, 5, 0)
        Me.TableLayoutPanel.Controls.Add(Me.DateTimeHasta, 3, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelHasta, 2, 0)
        Me.TableLayoutPanel.Controls.Add(Me.DateTimeDesde, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelDesde, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelEmpleado, 6, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxEmpleado, 7, 0)
        Me.TableLayoutPanel.Controls.Add(Me.ButtonFiltrar, 8, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelSucursal, 4, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 9)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 1
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(963, 30)
        Me.TableLayoutPanel.TabIndex = 9
        '
        'ComboBoxSucursal
        '
        Me.ComboBoxSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSucursal.FormattingEnabled = True
        Me.ComboBoxSucursal.Location = New System.Drawing.Point(485, 5)
        Me.ComboBoxSucursal.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBoxSucursal.Name = "ComboBoxSucursal"
        Me.ComboBoxSucursal.Size = New System.Drawing.Size(131, 21)
        Me.ComboBoxSucursal.TabIndex = 18
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
        'LabelEmpleado
        '
        Me.LabelEmpleado.AutoSize = True
        Me.LabelEmpleado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelEmpleado.Location = New System.Drawing.Point(626, 5)
        Me.LabelEmpleado.Margin = New System.Windows.Forms.Padding(5)
        Me.LabelEmpleado.Name = "LabelEmpleado"
        Me.LabelEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.LabelEmpleado.TabIndex = 14
        Me.LabelEmpleado.Text = "Empleado"
        Me.LabelEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxEmpleado
        '
        Me.ComboBoxEmpleado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxEmpleado.FormattingEnabled = True
        Me.ComboBoxEmpleado.Location = New System.Drawing.Point(706, 5)
        Me.ComboBoxEmpleado.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBoxEmpleado.Name = "ComboBoxEmpleado"
        Me.ComboBoxEmpleado.Size = New System.Drawing.Size(131, 21)
        Me.ComboBoxEmpleado.TabIndex = 15
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFiltrar.Location = New System.Drawing.Point(842, 0)
        Me.ButtonFiltrar.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(121, 30)
        Me.ButtonFiltrar.TabIndex = 16
        Me.ButtonFiltrar.Text = "Filtrar"
        Me.ButtonFiltrar.UseVisualStyleBackColor = True
        '
        'LabelSucursal
        '
        Me.LabelSucursal.AutoSize = True
        Me.LabelSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSucursal.Location = New System.Drawing.Point(403, 0)
        Me.LabelSucursal.Name = "LabelSucursal"
        Me.LabelSucursal.Size = New System.Drawing.Size(74, 30)
        Me.LabelSucursal.TabIndex = 17
        Me.LabelSucursal.Text = "Sucursal"
        Me.LabelSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormEstadisticasPresupuestosYVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 311)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.Chart)
        Me.Name = "FormEstadisticasPresupuestosYVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas de Presupuestos y Ventas"
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelHasta As System.Windows.Forms.Label
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDesde As System.Windows.Forms.Label
    Friend WithEvents LabelEmpleado As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonFiltrar As System.Windows.Forms.Button
    Friend WithEvents ComboBoxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSucursal As System.Windows.Forms.Label
End Class
