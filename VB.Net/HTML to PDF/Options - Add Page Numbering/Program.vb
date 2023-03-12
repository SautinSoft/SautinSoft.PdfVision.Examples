Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			AddPageNumbering()
		End Sub
		Public Shared Sub AddPageNumbering()
			' Let's convert HTML to PDF and add page numbering in header.
			Dim inpFile As String = File.ReadAllText("..\..\..\example.html")
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			Dim v As New PdfVision()
			' v.Serial = "123456789";
			Dim options As New HtmlToPdfOptions() With {
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
				.Scale = 1D
			}

			' Unpack portable Chromium browser if necessary.
            ' To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
			If Not ChromiumEngine.IsExist(options.ChromiumBaseDirectory) Then
				ChromiumEngine.Unpack(options.ChromiumBaseDirectory)
			End If

			' Let's set page numbering in the page header (we can do the same in footer):
			' P.S. the property 'Footer' works only in licensed version.

			' 1. We've to increase the page margin top to fit page numbering.
			options.PageSetup.PageMargins.Top += LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter)

			' 2. Specify page numbering in header in HTML format.
			' Add attributes class="pageNumber" and class="totalPages" to any HTML tag,
			' after converting this tag will be replaced by the appropriate values.
			Dim headerWithNumbering As String = "<div style=""font-size: 18pt; font-family: Sans-serif;" & "color: #0d6efd; margin: 0px auto;"">" & "Page <span class=""pageNumber""></span> of " & "<span class=""totalPages""></span><div>"

			options.Header = headerWithNumbering

            ' Footer: In case of adding the page footer, don't forget to increase the margin bottom.
            ' Like this:
            'options.PageSetup.PageMargins.Bottom += LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter)


			Try
				' The whole conversion process will be done completely in memory.
				v.ConvertHtmlToPdf(inpFile, outFile, options)

				' Open the result for demonstration purposes.                
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
