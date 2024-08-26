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
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();
            
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
                FullPage = false,
				//Set a custom directory where will be placed portable Chromium browser. 
                //Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
                ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\")
            };

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
