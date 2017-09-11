Public Class FormEstadisticasProductos

    Dim _EstadisticaLogica As New BLL.EstadisticaLogica
    Dim _EmpleadoLogica As New BLL.EmpleadoLogica
    Dim _SucursalLogica As New BLL.SucursalLogica

    Private Sub FormEstadisticasVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.DateTimeDesde.Value = New DateTime(Now.Year, 1, 1)
        Me.DateTimeHasta.Value = New DateTime(Now.Year, 12, 31)

        Me.ButtonFiltrar.PerformClick()

    End Sub

    Private Sub ButtonFiltrar_Click(sender As Object, e As EventArgs) Handles ButtonFiltrar.Click

        Me.Chart.Series.Clear()

        Dim Productos As Dictionary(Of String, Integer) = Me._EstadisticaLogica.ConsultarProductos(Me.DateTimeDesde.Value, Me.DateTimeHasta.Value)

        Me.Chart.Series.Add("Productos").ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Me.Chart.Series("Productos").Points.DataBindXY(Productos.Keys, Productos.Values)

    End Sub

    Private Sub Chart_DoubleClick(sender As Object, e As EventArgs) Handles Chart.DoubleClick
        Try
            Me.Chart.Series("Productos").ChartType = Me.Chart.Series("Productos").ChartType + 1
        Catch ex As Exception
            Me.Chart.Series("Productos").ChartType = 1
        End Try
    End Sub


End Class