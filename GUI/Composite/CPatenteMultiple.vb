Public Class CPatenteMultiple
    Inherits CPatente

    Private _Opciones As New List(Of CPatente)
    Public Property Opciones() As List(Of CPatente)
        Get
            Return _Opciones
        End Get
        Set(ByVal value As List(Of CPatente))
            _Opciones = value
        End Set
    End Property

    Public Sub New(pPatente As Estructura.Patente)
        MyBase.New(pPatente)
    End Sub

    Public Overrides Sub Mostrar(ByRef ToolStripItemCollection As ToolStripItemCollection)

        Dim ItemNuevo As New ToolStripMenuItem

        If Not IsNothing(Me.Patente) Then
            ItemNuevo = New ToolStripMenuItem(Me.Patente.Nombre)
            ItemNuevo.Image = My.Resources.ResourceManager.GetObject(Me.Patente.Imagen)
            ToolStripItemCollection.Add(ItemNuevo)
            ItemNuevo.Tag = Me.Patente
        End If

        For Each Subitem As CPatente In _Opciones
            If IsNothing(Me.Patente) Then
                Subitem.Mostrar(ToolStripItemCollection)
            Else
                Subitem.Mostrar(ItemNuevo.DropDownItems)
            End If
        Next

    End Sub

    Public Overrides Sub Mostrar(ByRef TreeNodeCollection As TreeNodeCollection)

        Dim NodoNuevo As New TreeNode

        If Not IsNothing(Me.Patente) Then
            NodoNuevo = TreeNodeCollection.Add(Me.Patente.Nombre)
            NodoNuevo.Tag = Me.Patente
        End If

        For Each SubItem As CPatente In _Opciones
            If IsNothing(Me.Patente) Then
                SubItem.Mostrar(TreeNodeCollection)
            Else
                SubItem.Mostrar(NodoNuevo.Nodes)
            End If
        Next

    End Sub

End Class
