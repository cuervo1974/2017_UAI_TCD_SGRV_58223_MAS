Public Class FormLogin

    Private _Logica As New BLL.EmpleadoLogica

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '[BORRAR]
        UsernameTextBox.Text = "admin"
        PasswordTextBox.Text = "admin"
        '[/BORRAR]
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Me._Logica.Login(Me.UsernameTextBox.Text, PasswordTextBox.Text)
            Dim FormMain As New FormMain
            FormMain.Show()
            AddHandler FormMain.FormClosed, AddressOf Me.Show
            Me.Hide()
        Catch ex As Exception
            Alertador.Alertar(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'Me.Close()
        Close()
    End Sub

End Class
