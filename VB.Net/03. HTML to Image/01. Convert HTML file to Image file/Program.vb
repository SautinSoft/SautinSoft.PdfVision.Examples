Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ConvertHtmlFileToPngFile()
		End Sub
		Public Shared Sub ConvertHtmlFileToPngFile()
			Dim inpFile As String = Path.GetFullPath("..\..\..\Sample.html")
			Dim outFile As String = (New FileInfo("Result.png")).FullName

			Dim v As New PdfVision()
			
			Dim options As New ScreenshotOptions() With {
				.Type = ScreenshotType.Png,
				.ViewPortOptions = New ViewPortOptions() With {
					.Width = 800,
					.Height = 600
				},
				.FullPage = False,
				.ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\")
			}

			Try
				v.GetScreenshot(inpFile, outFile, options)
				' Open the result for demonstration purposes.
				System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
			Catch ex As Exception
				Console.WriteLine($"Error: {ex.Message}")
				Console.ReadLine()
			End Try
		End Sub
	End Class
End Namespace
