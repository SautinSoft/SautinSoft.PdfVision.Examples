Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ImagePlacement()
		End Sub
		Public Shared Sub ImagePlacement()
			Dim inpFolder As String = (New DirectoryInfo("..\..\..\testing\")).FullName
			Dim outFile As String = (New FileInfo("Horizontal.pdf")).FullName

			Dim v As New PdfVision()
			Dim options As New ImageToPdfOptions()
			options.PageSetup.PaperType = PaperType.Letter
			options.PageSetup.Orientation = Orientation.Landscape
			options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter)
			options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter)

			' Case 1: Place all images in horizontal order,
			' set image size 75 x 75 mm, distance 10 mm between images.
			options.PlaceImagesByHorizontal = True
			options.Width = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter)
			options.Height = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter)
			options.DistanceBetweenImages = LengthUnitConverter.ToPoint(10, LengthUnit.Millimeter)

			Try
				v.ConvertImageToPdf(inpFolder, outFile, options)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try

			' Case 2: Place all images in vertical order,
			' set image size 75 x 75 mm, distance 10 mm between images.
			outFile = (New FileInfo("Vertical.pdf")).FullName
			options.PageSetup.Orientation = Orientation.Portrait
			options.PlaceImagesByHorizontal = False
			options.Width = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter)
			options.Height = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter)
			options.DistanceBetweenImages = LengthUnitConverter.ToPoint(10, LengthUnit.Millimeter)

			Try
				v.ConvertImageToPdf(inpFolder, outFile, options)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
