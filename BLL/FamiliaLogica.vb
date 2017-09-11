Public Class FamiliaLogica

    Private _Datos As New DAL.FamiliaDatos

    Public Function ConsultarTodos() As List(Of Estructura.Familia)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Familia)
        Me._Datos.Guardar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Guardó la Familia #{0}", pObj.Nombre))
    End Sub

    Public Sub Eliminar(pObj As Estructura.Familia)
        Me._Datos.Eliminar(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Eliminó la Familia #{0}", pObj.Nombre))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Familia)
        If pObj.Nombre = "" Then Throw New Exception("La Familia debe tener nombre.")
        If pObj.Nombre.Length > 50 Then Throw New Exception("El nombre de la Familia es demasiado largo.")
    End Sub

    Private Function TieneAcceso(pObj As Estructura.Familia, pPatente As Estructura.Patente) As Boolean
        For Each Patente As Estructura.Patente In pObj.Patentes
            If Patente.Id = pPatente.Id Then Return True
        Next
        Return False
    End Function

    Public Function ConsultarPatentes(pObj As Estructura.Familia) As List(Of Estructura.Patente)
        Dim PatenteLogica As New BLL.PatenteLogica
        Dim Patentes As List(Of Estructura.Patente) = PatenteLogica.ConsultarTodos
        Dim PatentesAux As New List(Of Estructura.Patente)
        For Each Patente As Estructura.Patente In Patentes
            If TieneAcceso(pObj, Patente) Then
                PatentesAux.Add(Me.ConsultarPatente(pObj, Patente))
            End If
        Next
        Return PatentesAux
    End Function

    Private Function ConsultarPatente(pObj As Estructura.Familia, pPatente As Estructura.Patente) As Estructura.Patente
        Dim PatentesAux As New List(Of Estructura.Patente)
        If Not IsNothing(pPatente.Hijos) Then
            For Each Patente As Estructura.Patente In pPatente.Hijos
                If TieneAcceso(pObj, Patente) Then
                    PatentesAux.Add(Me.ConsultarPatente(pObj, Patente))
                End If
            Next
            pPatente.Hijos = PatentesAux
        End If
        Return pPatente
    End Function

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Familia)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
