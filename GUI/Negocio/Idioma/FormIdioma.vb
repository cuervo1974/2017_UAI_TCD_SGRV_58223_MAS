Public Class FormIdioma
    Implements InterfaceObservador

    Private _Obj As Estructura.Idioma
    Private _Logica As New BLL.IdiomaLogica

    Sub New(ByRef pObj As Estructura.Idioma)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBoxNombre.Text = Me._Obj.Nombre
        Me.CargarPalabras()
    End Sub

    Private Sub CargarPalabras()
        Me.DataGridViewTraducciones.Columns.Add("PalabraOriginal", "Palabra / Frase Original")
        Me.DataGridViewTraducciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTraducciones.Columns(0).ReadOnly = True
        Me.DataGridViewTraducciones.Columns.Add("PalabraTraducida", "Palabra / Frase Traducida")
        Me.DataGridViewTraducciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTraducciones.AllowUserToAddRows = False
        For Each PalabraOriginal As Estructura.Palabra In Me._Logica.ConsultarPalabrasOriginales
            Dim PalabraTraducida As Estructura.PalabraTraducida
            PalabraTraducida = Me._Obj.PalabrasTraducidas.Find(Function(x) x.Palabra.Id = PalabraOriginal.Id)
            If IsNothing(PalabraTraducida) Then
                PalabraTraducida = New Estructura.PalabraTraducida(Nothing, PalabraOriginal, "")
                Me._Obj.PalabrasTraducidas.Add(PalabraTraducida)
            End If
            Me.DataGridViewTraducciones.Rows.Add({PalabraOriginal, PalabraTraducida})
            Me.DataGridViewTraducciones.Rows(Me.DataGridViewTraducciones.Rows.Count - 1).Tag = PalabraTraducida
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Me._Obj.Nombre = Me.TextBoxNombre.Text
            BLL.IdiomaLogica.Validar(Me._Obj)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If Alertador.Alertar("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DataGridViewTraducciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewTraducciones.CellEndEdit
        Dim DataGrid As DataGridView = sender
        Dim PalabraTraducida As Estructura.PalabraTraducida = DataGrid.Rows(e.RowIndex).Tag
        PalabraTraducida.CadenaTraducida = DataGrid.Rows(e.RowIndex).Cells(1).Value.ToString
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub

End Class
