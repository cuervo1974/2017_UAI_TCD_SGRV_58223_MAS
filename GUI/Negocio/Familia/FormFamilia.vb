Imports System.Windows.Forms

Public Class FormFamilia
    Implements InterfaceObservador

    Private _Obj As Estructura.Familia
    Private _Logica As New BLL.PatenteLogica

    Sub New(ByRef pObj As Estructura.Familia)
        InitializeComponent()
        Me._Obj = pObj
    End Sub

    Private Sub Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Patentes As New CPatenteMultiple(Nothing)
        CPatente.RellenarCPatentes(Patentes, Me._Logica.ConsultarTodos)
        Patentes.Mostrar(Me.TreeViewPatentes.Nodes)
        Me.TextBoxNombre.Text = Me._Obj.Nombre
        Me.TildarNodos(Me.TreeViewPatentes.Nodes)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Me._Obj.Nombre = Me.TextBoxNombre.Text
            Me._Obj.Patentes.Clear()
            Me.AgregarPatentesSeleccionadas(Me.TreeViewPatentes.Nodes)
            BLL.FamiliaLogica.Validar(Me._Obj)
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

    Private Sub TildarNodos(ByRef Nodos As TreeNodeCollection)
        For Each Nodo As TreeNode In Nodos
            For Each Patente As Estructura.Patente In Me._Obj.Patentes
                If Patente.Id = DirectCast(Nodo.Tag, Estructura.Patente).Id Then
                    Nodo.Checked = True
                End If
            Next
            If Nodo.Nodes.Count > 0 Then Me.TildarNodos(Nodo.Nodes)
        Next
    End Sub

    Private Sub AgregarPatentesSeleccionadas(Nodes As TreeNodeCollection)
        For Each Node As TreeNode In Nodes
            If Node.Checked Then
                Me._Obj.Patentes.Add(Node.Tag)
            End If
            If Node.Nodes.Count > 0 Then
                AgregarPatentesSeleccionadas(Node.Nodes)
            End If
        Next
    End Sub

    Public Sub Actualizar(pIdiomaNuevo As Estructura.Idioma, pIdiomaViejo As Estructura.Idioma) Implements InterfaceObservador.Actualizar
        ServicioTraduccion.Traducir(Me, pIdiomaNuevo, pIdiomaViejo)
    End Sub
End Class
