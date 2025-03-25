Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			SetupPageProperties()
		End Sub
		Public Shared Sub SetupPageProperties()
			Dim inpFile As String = Path.GetFullPath("..\..\..\example.html")
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");

			Dim v As New PdfVision()
			

			' Page size: A3 (297 x 420 mm)
			' Orientation: Portrait
			' Margins: Left: 30mm, Top: 15mm, Right: 25mm, Bottom: 15mm.

			Dim options As New HtmlToPdfOptions() With {
				.PageSetup = New PageSetup() With {
					.PaperType = PaperType.A3,
					.Orientation = Orientation.Portrait,
					.PageMargins = New PageMargins() With {
						.Left = LengthUnitConverter.ToPoint(30, LengthUnit.Millimeter),
						.Top = LengthUnitConverter.ToPoint(15, LengthUnit.Millimeter),
						.Right = LengthUnitConverter.ToPoint(25, LengthUnit.Millimeter),
						.Bottom = LengthUnitConverter.ToPoint(15, LengthUnit.Millimeter)
					}
				},
				.PrintBackground = True,
				.Scale = 1D,
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
