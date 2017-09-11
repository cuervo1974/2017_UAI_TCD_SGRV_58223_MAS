Public MustInherit Class CPatente

    Public MustOverride Sub Mostrar(ByRef pToolStripItemCollection As ToolStripItemCollection)
    Public MustOverride Sub Mostrar(ByRef pTreeNodeCollection As TreeNodeCollection)

    Private _Patente As Estructura.Patente
    Public Property Patente() As Estructura.Patente
        Get
            Return _Patente
        End Get
        Set(ByVal value As Estructura.Patente)
            _Patente = value
        End Set
    End Property

    Public Sub New(pPatente As Estructura.Patente)
        With Me
            .Patente = pPatente
        End With
    End Sub

    Public Shared Sub RellenarCPatentes(pCPatenteMultiple As CPatenteMultiple, pPatentes As List(Of Estructura.Patente), Optional pItemClickHandler As EventHandler = Nothing)
        Dim CPatente As CPatente
        For Each Patente As Estructura.Patente In pPatentes
            If IsNothing(Patente.Hijos) Then
                CPatente = New CPatenteSimple(Patente, pItemClickHandler)
            Else
                CPatente = New CPatenteMultiple(Patente)
                CPatente.RellenarCPatentes(CPatente, Patente.Hijos, pItemClickHandler)
            End If
            pCPatenteMultiple.Opciones.Add(CPatente)
        Next
    End Sub

End Class
