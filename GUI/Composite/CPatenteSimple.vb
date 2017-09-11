Public Class CPatenteSimple
    Inherits CPatente

    Public Event Click(sender As Object, e As EventArgs)
    Private _ItemClickHandler As System.EventHandler

    Public Sub New(pPatente As Estructura.Patente, Optional pItemClickHandler As System.EventHandler = Nothing)
        MyBase.New(pPatente)
        Me._ItemClickHandler = pItemClickHandler
    End Sub

    Public Overrides Sub Mostrar(ByRef ToolStripItemCollection As ToolStripItemCollection)
        Dim ItemNuevo As ToolStripItem = ToolStripItemCollection.Add(Me.Patente.Nombre)
        ItemNuevo.Image = My.Resources.ResourceManager.GetObject(Me.Patente.Imagen)
        ItemNuevo.Tag = Me.Patente
        If Not IsNothing(Me._ItemClickHandler) Then AddHandler ItemNuevo.Click, _ItemClickHandler
    End Sub

    Public Overrides Sub Mostrar(ByRef TreeNodeCollection As TreeNodeCollection)
        Dim NodoNuevo As TreeNode = TreeNodeCollection.Add(Me.Patente.Nombre)
        NodoNuevo.Tag = Me.Patente
    End Sub

End Class
