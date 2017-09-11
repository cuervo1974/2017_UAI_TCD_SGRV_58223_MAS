Public Class ServicioTraduccion

#Region "Contenedores"
    Public Shared Sub Traducir(ByRef pForm As Form, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        Traducir(pForm.Text, pIdiomaNuevo, pIdiomaViejo)
        For Each Control As Control In pForm.Controls
            Traducir(Control, pIdiomaNuevo, pIdiomaViejo)
        Next
    End Sub

    Public Shared Sub Traducir(ByRef pPanel As Panel, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        For Each Control As Control In pPanel.Controls
            Traducir(Control, pIdiomaNuevo, pIdiomaViejo)
        Next
    End Sub

    Public Shared Sub Traducir(ByRef pTableLayout As TableLayoutPanel, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        For Each Control As Control In pTableLayout.Controls
            Traducir(Control, pIdiomaNuevo, pIdiomaViejo)
        Next
    End Sub

#End Region

#Region "Controles"
    Public Shared Sub Traducir(ByRef pControl As Control, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        If TypeOf (pControl) Is MenuStrip Then Traducir(DirectCast(pControl, MenuStrip), pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is ToolStrip Then Traducir(DirectCast(pControl, ToolStrip), pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is BotoneraFiltrador Then Traducir(DirectCast(pControl, BotoneraFiltrador), pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is Button Then Traducir(DirectCast(pControl, Button).Text, pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is Panel Then Traducir(DirectCast(pControl, Panel), pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is TableLayoutPanel Then Traducir(DirectCast(pControl, TableLayoutPanel), pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is Label Then Traducir(DirectCast(pControl, Label).Text, pIdiomaNuevo, pIdiomaViejo)
        If TypeOf (pControl) Is DataGridView Then Traducir(DirectCast(pControl, DataGridView), pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Public Shared Sub Traducir(ByRef pMenuStrip As MenuStrip, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        Traducir(pMenuStrip.Items, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Public Shared Sub Traducir(ByRef pToolStrip As ToolStrip, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        Traducir(pToolStrip.Items, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Public Shared Sub Traducir(ByRef pBotoneraFiltrador As BotoneraFiltrador, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        Traducir(pBotoneraFiltrador.ToolStrip, pIdiomaNuevo, pIdiomaViejo)
    End Sub

    Public Shared Sub Traducir(ByRef pToolStripItemCollection As ToolStripItemCollection, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        For Each ToolStripItem As ToolStripItem In pToolStripItemCollection
            If TypeOf (ToolStripItem) Is ToolStripMenuItem Then
                Traducir(ToolStripItem.Text, pIdiomaNuevo, pIdiomaViejo)
                If DirectCast(ToolStripItem, ToolStripMenuItem).DropDownItems.Count > 0 Then
                    Traducir(DirectCast(ToolStripItem, ToolStripMenuItem).DropDownItems, pIdiomaNuevo, pIdiomaViejo)
                End If
            End If
            If TypeOf (ToolStripItem) Is ToolStripButton Or _
                TypeOf (ToolStripItem) Is ToolStripLabel Then
                Traducir(ToolStripItem.Text, pIdiomaNuevo, pIdiomaViejo)
            End If
        Next
    End Sub

    Public Shared Sub Traducir(ByRef pDataGridView As DataGridView, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)
        For Each DataGridViewColumn As DataGridViewColumn In pDataGridView.Columns
            Traducir(DataGridViewColumn.HeaderText, pIdiomaNuevo, pIdiomaViejo)
        Next
        pDataGridView.AutoResizeColumns()
    End Sub

#End Region

#Region "Strings"
    Public Shared Sub Traducir(ByRef pTexto As String, ByRef pIdiomaNuevo As Estructura.Idioma, ByRef pIdiomaViejo As Estructura.Idioma)

        If pIdiomaNuevo.Nombre = pIdiomaViejo.Nombre Then Exit Sub

        If pIdiomaViejo.Predeterminado Then
            For Each PalabraTraducida As Estructura.PalabraTraducida In pIdiomaNuevo.PalabrasTraducidas
                If PalabraTraducida.Palabra.Cadena = pTexto Then
                    pTexto = PalabraTraducida.CadenaTraducida
                End If
            Next
        ElseIf pIdiomaNuevo.Predeterminado Then
            For Each PalabraTraducida As Estructura.PalabraTraducida In pIdiomaViejo.PalabrasTraducidas
                If PalabraTraducida.CadenaTraducida = pTexto Then
                    pTexto = PalabraTraducida.Palabra.Cadena
                End If
            Next
        Else
            For Each PalabraTraducida As Estructura.PalabraTraducida In pIdiomaViejo.PalabrasTraducidas
                If PalabraTraducida.CadenaTraducida = pTexto Then
                    pTexto = PalabraTraducida.Palabra.Cadena
                End If
            Next
            For Each PalabraTraducida As Estructura.PalabraTraducida In pIdiomaNuevo.PalabrasTraducidas
                If PalabraTraducida.Palabra.Cadena = pTexto Then
                    pTexto = PalabraTraducida.CadenaTraducida
                End If
            Next
        End If

    End Sub
#End Region

End Class
