using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeViewportOptions();
        }
        public static void ChangeViewportOptions()
        {
            // This string will contains our input HTML document.
            string inpHtml = File.ReadAllText(@"..\..\..\example.html");
            byte[] imgBytes = null;
            
            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            ScreenshotOptions options = new ScreenshotOptions()
            {
                FullPage = true,
                // Set 2560 x 1920
                ViewPortOptions = new ViewPortOptions()
                {
                    Width = 2560,
                    Height = 1920                    
                },
                Type = ScreenshotType.Png
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
