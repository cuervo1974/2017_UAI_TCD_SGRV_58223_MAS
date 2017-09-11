Public Class FormEstadisticasPresupuestosYVentas

    Dim _EstadisticaLogica As New BLL.EstadisticaLogica
    Dim _EmpleadoLogica As New BLL.EmpleadoLogica
    Dim _SucursalLogica As New BLL.SucursalLogica

    Private Sub FormEstadisticasVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.RellenarSucursales()
        Me.RellenarEmpleados()
        Me.DateTimeDesde.Value = New DateTime(Now.Year, 1, 1)
        Me.DateTimeHasta.Value = New DateTime(Now.Year, 1, 31)

        Me.ButtonFiltrar.PerformClick()

    End Sub

    Private Sub ButtonFiltrar_Click(sender As Object, e As EventArgs) Handles ButtonFiltrar.Click

        Me.Chart.Series.Clear()

        Dim Ventas As Dictionary(Of Date, Integer) = Me._EstadisticaLogica.ConsultarVentas(Me.DateTimeDesde.Text, Me.DateTimeHasta.Text, _
                                                                                           IIf(Me.ComboBoxSucursal.SelectedItem.ToString = "Todos", Nothing, Me.ComboBoxSucursal.SelectedItem), _
                                                                                           IIf(Me.ComboBoxEmpleado.SelectedItem.ToString = "Todos", Nothing, Me.ComboBoxEmpleado.SelectedItem))

        Me.Chart.Series.Add("Ventas")
        Me.Chart.Series("Ventas").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Me.Chart.Series("Ventas").Points.DataBindXY(Ventas.Keys, Ventas.Values)

        Dim Presupuestos As Dictionary(Of Date, Integer) = Me._EstadisticaLogica.ConsultarPresupuestos(Me.DateTimeDesde.Text, Me.DateTimeHasta.Text, _
                                                                                           IIf(Me.ComboBoxSucursal.SelectedItem.ToString = "Todos", Nothing, Me.ComboBoxSucursal.SelectedItem), _
                                                                                           IIf(Me.ComboBoxEmpleado.SelectedItem.ToString = "Todos", Nothing, Me.ComboBoxEmpleado.SelectedItem))

        Me.Chart.Series.Add("Presupuestos")
        Me.Chart.Series("Presupuestos").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Me.Chart.Series("Presupuestos").Points.DataBindXY(Presupuestos.Keys, Presupuestos.Values)

    End Sub

    Private Sub RellenarEmpleados()

        Me.ComboBoxEmpleado.Items.Clear()

        Me.ComboBoxEmpleado.Items.Add("Todos")

        For Each Empleado As Estructura.Empleado In Me._EmpleadoLogica.ConsultarTodos
            Me.ComboBoxEmpleado.Items.Add(Empleado)
        Next

        Me.ComboBoxEmpleado.SelectedItem = Me.ComboBoxEmpleado.Items(0)

    End Sub

    Private Sub RellenarSucursales()

        Me.ComboBoxSucursal.Items.Clear()

        Me.ComboBoxSucursal.Items.Add("Todos")

        For Each Sucursal As Estructura.Sucursal In Me._SucursalLogica.ConsultarTodos
            Me.ComboBoxSucursal.Items.Add(Sucursal)
        Next

        Me.ComboBoxSucursal.SelectedItem = Me.ComboBoxSucursal.Items(0)

    End Sub

End Class