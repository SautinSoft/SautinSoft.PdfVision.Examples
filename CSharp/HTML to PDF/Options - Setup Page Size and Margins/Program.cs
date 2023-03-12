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
            // v.Serial = "123456789";

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
                Scale = 1M
            };

            // Unpack portable Chromium browser if necessary.
            // To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
            if (!ChromiumEngine.IsExist(options.ChromiumBaseDirectory))
                ChromiumEngine.Unpack(options.ChromiumBaseDirectory);

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
