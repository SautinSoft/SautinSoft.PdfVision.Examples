using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertUrlToPdfFile();
        }
        public static void ConvertUrlToPdfFile()
        {
            string inpFile = @"https://sautinsoft.com/";
            string outFile = new FileInfo("Result.pdf").FullName;

            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                PageSetup = new PageSetup()
                {
                    PaperType = PaperType.Letter,
                    Orientation = Orientation.Portrait,
                    PageMargins = new PageMargins()
                    {
                        Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
                    }
                },
                PrintBackground = true,
                Scale = 1
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
