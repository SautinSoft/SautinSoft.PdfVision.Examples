Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			MergePdfInMemory()
		End Sub
		Public Shared Sub MergePdfInMemory()
		' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");
			Dim v As New PdfVision()
			' The whole merge process will be done in memory.
			' We're using files only to get input data and show the result.
			Dim inpFiles() As String = {"..\..\..\simple text.pdf", "..\..\..\table.pdf"}
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			' Get bytes from input pdf documents.
			Dim mergingPdf As New List(Of Byte())()
			For Each inpFile As String In inpFiles
				mergingPdf.Add(File.ReadAllBytes(inpFile))
			Next inpFile

			' Merge PDF documents in memory into single document.
			Dim singlePdf() As Byte = v.MergePdf(mergingPdf)

			If singlePdf IsNot Nothing Then
				File.WriteAllBytes(outFile, singlePdf)
				' Open the resulting PDF document in a default PDF Viewer.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			End If
		End Sub
	End Class
End Namespace
