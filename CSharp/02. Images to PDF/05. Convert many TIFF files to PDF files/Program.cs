using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertTiffFilesToPdfFiles();
        }
        public static void ConvertTiffFilesToPdfFiles()
        {            
		// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            
            PdfVision v = new PdfVision();
            string[] inpFiles = Directory.GetFiles(@"..\..\..\", "*.tif*");
            try
            {
                foreach (string inpFile in inpFiles)
                {
                    string pdfName = Path.GetFileNameWithoutExtension(inpFile) + ".pdf";
                    string outFile = new FileInfo(pdfName).FullName;
                    v.ConvertImageToPdf(new string[] { inpFile }, outFile);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
