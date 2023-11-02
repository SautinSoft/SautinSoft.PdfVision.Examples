Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertHtmlToPdfInMemory()
		End Sub
		Public Shared Sub ConvertHtmlToPdfInMemory()
			' This string will contains HTML string with the local image.
			Dim inpHtml As String = "<html>" & vbCrLf & "<body>" & vbCrLf & "<p> Hello </p>" & vbCrLf & "<p><img src=""sautinsoft.png""/></p>" & vbCrLf & "<p>Bye </p>" & vbCrLf & "</body>" & vbCrLf & "</html>"
			Dim pdfBytes() As Byte = Nothing

			Dim v As New PdfVision()
			

			' The baseURL property specifies Or retrieves the base URL used for
			' relative path resolution with URL script commands that are embedded in media items.
			' Website - http://example.com/ Or http://example.com/contact
			' LocalPath - C:/example/ Or C:/example/contact

			Dim options As New HtmlToPdfOptions() With {
				.BaseUrl = "https://sautinsoft.com/images/",
				.PageSetup = New PageSetup() With {
					.PaperType = PaperType.Letter,
					.Orientation = Orientation.Landscape,
					.PageMargins = New PageMargins() With {
						.Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
					}
				},
				.PrintBackground = True,
				.Scale = 0.7D,
				.ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\")
			}

			Try
				' The whole conversion process will be done completely in memory.
				pdfBytes = v.ConvertHtmlToPdf(inpHtml, options)

				' This file is necessary only to show the result.
				Dim outFile As String = (New FileInfo("Result.pdf")).FullName
				' Save pdfBytes to the file and open the result for demonstration purposes.
				File.WriteAllBytes(outFile, pdfBytes)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
