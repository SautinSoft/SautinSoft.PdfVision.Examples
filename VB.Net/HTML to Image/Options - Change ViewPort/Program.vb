Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ChangeViewportOptions()
		End Sub
		Public Shared Sub ChangeViewportOptions()
			' This string will contains our input HTML document.
			Dim inpHtml As String = File.ReadAllText("..\..\..\example.html")
			Dim imgBytes() As Byte = Nothing

			Dim v As New PdfVision()
			' v.Serial = "123456789";
			Dim options As New ScreenshotOptions() With {
				.FullPage = True,
				.ViewPortOptions = New ViewPortOptions() With {
					.Width = 2560,
					.Height = 1920
				},
				.Type = ScreenshotType.Png,
				.ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\")
			}

			Try
				' The whole conversion process will be done completely in memory.
				imgBytes = v.GetScreenshot(inpHtml, options)

				' This file is necessary only to show the result.
				Dim outFile As String = (New FileInfo("Result.png")).FullName
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
