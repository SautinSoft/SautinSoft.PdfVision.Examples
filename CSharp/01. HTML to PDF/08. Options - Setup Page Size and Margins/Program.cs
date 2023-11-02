using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupPageProperties();
        }
        public static void SetupPageProperties()
        {
            string inpFile = Path.GetFullPath(@"..\..\..\example.html");
            string outFile = new FileInfo("Result.pdf").FullName;

            PdfVision v = new PdfVision();
            

            // Page size: A3 (297 x 420 mm)
            // Orientation: Portrait
            // Margins: Left: 30mm, Top: 15mm, Right: 25mm, Bottom: 15mm.

            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                PageSetup = new PageSetup()
                {
                    PaperType = PaperType.A3,
                    Orientation = Orientation.Portrait,
                    PageMargins = new PageMargins()
                    {
                        Left = LengthUnitConverter.ToPoint(30, LengthUnit.Millimeter),
                        Top = LengthUnitConverter.ToPoint(15, LengthUnit.Millimeter),
                        Right = LengthUnitConverter.ToPoint(25, LengthUnit.Millimeter),
                        Bottom = LengthUnitConverter.ToPoint(15, LengthUnit.Millimeter)
                    }
                },
                PrintBackground = true,
                Scale = 1M,
				//Set a custom directory where will be placed portable Chromium browser. 
				//Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
				ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\")
            };

            try
            {
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
