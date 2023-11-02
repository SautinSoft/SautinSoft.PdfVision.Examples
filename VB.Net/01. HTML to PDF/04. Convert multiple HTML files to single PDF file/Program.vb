Imports System
Imports System.IO
Imports System.Collections.Generic
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertMultipleHtmlToPdfFile()
		End Sub
		Public Shared Sub ConvertMultipleHtmlToPdfFile()
			Dim inpFiles() As String = {Path.GetFullPath("..\..\..\1.html"), Path.GetFullPath("..\..\..\2.html")}
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			Dim v As New PdfVision()
			
			Dim options As New HtmlToPdfOptions() With {
				.PageSetup = New PageSetup() With {
					.PaperType = PaperType.Letter,
					.Orientation = Orientation.Portrait,
					.PageMargins = New PageMargins() With {
						.Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
					}
				},
				.PrintBackground = True,
				.Scale = 1,
				.ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\")
			}

			Try
				Dim pdfCollection As New List(Of Byte())()
				For Each inpFile As String In inpFiles
					Console.WriteLine($"Converting {Path.GetFileName(inpFile)} ...")
					Dim pdfData() As Byte = v.ConvertHtmlToPdf(inpFile, options)
					pdfCollection.Add(pdfData)
				Next inpFile

				' Merge PDFs into single PDF document.
				Dim singlePdfData() As Byte = v.MergePdf(pdfCollection)
				File.WriteAllBytes(outFile, singlePdfData)

				' Open the result for demonstration purposes.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
