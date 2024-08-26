using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductActivation();
        }
        public static void ProductActivation()
        {
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            // You will get own serial number(s) after purchasing the license.
            // If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.
            PdfVision v = new PdfVision();
           

            string inpFile = @"https://sautinsoft.com/";
            string outFile = new FileInfo("Result.pdf").FullName;

            HtmlToPdfOptions options = new HtmlToPdfOptions()
			{
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
