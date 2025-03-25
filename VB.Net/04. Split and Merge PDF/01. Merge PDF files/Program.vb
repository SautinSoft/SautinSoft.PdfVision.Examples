Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			MergePdfInFiles()
		End Sub
		Public Shared Sub MergePdfInFiles()
		' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");
			Dim v As New PdfVision()
			Dim inpFiles() As String = {"..\..\..\simple text.pdf", "..\..\..\table.pdf"}
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			' Merge PDF files into single document.
			Dim ret As Integer = v.MergePdf(inpFiles, outFile)

			' 0 - Merged successfully.
			' 1 - Error, can't merge PDF documents.
			' 2 - Error, can't create the output file, probably it used by another application.
			' 3 - Merging failed.
			' 4 - Merged successfully, but some files were not merged.
			If ret = 0 Then
				' Open the resulting PDF document in a default PDF Viewer.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			End If
		End Sub
	End Class
End Namespace
