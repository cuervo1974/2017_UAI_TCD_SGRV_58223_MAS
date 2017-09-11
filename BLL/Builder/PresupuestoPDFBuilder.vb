Imports PdfSharp
Imports MigraDoc.Rendering
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables

Public Class PresupuestoPDFBuilder

    Public Sub Crear()
        Me._Documento.AddSection()
        Me.ComponerCabecera()
        Me.ComponerDetalles()
        Me.ComponerEspacioFirma()
        Me.Guardar()
    End Sub

    Private Sub Guardar()
        Dim NombreArchivo = String.Format("{0}/{1}.pdf", Me._Directorio, Me._Numero)
        MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(Me._Documento, "MigraDoc.mdddl")
        Dim PDFRender As PdfDocumentRenderer = New PdfDocumentRenderer(True, Pdf.PdfFontEmbedding.Always)
        PDFRender.Document = Me._Documento
        PDFRender.RenderDocument()
        If (Not System.IO.Directory.Exists(Me._Directorio)) Then System.IO.Directory.CreateDirectory(Me._Directorio)
        PDFRender.PdfDocument.Save(NombreArchivo)
    End Sub

#Region "Propiedades + Constructor + Setters"

    Private _Documento As New Document
    Private _Directorio As String
    Private _Empresa As String
    Private _Eslogan As String
    Private _Numero As Integer
    Private _Fecha As Date
    Private _Vencimiento As Date
    Private _NombreEmpleado As String
    Private _Detalles As New List(Of Detalle)

    Sub New(pDirectorio As String)
        Me._Directorio = pDirectorio
    End Sub

    Public Sub SetEmpresa(ByVal pEmpresa As String)
        Me._Empresa = pEmpresa
    End Sub

    Public Sub SetEslogan(ByVal pEslogan As String)
        Me._Eslogan = pEslogan
    End Sub

    Public Sub SetNumero(ByVal pNumero As Integer)
        Me._Numero = pNumero
    End Sub

    Public Sub SetFecha(ByVal pFecha As Date)
        Me._Fecha = pFecha
    End Sub

    Public Sub SetVencimiento(ByVal pVencimiento As Date)
        Me._Vencimiento = pVencimiento
    End Sub

    Public Sub SetNombreEmpleado(ByVal pNombreEmpleado As String)
        Me._NombreEmpleado = pNombreEmpleado
    End Sub

    Public Sub AgregarDetalleComplejo(ByVal pCodigo As Integer, ByVal pNombre As String, ByVal pCantidad As Integer, ByVal pPrecio As Double, ByVal pTotal As Double)
        Me._Detalles.Add(New DetalleComplejo(pCodigo, pNombre, pCantidad, pPrecio, pTotal))
    End Sub

    Public Sub AgregarDetalleSimple(ByVal pNombre As String, ByVal pTotal As Double)
        Me._Detalles.Add(New Detalle(pNombre, pTotal))
    End Sub

#End Region

