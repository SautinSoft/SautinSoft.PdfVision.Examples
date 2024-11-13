using System;
using System.IO;
using SautinSoft.PdfVision;
using static System.Net.Mime.MediaTypeNames;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertSystemDrawingToPdf();
        }
        public static void ConvertSystemDrawingToPdf()
        {
            byte[] image = File.ReadAllBytes(@"..\..\..\image-jpeg.jpg");
            
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Auto;


            byte[] pdfDocument = v.ConvertImageToPdf(image, options);
            File.WriteAllBytes(outFile, pdfDocument);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });

        }
    }
}
