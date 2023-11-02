using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ClipImageOptions();
        }
        public static void ClipImageOptions()
        {
            // This string will contains our input HTML document.
            string inpHtml = File.ReadAllText(@"..\..\..\example.html");
            byte[] imgBytes = null;

            PdfVision v = new PdfVision();
            
            ScreenshotOptions options = new ScreenshotOptions()
            {
                FullPage = false,
                // Set 1920 x 1080
                ViewPortOptions = new ViewPortOptions()
                {
                    Width = 1920,
                    Height = 1080
                },
                Type = ScreenshotType.Png,
				//Set a custom directory where will be placed portable Chromium browser. 
                //Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
                ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\"),

                // Let's clip the specified area and scale it.
                Clip = new Clip()
                {
                    X = 744,
                    Y = 525,
                    Width = 431,
                    Height = 381,
                    Scale = 2
                }
            };

            try
            {
                // The whole conversion process will be done completely in memory.
                imgBytes = v.GetScreenshot(inpHtml, options);

                // This file is necessary only to show the result.
                string outFile = new FileInfo("Result.png").FullName;
                // Save imgBytes to the file and open the result for demonstration purposes.
                File.WriteAllBytes(outFile, imgBytes);
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
