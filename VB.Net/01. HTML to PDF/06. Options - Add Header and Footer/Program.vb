Imports System
Imports System.IO
Imports SautinSoft.PdfVision

Namespace Sample
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			AddHeaderAndFooter()
		End Sub
		Public Shared Sub AddHeaderAndFooter()
			Dim inpFile As String = Path.GetFullPath("..\..\..\Sample.html")
			Dim outFile As String = (New FileInfo("Result.pdf")).FullName
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfVision.SetLicense("...");

			Dim v As New PdfVision()
			
			Dim options As New HtmlToPdfOptions() With {
				.PageSetup = New PageSetup() With {
					.PaperType = PaperType.Letter,
					.Orientation = Orientation.Portrait,
					.PageMargins = New PageMargins() With {
						.Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
						.Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
					}
				},
				.PrintBackground = True,
				.Scale = 1, 
                .ChromiumBaseDirectory = Path.GetFullPath("..\..\..\..\..\..\Chromium\")
			}

			' Add page header:
			' 1. Increase top margin to fit header.
			options.PageSetup.PageMargins.Top += LengthUnitConverter.ToPoint(40, LengthUnit.Millimeter)

			' 2. Set up page Header in HTML format with image logo.
			' Please notice, images in header/footer are supported only in base64 format, therefore we'll encode it.
			Dim imgPath As String = "..\..\..\logo.png"
			Dim imgBase64Encoded As String = Convert.ToBase64String(File.ReadAllBytes(imgPath))
			Dim header As String = "<div style=""border: solid 0.5pt grey; width: 100%; display: flex; justify-content: flex-start; align-items: center; margin: 5px; padding: 0; "">" & $"<img style=""width: 96px; height: 96px; margin: 0;"" src=""data:image/png;base64,{imgBase64Encoded}"" />" & "<div style=""width: calc(100% -300px - 50px); height: 96px; margin: 0; padding: 0; display: flex; flex-direction: column; justify-content: space-between; align-items: flex-start;"">" & "<h1 style=""width: 100%; margin: 0; padding-left: 10px; font-family: 'Arial', sans-serif; color: gray; font-size: 24px; font-weight: bold; text-align: left; "">" & "PDF Vision .Net</h1>" & "<p style=""margin: 0; padding-left: 10px; font-family: 'Arial', sans-serif; color: #000; font-size: 18px; font-weight: normal; text-align: left;"">" & "Gives your apps API to convert ASPX, HTML, Images (Multipage TIFF, PNG, Jpeg, Bitmap) to PDF." & "</p></div>" & "<div style=""width: 100px; margin: 0; padding-top: 5px; padding-right: 5px; align-self: flex-start; display: flex; justify-content: flex-end; font-family: 'Arial', sans-serif; color: #ccc; font-size: 10px; font-weight: bold;"">" & "<div>Page <span class=""pageNumber""></span> of <span class=""totalPages""></span></div>" & "</div></div>"

			options.Header = header

            ' Add page footer (doesn't work in trial version):

			' Please notice, the property 'Footer' doesn't work in the unlicensed version.
			' In the unlicensed version you will see trial notice instead of the footer.

			' In case of adding the page footer, don't forget to increase the margin bottom.
            ' Like this:
            options.PageSetup.PageMargins.Bottom += LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter)
			
			Dim footer As String = "<div style=""font-family: 'Arial', sans-serif; color: #ccc; font-size: 18px; margin: 0 auto;"">Simple page footer aligned by center.</div>"
			options.Footer = footer

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
