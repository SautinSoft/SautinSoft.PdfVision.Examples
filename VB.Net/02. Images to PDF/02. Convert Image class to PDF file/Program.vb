Imports System
Imports System.IO
Imports SautinSoft.PdfVision
Imports System.Drawing

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertSystemDrawingToPdf()
		End Sub
		Public Shared Sub ConvertSystemDrawingToPdf()
			Dim image As System.Drawing.Image = System.Drawing.Image.FromFile("..\..\..\image-jpeg.jpg")
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			Dim v As New PdfVision()
			Dim options As New ImageToPdfOptions()
			options.PageSetup.PaperType = PaperType.Auto


			Dim imgBytes() As Byte = Nothing

			Using ms As MemoryStream = New System.IO.MemoryStream()
				image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
				imgBytes = ms.ToArray()
			End Using

			Try
				v.ConvertImageToPdf(imgBytes, outFile, options)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
