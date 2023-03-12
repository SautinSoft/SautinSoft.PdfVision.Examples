using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertHtmlFileToPngFile();
        }
        public static void ConvertHtmlFileToPngFile()
        {
            string inpFile = Path.GetFullPath(@"..\..\..\Sample.html");
            string outFile = new FileInfo("Result.png").FullName;

            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            ScreenshotOptions options = new ScreenshotOptions()
            {
                Type = ScreenshotType.Png,
                ViewPortOptions = new ViewPortOptions()
                {
                    Width = 800,
                    Height = 600
                },
                // Get only visible part
                /// Depends of <see cref="ViewPortOptions"/>.
                FullPage = false
            };

            // Unpack portable Chromium browser if necessary.
            // To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
            if (!ChromiumEngine.IsExist(options.ChromiumBaseDirectory))
                ChromiumEngine.Unpack(options.ChromiumBaseDirectory);

            try
            {
                v.GetScreenshot(inpFile, outFile, options);
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
