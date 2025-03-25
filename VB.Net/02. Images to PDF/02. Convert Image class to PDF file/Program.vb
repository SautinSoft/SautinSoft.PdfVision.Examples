Imports System
Imports System.IO
Imports SautinSoft.PdfVision
Imports System.Diagnostics

Namespace Sample
    Friend Class Program
        Shared Sub Main(args As String())
            ConvertSystemDrawingToPdf()
        End Sub

        Public Shared Sub ConvertSystemDrawingToPdf()
            Dim image As Byte() = File.ReadAllBytes("..\..\..\..\image-jpeg.jpg")

            Dim outFile As String = New FileInfo("Result.pdf").FullName
            ' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/

            ' Apply the key here:
            ' SautinSoft.PdfVision.SetLicense("...")

            Dim v As New PdfVision()
            Dim options As New ImageToPdfOptions()
            options.PageSetup.PaperType = PaperType.Auto

            Dim pdfDocument As Byte() = v.ConvertImageToPdf(image, options)
            File.WriteAllBytes(outFile, pdfDocument)
            Process.Start(New ProcessStartInfo(outFile) With {.UseShellExecute = True})
        End Sub
    End Class
End Namespace
