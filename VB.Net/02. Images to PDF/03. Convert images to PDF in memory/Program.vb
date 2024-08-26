Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertImagesToPdfInMemory()
		End Sub
		Public Shared Sub ConvertImagesToPdfInMemory()
			' We'll use files here only to get input data and show the PDF result.
			' The converting process will be done completely in memory.
			Dim inpFiles() As String = {
				"..\..\..\testing\image-jpeg.jpg",
				"..\..\..\testing\image-png.png",
				"..\..\..\testing\image-tiff.tiff",
				"..\..\..\testing\multipage.tiff"}

			Dim outFile As String = (New FileInfo("Result.pdf")).FullName
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");

			Dim v As New PdfVision()
			Dim options As New ImageToPdfOptions()
			options.PageSetup.PaperType = PaperType.Letter

			Dim imageBytesCollection As New List(Of Byte())()
			For Each inpFile As String In inpFiles
				imageBytesCollection.Add(File.ReadAllBytes(inpFile))
			Next inpFile

			Try
				Dim pdfDocument() As Byte = v.ConvertImageToPdf(imageBytesCollection, options)
				File.WriteAllBytes(outFile, pdfDocument)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
