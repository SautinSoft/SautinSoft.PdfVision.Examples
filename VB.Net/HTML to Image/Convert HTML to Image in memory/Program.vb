Imports System
Imports System.IO
Imports System.IO.Compression
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertHtmlToJpegInMemory()
		End Sub
		Public Shared Sub ConvertHtmlToJpegInMemory()
			' This string will contains our input HTML document.
			Dim inpFile As String = Path.GetFullPath("..\..\..\example.html")
			Dim inpHtml As String = File.ReadAllText(inpFile)
			Dim imgBytes() As Byte = Nothing

			Dim v As New PdfVision()
			' v.Serial = "123456789";
			Dim options As New ScreenshotOptions() With {
				.FullPage = False,
				.ViewPortOptions = New ViewPortOptions() With {
					.Width = 800,
					.Height = 600
				},
				.Type = ScreenshotType.Jpeg,
				.Quality = 90,
				.BaseUrl = Path.GetDirectoryName(inpFile)
			}

			' The baseURL property specifies Or retrieves the base URL used for
			' relative path resolution with URL script commands that are embedded in media items.
			' Website - http://example.com/ Or http://example.com/contact
			' LocalPath - C:/example/ Or C:/example/contact
			' BaseUrl = @"The_Absolute_Path_to_Image"

			Try
				' The whole conversion process will be done completely in memory.
				imgBytes = v.GetScreenshot(inpHtml, options)

				' This file is necessary only to show the result.
				Dim outFile As String = (New FileInfo("Result.jpg")).FullName
				' Save imgBytes to the file and open the result for demonstration purposes.
				File.WriteAllBytes(outFile, imgBytes)
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
