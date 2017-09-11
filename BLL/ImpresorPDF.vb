Imports System
Imports System.Linq
Imports System.Diagnostics

Public Class ImpresorPDF

    Public Shared Sub Imprimir(pArchivoPDF As String)

        Dim proc As New Process()

        With proc
            .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            .StartInfo.Verb = "print"
            .StartInfo.FileName = Configuration.ConfigurationManager.AppSettings("archivo_adobe_reader")
            .StartInfo.Arguments = String.Format("/p {0}", pArchivoPDF)
            .StartInfo.UseShellExecute = False
            .StartInfo.CreateNoWindow = True
            .Start()
        End With

    End Sub

End Class
