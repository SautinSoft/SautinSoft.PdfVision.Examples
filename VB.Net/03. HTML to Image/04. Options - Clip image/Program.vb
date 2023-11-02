Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ClipImageOptions()
		End Sub
		Public Shared Sub ClipImageOptions()
			' This string will contains our input HTML document.
			Dim inpHtml As String = File.ReadAllText("..\..\..\example.html")
			Dim imgBytes() As Byte = Nothing

			Dim v As New PdfVision()
			
			Dim options As New ScreenshotOptions() With {
				.FullPage = False,
				.ViewPortOptions = New ViewPortOptions() With {
					.Width = 1920,
					.Height = 1080
				},
				.Type = ScreenshotType.Png,
				.ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\"),
				.Clip = New Clip() With {
					.X = 744,
					.Y = 525,
					.Width = 431,
					.Height = 381,
					.Scale = 2
				}
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
