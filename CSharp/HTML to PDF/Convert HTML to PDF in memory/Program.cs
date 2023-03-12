using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertHtmlToPdfInMemory();
        }
        public static void ConvertHtmlToPdfInMemory()
        {
            // This string will contains HTML string with the local image.
            string inpHtml = "<html>\r\n<body>\r\n<p> Hello </p>\r\n<p><img src=\"sautinsoft.png\"/></p>\r\n<p>Bye </p>\r\n</body>\r\n</html>";
            byte[] pdfBytes = null;

            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                // The baseURL property specifies or retrieves the base URL used for
                // relative path resolution with URL script commands that are embedded in media items.
                // Website - http://example.com/ or http://example.com/contact
                // LocalPath - C:/example/ or C:/example/contact
                BaseUrl = @"https://sautinsoft.com/images/",
                
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
                Scale = 0.7M,              
            };

            // Unpack portable Chromium browser if necessary.
            // To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
            if (!ChromiumEngine.IsExist(options.ChromiumBaseDirectory))
                ChromiumEngine.Unpack(options.ChromiumBaseDirectory);

            try
            {
                // The whole conversion process will be done completely in memory.
                pdfBytes = v.ConvertHtmlToPdf(inpHtml, options);

                // This file is necessary only to show the result.
                string outFile = new FileInfo("Result.pdf").FullName;
                // Save pdfBytes to the file and open the result for demonstration purposes.
                File.WriteAllBytes(outFile, pdfBytes);
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
