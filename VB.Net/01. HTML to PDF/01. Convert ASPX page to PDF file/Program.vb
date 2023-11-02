Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertAspxToPdfFile()
		End Sub
		Public Shared Sub ConvertAspxToPdfFile()
			Dim inpFile As String = "https://sautinsoft.net/default.aspx"
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
