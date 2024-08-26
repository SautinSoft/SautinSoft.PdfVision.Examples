using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertImageFolderToPdf();
        }
        public static void ConvertImageFolderToPdf()
        {
            string inpFolder = new DirectoryInfo(@"..\..\..\testing\").FullName;
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Auto;
            options.FitImageToPageSize = true;
            options.JpegQuality = 95;

            try
            {
                v.ConvertImageToPdf(inpFolder, outFile, options);
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
