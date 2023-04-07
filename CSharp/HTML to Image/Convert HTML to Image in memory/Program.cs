using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertHtmlToJpegInMemory();
        }
        public static void ConvertHtmlToJpegInMemory()
        {
            // This string will contains our input HTML document.
            string inpFile = Path.GetFullPath(@"..\..\..\example.html");
            string inpHtml = File.ReadAllText(inpFile);
            byte[] imgBytes = null;
            
            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            ScreenshotOptions options = new ScreenshotOptions()
            {
                FullPage = false,
                ViewPortOptions = new ViewPortOptions()
                {
                    Width = 800,
                    Height = 600
                },
                Type = ScreenshotType.Jpeg,
                Quality = 90,
                BaseUrl = Path.GetDirectoryName(inpFile),
                // The baseURL property specifies or retrieves the base URL used for
                // relative path resolution with URL script commands that are embedded in media items.
                // Website - http://example.com/ or http://example.com/contact
                // LocalPath - C:/example/ or C:/example/contact
                // BaseUrl = @"The_Absolute_Path_to_Image"
				
				//Set a custom directory where will be placed portable Chromium browser. 
                //Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
                ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\")
            };

            try
            {
                // The whole conversion process will be done completely in memory.
                imgBytes = v.GetScreenshot(inpHtml, options);

                // This file is necessary only to show the result.
                string outFile = new FileInfo("Result.jpg").FullName;
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
