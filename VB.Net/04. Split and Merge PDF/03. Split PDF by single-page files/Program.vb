Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SplitPdfDocument()
		End Sub
		Public Shared Sub SplitPdfDocument()
		' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");
			Dim v As New PdfVision()

			Dim inpFile As String = "..\..\..\simple text.pdf"
			Dim outFolder As New DirectoryInfo("Pages")

			If Not outFolder.Exists Then
				outFolder.Create()
			End If

			Dim ret As Integer = v.SplitPdf(inpFile, outFolder.FullName)

			' 0 - Split successfully.
			' 1 - Error, can't open input file.
			' 2 - Error, output directory doesn't exist.
			If ret = 0 Then
				System.Console.WriteLine("Split successfully!")
				' Open the resulting folder with the PDF pages.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFolder.FullName) With {.UseShellExecute = True})
			End If
		End Sub
	End Class
End Namespace
