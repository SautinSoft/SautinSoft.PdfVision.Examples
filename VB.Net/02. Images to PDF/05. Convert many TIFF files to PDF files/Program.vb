Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertTiffFilesToPdfFiles()
		End Sub
		Public Shared Sub ConvertTiffFilesToPdfFiles()
		' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");
			Dim v As New PdfVision()
			Dim inpFiles() As String = Directory.GetFiles("..\..\..\", "*.tif*")
			Try
				For Each inpFile As String In inpFiles
					Dim pdfName As String = Path.GetFileNameWithoutExtension(inpFile) & ".pdf"
					Dim outFile As String = (New FileInfo(pdfName)).FullName
					v.ConvertImageToPdf(New String() { inpFile }, outFile)
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
				Next inpFile
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
