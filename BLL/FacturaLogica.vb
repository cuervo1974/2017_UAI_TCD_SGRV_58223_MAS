Imports System.Configuration
Imports System.Diagnostics

Public Class FacturaLogica

    Private _Datos As New DAL.FacturaDatos

    Public Function ConsultarTodos() As List(Of Estructura.Factura)
        Return Me._Datos.ConsultarTodos
    End Function

    Public Sub Guardar(pObj As Estructura.Factura)
        If pObj.FechaCreado = Nothing Then pObj.FechaCreado = Date.Now
        Me._Datos.Guardar(pObj)
        Me.CrearPDF(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Creó la Factura #{0}", pObj.Id))
    End Sub

    Public Shared Sub Validar(pObj As Estructura.Factura)
        If pObj.Tipo = "" Then Throw New Exception("La Factura debe tener un Tipo.")
        If Not pObj.Tipo = "A" And Not pObj.Tipo = "B" Then Throw New Exception("La Factura debe ser del Tipo A o B.")
        If pObj.Tipo = "A" And pObj.Cliente.CUIT = "" Then Throw New Exception("Las Facturas de tipo A necesitan un Cliente con CUIT")
        If IsNothing(pObj.Cliente) Then Throw New Exception("La Factura debe tener un Cliente.")
        If IsNothing(pObj.Empleado) Then Throw New Exception("La Factura debe tener un Empleado.")
        If IsNothing(pObj.FormaPago) Then Throw New Exception("La Factura debe tener una Forma de Pago.")
        If pObj.FacturaDetalle.Count = 0 Then Throw New Exception("La Factura debe tener uno o más Productos.")
        For Each FacturaDetalle As Estructura.FacturaDetalle In pObj.FacturaDetalle
            If Not (FacturaDetalle.Cantidad > 0 And FacturaDetalle.Cantidad < 1000) Then Throw New Exception("El Producto debe tener una cantidad.")
            If FacturaDetalle.Descuento > 15 Then Throw New Exception("El Producto no puede tener más de un 15% de descuento.")
        Next
    End Sub

    Private Sub CrearPDF(pObj As Estructura.Factura)
        Dim PDFBuilder As New FacturaPDFBuilder(GetRutaArchivoPDF(pObj, True))
        PDFBuilder.SetEmpresa("S.G.R.V.")
        PDFBuilder.SetEslogan("Sistema de Gestion y Reporte de Ventas")
        PDFBuilder.SetNumero(pObj.Id)
        PDFBuilder.SetFecha(pObj.FechaCreado)
        PDFBuilder.SetNombreCliente(pObj.Cliente.ToString)
        If pObj.Tipo = "A" Then PDFBuilder.SetCUIT(pObj.Cliente.CUIT)
        PDFBuilder.SetTipo(pObj.Tipo)
        For Each Detalle As Estructura.FacturaDetalle In pObj.FacturaDetalle
            If pObj.Tipo = "A" Then
                PDFBuilder.AgregarDetalleComplejo(Detalle.Producto.Id, Detalle.Producto.Nombre, Detalle.Cantidad, Detalle.PrecioDescuento * 0.79, Detalle.Total * 0.79)
            Else
                PDFBuilder.AgregarDetalleComplejo(Detalle.Producto.Id, Detalle.Producto.Nombre, Detalle.Cantidad, Detalle.PrecioDescuento, Detalle.Total)
            End If
        Next
        If pObj.Tipo = "A" Then
            If (pObj.CostoFormaPago > 0) Then PDFBuilder.AgregarDetalleSimple("Forma de Pago", pObj.CostoFormaPago * 0.79)
            PDFBuilder.AgregarDetalleSimple("IVA", pObj.Total * 0.21)
        Else
            If (pObj.CostoFormaPago > 0) Then PDFBuilder.AgregarDetalleSimple("Forma de Pago", pObj.CostoFormaPago)
            PDFBuilder.AgregarDetalleSimple("IVA", pObj.Total)
        End If
        PDFBuilder.AgregarDetalleSimple("Total", pObj.Total)
        PDFBuilder.Crear()
    End Sub

    Private Function GetRutaArchivoPDF(pObj As Estructura.Factura, Optional pDir As Boolean = False)
        If pDir Then
            Return ConfigurationManager.AppSettings("directorio_facturas")
        Else
            Return String.Format("{0}\{1}.pdf", ConfigurationManager.AppSettings("directorio_facturas"), pObj.Id)
        End If
    End Function

    Public Sub Abrir(pObj As Estructura.Factura)
        System.Diagnostics.Process.Start(GetRutaArchivoPDF(pObj))
    End Sub

    Public Sub Anular(pObj As Estructura.Factura)
        Me._Datos.Anular(pObj)
        EventoBitacoraLogica.RegistrarEvento(String.Format("Anuló la Factura #{0}", pObj.Id))
    End Sub

    Public Sub Imprimir(pObj As Estructura.Factura)
        ImpresorPDF.Imprimir(GetRutaArchivoPDF(pObj))
        EventoBitacoraLogica.RegistrarEvento(String.Format("Imprimió la Factura #{0}", pObj.Id))
    End Sub

    Public Sub Enviar(pObj As Estructura.Factura)

        If Not ServicioValidacion.IsEmail(pObj.Cliente.Email) Then Throw New Exception("Imposible enviar el E-Mail, el cliente no tiene una direccion válida.")

        Dim SMTP As Net.Mail.SmtpClient = SMTPBuilder.Crear()
        Dim Mail As New Net.Mail.MailMessage

        With Mail
            .From = New Net.Mail.MailAddress(ConfigurationManager.AppSettings("smtp_username"), ConfigurationManager.AppSettings("smtp_from_name"), System.Text.Encoding.UTF8)
            .To.Add(pObj.Cliente.Email)
            .Subject = String.Format("Factura #{0}", pObj.Id)
            .Body = "A continuación se adjunta la Factura conformada."
            .Attachments.Add(New Net.Mail.Attachment(Me.GetRutaArchivoPDF(pObj)))
        End With

        'SMTP.Send(Mail)
        System.Threading.Thread.Sleep(2500)

        EventoBitacoraLogica.RegistrarEvento(String.Format("Envió la Factura #{0}", pObj.Id))

    End Sub

    Public Function Filtrar(pTexto As String) As List(Of Estructura.Factura)
        Return Me._Datos.Filtrar(pTexto)
    End Function

End Class
