Imports System.Data
Imports System.Text
Imports System.Collections

Public Class DigitoVerificador

    Public Shared Function CalcularDV(pItems As ArrayList) As Integer
        Dim Sum As Integer
        For Each Item In pItems
            Dim Bytes() As Byte = Encoding.ASCII.GetBytes(Item)
            For Each Bt As Byte In Bytes
                Sum += Bt
            Next
        Next
        Return Sum
    End Function

    Public Shared Function CalcularDV(pDataRows As DataRowCollection) As String
        Dim Sum As Integer
        For Each DR As DataRow In pDataRows
            Sum += IIf(TypeOf (DR.Item("digito_verificador")) Is System.DBNull, 0, DR.Item("digito_verificador"))
        Next
        Return Hash.Encriptar(Sum)
    End Function

End Class
