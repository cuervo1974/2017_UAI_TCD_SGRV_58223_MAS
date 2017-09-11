Imports System.Configuration

Public Class SMTPBuilder

    Public Shared Function Crear() As Net.Mail.SmtpClient

        Dim Credentials As New System.Net.NetworkCredential
        Dim SMTP As New Net.Mail.SmtpClient

        With Credentials
            .UserName = ConfigurationManager.AppSettings("smtp_username")
            .Password = ConfigurationManager.AppSettings("smtp_password")
        End With

        With SMTP
            .Host = ConfigurationManager.AppSettings("smtp_host")
            .Port = ConfigurationManager.AppSettings("smtp_port")
            .EnableSsl = True
            .Credentials = Credentials
        End With

        Return SMTP

    End Function

End Class
