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
            SplitPdfDocument();
        }
        public static void SplitPdfDocument()
        {
			// Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            PdfVision v = new PdfVision();

            string inpFile = @"..\..\..\simple text.pdf";
            DirectoryInfo outFolder = new DirectoryInfo(@"Pages");

            if (!outFolder.Exists)
                outFolder.Create();

            int ret = v.SplitPdf(inpFile, outFolder.FullName);

            // 0 - Split successfully.
            // 1 - Error, can't open input file.
            // 2 - Error, output directory doesn't exist.
            if (ret == 0)
            {
                System.Console.WriteLine("Split successfully!");
                // Open the resulting folder with the PDF pages.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFolder.FullName) { UseShellExecute = true });
            }
        }
    }
}
