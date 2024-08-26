Imports System
Imports System.IO
Imports SautinSoft.PdfVision
Imports System.Drawing

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			PageSetupAndNumbering()
		End Sub
		Public Shared Sub PageSetupAndNumbering()
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
			options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(10F, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Right = LengthUnitConverter.ToPoint(10F, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Bottom = LengthUnitConverter.ToPoint(10F, LengthUnit.Millimeter)
			options.PageNumbering.PageNumbersInTop = "Page {page} of {numpages}"
			options.PageNumbering.FontFamily = PdfStandardFonts.HelveticaBold
			options.PageNumbering.FontSize = 18
			options.PageNumbering.Aligment = HorizontalAlignment.Left

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
