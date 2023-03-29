Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			ProductActivation()
		End Sub
		Public Shared Sub ProductActivation()
			Dim v As New PdfVision()

			' Place your serial(s) number.
			' You will get own serial number(s) after purchasing the license.
			' If you will have any questions, email us at sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.
			v.Serial = "123456789"

			Dim inpFile As String = "https://sautinsoft.com/"
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName

			Dim options As New HtmlToPdfOptions()

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