#Region "Builders Internos"

    Private Sub ComponerCabecera()

        Dim Columnas As New Table
        Columnas.AddColumn().Width = Unit.FromCentimeter(10)
        Columnas.AddColumn().Width = Unit.FromCentimeter(6)
        With Columnas.AddRow()
            .BottomPadding = 5
            .Borders.Bottom.Visible = True
            .Borders.Bottom.Width = 1
        End With

        Dim PresupuestoParagraph As New Paragraph
        With PresupuestoParagraph
            .AddText("PRESUPUESTO")
            .Format.Font.Size = 13
        End With
        Columnas.Rows(0).Cells(0).Add(PresupuestoParagraph)
        Dim EmpresaParagraph As New Paragraph
        With EmpresaParagraph
            .AddText(Me._Empresa)
            .Format.Font.Size = 13
        End With
        Columnas.Rows(0).Cells(0).Add(EmpresaParagraph)
        Dim EsloganParagraph As New Paragraph
        With EsloganParagraph
            .AddText(Me._Eslogan)
            .Format.Font.Size = 12
        End With
        Columnas.Rows(0).Cells(0).Add(EsloganParagraph)

        Dim DetallesCabeceraParagraph As New Paragraph
        With DetallesCabeceraParagraph
            .Format.Font.Size = 9
            .AddText(String.Format("Número: #{0}", Me._Numero))
            .AddLineBreak()
            .AddText(String.Format("Fecha: {0}", Me._Fecha.ToShortDateString))
            .AddLineBreak()
            .AddText(String.Format("Vencimiento: {0}", Me._Vencimiento.ToShortDateString))
            .AddLineBreak()
            .AddText(String.Format("Vendedor: {0}", Me._NombreEmpleado))
        End With
        Columnas.Rows(0).Cells(1).Add(DetallesCabeceraParagraph)

        Me._Documento.LastSection.Add(Columnas)

    End Sub

    Private Sub ComponerDetalles()

        Dim Separador As New Paragraph
        Separador.AddLineBreak()
        Me._Documento.LastSection.Add(Separador)

        Dim Tabla As New Table

        Tabla.TopPadding = 3
        Tabla.BottomPadding = 3
        Tabla.LeftPadding = 3
        Tabla.RightPadding = 3

        Tabla.Borders.Width = 0.5
        Tabla.Format.Font.Size = 8

        Tabla.AddColumn(Unit.FromMillimeter(30)).Format.Alignment = ParagraphAlignment.Center
        Tabla.AddColumn(Unit.FromMillimeter(50))
        Tabla.AddColumn(Unit.FromMillimeter(30)).Format.Alignment = ParagraphAlignment.Right
        Tabla.AddColumn(Unit.FromMillimeter(20)).Format.Alignment = ParagraphAlignment.Center
        Tabla.AddColumn(Unit.FromMillimeter(30)).Format.Alignment = ParagraphAlignment.Right

        Dim Cabeceras As Row = Tabla.AddRow()
        Cabeceras.Shading.Color = Colors.LightGray
        Cabeceras.Cells(0).AddParagraph("Código")
        Cabeceras.Cells(1).AddParagraph("Nombre")
        Cabeceras.Cells(2).AddParagraph("Precio")
        Cabeceras.Cells(3).AddParagraph("Cantidad")
        Cabeceras.Cells(4).AddParagraph("Total")

        For Each Detalle As Detalle In Me._Detalles
            Dim NuevaFila As Row = Tabla.AddRow
            If TypeOf (Detalle) Is DetalleComplejo Then
                NuevaFila.Cells(0).AddParagraph(DirectCast(Detalle, DetalleComplejo).Codigo)
                NuevaFila.Cells(1).AddParagraph(Detalle.Nombre)
                NuevaFila.Cells(2).AddParagraph(DirectCast(Detalle, DetalleComplejo).Cantidad)
                NuevaFila.Cells(3).AddParagraph(DirectCast(Detalle, DetalleComplejo).Precio)
            Else
                NuevaFila.Cells(0).MergeRight = 3
                NuevaFila.Cells(0).AddParagraph(Detalle.Nombre).Format.Font.Bold = True
                NuevaFila.Cells(0).Format.Alignment = ParagraphAlignment.Right
            End If
            NuevaFila.Cells(4).AddParagraph(String.Format("$ {0}", Detalle.Total))
        Next
        Me._Documento.LastSection.Add(Tabla)

    End Sub

    Private Sub ComponerEspacioFirma()

        Dim Separador As New Paragraph
        Separador.AddLineBreak()
        Me._Documento.LastSection.Add(Separador)

        Dim Tabla As New Table
        Tabla.TopPadding = 3
        Tabla.BottomPadding = 3
        Tabla.LeftPadding = 3
        Tabla.RightPadding = 3
        Tabla.Borders.Width = 0.5
        Tabla.Format.Font.Size = 5
        Tabla.AddColumn(Unit.FromMillimeter(30)).Format.Alignment = ParagraphAlignment.Center

        With Tabla.AddRow()
            .Shading.Color = Colors.LightGray
            .Cells(0).AddParagraph("Firma del Vendedor")
        End With

        With Tabla.AddRow
            .Height = 20
        End With

        Me._Documento.LastSection.Add(Tabla)

    End Sub

#End Region


End Class
