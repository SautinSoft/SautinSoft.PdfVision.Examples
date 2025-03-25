using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertTiffToPdfInMemory();
        }
        public static void ConvertTiffToPdfInMemory()
        {
            // We'll use files here only to get input data and show the PDF result.
            // The converting process will be done completely in memory.
            string inpFile = Path.GetFullPath(@"..\..\..\image-tiff.tiff");
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Letter;

            byte[] tiffBytes = File.ReadAllBytes(inpFile);

            try
            {
                byte[] pdfDocument = v.ConvertImageToPdf(tiffBytes, options);
                File.WriteAllBytes(outFile, pdfDocument);
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
