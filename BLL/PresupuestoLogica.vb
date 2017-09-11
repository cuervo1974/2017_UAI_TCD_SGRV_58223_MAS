Imports System.Configuration
Imports System.Diagnostics

Public Class PresupuestoLogica

    Private _Datos As New DAL.PresupuestoDatos

    Public Function ConsultarTodos() As List(Of Estructura.Presupuesto)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Presupuesto)
        If pObj.FechaCreado = Nothing Then pObj.FechaCreado = Date.Now
        pObj.FechaVencimiento = pObj.FechaCreado.AddDays(15)
        Me._Datos.Guardar(pObj)
        Me.CrearPDF(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Creó el Presupuesto #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Presupuesto)
        If IsNothing(pObj.Cliente) Then Throw New Exception("El Presupuesto debe tener un Cliente.")
        If IsNothing(pObj.Empleado) Then Throw New Exception("El Presupuesto debe tener un Empleado.")
        If IsNothing(pObj.FormaPago) Then Throw New Exception("El Presupuesto debe tener una Forma de Pago.")
        If pObj.PresupuestoDetalle.Count = 0 Then Throw New Exception("El Presupuesto debe tener uno o más Productos.")
        For Each PresupuestoDetalle As Estructura.PresupuestoDetalle In pObj.PresupuestoDetalle
            If Not (PresupuestoDetalle.Cantidad > 0 And PresupuestoDetalle.Cantidad < 1000) Then Throw New Exception("El Producto debe tener una cantidad.")
            If PresupuestoDetalle.Descuento > 15 Then Throw New Exception("El Producto no puede tener más de un 15% de descuento.")
        Next
    End Sub

    Private Sub CrearPDF(pObj As Estructura.Presupuesto)
        Dim PDFBuilder As New PresupuestoPDFBuilder(GetRutaArchivoPDF(pObj, True))
        PDFBuilder.SetEmpresa("S.G.R.V.")
        PDFBuilder.SetEslogan("Sistema de Gestion y Reporte de Ventas")
        PDFBuilder.SetNumero(pObj.Id)
        PDFBuilder.SetFecha(pObj.FechaCreado)
        PDFBuilder.SetVencimiento(pObj.FechaVencimiento)
        PDFBuilder.SetNombreEmpleado(pObj.Empleado.ToString)
        For Each Detalle As Estructura.PresupuestoDetalle In pObj.PresupuestoDetalle
            PDFBuilder.AgregarDetalleComplejo(Detalle.Producto.Id, Detalle.Producto.Nombre, Detalle.Cantidad, Detalle.PrecioDescuento, Detalle.Total)
        Next
        If (pObj.CostoFormaPago > 0) Then PDFBuilder.AgregarDetalleSimple("Forma de Pago", pObj.CostoFormaPago)
        PDFBuilder.AgregarDetalleSimple("Total", pObj.Total)
        PDFBuilder.Crear()
    End Sub

    Private Function GetRutaArchivoPDF(pObj As Estructura.Presupuesto, Optional pDir As Boolean = False) As String
        If pDir Then
            Return ConfigurationManager.AppSettings("directorio_presupuestos")
        Else
            Return String.Format("{0}\{1}.pdf", ConfigurationManager.AppSettings("directorio_presupuestos"), pObj.Id)
        End If
    End Function

    Public Sub Abrir(pObj As Estructura.Presupuesto)
        System.Diagnostics.Process.Start(GetRutaArchivoPDF(pObj))
    End Sub

    Public Sub Anular(pObj As Estructura.Presupuesto)
        Me._Datos.Anular(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Anuló el Presupuesto #{0}", pObj.Id))
    End Sub

    Public Sub Imprimir(pObj As Estructura.Presupuesto)
        ImpresorPDF.Imprimir(GetRutaArchivoPDF(pObj))
        EventoBitacoraLogica.RegistrarEvento(String.Format("Imprimió el Presupuesto #{0}", pObj.Id))
    End Sub

    Public Sub Enviar(pObj As Estructura.Presupuesto)

        If Not ServicioValidacion.IsEmail(pObj.Cliente.Email) Then Throw New Exception("Imposible enviar el E-Mail, el cliente no tiene una direccion válida.")

        Dim SMTP As Net.Mail.SmtpClient = SMTPBuilder.Crear()
        Dim Mail As New Net.Mail.MailMessage

        With Mail
            .From = New Net.Mail.MailAddress(ConfigurationManager.AppSettings("smtp_username"), ConfigurationManager.AppSettings("smtp_from_name"), System.Text.Encoding.UTF8)
            .To.Add(pObj.Cliente.Email)
            .Subject = String.Format("Presupuesto #{0}", pObj.Id)
            .Body = "A continuación se adjunta el Presupuesto conformado."
            .Attachments.Add(New Net.Mail.Attachment(Me.GetRutaArchivoPDF(pObj)))
        End With

        'SMTP.Send(Mail)
        System.Threading.Thread.Sleep(2500)

        EventoBitacoraLogica.RegistrarEvento(String.Format("Envió el Presupuesto #{0}", pObj.Id))

    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Presupuesto)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
