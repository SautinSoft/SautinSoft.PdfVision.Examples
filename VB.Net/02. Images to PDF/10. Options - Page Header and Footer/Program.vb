Imports System
Imports System.IO
Imports SautinSoft.PdfVision
Imports System.Drawing

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			PageHeaderAndFooter()
		End Sub
		Public Shared Sub PageHeaderAndFooter()
			Dim inpFile As String = Path.GetFullPath("..\..\..\image-png.png")
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");

			Dim v As New PdfVision()

			Dim options As New ImageToPdfOptions()
			options.PageSetup.PaperType = PaperType.A3
			options.PageSetup.Orientation = Orientation.Landscape
			options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(10F, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(20F, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Right = LengthUnitConverter.ToPoint(10F, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Bottom = LengthUnitConverter.ToPoint(30F, LengthUnit.Millimeter)

			' You can add any single-line text into top and bottom of the pages using these properties:
			options.PageNumbering.PageNumbersInTop = "This is a simple document Header!"
			options.PageNumbering.Aligment = HorizontalAlignment.Left
			options.PageNumbering.FontFamily = PdfStandardFonts.HelveticaOblique
			options.PageNumbering.FontSize = 28
			options.PageNumbering.FontColor = Color.OrangeRed

			Try
				v.ConvertImageToPdf(New String() {inpFile}, outFile, options)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
