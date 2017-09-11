Public Class FormaPagoLogica

    Private _Datos As New DAL.FormaPagoDatos

    Public Function ConsultarTodos() As List(Of Estructura.FormaPago)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.FormaPago)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó la Forma de Pago #{0}", pObj.Nombre))
    End Sub

    Public Sub Eliminar(pObj As Estructura.FormaPago)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó la Forma de Pago #{0}", pObj.Nombre))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.FormaPago)
        If pObj.Nombre = "" Then Throw New Exception("La Forma de Pago debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre de la Forma de Pago es demasiado largo.")
        If String.IsNullOrEmpty(pObj.RecargoTipo) Then Throw New Exception("La Forma de Pago debe tener un tipo.")
        Select Case pObj.RecargoTipo
            Case "P"
                If Not (pObj.RecargoValor > 0 And pObj.RecargoValor <= 100) Then Throw New Exception("La Forma de Pago debe tener un valor de recargo entre 1 y 100.")
            Case "V"
                If Not pObj.RecargoValor >= 0 Then Throw New Exception("La Forma de Pago debe tener un valor de recargo mayor o igual a 0.")
            Case Else
                Throw New Exception("La Forma de Pago debe tener un tipo de recargo válido")
        End Select
    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.FormaPago)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
