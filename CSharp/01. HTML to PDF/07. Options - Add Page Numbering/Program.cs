using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            AddPageNumbering();
        }
        public static void AddPageNumbering()
        {
            // Let's convert HTML to PDF and add page numbering in header.
            string inpFile = File.ReadAllText(@"..\..\..\example.html");
            string outFile = new FileInfo("Result.pdf").FullName;
			// Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            
            
            PdfVision v = new PdfVision();
            
            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                PageSetup = new PageSetup()
                {
                    PaperType = PaperType.Letter,
                    Orientation = Orientation.Landscape,
                    PageMargins = new PageMargins()
                    {
                        Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
                    }
                },
                PrintBackground = true,
                Scale = 1,
				//Set a custom directory where will be placed portable Chromium browser. 
				//Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
				ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\")           
            };

            // Let's set page numbering in the page header (we can do the same in footer):
            // P.S. the property 'Footer' works only in licensed version.

            // 1. We've to increase the page margin top to fit page numbering.
            options.PageSetup.PageMargins.Top += LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter);
            
            // 2. Specify page numbering in header in HTML format.
            // Add attributes class="pageNumber" and class="totalPages" to any HTML tag,
            // after converting this tag will be replaced by the appropriate values.
            string headerWithNumbering = "<div style=\"font-size: 18pt; font-family: Sans-serif;" +
                                         "color: #0d6efd; margin: 0px auto;\">" +
                                         "Page <span class=\"pageNumber\"></span> of " +
                                         "<span class=\"totalPages\"></span><div>";

            options.Header = headerWithNumbering;

            // Footer: In case of adding the page footer, don't forget to increase the margin bottom.
            // Like this:
            //options.PageSetup.PageMargins.Bottom += LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter);

            try
            {
                // The whole conversion process will be done completely in memory.
                v.ConvertHtmlToPdf(inpFile, outFile, options);
                
                // Open the result for demonstration purposes.                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
