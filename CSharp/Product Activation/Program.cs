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
            PdfVision v = new PdfVision();
            
            // Place your serial(s) number.
            // You will get own serial number(s) after purchasing the license.
            // If you will have any questions, email us at sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.
            v.Serial = "123456789";

            string inpFile = @"https://sautinsoft.com/";
            string outFile = new FileInfo("Result.pdf").FullName;

            HtmlToPdfOptions options = new HtmlToPdfOptions();

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
