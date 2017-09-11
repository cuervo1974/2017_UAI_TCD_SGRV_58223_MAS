Public Class FormFormaPago
    Implements InterfaceObservador

    Private _Obj As Estructura.FormaPago
    Private _RecargoTipo As New Dictionary(Of String, String)

    Sub New(ByRef pObj As Estructura.FormaPago)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._RecargoTipo.Add("P", "Porcentual")
        Me._RecargoTipo.Add("V", "Valor")
        With Me
            .TextBoxNombre.Text = ._Obj.Nombre
            .TextBoxRecargoValor.Text = ._Obj.RecargoValor
        End With
        For Each Word In Me._RecargoTipo
            If Me._Obj.RecargoTipo = Word.Key Then Me.ComboBoxRecargoTipo.Text = Word.Value
            Me.ComboBoxRecargoTipo.Items.Add(Word.Value)
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            With Me
                ._Obj.Nombre = .TextBoxNombre.Text
                ._Obj.RecargoTipo = .ComboBoxRecargoTipo.Text
                ._Obj.RecargoValor = .TextBoxRecargoValor.Text
            End With
            For Each Word In Me._RecargoTipo
                If Me.ComboBoxRecargoTipo.Text = Word.Value Then Me._Obj.RecargoTipo = Word.Key
            Next
            BLL.FormaPagoLogica.Validar(Me._Obj)
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

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub
End Class
