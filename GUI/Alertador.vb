Public Class Alertador

    Private Shared _IdiomaViejo As Estructura.Idioma = New Estructura.Idioma(Nothing, "Español", True)
    Private Shared _IdiomaNuevo As Estructura.Idioma = New Estructura.Idioma(Nothing, "Español", True)

    Public Shared Sub Alertar(pMensaje As String)
        ServicioTraduccion.Traducir(pMensaje, _IdiomaNuevo, _IdiomaViejo)
        MessageBox.Show(pMensaje)
    End Sub

    Public Shared Function Alertar(pMensaje As String, pTitulo As String, pBotones As System.Windows.Forms.MessageBoxButtons) As DialogResult
        ServicioTraduccion.Traducir(pMensaje, _IdiomaNuevo, _IdiomaViejo)
        ServicioTraduccion.Traducir(pTitulo, _IdiomaNuevo, _IdiomaViejo)
        Return MessageBox.Show(pMensaje, pTitulo, pBotones)
    End Function

    Public Shared Function Alertar(pMensaje As String, pTitulo As String, pBotones As System.Windows.Forms.MessageBoxButtons, pIcono As System.Windows.Forms.MessageBoxIcon) As DialogResult
        ServicioTraduccion.Traducir(pMensaje, _IdiomaNuevo, _IdiomaViejo)
        ServicioTraduccion.Traducir(pTitulo, _IdiomaNuevo, _IdiomaViejo)
        Return MessageBox.Show(pMensaje, pTitulo, pBotones, pIcono)
    End Function

    Public Shared Sub ActualizarIdiomas(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma)
        _IdiomaNuevo = pIdiomaNuevo
        _IdiomaViejo = pIdiomaViejo
    End Sub

End Class
