Imports System.Security.Cryptography
Imports System.Text

Public Class Hash

    Public Shared Function Encriptar(ByVal pCadena As String) As String

        Dim data As Byte()

        Using md5Hash As MD5 = MD5.Create()
            data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pCadena))
        End Using

        Dim sBuilder As New StringBuilder()

        Dim i As Integer
        For i = 0 To Data.Length - 1
            sBuilder.Append(Data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()

    End Function

End Class
